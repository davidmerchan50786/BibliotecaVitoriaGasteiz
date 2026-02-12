using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaVitoriaGasteiz.helpers;

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Gestión de Usuarios de la Biblioteca Municipal de Vitoria-Gasteiz.
    ///
    /// RESPONSABILIDADES:
    ///   - Registrar nuevos usuarios en la base de datos.
    ///   - Modificar usuarios existentes (doble clic en la fila del grid).
    ///   - Eliminar usuarios con confirmación previa.
    ///   - Buscar usuarios en tiempo real mientras se escribe.
    ///   - Mostrar la lista completa de usuarios paginable con scroll vertical.
    ///
    /// PATRÓN MVC:
    ///   Vista pura. Toda la lógica de negocio se delega al <see cref="Controlador"/>
    ///   inyectado por el Gestor a través de <see cref="MiControlador"/>.
    ///
    /// PATRÓN SINGLETON:
    ///   Una única instancia activa. Se obtiene con <see cref="GetInstance()"/>.
    ///
    /// SCROLL:
    ///   - El formulario tiene AutoScroll = true para desplazarse si el contenido
    ///     supera el tamaño visible de la ventana MDI hija.
    ///   - El DataGridView tiene ScrollBars = Both para scroll propio de la tabla.
    ///
    /// EDICIÓN:
    ///   El botón "Editar" carga la fila en los campos.
    ///   El doble clic en el grid hace exactamente lo mismo (acceso rápido).
    ///   Ambas vías son equivalentes; el botón existe para usuarios que no conocen
    ///   el doble clic como interacción.
    ///
    /// COLUMNAS DE LA BASE DE DATOS (tabla Usuarios):
    ///   ID (INTEGER) | Nombre (TEXT) | Apellido_1 (TEXT) | Apellido_2 (TEXT) | Telefono (NUMERIC)
    ///
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// Asignatura: Desarrollo de Interfaces - 3º DAM
    /// </summary>
    public partial class FormUsuarios : Form
    {
        // ═══════════════════════════════════════════════════════════════════════
        #region Singleton

        /// <summary>Instancia única del formulario.</summary>
        private static FormUsuarios formulario;

        /// <summary>
        /// Devuelve la instancia única. Si fue cerrada (IsDisposed), la recrea.
        /// </summary>
        public static FormUsuarios GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new FormUsuarios();
            return formulario;
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Campos y propiedades

        /// <summary>
        /// Controlador MVC inyectado desde el Gestor antes de mostrar el formulario.
        /// </summary>
        public Controlador MiControlador { get; set; }

        /// <summary>ID del usuario en edición activa. 0 = ninguno.</summary>
        private int usuarioIdSeleccionado = 0;

        /// <summary>
        /// true = modo edición (ModificarUsuario).
        /// false = modo alta (InsertarUsuario).
        /// </summary>
        private bool modoEdicion = false;

        /// <summary>Texto fantasma del buscador cuando está vacío.</summary>
        private const string PLACEHOLDER_BUSCAR = "Buscar usuario...";

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Constructor

        /// <summary>
        /// Constructor privado (Singleton).
        /// Activa el scroll del formulario, inicializa el placeholder del buscador
        /// y registra todos los eventos.
        /// </summary>
        private FormUsuarios()
        {
            InitializeComponent();

            // ── Scroll del formulario ────────────────────────────────────────
            // AutoScroll = true añade barras de desplazamiento automáticas cuando
            // el contenido supera el área visible. Imprescindible en ventanas MDI
            // que el usuario puede redimensionar a tamaños pequeños.
            this.AutoScroll = true;

            // ── Placeholder del buscador ─────────────────────────────────────
            textBoxBuscarUsuario.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscarUsuario.ForeColor = Color.Gray;

            ConfigurarEventos();
            UIHelper.SetPlaceholder(textBoxBuscarUsuario, PLACEHOLDER_BUSCAR);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Configuración de eventos

        /// <summary>
        /// Registra todos los eventos de la vista. Se llama una sola vez desde el constructor.
        ///
        /// EVENTOS:
        ///   TextChanged  → filtrado de usuarios en tiempo real.
        ///   Click botones → Guardar / Editar / Eliminar.
        ///   CellDoubleClick → edición rápida (equivalente al botón Editar).
        ///   Resize + Paint  → bordes redondeados nítidos al redimensionar.
        /// </summary>
        private void ConfigurarEventos()
        {
            // ── Búsqueda en tiempo real ──────────────────────────────────────
            textBoxBuscarUsuario.TextChanged += TextBoxBuscar_TextChanged;

            // ── Botones de acción ────────────────────────────────────────────
            // Panel + Label responden al clic para maximizar el área pulsable.
            panelButtonAnadir.Click += BtnGuardar_Click;
            panelButtonEditar.Click += BtnEditar_Click;
            panelButtonEliminar.Click += BtnEliminar_Click;
            labelAnadir.Click += BtnGuardar_Click;
            labelEditar.Click += BtnEditar_Click;
            labelEliminar.Click += BtnEliminar_Click;

            // ── Doble clic en grid = editar (acceso rápido) ──────────────────
            // Mismo comportamiento que el botón Editar. El botón existe para
            // usuarios que desconozcan esta interacción.
            dataGridViewUsuarios.CellDoubleClick += (s, e) =>
            {
                if (((DataGridViewCellEventArgs)e).RowIndex >= 0)
                    BtnEditar_Click(s, EventArgs.Empty);
            };

            // ── Scroll propio del DataGridView ───────────────────────────────
            // ScrollBars.Both activa scroll vertical (muchas filas) y horizontal
            // (columnas que no caben en el ancho visible).
            dataGridViewUsuarios.ScrollBars = ScrollBars.Both;

            // ── Redibujado responsivo (anti-aliasing de bordes redondeados) ───
            panelBuscarBorder.Resize += (s, e) => panelBuscarBorder.Invalidate();
            panelNombre.Resize += (s, e) => panelNombre.Invalidate();
            panelApellido1.Resize += (s, e) => panelApellido1.Invalidate();
            panelApellido2.Resize += (s, e) => panelApellido2.Invalidate();
            panelTelefono.Resize += (s, e) => panelTelefono.Invalidate();
            panelButtonAnadir.Resize += (s, e) => panelButtonAnadir.Invalidate();
            panelButtonEditar.Resize += (s, e) => panelButtonEditar.Invalidate();
            panelButtonEliminar.Resize += (s, e) => panelButtonEliminar.Invalidate();

            // ── Diseño visual (UIHelper) ─────────────────────────────────────
            panelBuscarBorder.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.DarkCyan);
            panelNombre.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelApellido1.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelApellido2.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelTelefono.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelButtonAnadir.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
            panelButtonEditar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
            panelButtonEliminar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Carga del formulario

        /// <summary>
        /// Carga la lista de usuarios al abrir el formulario y ajusta el Z-Order
        /// para que los TextBox queden visibles sobre sus paneles contenedores.
        /// </summary>
        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            textBoxBuscarUsuario.BringToFront();
            textBoxNombre.BringToFront();
            textBoxApellido1.BringToFront();
            textBoxApellido2.BringToFront();
            textBoxTelefono.BringToFront();
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Búsqueda en tiempo real

        /// <summary>
        /// Filtra la lista de usuarios con cada tecla pulsada en el buscador.
        /// Si el campo está vacío o tiene el placeholder, recarga todos los usuarios.
        /// Los errores se escriben en Debug para no interrumpir la escritura.
        /// </summary>
        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBuscarUsuario.Text == PLACEHOLDER_BUSCAR ||
                string.IsNullOrWhiteSpace(textBoxBuscarUsuario.Text))
            {
                CargarUsuarios();
                return;
            }
            try
            {
                if (MiControlador == null) return;
                DataTable dt = MiControlador.BuscarUsuarios(textBoxBuscarUsuario.Text);
                MostrarUsuariosEnGrid(dt);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FormUsuarios] Error búsqueda: {ex.Message}");
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Guardar (Alta y Modificación)

        /// <summary>
        /// Guarda un usuario nuevo o actualiza uno existente según <see cref="modoEdicion"/>.
        ///
        /// VALIDACIONES:
        ///   1. Controlador inicializado.
        ///   2. Nombre no vacío.
        ///   3. Primer apellido no vacío.
        ///   4. Teléfono numérico de exactamente 9 dígitos.
        ///
        /// PROPIEDADES del modelo (= columnas BD):
        ///   ID | Nombre | Apellido_1 | Apellido_2 | Telefono
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MiControlador == null)
                {
                    MessageBox.Show("Error interno: controlador no inicializado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validación 1 – Nombre
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.",
                        "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNombre.Focus(); return;
                }

                // Validación 2 – Primer apellido
                if (string.IsNullOrWhiteSpace(textBoxApellido1.Text))
                {
                    MessageBox.Show("El primer apellido es obligatorio.",
                        "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxApellido1.Focus(); return;
                }

                // Validación 3 – Teléfono (numérico, 9 dígitos)
                string tel = textBoxTelefono.Text.Trim();
                if (string.IsNullOrWhiteSpace(tel) ||
                    !long.TryParse(tel, out long telNumero) ||
                    tel.Length != 9)
                {
                    MessageBox.Show("El teléfono debe ser numérico y tener exactamente 9 dígitos.",
                        "Dato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus(); return;
                }

                var usuario = new Usuario
                {
                    Nombre = textBoxNombre.Text.Trim(),
                    Apellido_1 = textBoxApellido1.Text.Trim(),
                    Apellido_2 = textBoxApellido2.Text.Trim(), // Opcional
                    Telefono = telNumero
                };

                if (modoEdicion)
                {
                    usuario.ID = usuarioIdSeleccionado;
                    MiControlador.ModificarUsuario(usuario);
                    MessageBox.Show("Usuario modificado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MiControlador.InsertarUsuario(usuario);
                    MessageBox.Show("Usuario registrado con éxito.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Editar

        /// <summary>
        /// Carga los datos de la fila seleccionada en los campos del formulario
        /// y activa el modo edición.
        ///
        /// Este método se invoca de dos formas equivalentes:
        ///   a) Clic en el botón "Editar".
        ///   b) Doble clic directamente sobre una fila del DataGridView.
        ///
        /// Al activarse, el texto del botón "Guardar" cambia a "Actualizar"
        /// para indicar visualmente que se está modificando un registro existente.
        /// </summary>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsuarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona un usuario de la lista para editarlo.",
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow fila = dataGridViewUsuarios.SelectedRows[0];

                // Columnas exactas de la BD: ID | Nombre | Apellido_1 | Apellido_2 | Telefono
                usuarioIdSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                textBoxNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
                textBoxApellido1.Text = fila.Cells["Apellido_1"].Value?.ToString() ?? "";
                textBoxApellido2.Text = fila.Cells["Apellido_2"].Value?.ToString() ?? "";
                textBoxTelefono.Text = fila.Cells["Telefono"].Value?.ToString() ?? "";

                modoEdicion = true;
                labelAnadir.Text = "Actualizar"; // Indicador visual del modo edición
                textBoxNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el usuario:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Eliminar

        /// <summary>
        /// Elimina el usuario seleccionado, previa confirmación obligatoria.
        /// Si el usuario pulsa "No", no se realiza ningún cambio.
        /// Tras el borrado exitoso limpia los campos y recarga el grid.
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsuarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona un usuario de la lista para eliminarlo.",
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Seguro que deseas eliminar este usuario?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No) return;

                int id = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["ID"].Value);
                MiControlador.EliminarUsuario(id);

                MessageBox.Show("Usuario eliminado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Carga y visualización del grid

        /// <summary>
        /// Obtiene todos los usuarios del controlador y los muestra en el grid.
        /// Protegido contra NullReference si el controlador aún no fue inyectado.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                if (MiControlador == null) return;
                DataTable dt = MiControlador.ObtenerUsuarios();
                MostrarUsuariosEnGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aplica el DataTable al grid y configura su apariencia visual.
        /// Las filas alternas usan lavanda claro para facilitar la lectura.
        /// La fila seleccionada se resalta en DarkTurquoise (paleta del proyecto).
        /// </summary>
        private void MostrarUsuariosEnGrid(DataTable dt)
        {
            dataGridViewUsuarios.DataSource = dt;
            dataGridViewUsuarios.BorderStyle = BorderStyle.None;
            dataGridViewUsuarios.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(238, 239, 249);
            dataGridViewUsuarios.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.RowHeadersVisible = false;
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Limpieza de campos

        /// <summary>
        /// Restablece el formulario al estado inicial (modo Alta):
        ///   - Borra todos los campos de texto.
        ///   - Restaura el placeholder del buscador.
        ///   - Desactiva modoEdicion y limpia el ID guardado.
        ///   - Restaura el texto del botón a "Guardar".
        ///   - Mueve el foco al campo Nombre.
        /// </summary>
        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido1.Clear();
            textBoxApellido2.Clear();
            textBoxTelefono.Clear();

            textBoxBuscarUsuario.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscarUsuario.ForeColor = Color.Gray;

            modoEdicion = false;
            usuarioIdSeleccionado = 0;
            labelAnadir.Text = "Guardar";
            textBoxNombre.Focus();
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Compatibilidad con el Designer de Visual Studio

        // El Designer registra eventos con nombres exactos en el .Designer.cs.
        // Estos métodos redirigen al método real para evitar duplicar lógica.

        /// <summary>Puente TextChanged buscador → <see cref="TextBoxBuscar_TextChanged"/>.</summary>
        private void textBoxBuscarUsuario_TextChanged_Designer(object sender, EventArgs e)
            => TextBoxBuscar_TextChanged(sender, e);

        /// <summary>Puente Click labelAnadir → <see cref="BtnGuardar_Click"/>.</summary>
        private void labelAnadir_Click_Designer(object sender, EventArgs e)
            => BtnGuardar_Click(sender, e);

        /// <summary>Puente Click labelEditar → <see cref="BtnEditar_Click"/>.</summary>
        private void labelEditar_Click(object sender, EventArgs e)
            => BtnEditar_Click(sender, e);

        /// <summary>Puente Click labelEliminar → <see cref="BtnEliminar_Click"/>.</summary>
        private void labelEliminar_Click(object sender, EventArgs e)
            => BtnEliminar_Click(sender, e);

        #endregion
    }
}
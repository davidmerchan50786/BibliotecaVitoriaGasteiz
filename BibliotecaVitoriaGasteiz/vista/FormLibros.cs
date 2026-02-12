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
    /// Formulario de Gestión de Libros de la Biblioteca Municipal de Vitoria-Gasteiz.
    ///
    /// RESPONSABILIDADES:
    ///   - Registrar nuevos libros en la base de datos.
    ///   - Modificar libros existentes (doble clic en grid o botón Editar).
    ///   - Eliminar libros con confirmación previa.
    ///   - Buscar libros por título o autor en tiempo real.
    ///   - Mostrar la lista completa con scroll vertical y horizontal.
    ///
    /// PATRÓN MVC:
    ///   Vista pura. Toda la lógica se delega al <see cref="Controlador"/>
    ///   inyectado por el Gestor a través de <see cref="MiControlador"/>.
    ///
    /// SCROLL:
    ///   - AutoScroll = true en el formulario.
    ///   - ScrollBars = Both en el DataGridView.
    ///
    /// COLUMNAS DE LA BASE DE DATOS (tabla Libros):
    ///   ID (INTEGER) | Titulo (TEXT) | Escritor (TEXT) | Ano_Edicion (INTEGER)
    ///   Sinopsis (TEXT) | Disponible (INTEGER 0/1)
    ///
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// Asignatura: Desarrollo de Interfaces - 3º DAM
    /// </summary>
    public partial class FormLibros : Form
    {
        // ═══════════════════════════════════════════════════════════════════════
        #region Singleton

        /// <summary>Instancia única del formulario.</summary>
        private static FormLibros formulario;

        /// <summary>
        /// Devuelve la instancia única. La recrea si fue cerrada (IsDisposed).
        /// </summary>
        public static FormLibros GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new FormLibros();
            return formulario;
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Campos y propiedades

        /// <summary>
        /// Controlador MVC inyectado desde el Gestor antes de mostrar el formulario.
        /// </summary>
        public Controlador MiControlador { get; set; }

        /// <summary>ID del libro en edición activa. 0 = ninguno.</summary>
        private int libroIdSeleccionado = 0;

        /// <summary>
        /// true = modo edición (ModificarLibro).
        /// false = modo alta (InsertarLibro / SumarLibro).
        /// </summary>
        private bool modoEdicion = false;

        /// <summary>Texto fantasma del buscador cuando está vacío.</summary>
        private const string PLACEHOLDER_BUSCAR = "Buscar Libro ...";

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Constructor

        /// <summary>
        /// Constructor privado (Singleton).
        /// Activa el scroll del formulario, inicializa el placeholder
        /// y registra todos los eventos.
        /// </summary>
        private FormLibros()
        {
            InitializeComponent();

            // Scroll automático del formulario
            this.AutoScroll = true;

            // Placeholder del buscador
            textBoxBuscar.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscar.ForeColor = Color.Gray;

            ConfigurarEventos();
            ConfigurarPlaceholder();
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Configuración de eventos y placeholder

        /// <summary>
        /// Registra todos los eventos de la vista.
        ///
        /// EVENTOS:
        ///   TextChanged → búsqueda en tiempo real.
        ///   Click botones → Guardar / Editar / Eliminar.
        ///   CellDoubleClick → edición rápida equivalente al botón Editar.
        ///   Resize + Paint → bordes redondeados nítidos al redimensionar.
        ///   ScrollBars → scroll propio del DataGridView.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Botón Guardar (panel + label)
            panelBotonGuardar.Click += BtnGuardar_Click;
            labelGuardar.Click += BtnGuardar_Click;

            // Scroll del DataGridView
            // ScrollBars.Both: scroll vertical (filas) + horizontal (columnas anchas)
            dataGridViewLibros.ScrollBars = ScrollBars.Both;

            // Doble clic en grid = cargar para editar (acceso rápido)
            dataGridViewLibros.CellDoubleClick += (s, e) =>
            {
                if (((DataGridViewCellEventArgs)e).RowIndex >= 0)
                    BtnEditar_Click(s, EventArgs.Empty);
            };
        }

        /// <summary>
        /// Configura el comportamiento de texto fantasma (placeholder) del buscador.
        /// Enter → borra el placeholder y cambia el color a blanco.
        /// Leave → si está vacío, restaura el placeholder en gris.
        /// </summary>
        private void ConfigurarPlaceholder()
        {
            textBoxBuscar.Enter += (s, e) =>
            {
                if (textBoxBuscar.Text == PLACEHOLDER_BUSCAR)
                {
                    textBoxBuscar.Text = "";
                    textBoxBuscar.ForeColor = Color.White;
                }
            };

            textBoxBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
                {
                    textBoxBuscar.Text = PLACEHOLDER_BUSCAR;
                    textBoxBuscar.ForeColor = Color.Gray;
                }
            };
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Carga del formulario

        /// <summary>
        /// Carga la lista de libros al abrir el formulario.
        /// </summary>
        private void FormLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Búsqueda en tiempo real

        /// <summary>
        /// Filtra la lista de libros con cada tecla pulsada en el buscador.
        /// Si el campo está vacío o tiene el placeholder, recarga todos los libros.
        /// </summary>
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == PLACEHOLDER_BUSCAR ||
                string.IsNullOrWhiteSpace(textBoxBuscar.Text))
            {
                CargarLibros();
                return;
            }
            try
            {
                if (MiControlador == null) return;
                DataTable dt = MiControlador.BuscarLibros(textBoxBuscar.Text);
                MostrarLibrosEnGrid(dt);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[FormLibros] Error búsqueda: {ex.Message}");
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Guardar (Alta y Modificación)

        /// <summary>
        /// Guarda un libro nuevo o actualiza uno existente según <see cref="modoEdicion"/>.
        ///
        /// VALIDACIONES:
        ///   1. Controlador inicializado.
        ///   2. Título no vacío.
        ///   3. Escritor no vacío.
        ///   4. Año de edición numérico (si se rellena).
        ///
        /// PROPIEDADES del modelo (= columnas BD):
        ///   ID | Titulo | Escritor | Ano_Edicion | Sinopsis | Disponible
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

                // Validación 1 – Título
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text))
                {
                    MessageBox.Show("El título es obligatorio.",
                        "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTitulo.Focus(); return;
                }

                // Validación 2 – Escritor
                if (string.IsNullOrWhiteSpace(textBoxAutor.Text))
                {
                    MessageBox.Show("El escritor/autor es obligatorio.",
                        "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxAutor.Focus(); return;
                }

                // Validación 3 – Año de edición (numérico, si se rellena)
                int ano = 0;
                if (!string.IsNullOrWhiteSpace(textBoxAnoEdicion.Text) &&
                    !int.TryParse(textBoxAnoEdicion.Text.Trim(), out ano))
                {
                    MessageBox.Show("El año de edición debe ser un número.",
                        "Dato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxAnoEdicion.Focus(); return;
                }

                var libro = new Libro
                {
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxAutor.Text.Trim(),
                    Ano_Edicion = ano,
                    Sinopsis = textBoxDescripcion.Text.Trim(),
                    Disponible = 1 // Disponible por defecto al registrar
                };

                if (modoEdicion)
                {
                    libro.ID = libroIdSeleccionado;
                    MiControlador.ModificarLibro(libro);
                    MessageBox.Show("Libro modificado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MiControlador.SumarLibro(libro);
                    MessageBox.Show("Libro registrado con éxito.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();
                CargarLibros();
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
        /// Carga los datos del libro seleccionado en los campos del formulario
        /// y activa el modo edición.
        ///
        /// Se invoca de dos formas equivalentes:
        ///   a) Clic en el botón "Editar" (si existe en el diseño).
        ///   b) Doble clic sobre una fila del DataGridView (acceso rápido).
        /// </summary>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLibros.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona un libro de la lista para editarlo.",
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow fila = dataGridViewLibros.SelectedRows[0];

                // Columnas exactas de la BD: ID | Titulo | Escritor | Ano_Edicion | Sinopsis | Disponible
                libroIdSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
                textBoxTitulo.Text = fila.Cells["Titulo"].Value?.ToString() ?? "";
                textBoxAutor.Text = fila.Cells["Escritor"].Value?.ToString() ?? "";
                textBoxAnoEdicion.Text = fila.Cells["Ano_Edicion"].Value?.ToString() ?? "";
                textBoxDescripcion.Text = fila.Cells["Sinopsis"].Value?.ToString() ?? "";

                modoEdicion = true;
                labelGuardar.Text = "Actualizar"; // Indicador visual del modo edición
                textBoxTitulo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el libro:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Eliminar

        /// <summary>
        /// Elimina el libro seleccionado, previa confirmación obligatoria.
        /// Si el usuario pulsa "No", no se realiza ningún cambio.
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLibros.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona un libro de la lista para eliminarlo.",
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "¿Seguro que deseas eliminar este libro?\nEsta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No) return;

                int id = Convert.ToInt32(dataGridViewLibros.SelectedRows[0].Cells["ID"].Value);
                MiControlador.EliminarLibro(id);

                MessageBox.Show("Libro eliminado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarLibros();
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
        /// Obtiene todos los libros del controlador y los muestra en el grid.
        /// Protegido contra NullReference si el controlador aún no fue inyectado.
        /// </summary>
        private void CargarLibros()
        {
            try
            {
                if (MiControlador == null) return;
                DataTable dt = MiControlador.ObtenerLibros();
                MostrarLibrosEnGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aplica el DataTable al grid y configura su apariencia visual.
        /// Filas alternas en lavanda claro; selección en DarkTurquoise.
        /// </summary>
        private void MostrarLibrosEnGrid(DataTable dt)
        {
            dataGridViewLibros.DataSource = dt;
            dataGridViewLibros.BorderStyle = BorderStyle.None;
            dataGridViewLibros.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(238, 239, 249);
            dataGridViewLibros.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewLibros.BackgroundColor = Color.White;
            dataGridViewLibros.RowHeadersVisible = false;
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Limpieza de campos

        /// <summary>
        /// Restablece el formulario al estado inicial (modo Alta):
        /// borra campos, restaura placeholder, desactiva modoEdicion,
        /// restaura texto del botón y mueve el foco a Título.
        /// </summary>
        private void LimpiarCampos()
        {
            textBoxTitulo.Clear();
            textBoxAutor.Clear();
            textBoxAnoEdicion.Clear();
            textBoxDescripcion.Clear();

            textBoxBuscar.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscar.ForeColor = Color.Gray;

            modoEdicion = false;
            libroIdSeleccionado = 0;
            labelGuardar.Text = "Guardar";
            textBoxTitulo.Focus();
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Compatibilidad con el Designer

        /// <summary>Evento Paint del panel buscador (registrado en el Designer).</summary>
        private void panelBuscarBorder_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.DibujarBordeRedondeado(sender, e, 20, Color.DarkCyan);
        }

        #endregion
    }
}
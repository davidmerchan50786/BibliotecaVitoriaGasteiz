using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Gestión de Usuarios
    /// 
    /// Permite gestionar los usuarios de la biblioteca:
    /// - Crear nuevos usuarios
    /// - Modificar usuarios existentes
    /// - Buscar usuarios por nombre/apellidos
    /// - Visualizar todos los usuarios en una tabla
    /// 
    /// VALIDACIONES IMPORTANTES:
    /// - Nombre y Apellido_1 obligatorios
    /// - Teléfono: 9 dígitos exactos (como los móviles españoles)
    /// 
    /// El diseño mantiene el estilo visual del resto de la aplicación
    /// con paneles personalizados en vez de botones estándar.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormUsuarios : Form
    {
        #region Singleton
        // Patrón Singleton: solo una instancia del formulario
        private static FormUsuarios formulario;

        public static FormUsuarios GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                formulario = new FormUsuarios();
            }
            return formulario;
        }
        #endregion

        // Controlador compartido (lo recibe desde Gestor.cs)
        public Controlador MiControlador { get; set; }

        // Variables de estado para saber si estamos editando
        private int usuarioIdSeleccionado = 0;
        private bool modoEdicion = false;

        /// <summary>
        /// Constructor privado (patrón Singleton)
        /// </summary>
        private FormUsuarios()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        /// <summary>
        /// Configura los eventos de los controles
        /// 
        /// Los botones son en realidad Paneles con Labels (diseño personalizado)
        /// por eso conecto tanto el Panel como el Label al mismo evento.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Búsqueda en tiempo real
            textBoxBuscarUsuario.TextChanged += TextBoxBuscar_TextChanged;

            // Botón "Añadir" / "Guardar"
            panelButtonAnadir.Click += BtnGuardar_Click;
            labelAnadir.Click += BtnGuardar_Click;

            // Botón "Nuevo" / "Limpiar"
            panelButtonEditar.Click += BtnNuevo_Click;
            labelEditar.Click += BtnNuevo_Click;
        }

        /// <summary>
        /// Evento Load: Carga los usuarios al abrir el formulario
        /// </summary>
        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        /// <summary>
        /// Búsqueda en tiempo real mientras el usuario escribe
        /// 
        /// Si el campo está vacío o tiene el placeholder, muestra todos los usuarios.
        /// Si hay texto, busca coincidencias en Nombre, Apellido_1 y Apellido_2.
        /// 
        /// Esto lo aprendí de la documentación de Microsoft sobre búsqueda incremental.
        /// </summary>
        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // Si está vacío o es el placeholder, mostrar todos
            if (string.IsNullOrWhiteSpace(textBoxBuscarUsuario.Text) ||
                textBoxBuscarUsuario.Text == "Buscar usuario...")
            {
                CargarUsuarios();
                return;
            }

            try
            {
                // Buscar usuarios que coincidan con el texto
                DataTable dt = MiControlador.BuscarUsuarios(textBoxBuscarUsuario.Text);
                MostrarUsuariosEnGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón "Añadir" o "Guardar" - Crea o modifica un usuario
        /// 
        /// VALIDACIONES (muy importantes):
        /// 1. Nombre obligatorio
        /// 2. Apellido_1 obligatorio
        /// 3. Teléfono obligatorio
        /// 4. Teléfono debe ser numérico
        /// 5. Teléfono debe tener exactamente 9 dígitos (estándar español)
        /// 
        /// Si estamos en modo edición, modifica el usuario seleccionado.
        /// Si no, crea uno nuevo.
        /// 
        /// Estas validaciones las vi en los apuntes de clase sobre formularios.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIÓN 1: Nombre obligatorio
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNombre.Focus();
                    return;
                }

                // VALIDACIÓN 2: Primer apellido obligatorio
                if (string.IsNullOrWhiteSpace(textBoxApellido1.Text))
                {
                    MessageBox.Show("El primer apellido es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxApellido1.Focus();
                    return;
                }

                // VALIDACIÓN 3: Teléfono obligatorio
                if (string.IsNullOrWhiteSpace(textBoxTelefono.Text))
                {
                    MessageBox.Show("El teléfono es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus();
                    return;
                }

                // VALIDACIÓN 4: Teléfono debe ser numérico
                if (!int.TryParse(textBoxTelefono.Text, out int telefono))
                {
                    MessageBox.Show("El teléfono debe ser un número", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus();
                    return;
                }

                // VALIDACIÓN 5: Teléfono debe tener 9 dígitos
                // En España, los móviles tienen 9 dígitos (ej: 612345678)
                if (textBoxTelefono.Text.Length != 9)
                {
                    MessageBox.Show("El teléfono debe tener 9 dígitos", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus();
                    return;
                }

                // Crear objeto Usuario con los datos del formulario
                var usuario = new Usuario
                {
                    Nombre = textBoxNombre.Text.Trim(),
                    Apellido1 = textBoxApellido1.Text.Trim(),
                    Apellido2 = textBoxApellido2.Text.Trim(),  // Opcional (puede estar vacío)
                    Telefono = telefono
                };

                // Decidir si es CREAR o MODIFICAR
                if (modoEdicion)
                {
                    // MODIFICAR: Asigno el ID del usuario seleccionado
                    usuario.Id = usuarioIdSeleccionado;
                    MiControlador.ModificarUsuario(usuario);
                    MessageBox.Show("Usuario modificado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // CREAR: No asigno ID, SQLite lo genera automáticamente
                    MiControlador.InsertarUsuario(usuario);
                    MessageBox.Show("Usuario guardado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Actualizar interfaz
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón "Nuevo" - Limpia el formulario para añadir un nuevo usuario
        /// </summary>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>
        /// Carga todos los usuarios en el DataGridView
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                DataTable dt = MiControlador.ObtenerUsuarios();
                MostrarUsuariosEnGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra los usuarios en el DataGridView
        /// 
        /// Configuro los encabezados y anchos de las columnas
        /// para que la tabla sea más legible.
        /// 
        /// Las columnas vienen directamente de la tabla Usuarios:
        /// - ID, Nombre, Apellido_1, Apellido_2, Telefono
        /// </summary>
        private void MostrarUsuariosEnGrid(DataTable dt)
        {
            dataGridViewUsuarios.DataSource = dt;

            // Configurar columnas solo si hay datos
            if (dataGridViewUsuarios.Columns.Count > 0)
            {
                dataGridViewUsuarios.Columns["ID"].HeaderText = "ID";
                dataGridViewUsuarios.Columns["ID"].Width = 50;

                dataGridViewUsuarios.Columns["Nombre"].HeaderText = "Nombre";
                dataGridViewUsuarios.Columns["Nombre"].Width = 120;

                dataGridViewUsuarios.Columns["Apellido_1"].HeaderText = "Primer Apellido";
                dataGridViewUsuarios.Columns["Apellido_1"].Width = 120;

                dataGridViewUsuarios.Columns["Apellido_2"].HeaderText = "Segundo Apellido";
                dataGridViewUsuarios.Columns["Apellido_2"].Width = 120;

                dataGridViewUsuarios.Columns["Telefono"].HeaderText = "Teléfono";
                dataGridViewUsuarios.Columns["Telefono"].Width = 100;
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// 
        /// Resetea el modo edición y deja el formulario listo
        /// para crear un nuevo usuario.
        /// </summary>
        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido1.Clear();
            textBoxApellido2.Clear();
            textBoxTelefono.Clear();
            textBoxBuscarUsuario.Text = "Buscar usuario...";

            modoEdicion = false;
            usuarioIdSeleccionado = 0;
            labelAnadir.Text = "Añadir";

            textBoxNombre.Focus();  // Pongo el foco en el primer campo
        }

        // --- MÉTODOS DE COMPATIBILIDAD CON EL DISEÑADOR ---
        // Estos métodos están conectados desde el diseñador y llaman a los métodos reales

        /// <summary>
        /// Evento del diseñador - Llama al método real de búsqueda
        /// </summary>
        private void textBoxBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            TextBoxBuscar_TextChanged(sender, e);
        }

        /// <summary>
        /// Evento del diseñador - Llama al método real de guardar
        /// </summary>
        private void labelAnadir_Click(object sender, EventArgs e)
        {
            BtnGuardar_Click(sender, e);
        }
    }
}
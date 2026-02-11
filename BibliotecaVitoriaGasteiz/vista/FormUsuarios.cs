using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaVitoriaGasteiz.helpers; // Necesario para el diseño responsivo

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Gestión de Usuarios
    /// 
    /// Permite gestionar los usuarios de la biblioteca:
    /// - Crear nuevos usuarios
    /// - Modificar usuarios existentes
    /// - Buscar usuarios por nombre/apellidos en tiempo real
    /// - Visualizar todos los usuarios en una tabla
    /// 
    /// DISEÑO RESPONSIVO Y VISUAL:
    /// - Utiliza TableLayoutPanel para adaptarse a diferentes tamaños de ventana.
    /// - Implementa redibujado manual (Invalidate) para mantener los bordes redondeados
    ///   nítidos al redimensionar la ventana (evita dientes de sierra).
    /// 
    /// SOLUCIÓN DE ERRORES (NullReference):
    /// - Se han añadido comprobaciones de seguridad en CargarUsuarios() y en la búsqueda
    ///   para evitar que el formulario intente acceder a la base de datos antes de que
    ///   el Gestor le haya inyectado el Controlador.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormUsuarios : Form
    {
        #region Singleton
        // Patrón Singleton: Asegura que solo exista una instancia del formulario.
        private static FormUsuarios formulario;

        /// <summary>
        /// Obtiene la instancia única del formulario.
        /// Si se cerró previamente (IsDisposed), crea una nueva para evitar errores.
        /// </summary>
        public static FormUsuarios GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                formulario = new FormUsuarios();
            }
            return formulario;
        }
        #endregion

        // Controlador compartido (Patrón MVC) inyectado desde el Gestor
        public Controlador MiControlador { get; set; }

        // Variables de estado para el control de edición
        private int usuarioIdSeleccionado = 0;
        private bool modoEdicion = false;

        // Constante para el texto fantasma del buscador
        private const string PLACEHOLDER_BUSCAR = "Buscar usuario...";

        /// <summary>
        /// Constructor privado (Singleton).
        /// Inicializa componentes y configura la estética visual.
        /// </summary>
        private FormUsuarios()
        {
            InitializeComponent();
            ConfigurarEventos();

            // Configuro el placeholder visual usando el Helper
            UIHelper.SetPlaceholder(textBoxBuscarUsuario, PLACEHOLDER_BUSCAR);
        }

        /// <summary>
        /// Configura los eventos lógicos y de renderizado visual.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Evento de búsqueda en tiempo real
            textBoxBuscarUsuario.TextChanged += TextBoxBuscar_TextChanged;

            // Eventos de botones (Paneles que actúan como botones)
            if (panelButtonAnadir != null) panelButtonAnadir.Click += BtnGuardar_Click;
            if (panelButtonEditar != null) panelButtonEditar.Click += BtnNuevo_Click;

            // --- LÓGICA DE REDIBUJADO RESPONSIVO (Anti-Aliasing) ---
            // Al cambiar el tamaño de la ventana (Resize), forzamos el redibujado (Invalidate)
            // de cada panel. Esto evita que los bordes redondeados se vean pixelados o deformes.
            panelBuscarBorder.Resize += (s, e) => panelBuscarBorder.Invalidate();
            panelNombre.Resize += (s, e) => panelNombre.Invalidate();
            panelApellido1.Resize += (s, e) => panelApellido1.Invalidate();
            panelApellido2.Resize += (s, e) => panelApellido2.Invalidate();
            panelTelefono.Resize += (s, e) => panelTelefono.Invalidate();
            panelButtonAnadir.Resize += (s, e) => panelButtonAnadir.Invalidate();
            panelButtonEditar.Resize += (s, e) => panelButtonEditar.Invalidate();

            // --- APLICACIÓN DE DISEÑO (UIHelper) ---
            // Dibujamos los bordes redondeados con GDI+ de alta calidad.
            panelBuscarBorder.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.DarkCyan);

            // Paneles de texto con fondo transparente para integración limpia
            panelNombre.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelApellido1.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelApellido2.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelTelefono.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);

            // Botones de acción
            panelButtonAnadir.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
            panelButtonEditar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);

            // Conectar clics de las etiquetas también a la lógica de los botones
            labelAnadir.Click += BtnGuardar_Click;
            labelEditar.Click += BtnNuevo_Click;
        }

        /// <summary>
        /// Carga inicial de datos y aseguramiento de capas (Z-Order).
        /// </summary>
        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();

            // Traer al frente los TextBox para evitar que el redibujado del panel los tape
            textBoxBuscarUsuario.BringToFront();
            textBoxNombre.BringToFront();
            textBoxApellido1.BringToFront();
            textBoxApellido2.BringToFront();
            textBoxTelefono.BringToFront();
        }

        /// <summary>
        /// Filtra la lista de usuarios mientras se escribe.
        /// </summary>
        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // Ignorar si es el placeholder o está vacío
            if (textBoxBuscarUsuario.Text == PLACEHOLDER_BUSCAR || string.IsNullOrWhiteSpace(textBoxBuscarUsuario.Text))
            {
                CargarUsuarios();
                return;
            }

            try
            {
                // --- PROTECCIÓN CONTRA CRASH ---
                // Si el Gestor aún no ha pasado el controlador, salimos sin error.
                if (MiControlador == null) return;

                // Búsqueda insensible a mayúsculas/minúsculas en la BD
                DataTable dt = MiControlador.BuscarUsuarios(textBoxBuscarUsuario.Text);
                MostrarUsuariosEnGrid(dt);
            }
            catch (Exception ex)
            {
                // En eventos de tecleo rápido, mejor usar Debug que MessageBox para no interrumpir
                System.Diagnostics.Debug.WriteLine($"Error en búsqueda: {ex.Message}");
            }
        }

        /// <summary>
        /// Lógica principal de Guardado (Alta o Modificación).
        /// Incluye todas las validaciones de negocio.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // --- PROTECCIÓN CONTRA CRASH ---
                if (MiControlador == null)
                {
                    MessageBox.Show("Error: El controlador no está inicializado.");
                    return;
                }

                // VALIDACIÓN 1: Nombre obligatorio
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                {
                    MessageBox.Show("El nombre es un campo obligatorio.");
                    textBoxNombre.Focus();
                    return;
                }

                // VALIDACIÓN 2: Primer Apellido obligatorio
                if (string.IsNullOrWhiteSpace(textBoxApellido1.Text))
                {
                    MessageBox.Show("El primer apellido es obligatorio.");
                    textBoxApellido1.Focus();
                    return;
                }

                // VALIDACIÓN 3: Teléfono (Numérico y longitud exacta de 9 dígitos)
                if (string.IsNullOrWhiteSpace(textBoxTelefono.Text) ||
                    !int.TryParse(textBoxTelefono.Text, out int telefono) ||
                    textBoxTelefono.Text.Length != 9)
                {
                    MessageBox.Show("El teléfono debe ser numérico y contener 9 dígitos.");
                    textBoxTelefono.Focus();
                    return;
                }

                // Construcción del objeto modelo
                var usuario = new Usuario
                {
                    Nombre = textBoxNombre.Text.Trim(),
                    Apellido1 = textBoxApellido1.Text.Trim(),
                    Apellido2 = textBoxApellido2.Text.Trim(), // Opcional
                    Telefono = telefono
                };

                // Decisión: INSERTAR vs ACTUALIZAR
                if (modoEdicion)
                {
                    usuario.Id = usuarioIdSeleccionado;
                    MiControlador.ModificarUsuario(usuario);
                    MessageBox.Show("Usuario modificado correctamente.");
                }
                else
                {
                    MiControlador.InsertarUsuario(usuario);
                    MessageBox.Show("Usuario registrado con éxito.");
                }

                // Limpieza y recarga
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la solicitud: {ex.Message}", "Error Crítico");
            }
        }

        /// <summary>
        /// Limpia el formulario para permitir un nuevo registro.
        /// </summary>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>
        /// Recupera la lista completa de usuarios desde el controlador.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                // --- PROTECCIÓN CONTRA CRASH (SOLUCIÓN DEL ERROR NULLREFERENCE) ---
                // El evento Load puede dispararse antes de que el Gestor asigne 'MiControlador'.
                // Si es null, simplemente abortamos la carga sin explotar.
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerUsuarios();
                MostrarUsuariosEnGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Configura el DataGridView para una visualización limpia y moderna.
        /// </summary>
        private void MostrarUsuariosEnGrid(DataTable dt)
        {
            dataGridViewUsuarios.DataSource = dt;

            // Estilos visuales del Grid
            dataGridViewUsuarios.BorderStyle = BorderStyle.None;
            dataGridViewUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewUsuarios.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.RowHeadersVisible = false; // Ocultar selector de fila lateral
        }

        /// <summary>
        /// Restablece el estado del formulario a "Nuevo Registro".
        /// Borra textos y reinicia variables de control.
        /// </summary>
        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido1.Clear();
            textBoxApellido2.Clear();
            textBoxTelefono.Clear();

            // Restaurar el placeholder visualmente
            textBoxBuscarUsuario.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscarUsuario.ForeColor = Color.Gray;

            modoEdicion = false;
            usuarioIdSeleccionado = 0;
            labelAnadir.Text = "Guardar"; // Restaurar texto del botón

            textBoxNombre.Focus();
        }

        // --- MÉTODOS DE COMPATIBILIDAD PARA EL DISEÑADOR DE VS ---
        // Evitan errores si el diseñador intenta enlazar eventos automáticamente
        private void textBoxBuscarUsuario_TextChanged_Designer(object sender, EventArgs e) { TextBoxBuscar_TextChanged(sender, e); }
        private void labelAnadir_Click_Designer(object sender, EventArgs e) { BtnGuardar_Click(sender, e); }
    }
}
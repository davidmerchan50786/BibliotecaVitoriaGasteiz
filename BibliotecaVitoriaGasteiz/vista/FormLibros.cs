using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaControles;

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Gestión de Libros
    /// 
    /// Esta fue una de las partes más interesantes del proyecto.
    /// En vez de usar un DataGridView tradicional, decidí mostrar los libros
    /// como TARJETAS visuales usando un UserControl personalizado (TarjetaLibro).
    /// 
    /// FUNCIONALIDADES:
    /// - Visualizar libros como tarjetas (más atractivo que una tabla)
    /// - Búsqueda en tiempo real por título o escritor
    /// - Añadir nuevos libros desde el panel lateral/inferior
    /// - Click en "Ver Detalles" de una tarjeta abre FormDetalleLibro
    /// 
    /// USERCONTROL TARJETALIBRO:
    /// Está en el proyecto BibliotecaControles (proyecto separado)
    /// Muestra: Título, Escritor, Estado (Disponible/Prestado)
    /// Tiene un botón "Ver Detalles" que dispara un evento
    /// 
    /// El diseño visual fue lo que más me gustó hacer del proyecto.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormLibros : Form
    {
        #region Singleton
        // Patrón Singleton: solo una instancia del formulario
        private static FormLibros formulario;

        public static FormLibros GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new FormLibros();
            return formulario;
        }
        #endregion

        // Controlador compartido (lo recibe desde Gestor.cs)
        public Controlador MiControlador { get; set; }

        // Placeholder para el campo de búsqueda
        private const string TEXTO_PLACEHOLDER = "Buscar Libro ...";

        // Variables de estado
        private int libroIdSeleccionado = 0;
        private bool modoEdicion = false;

        /// <summary>
        /// Constructor privado (patrón Singleton)
        /// </summary>
        private FormLibros()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarPlaceholder();
        }

        /// <summary>
        /// Evento Load: Carga los libros al abrir el formulario
        /// 
        /// También envío el FlowLayoutPanel al fondo para que no tape
        /// los controles del panel lateral donde están los campos de añadir libro.
        /// </summary>
        private void FormLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();

            // Aseguro que la lista de tarjetas no tape los botones/textboxes
            flowLayoutPanelLibros.SendToBack();

            // Pongo el foco en el botón Guardar
            if (labelGuardar != null)
                this.ActiveControl = labelGuardar;
        }

        /// <summary>
        /// Configura los eventos de los controles.
        /// NOTA: He comentado los eventos de los Labels porque ya están asignados 
        /// en el Designer, para evitar que el click se dispare dos veces.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Botón "Guardar" (Panel)
            if (panelBotonGuardar != null)
                panelBotonGuardar.Click += BtnGuardar_Click;

            // Botón "Nuevo" (Panel)
            if (panelBotonNuevo != null)
                panelBotonNuevo.Click += BtnNuevo_Click;

            // Búsqueda en tiempo real
            textBoxBuscar.TextChanged += TextBoxBuscar_TextChanged_Real;
        }

        /// <summary>
        /// Carga todos los libros desde la base de datos
        /// y los muestra como tarjetas en el FlowLayoutPanel
        /// </summary>
        private void CargarLibros()
        {
            try
            {
                if (MiControlador != null)
                {
                    DataTable dt = MiControlador.ObtenerLibros();
                    MostrarLibrosEnPanel(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando libros: " + ex.Message);
            }
        }

        /// <summary>
        /// Muestra los libros como tarjetas visuales en el FlowLayoutPanel
        /// 
        /// PROCESO:
        /// 1. Limpio todas las tarjetas anteriores
        /// 2. Por cada libro en el DataTable:
        ///    - Creo una TarjetaLibro (UserControl)
        ///    - Le paso los datos (ID, Titulo, Escritor, Disponible)
        ///    - Conecto el evento verDetalles (cuando click en "Ver Detalles")
        ///    - Añado la tarjeta al FlowLayoutPanel
        /// 
        /// El FlowLayoutPanel las organiza automáticamente en filas/columnas
        /// según el espacio disponible (responsive).
        /// </summary>
        private void MostrarLibrosEnPanel(DataTable dt)
        {
            flowLayoutPanelLibros.Controls.Clear();
            if (dt == null || dt.Rows.Count == 0) return;

            // SuspendLayout mejora el rendimiento al añadir muchos controles
            flowLayoutPanelLibros.SuspendLayout();

            foreach (DataRow row in dt.Rows)
            {
                // Creo una nueva tarjeta para cada libro
                TarjetaLibro tarjeta = new TarjetaLibro
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Titulo = row["Titulo"].ToString(),
                    Escritor = row["Escritor"].ToString(),
                    // Disponible: 1 = true, 0 = false (SQLite guarda booleanos como INTEGER)
                    Disponible = row["Disponible"] != DBNull.Value &&
                                 Convert.ToInt32(row["Disponible"]) == 1,
                    Margin = new Padding(10)  // Espacio entre tarjetas
                };

                // Conecto el evento verDetalles que dispara la tarjeta
                tarjeta.verDetalles += Tarjeta_VerDetalles;

                // Añado la tarjeta al panel
                flowLayoutPanelLibros.Controls.Add(tarjeta);
            }

            flowLayoutPanelLibros.ResumeLayout();
        }

        /// <summary>
        /// Evento que se dispara cuando se hace click en "Ver Detalles" de una tarjeta
        /// 
        /// Abre FormDetalleLibro en modo modal (ShowDialog) para ver/editar
        /// la información completa del libro.
        /// 
        /// Cuando se cierra el FormDetalleLibro, recargo los libros
        /// por si se modificó o eliminó algo.
        /// </summary>
        private void Tarjeta_VerDetalles(object sender, VerDetallesLibroEventArgs e)
        {
            try
            {
                // Creo el formulario de detalle
                FormDetalleLibro formDetalle = new FormDetalleLibro();
                formDetalle.MiControlador = this.MiControlador;
                formDetalle.LibroId = e.Id;  // Paso el ID del libro

                // Cuando se cierre, recargo los libros
                formDetalle.FormClosed += (s, args) => CargarLibros();

                // Muestro el formulario en modo modal (bloquea el formulario padre)
                formDetalle.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error abriendo detalle: " + ex.Message);
            }
        }

        /// <summary>
        /// Búsqueda en tiempo real mientras el usuario escribe
        /// 
        /// Busca coincidencias en Título o Escritor.
        /// Si el campo está vacío o tiene el placeholder, muestra todos los libros.
        /// </summary>
        private void TextBoxBuscar_TextChanged_Real(object sender, EventArgs e)
        {
            // Ignorar si es el placeholder
            if (textBoxBuscar.Text == TEXTO_PLACEHOLDER) return;

            string texto = textBoxBuscar.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(texto))
                    CargarLibros();  // Vacío = mostrar todos
                else
                    MostrarLibrosEnPanel(MiControlador.BuscarLibros(texto));
            }
            catch (Exception)
            {
                // Ignoro errores al escribir rápido
            }
        }

        /// <summary>
        /// Botón "Guardar" - Añade o edita un libro
        /// 
        /// VALIDACIONES:
        /// 1. Título obligatorio
        /// 2. Escritor obligatorio
        /// 3. Año (opcional) debe ser numérico si se proporciona
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIÓN 1: Título y Escritor obligatorios
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEscritor.Text))
                {
                    MessageBox.Show("Título y Escritor son obligatorios.");
                    return;
                }

                // VALIDACIÓN 2: Año (opcional) debe ser numérico
                int? ano = null;
                if (!string.IsNullOrWhiteSpace(textBoxAnoEdicion.Text))
                {
                    if (int.TryParse(textBoxAnoEdicion.Text, out int a))
                        ano = a;
                    else
                    {
                        MessageBox.Show("El año debe ser un número.");
                        return;
                    }
                }

                // Crear objeto Libro
                Libro libro = new Libro
                {
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxEscritor.Text.Trim(),
                    AnoEdicion = ano,
                    Sinopsis = textBoxSinopsis.Text.Trim(),
                    Disponible = true  // Por defecto los libros nuevos están disponibles
                };

                // Decidir si es CREAR o MODIFICAR
                if (modoEdicion)
                {
                    libro.Id = libroIdSeleccionado;
                    MiControlador.ModificarLibro(libro);
                    MessageBox.Show("Libro editado correctamente.");
                }
                else
                {
                    MiControlador.InsertarLibro(libro);
                    MessageBox.Show("Libro añadido correctamente.");
                }

                // Actualizar interfaz
                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        /// <summary>
        /// Botón "Nuevo" - Limpia el formulario
        /// </summary>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>
        /// Limpia todos los campos del panel lateral
        /// Deja el formulario listo para añadir un nuevo libro
        /// </summary>
        private void LimpiarCampos()
        {
            textBoxTitulo.Clear();
            textBoxEscritor.Clear();
            textBoxAnoEdicion.Clear();
            textBoxSinopsis.Clear();

            modoEdicion = false;
            libroIdSeleccionado = 0;
            labelGuardar.Text = "Guardar";

            textBoxTitulo.Focus();
        }

        /// <summary>
        /// Configura el placeholder del campo de búsqueda
        /// (Texto gris que desaparece al hacer clic)
        /// </summary>
        private void ConfigurarPlaceholder()
        {
            textBoxBuscar.Text = TEXTO_PLACEHOLDER;
            textBoxBuscar.ForeColor = Color.Gray;

            // Cuando entra (recibe el foco): limpiar el placeholder
            textBoxBuscar.Enter += (s, e) =>
            {
                if (textBoxBuscar.Text == TEXTO_PLACEHOLDER)
                {
                    textBoxBuscar.Text = "";
                    textBoxBuscar.ForeColor = Color.Black;
                }
            };

            // Cuando sale (pierde el foco): restaurar el placeholder si está vacío
            textBoxBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
                {
                    textBoxBuscar.Text = TEXTO_PLACEHOLDER;
                    textBoxBuscar.ForeColor = Color.Gray;
                }
            };
        }

        // --- MÉTODOS DE COMPATIBILIDAD CON EL DISEÑADOR ---

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            TextBoxBuscar_TextChanged_Real(sender, e);
        }

        private void panelBuscarBorder_Paint(object sender, PaintEventArgs e) { }
        private void textBoxDescripcion_TextChanged(object sender, EventArgs e) { }
        private void labelTitulo_Click(object sender, EventArgs e) { }
    }
}
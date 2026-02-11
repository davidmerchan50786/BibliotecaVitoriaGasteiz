using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaControles;
using BibliotecaVitoriaGasteiz.helpers; // Necesario para el diseño responsivo y redondeado

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
    /// DISEÑO VISUAL:
    /// Se ha refactorizado para ser totalmente responsivo y utilizar el UIHelper
    /// para obtener bordes redondeados con suavizado (Anti-Aliasing) de alta calidad.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormLibros : Form
    {
        #region Singleton
        // Patrón Singleton: solo una instancia del formulario para optimizar recursos.
        // Corregido: comprobamos IsDisposed para evitar errores al intentar reabrir 
        // un objeto que Windows ya ha destruido de la memoria.
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

        // Placeholder para el campo de búsqueda centralizado en UIHelper
        private const string PLACEHOLDER_BUSCAR = "Buscar Libro ...";

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

            // Usamos el UIHelper para centralizar la lógica del texto fantasma (Placeholder)
            UIHelper.SetPlaceholder(textBoxBuscar, PLACEHOLDER_BUSCAR);
        }

        /// <summary>
        /// Evento Load: Carga los libros al abrir el formulario
        /// </summary>
        private void FormLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();

            // Aseguro que la lista de tarjetas no tape los botones/textboxes del panel lateral
            flowLayoutPanelLibros.SendToBack();

            // Pongo el foco en el botón Guardar para una mejor experiencia de teclado
            if (labelGuardar != null)
                this.ActiveControl = labelGuardar;
        }

        /// <summary>
        /// Configura los eventos lógicos y los efectos visuales responsivos.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Eventos lógicos de botones
            if (panelBotonGuardar != null) panelBotonGuardar.Click += BtnGuardar_Click;
            if (panelBotonNuevo != null) panelBotonNuevo.Click += BtnNuevo_Click;

            // Búsqueda en tiempo real
            textBoxBuscar.TextChanged += TextBoxBuscar_TextChanged_Real;

            // --- MEJORA DE RENDERIZADO (Invalidación por Resize) ---
            // Forzamos al control a redibujarse cuando cambia su tamaño. 
            // Esto es vital para que UIHelper recalcule las curvas sin pixelación.
            panelBuscarBorder.Resize += (s, e) => panelBuscarBorder.Invalidate();
            panelTitulo.Resize += (s, e) => panelTitulo.Invalidate();
            panelEscritor.Resize += (s, e) => panelEscritor.Invalidate();
            panelAnoEdicion.Resize += (s, e) => panelAnoEdicion.Invalidate();
            panelSinopsis.Resize += (s, e) => panelSinopsis.Invalidate();
            panelBotonGuardar.Resize += (s, e) => panelBotonGuardar.Invalidate();
            panelBotonNuevo.Resize += (s, e) => panelBotonNuevo.Invalidate();

            // --- DISEÑO VISUAL REDONDEADO (UIHelper) ---

            // Buscador con el color corporativo
            panelBuscarBorder.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.DarkCyan);

            // Campos de texto: Usamos Transparent para que no se vea la línea de contorno 
            // y solo quede la forma redondeada blanca sobre el fondo gris.
            panelTitulo.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelEscritor.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelAnoEdicion.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelSinopsis.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);

            // Botones redondeados
            panelBotonGuardar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
            panelBotonNuevo.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
        }

        /// <summary>
        /// Carga todos los libros desde la base de datos y los muestra como tarjetas.
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
        /// PROCESO DE TARJETAS:
        /// 1. Limpio el FlowLayoutPanel.
        /// 2. Itero el DataTable creando una instancia del UserControl TarjetaLibro.
        /// 3. El FlowLayoutPanel organiza las tarjetas de forma "responsive" automáticamente.
        /// </summary>
        private void MostrarLibrosEnPanel(DataTable dt)
        {
            flowLayoutPanelLibros.Controls.Clear();
            if (dt == null || dt.Rows.Count == 0) return;

            flowLayoutPanelLibros.SuspendLayout(); // Mejora el rendimiento al añadir muchos controles

            foreach (DataRow row in dt.Rows)
            {
                TarjetaLibro tarjeta = new TarjetaLibro
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Titulo = row["Titulo"].ToString(),
                    Escritor = row["Escritor"].ToString(),
                    Disponible = row["Disponible"] != DBNull.Value &&
                                 Convert.ToInt32(row["Disponible"]) == 1,
                    Margin = new Padding(10)
                };

                tarjeta.verDetalles += Tarjeta_VerDetalles;
                flowLayoutPanelLibros.Controls.Add(tarjeta);
            }
            flowLayoutPanelLibros.ResumeLayout();
        }

        /// <summary>
        /// Abre el formulario modal de detalle al pulsar el botón de la tarjeta.
        /// </summary>
        private void Tarjeta_VerDetalles(object sender, VerDetallesLibroEventArgs e)
        {
            try
            {
                FormDetalleLibro formDetalle = new FormDetalleLibro();
                formDetalle.MiControlador = this.MiControlador;
                formDetalle.LibroId = e.Id;
                formDetalle.FormClosed += (s, args) => CargarLibros(); // Recarga al cerrar
                formDetalle.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error abriendo detalle: " + ex.Message);
            }
        }

        /// <summary>
        /// Búsqueda dinámica. Mejora la UX al encontrar libros sin necesidad de un botón "Buscar".
        /// </summary>
        private void TextBoxBuscar_TextChanged_Real(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == PLACEHOLDER_BUSCAR) return;

            string texto = textBoxBuscar.Text.Trim();
            try
            {
                if (string.IsNullOrEmpty(texto))
                    CargarLibros();
                else
                    MostrarLibrosEnPanel(MiControlador.BuscarLibros(texto));
            }
            catch (Exception) { /* Silenciar errores de escritura rápida */ }
        }

        /// <summary>
        /// Botón "Guardar" con validación obligatoria de Título y Escritor.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEscritor.Text))
                {
                    MessageBox.Show("Título y Escritor son obligatorios.");
                    return;
                }

                int? ano = null;
                if (!string.IsNullOrWhiteSpace(textBoxAnoEdicion.Text))
                {
                    if (int.TryParse(textBoxAnoEdicion.Text, out int a)) ano = a;
                    else { MessageBox.Show("El año debe ser un número."); return; }
                }

                Libro libro = new Libro
                {
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxEscritor.Text.Trim(),
                    AnoEdicion = ano,
                    Sinopsis = textBoxSinopsis.Text.Trim(),
                    Disponible = true
                };

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

                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textBoxTitulo.Clear();
            textBoxEscritor.Clear();
            textBoxAnoEdicion.Clear();
            textBoxSinopsis.Clear();

            textBoxBuscar.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscar.ForeColor = Color.Gray;

            modoEdicion = false;
            libroIdSeleccionado = 0;
            labelGuardar.Text = "Guardar";
            textBoxTitulo.Focus();
        }

        // MÉTODOS DE COMPATIBILIDAD CON EL DISEÑADOR
        private void textBoxBuscar_TextChanged(object sender, EventArgs e) { TextBoxBuscar_TextChanged_Real(sender, e); }
        private void panelBuscarBorder_Paint(object sender, PaintEventArgs e) { }
        private void textBoxDescripcion_TextChanged(object sender, EventArgs e) { }
        private void labelTitulo_Click(object sender, EventArgs e) { }
    }
}
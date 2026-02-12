using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Gestión de Préstamos de la Biblioteca Municipal de Vitoria-Gasteiz.
    ///
    /// RESPONSABILIDADES:
    ///   - Mostrar todos los préstamos activos con scroll vertical y horizontal.
    ///   - Registrar nuevos préstamos (ID_Libro + ID_Usuario + fechas).
    ///   - Registrar devoluciones de préstamos activos.
    ///   - Resaltar visualmente los préstamos con retraso en color rojo.
    ///
    /// PATRÓN MVC:
    ///   Vista pura. Toda la lógica se delega al <see cref="Controlador"/>
    ///   inyectado por el Gestor a través de <see cref="MiControlador"/>.
    ///
    /// PATRÓN SINGLETON:
    ///   Una única instancia activa. Se obtiene con <see cref="GetInstance()"/>.
    ///
    /// SCROLL:
    ///   - AutoScroll = true en el formulario.
    ///   - ScrollBars = Both en el DataGridView para tablas anchas.
    ///
    /// COLUMNAS DE LA BASE DE DATOS (tabla Prestamos):
    ///   ID (INTEGER) | ID_Libro (INTEGER) | ID_Usuario (INTEGER)
    ///   Fecha_Inicio (TEXT) | Fecha_Fin (TEXT)
    ///
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// Asignatura: Desarrollo de Interfaces - 3º DAM
    /// </summary>
    public partial class FormPrestamos : Form
    {
        // ═══════════════════════════════════════════════════════════════════════
        #region Singleton

        /// <summary>Instancia única del formulario.</summary>
        private static FormPrestamos formulario;

        /// <summary>
        /// Devuelve la instancia única. La recrea si fue cerrada (IsDisposed).
        /// </summary>
        public static FormPrestamos GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new FormPrestamos();
            return formulario;
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Campos y propiedades

        /// <summary>
        /// Controlador MVC inyectado desde el Gestor antes de mostrar el formulario.
        /// </summary>
        public Controlador MiControlador { get; set; }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Constructor

        /// <summary>
        /// Constructor privado (Singleton).
        /// Activa el scroll del formulario y registra los eventos.
        /// </summary>
        private FormPrestamos()
        {
            InitializeComponent();

            // ── Scroll del formulario ────────────────────────────────────────
            // AutoScroll = true añade barras de desplazamiento cuando el contenido
            // supera el área visible. Útil al redimensionar la ventana MDI hija.
            this.AutoScroll = true;

            ConfigurarEventos();

            // Recargar datos cada vez que el formulario se hace visible
            this.VisibleChanged += FormPrestamos_VisibleChanged;
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Configuración de eventos

        /// <summary>
        /// Registra los eventos del formulario.
        ///
        /// EVENTOS:
        ///   ScrollBars → scroll propio del DataGridView (filas y columnas).
        ///   CellDoubleClick → seleccionar préstamo para devolver.
        ///   VisibleChanged → recarga automática al mostrar el formulario.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Scroll vertical (muchos préstamos) y horizontal (columnas anchas)
            dataGridViewPrestamos.ScrollBars = ScrollBars.Both;
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Visibilidad y carga inicial

        /// <summary>
        /// Se dispara cuando el formulario cambia de visible a no visible (o viceversa).
        /// Recarga los préstamos cada vez que el formulario se abre/muestra,
        /// garantizando que los datos estén siempre actualizados.
        /// </summary>
        private void FormPrestamos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                CargarPrestamos();
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Carga y visualización del grid

        /// <summary>
        /// Obtiene todos los préstamos del controlador y los muestra en el grid.
        ///
        /// PROTECCIÓN:
        ///   Sale silenciosamente si MiControlador aún no fue inyectado por el Gestor,
        ///   evitando un NullReferenceException en la carga inicial.
        ///
        /// RESALTADO DE RETRASOS:
        ///   Tras cargar los datos, recorre las filas y colorea en rojo las que
        ///   tienen Fecha_Fin anterior a hoy (préstamo vencido sin devolver).
        /// </summary>
        private void CargarPrestamos()
        {
            try
            {
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerPrestamos();
                MostrarPrestamosEnGrid(dt);
                ResaltarRetrasos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aplica el DataTable al DataGridView y configura la apariencia visual.
        ///
        /// ESTILOS:
        ///   - Sin borde exterior.
        ///   - Filas alternas en lavanda claro para facilitar la lectura.
        ///   - Fila seleccionada en DarkTurquoise (paleta del proyecto).
        ///   - Sin cabecera de fila lateral.
        /// </summary>
        /// <param name="dt">DataTable con los préstamos a mostrar.</param>
        private void MostrarPrestamosEnGrid(DataTable dt)
        {
            dataGridViewPrestamos.DataSource = dt;
            dataGridViewPrestamos.BorderStyle = BorderStyle.None;
            dataGridViewPrestamos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(238, 239, 249);
            dataGridViewPrestamos.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewPrestamos.BackgroundColor = Color.White;
            dataGridViewPrestamos.RowHeadersVisible = false;
        }

        /// <summary>
        /// Recorre las filas del grid y resalta en rojo las que tienen
        /// Fecha_Fin anterior a la fecha actual (préstamo vencido).
        ///
        /// LÓGICA:
        ///   Se compara la columna "Fecha_Fin" (formato texto "yyyy-MM-dd" según la BD)
        ///   con DateTime.Today. Si la fecha de fin ya pasó, la fila se colorea en
        ///   rojo claro con texto rojo oscuro para alertar visualmente al bibliotecario.
        /// </summary>
        private void ResaltarRetrasos()
        {
            foreach (DataGridViewRow fila in dataGridViewPrestamos.Rows)
            {
                if (fila.IsNewRow) continue;

                object valorFecha = fila.Cells["Fecha_Fin"].Value;
                if (valorFecha == null || valorFecha == DBNull.Value) continue;

                if (DateTime.TryParse(valorFecha.ToString(), out DateTime fechaFin))
                {
                    if (fechaFin < DateTime.Today)
                    {
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                        fila.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Compatibilidad con el Designer de Visual Studio

        /// <summary>
        /// Evento CellContentClick del DataGridView registrado en el Designer.
        /// Actualmente reservado para futuras funcionalidades (ej. botones en celdas).
        /// </summary>
        private void dataGridViewPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Reservado para posibles botones en celdas (ej. columna "Devolver")
        }

        #endregion
    }
}
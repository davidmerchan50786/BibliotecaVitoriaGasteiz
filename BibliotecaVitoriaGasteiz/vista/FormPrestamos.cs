using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.helpers; // Referencia vital para el UIHelper de alta calidad

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Gestión de Préstamos
    /// 
    /// Esta es la interfaz donde los bibliotecarios pueden:
    /// - Realizar nuevos préstamos (seleccionar usuario, libro y fechas)
    /// - Ver la tabla de préstamos activos
    /// - Devolver libros prestados
    /// 
    /// El diseño visual utiliza UIHelper para redondear bordes y TableLayoutPanel
    /// para asegurar que la interfaz sea responsiva y moderna.
    /// 
    /// PATRÓN SINGLETON:
    /// Uso GetInstance() para que solo exista UNA instancia del formulario.
    /// Evita que se amontonen ventanas y asegura que el estado sea consistente.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormPrestamos : Form
    {
        #region Singleton
        // Patrón Singleton corregido con verificación de IsDisposed
        private static FormPrestamos instancia;

        public static FormPrestamos GetInstance()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormPrestamos();
            }
            return instancia;
        }
        #endregion

        // El Controlador se inyecta desde la clase Gestor siguiendo el patrón MVC
        public Controlador MiControlador { get; set; }

        /// <summary>
        /// Constructor privado para el patrón Singleton.
        /// </summary>
        private FormPrestamos()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        /// <summary>
        /// Configura los eventos y la estética visual de alta fidelidad.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Click en Paneles/Botones personalizados
            if (panelButtonPrestar != null) panelButtonPrestar.Click += BtnRealizarPrestamo_Click;
            if (panelButtonDevolver != null) panelButtonDevolver.Click += BtnDevolver_Click;

            // --- SOPORTE RESPONSIVO (Anti-Dientes de sierra) ---
            // Al redimensionar, invalidamos el dibujo anterior para forzar el suavizado de UIHelper.
            panelUsuario.Resize += (s, e) => panelUsuario.Invalidate();
            panelLibro.Resize += (s, e) => panelLibro.Invalidate();
            panelFechaInicio.Resize += (s, e) => panelFechaInicio.Invalidate();
            panelFechaFin.Resize += (s, e) => panelFechaFin.Invalidate();
            panelButtonPrestar.Resize += (s, e) => panelButtonPrestar.Invalidate();
            panelButtonDevolver.Resize += (s, e) => panelButtonDevolver.Invalidate();

            // --- APLICACIÓN DE DISEÑO REDONDEADO ---
            // Paneles de entrada con radio 15 y contorno invisible (Transparent)
            panelUsuario.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelLibro.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelFechaInicio.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelFechaFin.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);

            // Botones de acción con radio 20
            panelButtonPrestar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
            panelButtonDevolver.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
        }

        /// <summary>
        /// Inicializa las fechas por defecto: HOY y +14 días para el periodo de préstamo.
        /// </summary>
        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerInicio.Value = DateTime.Now;
                dateTimePickerFin.Value = DateTime.Now.AddDays(14);
            }
            catch { /* Ignorar errores de carga de componentes */ }
        }

        /// <summary>
        /// Carga Usuarios en el ComboBox.
        /// DisplayMember (lo que se ve) vs ValueMember (el ID real de la BD).
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                if (MiControlador == null) return;
                DataTable dt = MiControlador.ObtenerTodosUsuarios();
                comboBoxUsuarios.DataSource = null;
                comboBoxUsuarios.DataSource = dt;
                comboBoxUsuarios.DisplayMember = "Nombre";
                comboBoxUsuarios.ValueMember = "ID";
                comboBoxUsuarios.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Carga solo Libros Disponibles (evitamos prestar lo que ya está fuera).
        /// </summary>
        private void CargarLibrosDisponibles()
        {
            try
            {
                if (MiControlador == null) return;
                DataTable dt = MiControlador.ObtenerLibrosDisponibles();
                comboBoxLibros.DataSource = null;
                comboBoxLibros.DataSource = dt;
                comboBoxLibros.DisplayMember = "Titulo";
                comboBoxLibros.ValueMember = "ID";
                comboBoxLibros.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Carga la tabla central de préstamos activos con INNER JOINs para mostrar nombres en vez de IDs.
        /// </summary>
        private void CargarPrestamosActivos()
        {
            try
            {
                if (MiControlador == null) return;
                DataTable dt = MiControlador.ObtenerPrestamosActivos();
                dataGridViewPrestamos.DataSource = dt;

                if (dataGridViewPrestamos.Columns.Count > 0)
                {
                    // Aplicar estilo de tabla compartida
                    dataGridViewPrestamos.BorderStyle = BorderStyle.None;
                    dataGridViewPrestamos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                    dataGridViewPrestamos.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                    dataGridViewPrestamos.BackgroundColor = Color.White;
                    dataGridViewPrestamos.RowHeadersVisible = false;

                    // Ocultamos columnas de IDs que son irrelevantes para el bibliotecario
                    if (dataGridViewPrestamos.Columns.Contains("ID_Usuario")) dataGridViewPrestamos.Columns["ID_Usuario"].Visible = false;
                    if (dataGridViewPrestamos.Columns.Contains("ID_Libro")) dataGridViewPrestamos.Columns["ID_Libro"].Visible = false;
                }
                dataGridViewPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos: {ex.Message}");
            }
        }

        /// <summary>
        /// Botón "Realizar Préstamo". Valida Usuario, Libro e ID antes de ejecutar la acción SQL.
        /// </summary>
        private void BtnRealizarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MiControlador == null) return;

                if (comboBoxUsuarios.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBoxLibros.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un libro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idUsuario = Convert.ToInt32(comboBoxUsuarios.SelectedValue);
                int idLibro = Convert.ToInt32(comboBoxLibros.SelectedValue);
                DateTime fechaInicio = dateTimePickerInicio.Value.Date;
                DateTime fechaFin = dateTimePickerFin.Value.Date;

                if (fechaFin <= fechaInicio)
                {
                    MessageBox.Show("La fecha de fin debe ser posterior a la de inicio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MiControlador.RealizarPrestamo(idUsuario, idLibro, fechaInicio, fechaFin);
                MessageBox.Show("Préstamo realizado correctamente", "Éxito");

                CargarLibrosDisponibles();
                CargarPrestamosActivos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar préstamo: {ex.Message}");
            }
        }

        /// <summary>
        /// Botón "Devolver". Recupera el ID del préstamo de la fila seleccionada y libera el libro.
        /// </summary>
        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPrestamos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un préstamo de la tabla", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPrestamo = Convert.ToInt32(dataGridViewPrestamos.SelectedRows[0].Cells["ID"].Value);

                if (MessageBox.Show("¿Confirmar devolución?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MiControlador.DevolverLibro(idPrestamo);
                    CargarLibrosDisponibles();
                    CargarPrestamosActivos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver: {ex.Message}");
            }
        }

        private void LimpiarFormulario()
        {
            comboBoxUsuarios.SelectedIndex = -1;
            comboBoxLibros.SelectedIndex = -1;
            dateTimePickerInicio.Value = DateTime.Now;
            dateTimePickerFin.Value = DateTime.Now.AddDays(14);
        }

        /// <summary>
        /// OnVisibleChanged: Crucial para el patrón MVC. Carga los datos cuando el formulario 
        /// se muestra, garantizando que el controlador ya ha sido inyectado.
        /// </summary>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && MiControlador != null)
            {
                CargarUsuarios();
                CargarLibrosDisponibles();
                CargarPrestamosActivos();
            }
        }

        // COMPATIBILIDAD CON EL DISEÑADOR
        private void BtnRealizarPrestamo_Click(object sender, MouseEventArgs e) { BtnRealizarPrestamo_Click(sender, EventArgs.Empty); }
        private void BtnDevolver_Click(object sender, MouseEventArgs e) { BtnDevolver_Click(sender, EventArgs.Empty); }
    }
}
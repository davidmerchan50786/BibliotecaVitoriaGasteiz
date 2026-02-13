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
    /// Formulario de Gestión de Préstamos.
    /// 
    /// DESARROLLO Y PROBLEMAS RESUELTOS:
    ///    Mantenemos los paneles de datos blancos cuadrados y redondeamos 
    ///    exclusivamente los botones de acción para guiar el ojo del usuario (UIHelper).
    ///    
    ///    DEBOUNCE ANTI-BUGS: Control de tiempo de 1 segundo a los clics para evitar dobles envíos.
    ///    
    ///    Al devolver un libro, seguía en la tabla. El error era que 
    ///    la vista pedía el "Historial" completo (ObtenerTodos) en lugar de pedir los préstamos 
    ///    en curso. Se cambió la llamada a ObtenerPrestamosActivos() y se forzó DataSource = null 
    ///    para obligar al repintado.
    ///    ComboBox arrancan en blanco (SelectedIndex = -1) para evitar 
    ///    préstamos accidentales.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria Gasteiz
    /// </summary>
    public partial class FormPrestamos : Form
    {
        #region Singleton y Variables

        private static FormPrestamos formulario;
        public static FormPrestamos GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new FormPrestamos();
            return formulario;
        }

        public Controlador MiControlador { get; set; }

        // Control anti-doble clic
        private DateTime tiempoDesbloqueo = DateTime.MinValue;

        #endregion

        #region Constructor e Inicialización

        private FormPrestamos()
        {
            InitializeComponent();
            this.AutoScroll = true;
            dataGridViewPrestamos.ScrollBars = ScrollBars.Both;

            ConfigurarEventos();
            ConfigurarEstiloVisual();

            // Refresco automático al cambiar a esta pestaña
            this.VisibleChanged += (s, e) => { if (this.Visible) { CargarCombos(); CargarPrestamos(); } };
        }

        private bool PuedeProcesarClick()
        {
            return DateTime.Now >= tiempoDesbloqueo;
        }

        private void BloquearClicks()
        {
            tiempoDesbloqueo = DateTime.Now.AddMilliseconds(1000);
        }

        private void ConfigurarEstiloVisual()
        {
            // Botones redondeados 
            if (panelButtonPrestar != null) panelButtonPrestar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);
            if (panelButtonLimpiar != null) panelButtonLimpiar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);
            if (panelButtonDevolver != null) panelButtonDevolver.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);

            // Redibujado al maximizar/minimizar
            if (panelButtonPrestar != null) panelButtonPrestar.Resize += (s, e) => ((Control)s).Invalidate();
            if (panelButtonLimpiar != null) panelButtonLimpiar.Resize += (s, e) => ((Control)s).Invalidate();
            if (panelButtonDevolver != null) panelButtonDevolver.Resize += (s, e) => ((Control)s).Invalidate();
        }

        private void ConfigurarEventos()
        {
            if (panelButtonPrestar != null) panelButtonPrestar.Click += BtnRealizarPrestamo_Click;
            if (labelPrestar != null) labelPrestar.Click += BtnRealizarPrestamo_Click;

            if (panelButtonLimpiar != null) panelButtonLimpiar.Click += BtnLimpiar_Click;
            if (labelLimpiar != null) labelLimpiar.Click += BtnLimpiar_Click;

            if (panelButtonDevolver != null) panelButtonDevolver.Click += BtnDevolver_Click;
            if (labelDevolver != null) labelDevolver.Click += BtnDevolver_Click;
        }

        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarPrestamos();
        }

        #endregion

        #region Lógica de Préstamos y Devoluciones

        private void BtnRealizarPrestamo_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            try
            {
                if (MiControlador == null) { MessageBox.Show("Controlador no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (comboBoxUsuarios.SelectedValue == null)
                { MessageBox.Show("Selecciona un usuario.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (comboBoxLibros.SelectedValue == null)
                { MessageBox.Show("Selecciona un libro disponible.", "Dato requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (dateTimePickerFin.Value.Date <= dateTimePickerInicio.Value.Date)
                { MessageBox.Show("La fecha de devolución debe ser posterior a la de inicio.", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                int idUsuario = Convert.ToInt32(comboBoxUsuarios.SelectedValue);
                int idLibro = Convert.ToInt32(comboBoxLibros.SelectedValue);

                MiControlador.RealizarPrestamo(idUsuario, idLibro, dateTimePickerInicio.Value, dateTimePickerFin.Value);

                MessageBox.Show("Préstamo registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarCombos();
                CargarPrestamos();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { BloquearClicks(); }
        }

        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            try
            {
                if (MiControlador == null) { MessageBox.Show("Controlador no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (dataGridViewPrestamos.SelectedRows.Count == 0)
                { MessageBox.Show("Selecciona un préstamo de la lista.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (MessageBox.Show("¿Confirmas la devolución del libro seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int idPrestamo = Convert.ToInt32(dataGridViewPrestamos.SelectedRows[0].Cells["ID"].Value);
                MiControlador.DevolverLibro(idPrestamo);

                MessageBox.Show("Devolución registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarCombos();
                CargarPrestamos();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { BloquearClicks(); }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            comboBoxUsuarios.SelectedIndex = -1;
            comboBoxLibros.SelectedIndex = -1;
            dateTimePickerInicio.Value = DateTime.Today;
            dateTimePickerFin.Value = DateTime.Today.AddDays(15);
        }

        #endregion

        #region Combobox y Grid

        private void CargarCombos()
        {
            try
            {
                if (MiControlador == null) return;

                comboBoxUsuarios.DataSource = MiControlador.ObtenerTodosUsuarios();
                comboBoxUsuarios.DisplayMember = "Nombre";
                comboBoxUsuarios.ValueMember = "Id";

                comboBoxLibros.DataSource = MiControlador.ObtenerLibrosDisponibles();
                comboBoxLibros.DisplayMember = "Titulo";
                comboBoxLibros.ValueMember = "ID";

                LimpiarCampos(); // Asegura que arranquen en blanco
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CargarPrestamos()
        {
            try
            {
                if (MiControlador == null) return;

                dataGridViewPrestamos.DataSource = null; // Bofetón al caché del DataGrid

                // Pedimos los activos, no todos
                dataGridViewPrestamos.DataSource = MiControlador.ObtenerPrestamosActivos();

                dataGridViewPrestamos.BorderStyle = BorderStyle.None;
                dataGridViewPrestamos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridViewPrestamos.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridViewPrestamos.BackgroundColor = Color.White;
                dataGridViewPrestamos.RowHeadersVisible = false;

                ResaltarRetrasos();
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar préstamos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResaltarRetrasos()
        {
            foreach (DataGridViewRow fila in dataGridViewPrestamos.Rows)
            {
                if (fila.IsNewRow) continue;

                var val = fila.Cells["Fecha_Fin"].Value;
                if (val == null || val == DBNull.Value) continue;

                if (DateTime.TryParse(val.ToString(), out DateTime fechaFin) && fechaFin.Date < DateTime.Today)
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    fila.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        #endregion
    }
}
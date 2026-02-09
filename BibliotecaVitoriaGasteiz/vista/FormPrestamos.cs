using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;

namespace BibliotecaVitoriaGasteiz.vista
{
    public partial class FormPrestamos : Form
    {
        private static FormPrestamos instancia;
        public Controlador MiControlador { get; set; }

        public static FormPrestamos GetInstance()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormPrestamos();
            }
            return instancia;
        }

        private FormPrestamos()
        {
            InitializeComponent();

            // ⭐ CONECTAR EVENTOS DE LOS BOTONES
            panelButtonPrestar.Click += BtnRealizarPrestamo_Click;
            labelPrestar.Click += BtnRealizarPrestamo_Click;

            panelButtonDevolver.Click += BtnDevolver_Click;
            labelDevolver.Click += BtnDevolver_Click;
        }

        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            // Solo inicializar fechas, NO cargar datos aquí
            // Los datos se cargarán en OnVisibleChanged
            try
            {
                dateTimePickerInicio.Value = DateTime.Now;
                dateTimePickerFin.Value = DateTime.Now.AddDays(14);
            }
            catch
            {
                // Ignorar si hay error con los DateTimePickers
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                // ⭐ VERIFICAR que MiControlador no sea null
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerTodosUsuarios();

                comboBoxUsuarios.DataSource = null;
                comboBoxUsuarios.Items.Clear();

                comboBoxUsuarios.DataSource = dt;
                comboBoxUsuarios.DisplayMember = "Nombre";
                comboBoxUsuarios.ValueMember = "ID";

                comboBoxUsuarios.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarLibrosDisponibles()
        {
            try
            {
                // ⭐ VERIFICAR que MiControlador no sea null
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerLibrosDisponibles();

                comboBoxLibros.DataSource = null;
                comboBoxLibros.Items.Clear();

                comboBoxLibros.DataSource = dt;
                comboBoxLibros.DisplayMember = "Titulo";
                comboBoxLibros.ValueMember = "ID";

                comboBoxLibros.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPrestamosActivos()
        {
            try
            {
                // ⭐ VERIFICAR que MiControlador no sea null
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerPrestamosActivos();

                dataGridViewPrestamos.DataSource = dt;

                // ⭐ USAR LOS NOMBRES REALES DE LAS COLUMNAS DE LA BD
                if (dataGridViewPrestamos.Columns.Count > 0)
                {
                    // Configurar solo las columnas que existen
                    if (dataGridViewPrestamos.Columns.Contains("ID"))
                    {
                        dataGridViewPrestamos.Columns["ID"].HeaderText = "ID Préstamo";
                        dataGridViewPrestamos.Columns["ID"].Width = 80;
                    }

                    if (dataGridViewPrestamos.Columns.Contains("NombreUsuario"))
                    {
                        dataGridViewPrestamos.Columns["NombreUsuario"].HeaderText = "Usuario";
                        dataGridViewPrestamos.Columns["NombreUsuario"].Width = 150;
                    }

                    if (dataGridViewPrestamos.Columns.Contains("TituloLibro"))
                    {
                        dataGridViewPrestamos.Columns["TituloLibro"].HeaderText = "Libro";
                        dataGridViewPrestamos.Columns["TituloLibro"].Width = 200;
                    }

                    if (dataGridViewPrestamos.Columns.Contains("Fecha_Inicio"))
                    {
                        dataGridViewPrestamos.Columns["Fecha_Inicio"].HeaderText = "Fecha Inicio";
                        dataGridViewPrestamos.Columns["Fecha_Inicio"].Width = 100;
                    }

                    if (dataGridViewPrestamos.Columns.Contains("Fecha_Fin"))
                    {
                        dataGridViewPrestamos.Columns["Fecha_Fin"].HeaderText = "Fecha Fin";
                        dataGridViewPrestamos.Columns["Fecha_Fin"].Width = 100;
                    }

                    // Ocultar columnas de IDs internos si existen
                    if (dataGridViewPrestamos.Columns.Contains("ID_Usuario"))
                        dataGridViewPrestamos.Columns["ID_Usuario"].Visible = false;
                    if (dataGridViewPrestamos.Columns.Contains("ID_Libro"))
                        dataGridViewPrestamos.Columns["ID_Libro"].Visible = false;
                }

                dataGridViewPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRealizarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                // ⭐ VERIFICAR que MiControlador no sea null
                if (MiControlador == null)
                {
                    MessageBox.Show("Error: Controlador no inicializado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxUsuarios.SelectedIndex == -1 || comboBoxUsuarios.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxUsuarios.Focus();
                    return;
                }

                if (comboBoxLibros.SelectedIndex == -1 || comboBoxLibros.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un libro", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxLibros.Focus();
                    return;
                }

                int idUsuario = Convert.ToInt32(comboBoxUsuarios.SelectedValue);
                int idLibro = Convert.ToInt32(comboBoxLibros.SelectedValue);

                if (idUsuario <= 0)
                {
                    MessageBox.Show("ID de usuario no válido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (idLibro <= 0)
                {
                    MessageBox.Show("ID de libro no válido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime fechaInicio = dateTimePickerInicio.Value.Date;
                DateTime fechaFin = dateTimePickerFin.Value.Date;

                if (fechaFin <= fechaInicio)
                {
                    MessageBox.Show("La fecha de fin debe ser posterior a la fecha de inicio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTimePickerFin.Focus();
                    return;
                }

                MiControlador.RealizarPrestamo(idUsuario, idLibro, fechaInicio, fechaFin);

                MessageBox.Show("Préstamo realizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarLibrosDisponibles();
                CargarPrestamosActivos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar préstamo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                // ⭐ VERIFICAR que MiControlador no sea null
                if (MiControlador == null)
                {
                    MessageBox.Show("Error: Controlador no inicializado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataGridViewPrestamos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un préstamo para devolver", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPrestamo = Convert.ToInt32(dataGridViewPrestamos.SelectedRows[0].Cells["ID"].Value);

                DialogResult result = MessageBox.Show(
                    "¿Está seguro de que desea marcar este libro como devuelto?",
                    "Confirmar devolución",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MiControlador.DevolverLibro(idPrestamo);

                    MessageBox.Show("Libro devuelto correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarLibrosDisponibles();
                    CargarPrestamosActivos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            comboBoxUsuarios.SelectedIndex = -1;
            comboBoxLibros.SelectedIndex = -1;
            dateTimePickerInicio.Value = DateTime.Now;
            dateTimePickerFin.Value = DateTime.Now.AddDays(14);
        }

        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtro opcional
        }

        //Método para recargar datos cuando se muestra el formulario
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
    }
}
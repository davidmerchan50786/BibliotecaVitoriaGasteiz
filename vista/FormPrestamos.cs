using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.vista
{
    public partial class FormPrestamos : Form
    {
        #region Singleton
        private static FormPrestamos formulario;

        public static FormPrestamos GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                formulario = new FormPrestamos();
            }
            return formulario;
        }
        #endregion

        public Controlador MiControlador { get; set; }

        private FormPrestamos()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            panelButtonPrestar.Click += BtnPrestar_Click;
            labelPrestar.Click += BtnPrestar_Click;
            
            panelButtonDevolver.Click += BtnDevolver_Click;
            labelDevolver.Click += BtnDevolver_Click;
        }

        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            CargarComboUsuarios();
            CargarComboLibros();
            CargarPrestamosActivos();
        }

        private void CargarComboUsuarios()
        {
            try
            {
                DataTable dt = MiControlador.ObtenerUsuarios();
                
                comboBoxUsuarios.DataSource = dt;
                comboBoxUsuarios.DisplayMember = "Nombre";
                comboBoxUsuarios.ValueMember = "ID";
                
                if (comboBoxUsuarios.Items.Count > 0)
                {
                    comboBoxUsuarios.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboLibros()
        {
            try
            {
                // Solo libros disponibles
                DataTable dt = MiControlador.ObtenerLibrosDisponibles();
                
                comboBoxLibros.DataSource = dt;
                comboBoxLibros.DisplayMember = "Titulo";
                comboBoxLibros.ValueMember = "ID";
                
                if (comboBoxLibros.Items.Count > 0)
                {
                    comboBoxLibros.SelectedIndex = -1;
                }
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
                DataTable dt = MiControlador.ObtenerPrestamosActivos();
                dataGridViewPrestamos.DataSource = dt;

                if (dataGridViewPrestamos.Columns.Count > 0)
                {
                    dataGridViewPrestamos.Columns["ID"].HeaderText = "ID";
                    dataGridViewPrestamos.Columns["ID"].Width = 50;
                    dataGridViewPrestamos.Columns["TituloLibro"].HeaderText = "Libro";
                    dataGridViewPrestamos.Columns["TituloLibro"].Width = 200;
                    dataGridViewPrestamos.Columns["NombreUsuario"].HeaderText = "Usuario";
                    dataGridViewPrestamos.Columns["NombreUsuario"].Width = 200;
                    dataGridViewPrestamos.Columns["Fecha_Inicio"].HeaderText = "Fecha Inicio";
                    dataGridViewPrestamos.Columns["Fecha_Inicio"].Width = 100;
                    dataGridViewPrestamos.Columns["Fecha_Fin"].HeaderText = "Fecha Fin";
                    dataGridViewPrestamos.Columns["Fecha_Fin"].Width = 100;

                    // Ocultar columnas ID_Libro e ID_Usuario
                    if (dataGridViewPrestamos.Columns.Contains("ID_Libro"))
                        dataGridViewPrestamos.Columns["ID_Libro"].Visible = false;
                    if (dataGridViewPrestamos.Columns.Contains("ID_Usuario"))
                        dataGridViewPrestamos.Columns["ID_Usuario"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrestar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selección de usuario
                if (comboBoxUsuarios.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un usuario", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar selección de libro
                if (comboBoxLibros.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un libro", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear préstamo
                var prestamo = new Prestamo
                {
                    IdLibro = Convert.ToInt32(comboBoxLibros.SelectedValue),
                    IdUsuario = Convert.ToInt32(comboBoxUsuarios.SelectedValue),
                    FechaInicio = dateTimePickerInicio.Value.ToString("dd/MM/yyyy"),
                    FechaFin = dateTimePickerFin.Value.ToString("dd/MM/yyyy")
                };

                // Validar que fecha fin sea posterior a fecha inicio
                if (dateTimePickerFin.Value <= dateTimePickerInicio.Value)
                {
                    MessageBox.Show("La fecha de fin debe ser posterior a la fecha de inicio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MiControlador.RealizarPrestamo(prestamo);

                MessageBox.Show("Préstamo realizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar y recargar
                comboBoxUsuarios.SelectedIndex = -1;
                comboBoxLibros.SelectedIndex = -1;
                dateTimePickerInicio.Value = DateTime.Now;
                dateTimePickerFin.Value = DateTime.Now.AddDays(30);

                CargarComboLibros(); // Recargar libros disponibles
                CargarPrestamosActivos();
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
                if (dataGridViewPrestamos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un préstamo para devolver", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPrestamo = Convert.ToInt32(dataGridViewPrestamos.SelectedRows[0].Cells["ID"].Value);
                string tituloLibro = dataGridViewPrestamos.SelectedRows[0].Cells["TituloLibro"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"¿Confirmar devolución del libro '{tituloLibro}'?",
                    "Confirmar devolución",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MiControlador.DevolverLibro(idPrestamo);

                    MessageBox.Show("Libro devuelto correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarComboLibros(); // Recargar libros disponibles
                    CargarPrestamosActivos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

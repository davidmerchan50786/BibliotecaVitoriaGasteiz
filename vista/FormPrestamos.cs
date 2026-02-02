using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (formulario == null)
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
            this.VisibleChanged += FormPrestamos_VisibleChanged;
        }

        private void ConfigurarEventos()
        {
            // Aquí puedes agregar eventos adicionales si es necesario
        }

        private void FormPrestamos_VisibleChanged(object sender, EventArgs e)
        {
            // Cargar datos cuando el formulario se hace visible
            if (this.Visible)
            {
                CargarPrestamos();
            }
        }

        private void CargarPrestamos()
        {
            try
            {
                // Limpiar el DataGridView
                dataGridViewPrestamos.Rows.Clear();

                // Verificar si hay datos
                if (Datos.Prestamos == null || Datos.Prestamos.Count == 0)
                {
                    return;
                }

                // Cargar préstamos desde Datos
                foreach (var prestamo in Datos.Prestamos)
                {
                    dataGridViewPrestamos.Rows.Add(
                        prestamo.Libro?.Titulo ?? "N/A",
                        prestamo.Libro?.ISBN ?? "N/A",
                        prestamo.NumeroEjemplar,
                        prestamo.FechaPrestamo.ToString("dd/MM/yyyy"),
                        prestamo.FechaDevolucionEsperada.ToString("dd/MM/yyyy"),
                        prestamo.Usuario?.NombreCompleto ?? "N/A",
                        prestamo.MensajeAlerta
                    );

                    // Colorear filas con retraso en rojo
                    if (prestamo.DiasRetraso > 0)
                    {
                        int lastRowIndex = dataGridViewPrestamos.Rows.Count - 1;
                        dataGridViewPrestamos.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                        dataGridViewPrestamos.Rows[lastRowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este método se incluye para evitar el error de compilación
        // Si el diseñador tiene un evento registrado, no dará error
        private void dataGridViewPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este método puede quedar vacío o puedes agregar funcionalidad aquí
            // Por ejemplo, mostrar detalles del préstamo seleccionado
        }
    }
}
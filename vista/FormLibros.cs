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
    public partial class FormLibros : Form
    {
        #region Singleton

        private static FormLibros formulario;

        public static FormLibros GetInstance()
        {
            if (formulario == null)
            {
                formulario = new FormLibros();
            }
            return formulario;
        }

        #endregion

        public Controlador MiControlador { get; set; }

        private FormLibros()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarPlaceholder();
        }

        private void ConfigurarEventos()
        {
            // Eventos de botón guardar (panel + label)
            panelBotonGuardar.Click += BtnGuardar_Click;
            labelGuardar.Click += BtnGuardar_Click;
        }

        private void ConfigurarPlaceholder()
        {
            // Placeholder para el buscador
            textBoxBuscar.Enter += (s, e) =>
            {
                if (textBoxBuscar.Text == "Buscar Libro ...")
                {
                    textBoxBuscar.Text = "";
                    textBoxBuscar.ForeColor = Color.White;
                }
            };

            textBoxBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
                {
                    textBoxBuscar.Text = "Buscar Libro ...";
                    textBoxBuscar.ForeColor = Color.Gray;
                }
            };
        }

        #region Eventos del diseñador (para evitar errores de compilación)

        // Estos eventos están registrados en el diseñador
        // Se incluyen para evitar errores de compilación

        private void FormLibros_Load(object sender, EventArgs e)
        {
            // Evento Load del formulario
            // Puedes agregar inicialización aquí si es necesario
        }

        private void panelBuscarBorder_Paint(object sender, PaintEventArgs e)
        {
            // Evento Paint del panel
            // Puedes agregar dibujo personalizado aquí si es necesario
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // Funcionalidad de búsqueda (opcional)
            // Puedes implementar filtrado de libros aquí
            if (textBoxBuscar.Text == "Buscar Libro ..." || string.IsNullOrWhiteSpace(textBoxBuscar.Text))
            {
                return;
            }

            // Aquí podrías implementar búsqueda en tiempo real
            // Por ejemplo, filtrar Datos.Libros por título o autor
        }

        #endregion

        #region Métodos de funcionalidad

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = textBoxTitulo.Text.Trim();
                string autor = textBoxAutor.Text.Trim();
                string descripcion = textBoxDescripcion.Text.Trim();

                // Validaciones
                if (string.IsNullOrEmpty(titulo))
                {
                    MessageBox.Show("El título es obligatorio", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTitulo.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(autor))
                {
                    MessageBox.Show("El autor es obligatorio", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxAutor.Focus();
                    return;
                }

                // Crear libro
                var libro = new Libro
                {
                    Id = Datos.Libros.Count + 1,
                    Titulo = titulo,
                    Autor = autor,
                    ISBN = GenerarISBN(), // Generar ISBN automático
                    Descripcion = descripcion,
                    Disponible = true,
                    NumeroEjemplares = 1,
                    EjemplaresDisponibles = 1
                };

                // Guardar en la lista
                Datos.Libros.Add(libro);

                MessageBox.Show($"Libro '{libro.Titulo}' guardado correctamente\nISBN: {libro.ISBN}", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            textBoxTitulo.Clear();
            textBoxAutor.Clear();
            textBoxDescripcion.Clear();
            textBoxBuscar.Text = "Buscar Libro ...";
            textBoxBuscar.ForeColor = Color.Gray;
            textBoxTitulo.Focus();
        }

        private string GenerarISBN()
        {
            // Generar un ISBN-13 simple para demostración
            // Formato: 978-84-XXXX-XXX-X
            Random random = new Random();
            return $"978-84-{random.Next(1000, 9999)}-{random.Next(100, 999)}-{random.Next(0, 9)}";
        }

        #endregion
    }
}
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaControles;

namespace BibliotecaVitoriaGasteiz.vista
{
    public partial class FormLibros : Form
    {
        #region Singleton
        private static FormLibros formulario;

        public static FormLibros GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                formulario = new FormLibros();
            }
            return formulario;
        }
        #endregion

        public Controlador MiControlador { get; set; }
        private int libroIdSeleccionado = 0;
        private bool modoEdicion = false;

        private FormLibros()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarPlaceholder();
        }

        private void ConfigurarEventos()
        {
            // Eventos de botón guardar
            panelBotonGuardar.Click += BtnGuardar_Click;
            labelGuardar.Click += BtnGuardar_Click;

            // Eventos de botones adicionales
            panelBotonNuevo.Click += BtnNuevo_Click;
            labelNuevo.Click += BtnNuevo_Click;

            // Evento de búsqueda
            textBoxBuscar.TextChanged += TextBoxBuscar_TextChanged_Real;
        }

        private void ConfigurarPlaceholder()
        {
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

        #region Eventos del Designer (para evitar errores)

        private void FormLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private void panelBuscarBorder_Paint(object sender, PaintEventArgs e)
        {
            // Evento Paint vacío
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // Evento vacío - la funcionalidad real está en TextBoxBuscar_TextChanged_Real
        }

        private void textBoxDescripcion_TextChanged(object sender, EventArgs e)
        {
            // Evento vacío
        }

        #endregion

        #region Métodos de funcionalidad

        private void TextBoxBuscar_TextChanged_Real(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == "Buscar Libro ..." ||
                string.IsNullOrWhiteSpace(textBoxBuscar.Text))
            {
                CargarLibros();
                return;
            }

            try
            {
                DataTable dt = MiControlador.BuscarLibros(textBoxBuscar.Text);
                MostrarLibrosEnPanel(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar título
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text))
                {
                    MessageBox.Show("El título es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTitulo.Focus();
                    return;
                }

                // Validar escritor
                if (string.IsNullOrWhiteSpace(textBoxEscritor.Text))
                {
                    MessageBox.Show("El escritor es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEscritor.Focus();
                    return;
                }

                // Validar año (opcional pero si hay texto debe ser número válido)
                int? anoEdicion = null;
                if (!string.IsNullOrWhiteSpace(textBoxAnoEdicion.Text))
                {
                    if (int.TryParse(textBoxAnoEdicion.Text, out int ano))
                    {
                        if (ano < 1 || ano > DateTime.Now.Year + 1)
                        {
                            MessageBox.Show("El año de edición no es válido", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxAnoEdicion.Focus();
                            return;
                        }
                        anoEdicion = ano;
                    }
                    else
                    {
                        MessageBox.Show("El año debe ser un número", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxAnoEdicion.Focus();
                        return;
                    }
                }

                // Crear objeto Libro con los campos de la BD
                var libro = new Libro
                {
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxEscritor.Text.Trim(),
                    AnoEdicion = anoEdicion,
                    Sinopsis = textBoxSinopsis.Text.Trim(),
                    Disponible = true
                };

                if (modoEdicion)
                {
                    libro.Id = libroIdSeleccionado;
                    MiControlador.ModificarLibro(libro);
                    MessageBox.Show("Libro modificado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MiControlador.InsertarLibro(libro);
                    MessageBox.Show("Libro guardado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void CargarLibros()
        {
            try
            {
                DataTable dt = MiControlador.ObtenerLibros();
                MostrarLibrosEnPanel(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarLibrosEnPanel(DataTable dt)
        {
            // Limpiar panel de libros
            flowLayoutPanelLibros.Controls.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                Label lblVacio = new Label
                {
                    Text = "No se encontraron libros",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Padding = new Padding(20)
                };
                flowLayoutPanelLibros.Controls.Add(lblVacio);
                return;
            }

            // Crear tarjetas de libros
            foreach (DataRow row in dt.Rows)
            {
                TarjetaLibro tarjeta = new TarjetaLibro
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Titulo = row["Titulo"].ToString(),
                    Escritor = row["Escritor"].ToString(),
                    Disponible = Convert.ToBoolean(row["Disponible"]),
                    Margin = new Padding(10)
                };

                // Suscribirse al evento de ver detalles
                tarjeta.verDetalles += Tarjeta_VerDetalles;

                flowLayoutPanelLibros.Controls.Add(tarjeta);
            }
        }

        private void Tarjeta_VerDetalles(object sender, VerDetallesLibroEventArgs e)
        {
            try
            {
                // Abrir formulario de detalles
                FormDetalleLibro formDetalle = new FormDetalleLibro();
                formDetalle.MiControlador = MiControlador;
                formDetalle.LibroId = e.Id;
                formDetalle.LibroModificado += (s, args) =>
                {
                    CargarLibros(); // Recargar lista cuando se modifique
                };

                formDetalle.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir detalles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            textBoxTitulo.Clear();
            textBoxEscritor.Clear();
            textBoxAnoEdicion.Clear();
            textBoxSinopsis.Clear();
            textBoxBuscar.Text = "Buscar Libro ...";
            textBoxBuscar.ForeColor = Color.Gray;

            modoEdicion = false;
            libroIdSeleccionado = 0;
            labelGuardar.Text = "Guardar";

            textBoxTitulo.Focus();
        }

        #endregion
    }
}

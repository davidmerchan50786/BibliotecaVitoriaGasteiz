using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.vista
{
    public partial class FormDetalleLibro : Form
    {
        public Controlador MiControlador { get; set; }
        public int LibroId { get; set; }
        public event EventHandler LibroModificado;

        private bool modoEdicion = false;

        public FormDetalleLibro()
        {
            InitializeComponent();
        }

        private void FormDetalleLibro_Load(object sender, EventArgs e)
        {
            CargarDatosLibro();
            DeshabilitarEdicion();
        }

        private void CargarDatosLibro()
        {
            try
            {
                DataTable dt = MiControlador.BuscarLibroPorId(LibroId);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    textBoxTitulo.Text = row["Titulo"].ToString();
                    textBoxEscritor.Text = row["Escritor"].ToString();
                    textBoxAnoEdicion.Text = row["Ano_Edicion"] != DBNull.Value 
                        ? row["Ano_Edicion"].ToString() 
                        : "";
                    textBoxSinopsis.Text = row["Sinopsis"] != DBNull.Value 
                        ? row["Sinopsis"].ToString() 
                        : "";

                    bool disponible = Convert.ToBoolean(row["Disponible"]);
                    labelEstado.Text = disponible ? "✓ Disponible" : "✗ Prestado";
                    labelEstado.ForeColor = disponible 
                        ? Color.FromArgb(0, 204, 102) 
                        : Color.FromArgb(255, 87, 87);
                }
                else
                {
                    MessageBox.Show("No se encontró el libro", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                // Guardar cambios
                GuardarCambios();
            }
            else
            {
                // Activar modo edición
                HabilitarEdicion();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                // Cancelar edición
                DialogResult result = MessageBox.Show(
                    "¿Desea cancelar los cambios?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CargarDatosLibro();
                    DeshabilitarEdicion();
                }
            }
            else
            {
                // Cerrar formulario
                this.Close();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar este libro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    MiControlador.EliminarLibro(LibroId);
                    MessageBox.Show("Libro eliminado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LibroModificado?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GuardarCambios()
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text))
                {
                    MessageBox.Show("El título es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTitulo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEscritor.Text))
                {
                    MessageBox.Show("El escritor es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEscritor.Focus();
                    return;
                }

                // Validar año
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

                // Crear objeto Libro
                var libro = new Libro
                {
                    Id = LibroId,
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxEscritor.Text.Trim(),
                    AnoEdicion = anoEdicion,
                    Sinopsis = textBoxSinopsis.Text.Trim(),
                    Disponible = labelEstado.Text.Contains("Disponible")
                };

                MiControlador.ModificarLibro(libro);

                MessageBox.Show("Libro modificado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LibroModificado?.Invoke(this, EventArgs.Empty);
                DeshabilitarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarEdicion()
        {
            modoEdicion = true;

            textBoxTitulo.ReadOnly = false;
            textBoxEscritor.ReadOnly = false;
            textBoxAnoEdicion.ReadOnly = false;
            textBoxSinopsis.ReadOnly = false;

            textBoxTitulo.BackColor = Color.White;
            textBoxEscritor.BackColor = Color.White;
            textBoxAnoEdicion.BackColor = Color.White;
            textBoxSinopsis.BackColor = Color.White;

            labelBtnEditar.Text = "Guardar";
            labelBtnCancelar.Text = "Cancelar Edición";
            panelBtnEliminar.Enabled = false;
            panelBtnEliminar.BackColor = Color.Gray;
        }

        private void DeshabilitarEdicion()
        {
            modoEdicion = false;

            textBoxTitulo.ReadOnly = true;
            textBoxEscritor.ReadOnly = true;
            textBoxAnoEdicion.ReadOnly = true;
            textBoxSinopsis.ReadOnly = true;

            textBoxTitulo.BackColor = Color.WhiteSmoke;
            textBoxEscritor.BackColor = Color.WhiteSmoke;
            textBoxAnoEdicion.BackColor = Color.WhiteSmoke;
            textBoxSinopsis.BackColor = Color.WhiteSmoke;

            labelBtnEditar.Text = "Editar";
            labelBtnCancelar.Text = "Cerrar";
            panelBtnEliminar.Enabled = true;
            panelBtnEliminar.BackColor = Color.FromArgb(220, 53, 69); // Rojo
        }
    }
}

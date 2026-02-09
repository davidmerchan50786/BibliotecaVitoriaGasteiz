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

        //Inicializamos a -1 para que el 0 sea válido
        public int LibroId { get; set; } = -1;

        public event EventHandler LibroModificado;
        private bool modoEdicion = false;

        public FormDetalleLibro()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormDetalleLibro_Load);
        }

        private void FormDetalleLibro_Load(object sender, EventArgs e)
        {
            //Validamos contra -1 (así el ID 0 pasa)
            if (MiControlador == null || LibroId == -1)
            {
                MessageBox.Show($"Error: Datos incompletos (Controlador: {MiControlador != null}, ID: {LibroId})");
                this.Close();
                return;
            }

            CargarDatosLibro();
            DeshabilitarEdicion();
        }

        private void CargarDatosLibro()
        {
            try
            {
                DataTable dt = MiControlador.BuscarLibroPorId(LibroId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    textBoxTitulo.Text = row["Titulo"].ToString();
                    textBoxEscritor.Text = row["Escritor"].ToString();

                    if (row["Ano_Edicion"] != DBNull.Value)
                        textBoxAnoEdicion.Text = row["Ano_Edicion"].ToString();
                    else
                        textBoxAnoEdicion.Text = "";

                    textBoxSinopsis.Text = row["Sinopsis"] != DBNull.Value ? row["Sinopsis"].ToString() : "";

                    bool disponible = false;
                    if (row["Disponible"] != DBNull.Value)
                    {
                        disponible = Convert.ToInt32(row["Disponible"]) == 1;
                    }

                    labelEstado.Text = disponible ? "✓ Disponible" : "✗ Prestado";
                    labelEstado.ForeColor = disponible ? Color.Green : Color.Red;
                }
                else
                {
                    MessageBox.Show($"No se encontró el libro con ID {LibroId} en la base de datos.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer datos: {ex.Message}");
            }
        }

        // --- BOTONES ---

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (modoEdicion) GuardarCambios();
            else HabilitarEdicion();
        }

        private void GuardarCambios()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text)) return;

                int? ano = null;
                if (int.TryParse(textBoxAnoEdicion.Text, out int a)) ano = a;

                bool disp = labelEstado.Text.Contains("Disponible");

                var libro = new Libro
                {
                    Id = this.LibroId,
                    Titulo = textBoxTitulo.Text,
                    Escritor = textBoxEscritor.Text,
                    AnoEdicion = ano,
                    Sinopsis = textBoxSinopsis.Text,
                    Disponible = disp
                };

                MiControlador.ModificarLibro(libro);
                MessageBox.Show("Libro guardado correctamente.");

                LibroModificado?.Invoke(this, EventArgs.Empty);
                DeshabilitarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (modoEdicion) { CargarDatosLibro(); DeshabilitarEdicion(); }
            else this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar este libro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MiControlador.EliminarLibro(LibroId);
                LibroModificado?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        // --- ESTILOS ---
        private void HabilitarEdicion()
        {
            modoEdicion = true;
            SetReadOnly(false, Color.White);
            if (labelBtnEditar != null) labelBtnEditar.Text = "Guardar";
            if (labelBtnCancelar != null) labelBtnCancelar.Text = "Cancelar";
            if (panelBtnEliminar != null) panelBtnEliminar.Enabled = false;
        }

        private void DeshabilitarEdicion()
        {
            modoEdicion = false;
            SetReadOnly(true, Color.WhiteSmoke);
            if (labelBtnEditar != null) labelBtnEditar.Text = "Editar";
            if (labelBtnCancelar != null) labelBtnCancelar.Text = "Cerrar";
            if (panelBtnEliminar != null) panelBtnEliminar.Enabled = true;
        }

        private void SetReadOnly(bool activado, Color fondo)
        {
            textBoxTitulo.ReadOnly = activado; textBoxTitulo.BackColor = fondo;
            textBoxEscritor.ReadOnly = activado; textBoxEscritor.BackColor = fondo;
            textBoxAnoEdicion.ReadOnly = activado; textBoxAnoEdicion.BackColor = fondo;
            textBoxSinopsis.ReadOnly = activado; textBoxSinopsis.BackColor = fondo;
        }
    }
}
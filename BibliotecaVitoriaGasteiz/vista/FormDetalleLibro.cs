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
    /// Formulario de Detalle de Libro
    /// 
    /// Se abre cuando se hace click en "Ver Detalles" de una TarjetaLibro.
    /// 
    /// FUNCIONALIDADES:
    /// - Visualizar todos los datos de un libro (incluida la sinopsis completa)
    /// - Editar los datos del libro
    /// - Eliminar el libro de la base de datos
    /// - Ver el estado actual (Disponible / Prestado)
    /// 
    /// MODOS:
    /// 1. Modo Visualización: Solo lectura, botones Editar/Cerrar.
    /// 2. Modo Edición: Escritura, botones Guardar/Cancelar.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormDetalleLibro : Form
    {
        public Controlador MiControlador { get; set; }
        public int LibroId { get; set; } = -1;
        public event EventHandler LibroModificado;
        private bool modoEdicion = false;

        public FormDetalleLibro()
        {
            InitializeComponent();
            ConfigurarEsteticaResponsiva();

            // IMPORTANTE: Conectar el evento Load manualmente
            this.Load += FormDetalleLibro_Load;
        }

        /// <summary>
        /// Configura el redibujado para evitar dientes de sierra y bordes feos.
        /// </summary>
        private void ConfigurarEsteticaResponsiva()
        {
            // Forzar redibujado al cambiar tamaño
            panelTitulo.Resize += (s, e) => panelTitulo.Invalidate();
            panelEscritor.Resize += (s, e) => panelEscritor.Invalidate();
            panelAnoEdicion.Resize += (s, e) => panelAnoEdicion.Invalidate();
            panelSinopsis.Resize += (s, e) => panelSinopsis.Invalidate();

            panelBtnEditar.Resize += (s, e) => panelBtnEditar.Invalidate();
            panelBtnCancelar.Resize += (s, e) => panelBtnCancelar.Invalidate();
            panelBtnEliminar.Resize += (s, e) => panelBtnEliminar.Invalidate();

            // Dibujo de bordes redondeados
            panelTitulo.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelEscritor.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelAnoEdicion.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            panelSinopsis.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);

            panelBtnEditar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
            panelBtnCancelar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
            panelBtnEliminar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);

            // Clicks en Labels
            labelBtnEditar.Click += BtnEditar_Click;
            labelBtnCancelar.Click += BtnCancelar_Click;
            labelBtnEliminar.Click += BtnEliminar_Click;
            
            // Clicks en Paneles (para mejor UX)
            panelBtnEditar.Click += BtnEditar_Click;
            panelBtnCancelar.Click += BtnCancelar_Click;
            panelBtnEliminar.Click += BtnEliminar_Click;
        }

        private void FormDetalleLibro_Load(object sender, EventArgs e)
        {
            if (MiControlador == null || LibroId == -1)
            {
                MessageBox.Show("Error: Datos incompletos.");
                this.Close();
                return;
            }

            CargarDatosLibro();
            DeshabilitarEdicion();

            // Aseguramos que los textos estén encima del fondo pintado
            textBoxTitulo.BringToFront();
            textBoxEscritor.BringToFront();
            textBoxAnoEdicion.BringToFront();
            textBoxSinopsis.BringToFront();
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
                    textBoxAnoEdicion.Text = row["Ano_Edicion"] != DBNull.Value ? row["Ano_Edicion"].ToString() : "";
                    textBoxSinopsis.Text = row["Sinopsis"] != DBNull.Value ? row["Sinopsis"].ToString() : "";

                    bool disponible = Convert.ToInt32(row["Disponible"]) == 1;
                    labelEstado.Text = disponible ? "✓ Disponible" : "✗ Prestado";
                    labelEstado.ForeColor = disponible ? Color.LimeGreen : Color.Crimson;
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
                GuardarCambios();
            else
                HabilitarEdicion();
        }

        private void GuardarCambios()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text)) return;

                int? ano = null;
                if (int.TryParse(textBoxAnoEdicion.Text, out int a)) ano = a;

                var libro = new Libro
                {
                    Id = this.LibroId,
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxEscritor.Text.Trim(),
                    AnoEdicion = ano,
                    Sinopsis = textBoxSinopsis.Text.Trim(),
                    Disponible = labelEstado.Text.Contains("Disponible")
                };

                MiControlador.ModificarLibro(libro);
                MessageBox.Show("Libro actualizado.");

                LibroModificado?.Invoke(this, EventArgs.Empty);
                DeshabilitarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                CargarDatosLibro();
                DeshabilitarEdicion();
            }
            else
            {
                this.Close();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar libro?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MiControlador.EliminarLibro(LibroId);
                LibroModificado?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        private void HabilitarEdicion()
        {
            modoEdicion = true;
            SetReadOnly(false, Color.White);
            labelBtnEditar.Text = "Guardar";
            labelBtnCancelar.Text = "Cancelar";
            panelBtnEliminar.Visible = false;
        }

        private void DeshabilitarEdicion()
        {
            modoEdicion = false;
            SetReadOnly(true, Color.WhiteSmoke);
            labelBtnEditar.Text = "Editar";
            labelBtnCancelar.Text = "Cerrar";
            panelBtnEliminar.Visible = true;
        }

        private void SetReadOnly(bool activado, Color colorFondo)
        {
            textBoxTitulo.ReadOnly = activado; textBoxTitulo.BackColor = colorFondo;
            textBoxEscritor.ReadOnly = activado; textBoxEscritor.BackColor = colorFondo;
            textBoxAnoEdicion.ReadOnly = activado; textBoxAnoEdicion.BackColor = colorFondo;
            textBoxSinopsis.ReadOnly = activado; textBoxSinopsis.BackColor = colorFondo;
        }
    }
}
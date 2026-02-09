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
            if (formulario == null || formulario.IsDisposed) formulario = new FormLibros();
            return formulario;
        }
        #endregion

        public Controlador MiControlador { get; set; }
        private const string TEXTO_PLACEHOLDER = "Buscar Libro ...";

        // Variables de estado
        private int libroIdSeleccionado = 0;
        private bool modoEdicion = false;

        private FormLibros()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarPlaceholder();
            // AJUSTE VISUAL: Quitamos el Dock por código para evitar que tape tus campos
            // ConfigurarDiseñoResponsivo(); 
        }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();
            // Aseguramos que la lista no tape los botones/textboxes
            flowLayoutPanelLibros.SendToBack();

            if (labelGuardar != null) this.ActiveControl = labelGuardar;
        }

        private void ConfigurarEventos()
        {
            // Botones Panel Lateral / Inferior
            if (panelBotonGuardar != null) panelBotonGuardar.Click += BtnGuardar_Click;
            if (labelGuardar != null) labelGuardar.Click += BtnGuardar_Click;

            if (panelBotonNuevo != null) panelBotonNuevo.Click += BtnNuevo_Click;
            if (labelNuevo != null) labelNuevo.Click += BtnNuevo_Click;

            // Búsqueda: Usamos el nombre original que tenías para no romper el diseñador
            textBoxBuscar.TextChanged += TextBoxBuscar_TextChanged_Real;
        }

        // --- CARGA DE DATOS ---
        private void CargarLibros()
        {
            try
            {
                if (MiControlador != null)
                {
                    DataTable dt = MiControlador.ObtenerLibros();
                    MostrarLibrosEnPanel(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error cargando libros: " + ex.Message); }
        }

        private void MostrarLibrosEnPanel(DataTable dt)
        {
            flowLayoutPanelLibros.Controls.Clear();
            if (dt == null || dt.Rows.Count == 0) return;

            flowLayoutPanelLibros.SuspendLayout();
            foreach (DataRow row in dt.Rows)
            {
                TarjetaLibro tarjeta = new TarjetaLibro
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Titulo = row["Titulo"].ToString(),
                    Escritor = row["Escritor"].ToString(),
                    Disponible = row["Disponible"] != DBNull.Value && Convert.ToInt32(row["Disponible"]) == 1,
                    Margin = new Padding(10)
                };

                tarjeta.verDetalles += Tarjeta_VerDetalles;
                flowLayoutPanelLibros.Controls.Add(tarjeta);
            }
            flowLayoutPanelLibros.ResumeLayout();
        }

        // --- ABRIR DETALLE ---
        private void Tarjeta_VerDetalles(object sender, VerDetallesLibroEventArgs e)
        {
            try
            {
                FormDetalleLibro formDetalle = new FormDetalleLibro();
                formDetalle.MiControlador = this.MiControlador;
                formDetalle.LibroId = e.Id;

                formDetalle.FormClosed += (s, args) => CargarLibros();

                formDetalle.ShowDialog(this);
            }
            catch (Exception ex) { MessageBox.Show("Error abriendo detalle: " + ex.Message); }
        }

        // --- BÚSQUEDA (Aquí está la lógica de buscar) ---
        private void TextBoxBuscar_TextChanged_Real(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == TEXTO_PLACEHOLDER) return;

            string texto = textBoxBuscar.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(texto)) CargarLibros();
                else MostrarLibrosEnPanel(MiControlador.BuscarLibros(texto));
            }
            catch (Exception ex) { /* Ignorar errores al escribir rápido */ }
        }

        // --- GUARDAR / EDITAR (Campos de abajo/lateral) ---
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text) || string.IsNullOrWhiteSpace(textBoxEscritor.Text))
                {
                    MessageBox.Show("Título y Escritor son obligatorios.");
                    return;
                }

                int? ano = null;
                if (!string.IsNullOrWhiteSpace(textBoxAnoEdicion.Text))
                {
                    if (int.TryParse(textBoxAnoEdicion.Text, out int a)) ano = a;
                    else { MessageBox.Show("El año debe ser un número."); return; }
                }

                // 2. Crear objeto
                Libro libro = new Libro
                {
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxEscritor.Text.Trim(),
                    AnoEdicion = ano,
                    Sinopsis = textBoxSinopsis.Text.Trim(),
                    Disponible = true
                };

                // 3. Acción
                if (modoEdicion)
                {
                    libro.Id = libroIdSeleccionado;
                    MiControlador.ModificarLibro(libro);
                    MessageBox.Show("Libro editado correctamente.");
                }
                else
                {
                    MiControlador.InsertarLibro(libro);
                    MessageBox.Show("Libro añadido correctamente.");
                }

                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        // --- NUEVO / LIMPIAR ---
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // Limpia los campos "que salían debajo"
            textBoxTitulo.Clear();
            textBoxEscritor.Clear();
            textBoxAnoEdicion.Clear();
            textBoxSinopsis.Clear();

            modoEdicion = false;
            libroIdSeleccionado = 0;
            labelGuardar.Text = "Guardar";

            textBoxTitulo.Focus();
        }

        // --- PLACEHOLDER ---
        private void ConfigurarPlaceholder()
        {
            textBoxBuscar.Text = TEXTO_PLACEHOLDER;
            textBoxBuscar.ForeColor = Color.Gray;
            textBoxBuscar.Enter += (s, e) => { if (textBoxBuscar.Text == TEXTO_PLACEHOLDER) { textBoxBuscar.Text = ""; textBoxBuscar.ForeColor = Color.Black; } };
            textBoxBuscar.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(textBoxBuscar.Text)) { textBoxBuscar.Text = TEXTO_PLACEHOLDER; textBoxBuscar.ForeColor = Color.Gray; } };
        }

        // --- MÉTODOS COMPATIBILIDAD DISEÑADOR ---
        // Estos métodos vacíos evitan que el diseñador te de error si busca estos nombres
        private void textBoxBuscar_TextChanged(object sender, EventArgs e) { TextBoxBuscar_TextChanged_Real(sender, e); }
        private void panelBuscarBorder_Paint(object sender, PaintEventArgs e) { }
        private void textBoxDescripcion_TextChanged(object sender, EventArgs e) { }
    }
}
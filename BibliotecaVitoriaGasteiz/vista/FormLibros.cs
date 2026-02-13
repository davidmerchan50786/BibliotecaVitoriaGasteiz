using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaVitoriaGasteiz.helpers;
using BibliotecaControles;

namespace BibliotecaVitoriaGasteiz.vista
{
    public partial class FormLibros : Form
    {
        #region Singleton y Variables

        private static FormLibros formulario;

        public static FormLibros GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new FormLibros();
            return formulario;
        }

        public Controlador MiControlador { get; set; }
        private const string PLACEHOLDER_BUSCAR = "Buscar Libro ...";

        private DateTime tiempoDesbloqueo = DateTime.MinValue;

        #endregion

        #region Constructor e Inicialización

        private FormLibros()
        {
            InitializeComponent();

            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(0, 950);

            ConfigurarPlaceholder();
            ConfigurarEstiloVisual();
            ConfigurarEventos();

            // Responsividad inyectada
            UIHelper.HacerBuscadorResponsivo(panelBuscarBorder, textBoxBuscar);
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
            // El Designer ya tenía el Paint del panel buscar, pero lo reforzamos aquí para estar seguros
            panelBuscarBorder.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.DarkCyan);

            panelBotonGuardar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);
            panelBotonGuardar.Resize += (s, e) => ((Control)s).Invalidate();

            panelBotonNuevo.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);
            panelBotonNuevo.Resize += (s, e) => ((Control)s).Invalidate();
        }

        private void ConfigurarEventos()
        {
            // Limpieza de eventos del Designer para evitar dobles clics
            panelBotonGuardar.Click -= BtnGuardar_Click;
            labelGuardar.Click -= BtnGuardar_Click;
            panelBotonNuevo.Click -= BtnNuevo_Click;
            labelNuevo.Click -= BtnNuevo_Click;

            // Suscripción segura
            panelBotonGuardar.Click += BtnGuardar_Click;
            labelGuardar.Click += BtnGuardar_Click;
            panelBotonNuevo.Click += BtnNuevo_Click;
            labelNuevo.Click += BtnNuevo_Click;
        }

        private void ConfigurarPlaceholder()
        {
            // Al arrancar, si el textbox está vacío, no pondrá el texto gris a menos que le digamos
            textBoxBuscar.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscar.ForeColor = Color.Gray;

            textBoxBuscar.Enter += (s, e) => {
                if (textBoxBuscar.Text == PLACEHOLDER_BUSCAR)
                {
                    textBoxBuscar.Text = "";
                    textBoxBuscar.ForeColor = Color.White;
                }
            };
            textBoxBuscar.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
                {
                    textBoxBuscar.Text = PLACEHOLDER_BUSCAR;
                    textBoxBuscar.ForeColor = Color.Gray;
                }
            };
        }

        #endregion

        #region Eventos de Carga y Foco

        private void FormLibros_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Activate();
            this.ActiveControl = labelListaLibros; // Evita que se borre el placeholder al arrancar
        }

        #endregion

        #region Lógica CRUD (SOLO AÑADIR NUEVO)

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            if (MiControlador == null) return;

            try
            {
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text) || string.IsNullOrWhiteSpace(textBoxEscritor.Text))
                {
                    MessageBox.Show("El Título y el Escritor son campos obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BloquearClicks();
                    return;
                }

                int? ano = null;
                if (int.TryParse(textBoxAnoEdicion.Text, out int a)) ano = a;

                var libro = new Libro
                {
                    ID = 0, // Siempre 0 porque en esta vista SOLO se crean libros nuevos
                    Titulo = textBoxTitulo.Text.Trim(),
                    Escritor = textBoxEscritor.Text.Trim(),
                    Ano_Edicion = ano,
                    Sinopsis = textBoxSinopsis.Text.Trim(),
                    Disponible = true
                };

                MiControlador.SumarLibro(libro);
                MessageBox.Show("Libro registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BloquearClicks();
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textBoxTitulo.Clear();
            textBoxEscritor.Clear();
            textBoxSinopsis.Clear();
            textBoxAnoEdicion.Clear();

            textBoxBuscar.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscar.ForeColor = Color.Gray;

            this.ActiveControl = labelListaLibros;
        }

        #endregion

        #region Gestión del FlowPanel y Búsqueda

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == PLACEHOLDER_BUSCAR) return;

            if (string.IsNullOrWhiteSpace(textBoxBuscar.Text))
                CargarLibros();
            else
            {
                if (MiControlador != null)
                    PoblarFlowPanel(MiControlador.BuscarLibros(textBoxBuscar.Text));
            }
        }

        private void CargarLibros()
        {
            if (MiControlador != null)
                PoblarFlowPanel(MiControlador.ObtenerLibros());
        }

        private void PoblarFlowPanel(DataTable dt)
        {
            flowLayoutPanelLibros.Controls.Clear();
            if (dt == null || dt.Rows.Count == 0) return;

            flowLayoutPanelLibros.SuspendLayout();

            foreach (DataRow fila in dt.Rows)
            {
                var tarjeta = new TarjetaLibro();

                int idRecuperado = 0;
                if (!int.TryParse(fila[0].ToString(), out idRecuperado))
                {
                    if (dt.Columns.Contains("ID")) int.TryParse(fila["ID"].ToString(), out idRecuperado);
                    else if (dt.Columns.Contains("id")) int.TryParse(fila["id"].ToString(), out idRecuperado);
                }

                tarjeta.Id = idRecuperado;
                tarjeta.Titulo = fila["Titulo"].ToString();
                tarjeta.Escritor = fila["Escritor"].ToString();

                var valDisp = fila["Disponible"];
                try
                {
                    tarjeta.Disponible = (valDisp is bool b) ? b : (Convert.ToInt32(valDisp) == 1);
                }
                catch { tarjeta.Disponible = false; }

                tarjeta.Margin = new Padding(10);
                tarjeta.OnVerDetalles += Tarjeta_OnVerDetalles;

                flowLayoutPanelLibros.Controls.Add(tarjeta);
            }

            flowLayoutPanelLibros.ResumeLayout();
        }

        #endregion

        #region Navegación a Detalle

        private void Tarjeta_OnVerDetalles(object sender, VerDetallesEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                AbrirFormularioDetalle(e.LibroId);
            }));
        }

        private void AbrirFormularioDetalle(int idLibro)
        {
            try
            {
                FormDetalleLibro detalle = new FormDetalleLibro();
                detalle.MiControlador = this.MiControlador;
                detalle.LibroId = idLibro;

                // Al cerrar, refrescamos
                detalle.LibroModificado += (s, ev) => CargarLibros();
                detalle.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir detalle: " + ex.Message);
            }
        }

        #endregion

        #region Eventos Visuales (Designer)

        // Estos métodos se mantienen para que el Designer no se queje si están asignados ahí
        private void panelBuscarBorder_Paint(object sender, PaintEventArgs e) { }
        private void labelTitulo_Click(object sender, EventArgs e) { }
        private void textBoxDescripcion_TextChanged(object sender, EventArgs e) { }

        #endregion
    }
}
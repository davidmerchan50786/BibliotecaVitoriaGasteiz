using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaVitoriaGasteiz.helpers;

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Detalle de Libro (Ficha Técnica).
    /// 
    /// DESARROLLO Y PROBLEMAS RESUELTOS:
    /// 
    /// 1. AGUJERO DE SEGURIDAD AL EDITAR: Me di cuenta de que, aunque había validado estrictamente 
    ///    los datos al crear un libro (4 cifras para el año, campos obligatorios...), se me había
    ///    olvidado poner esas mismas validaciones al EDITARLO. Cualquier usuario podría haber 
    ///    borrado el título y haber roto la base de datos. ¡Solucionado!
    /// 2. DEBOUNCE GLOBAL: Para mantener la coherencia con el resto de la app, añadí el sistema 
    ///    Anti-Doble Clic a esta ventana modal para evitar envíos múltiples a la base de datos.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria Gasteiz
    /// Asignatura: Diseño de Interfaces - DAM
    /// </summary>
    public partial class FormDetalleLibro : Form
    {
        // ═══════════════════════════════════════════════════════════════════════
        #region Propiedades y Estado

        public Controlador MiControlador { get; set; }
        public int LibroId { get; set; } = -1;

        /// <summary>Evento para avisar a FormLibros de que recargue sus tarjetas.</summary>
        public event EventHandler LibroModificado;

        private bool modoEdicionActivado = false;

        // CONTROL ANTI-REBOTE
        private DateTime tiempoDesbloqueo = DateTime.MinValue;

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Constructor e Inicialización

        public FormDetalleLibro()
        {
            InitializeComponent();
            ConfigurarEstiloYSeguridad();
            this.Load += Evento_CargarFormulario;
        }

        private bool PuedeProcesarClick()
        {
            return DateTime.Now >= tiempoDesbloqueo;
        }

        private void BloquearClicks()
        {
            tiempoDesbloqueo = DateTime.Now.AddMilliseconds(1000);
        }

        private void ConfigurarEstiloYSeguridad()
        {
            // Evitar cierres fantasma si el Designer asignó DialogResult a algún control
            foreach (Control c in this.Controls)
            {
                if (c is Panel p)
                {
                    foreach (Control hijo in p.Controls)
                    {
                        if (hijo is Label lbl) lbl.Click += (s, e) => { };
                    }
                }
            }

            // Bordes de los paneles de texto
            if (panelTitulo != null) panelTitulo.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            if (panelEscritor != null) panelEscritor.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            if (panelAnoEdicion != null) panelAnoEdicion.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);
            if (panelSinopsis != null) panelSinopsis.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 15, Color.Transparent);

            // Botón EDITAR / GUARDAR
            if (panelBtnEditar != null)
            {
                panelBtnEditar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
                panelBtnEditar.Click += BtnEditar_Click;
                if (labelBtnEditar != null) labelBtnEditar.Click += BtnEditar_Click;
            }

            // Botón CANCELAR / VOLVER
            if (panelBtnCancelar != null)
            {
                panelBtnCancelar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
                panelBtnCancelar.Click += BtnCancelar_Click;
                if (labelBtnCancelar != null) labelBtnCancelar.Click += BtnCancelar_Click;
            }

            // Botón ELIMINAR
            if (panelBtnEliminar != null)
            {
                panelBtnEliminar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.Transparent);
                panelBtnEliminar.Click += BtnEliminar_Click;
                if (labelBtnEliminar != null) labelBtnEliminar.Click += BtnEliminar_Click;
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Carga de Datos (Backend)

        private void Evento_CargarFormulario(object sender, EventArgs e)
        {
            try
            {
                if (MiControlador == null)
                {
                    if (this.Owner is BibliotecaVitoriaGasteiz.Gestor gestor) MiControlador = gestor.miControlador;
                    else if (this.MdiParent is BibliotecaVitoriaGasteiz.Gestor mdi) MiControlador = mdi.miControlador;
                }

                if (MiControlador == null || LibroId <= 0)
                {
                    MessageBox.Show("Error crítico: No se han recibido los datos del libro o el controlador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CargarDatosDelLibro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ficha: " + ex.Message);
            }
        }

        private void CargarDatosDelLibro()
        {
            DataTable dt = MiControlador.BuscarLibroPorId(LibroId);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];

                textBoxTitulo.Text = fila["Titulo"].ToString();
                textBoxEscritor.Text = fila["Escritor"].ToString();
                textBoxAnoEdicion.Text = fila["Ano_Edicion"] != DBNull.Value ? fila["Ano_Edicion"].ToString() : "";

                if (dt.Columns.Contains("Sinopsis") && fila["Sinopsis"] != DBNull.Value)
                    textBoxSinopsis.Text = fila["Sinopsis"].ToString();
                else
                    textBoxSinopsis.Text = "";

                bool disponible = false;
                var valDisp = fila["Disponible"];
                if (valDisp is bool b) disponible = b;
                else if (valDisp is int i) disponible = (i == 1);
                else if (valDisp is long l) disponible = (l == 1);

                labelEstado.Text = disponible ? "✓ Disponible" : "✗ Prestado";
                labelEstado.ForeColor = disponible ? Color.FromArgb(0, 204, 102) : Color.Crimson;
            }
            else
            {
                MessageBox.Show("No se encontró el registro en la base de datos.");
                this.Close();
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Lógica de Negocio (Acciones y Validaciones)

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            if (!modoEdicionActivado)
            {
                // --- CAMBIO A MODO EDICIÓN ---
                modoEdicionActivado = true;

                labelBtnEditar.Text = "Guardar";
                panelBtnEditar.BackColor = Color.ForestGreen;

                labelBtnCancelar.Text = "Cancelar";
                panelBtnEliminar.Visible = false; // Ocultamos el botón eliminar por seguridad

                SetReadOnly(false, Color.Ivory);
                textBoxTitulo.Focus();

                BloquearClicks();
            }
            else
            {
                // --- GUARDAR CAMBIOS ---
                try
                {
                    // 1. Validar campos obligatorios
                    if (string.IsNullOrWhiteSpace(textBoxTitulo.Text) || string.IsNullOrWhiteSpace(textBoxEscritor.Text))
                    {
                        MessageBox.Show("El Título y el Escritor son campos obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        BloquearClicks();
                        return;
                    }

                    // 2. Validación de Año de Edición (Debe ser de 4 cifras exactas si se rellena)
                    int? ano = null;
                    string anoTexto = textBoxAnoEdicion.Text.Trim();

                    if (!string.IsNullOrWhiteSpace(anoTexto))
                    {
                        if (anoTexto.Length != 4 || !int.TryParse(anoTexto, out int a))
                        {
                            MessageBox.Show("El Año de Edición debe ser un número de exactamente 4 cifras (ej: 1998).", "Año Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxAnoEdicion.Focus();
                            BloquearClicks();
                            return;
                        }
                        ano = a;
                    }

                    // 3. Construcción del objeto
                    var libroEditado = new Libro
                    {
                        ID = this.LibroId,
                        Titulo = textBoxTitulo.Text.Trim(),
                        Escritor = textBoxEscritor.Text.Trim(),
                        Ano_Edicion = ano,
                        Sinopsis = textBoxSinopsis.Text.Trim(),
                        Disponible = labelEstado.Text.Contains("Disponible")
                    };

                    // 4. Modificación en BD
                    MiControlador.ModificarLibro(libroEditado);
                    MessageBox.Show("Libro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Avisar al formulario principal para que recargue las tarjetas
                    LibroModificado?.Invoke(this, EventArgs.Empty);

                    RestaurarModoLectura();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    BloquearClicks();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este libro permanentemente?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    MiControlador.EliminarLibro(LibroId);
                    LibroModificado?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            BloquearClicks();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            if (modoEdicionActivado)
            {
                // El usuario se ha arrepentido a mitad de la edición. Recargamos datos originales de BD.
                CargarDatosDelLibro();
                RestaurarModoLectura();
                BloquearClicks();
            }
            else
            {
                this.Close();
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Métodos Auxiliares de Interfaz

        private void RestaurarModoLectura()
        {
            modoEdicionActivado = false;

            // Devolver apariencia original
            labelBtnEditar.Text = "Editar";
            panelBtnEditar.BackColor = Color.DarkCyan;

            labelBtnCancelar.Text = "Cerrar";
            panelBtnEliminar.Visible = true;

            // Bloquear escritura
            SetReadOnly(true, Color.WhiteSmoke);
        }

        /// <summary>
        /// Enciende o apaga la capacidad de escribir en todos los TextBox de la ficha.
        /// </summary>
        private void SetReadOnly(bool activado, Color colorFondo)
        {
            textBoxTitulo.ReadOnly = activado; textBoxTitulo.BackColor = colorFondo;
            textBoxEscritor.ReadOnly = activado; textBoxEscritor.BackColor = colorFondo;
            textBoxAnoEdicion.ReadOnly = activado; textBoxAnoEdicion.BackColor = colorFondo;
            textBoxSinopsis.ReadOnly = activado; textBoxSinopsis.BackColor = colorFondo;
        }

        #endregion
    }
}
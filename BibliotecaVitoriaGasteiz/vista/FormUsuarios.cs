using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;
using BibliotecaVitoriaGasteiz.helpers;

namespace BibliotecaVitoriaGasteiz.vista
{
    public partial class FormUsuarios : Form
    {
        #region Singleton y Variables

        private static FormUsuarios formulario;
        public static FormUsuarios GetInstance()
        {
            if (formulario == null || formulario.IsDisposed) formulario = new FormUsuarios();
            return formulario;
        }

        public Controlador MiControlador { get; set; }
        private int usuarioIdSeleccionado = 0;
        private bool modoEdicion = false;
        private const string PLACEHOLDER_BUSCAR = "Buscar usuario...";

        private DateTime tiempoDesbloqueo = DateTime.MinValue;

        #endregion

        #region Constructor e Inicialización

        private FormUsuarios()
        {
            InitializeComponent();

            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(0, 950);
            labelEditar.Text = "Limpiar";

            ConfigurarEventos();
            ConfigurarPlaceholder();
            ConfigurarEstiloVisual();

            UIHelper.HacerBuscadorResponsivo(panelBuscarBorder, textBoxBuscarUsuario);
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
            panelBuscarBorder.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 20, Color.DarkCyan);
            panelButtonGuardarUsuario.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);
            panelButtonEditar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);
            panelButtonEliminar.Paint += (s, e) => UIHelper.DibujarBordeRedondeado(s, e, 30, Color.Transparent);

            panelButtonGuardarUsuario.Resize += (s, e) => ((Control)s).Invalidate();
            panelButtonEditar.Resize += (s, e) => ((Control)s).Invalidate();
            panelButtonEliminar.Resize += (s, e) => ((Control)s).Invalidate();
        }

        private void ConfigurarEventos()
        {
            // ¡AQUÍ ESTABA EL FALLO! Desuscribimos el evento zombi del Designer
            labelGuardarUsuario.Click -= labelAnadir_Click_Designer;

            // Limpiamos el resto por seguridad
            panelButtonGuardarUsuario.Click -= BtnGuardar_Click;
            labelGuardarUsuario.Click -= BtnGuardar_Click;
            panelButtonEditar.Click -= BtnLimpiar_Click;
            labelEditar.Click -= BtnLimpiar_Click;
            panelButtonEliminar.Click -= BtnEliminar_Click;
            labelEliminar.Click -= BtnEliminar_Click;

            // Ahora sí, asignamos la única lógica válida
            panelButtonGuardarUsuario.Click += BtnGuardar_Click;
            labelGuardarUsuario.Click += BtnGuardar_Click;
            panelButtonEditar.Click += BtnLimpiar_Click;
            labelEditar.Click += BtnLimpiar_Click;
            panelButtonEliminar.Click += BtnEliminar_Click;
            labelEliminar.Click += BtnEliminar_Click;

            dataGridViewUsuarios.ScrollBars = ScrollBars.Vertical;
            dataGridViewUsuarios.CellDoubleClick += (s, e) =>
            {
                if (((DataGridViewCellEventArgs)e).RowIndex >= 0) CargarUsuarioParaEdicion();
            };
        }

        private void ConfigurarPlaceholder()
        {
            textBoxBuscarUsuario.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscarUsuario.ForeColor = Color.Gray;

            textBoxBuscarUsuario.Enter += (s, e) => {
                if (textBoxBuscarUsuario.Text == PLACEHOLDER_BUSCAR)
                {
                    textBoxBuscarUsuario.Text = ""; textBoxBuscarUsuario.ForeColor = Color.White;
                }
            };
            textBoxBuscarUsuario.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(textBoxBuscarUsuario.Text))
                {
                    textBoxBuscarUsuario.Text = PLACEHOLDER_BUSCAR; textBoxBuscarUsuario.ForeColor = Color.Gray;
                }
            };
        }

        #endregion

        #region Eventos Base

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Activate();
            this.ActiveControl = labelListaUsuarios;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void textBoxBuscarUsuario_TextChanged_Designer(object sender, EventArgs e)
        {
            if (textBoxBuscarUsuario.Text == PLACEHOLDER_BUSCAR) return;
            if (string.IsNullOrWhiteSpace(textBoxBuscarUsuario.Text)) CargarUsuarios();
            else
            {
                try { if (MiControlador != null) MostrarEnGrid(MiControlador.BuscarUsuarios(textBoxBuscarUsuario.Text)); }
                catch { }
            }
        }

        #endregion

        #region Lógica CRUD

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            try
            {
                if (MiControlador == null) return;

                if (string.IsNullOrWhiteSpace(textBoxNombre.Text) || string.IsNullOrWhiteSpace(textBoxApellido1.Text))
                {
                    MessageBox.Show("Nombre y Primer Apellido obligatorios.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BloquearClicks();
                    return;
                }

                int telNum = 0;
                string telTexto = textBoxTelefono.Text.Trim();

                if (!string.IsNullOrWhiteSpace(telTexto))
                {
                    if (!int.TryParse(telTexto, out telNum) || telTexto.Length != 9)
                    {
                        MessageBox.Show("Teléfono incorrecto (debe ser 9 dígitos).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxTelefono.Focus();
                        BloquearClicks();
                        return;
                    }

                    if (ValidarTelefonoDuplicado(telTexto))
                    {
                        MessageBox.Show($"El teléfono {telTexto} ya existe en el sistema.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxTelefono.Focus();
                        BloquearClicks();
                        return;
                    }
                }

                var usuario = new Usuario
                {
                    Nombre = textBoxNombre.Text.Trim(),
                    Apellido1 = textBoxApellido1.Text.Trim(),
                    Apellido2 = textBoxApellido2.Text.Trim(),
                    Telefono = telNum
                };

                if (modoEdicion)
                {
                    usuario.Id = usuarioIdSeleccionado;
                    MiControlador.ModificarUsuario(usuario);
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MiControlador.InsertarUsuario(usuario);
                    MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BloquearClicks();
            }
        }

        private bool ValidarTelefonoDuplicado(string telefono)
        {
            foreach (DataGridViewRow row in dataGridViewUsuarios.Rows)
            {
                if (row.Cells["Telefono"].Value == null) continue;
                if (row.Cells["Telefono"].Value.ToString() == telefono)
                {
                    if (modoEdicion && Convert.ToInt32(row.Cells["Id"].Value) == usuarioIdSeleccionado)
                        continue;
                    return true;
                }
            }
            return false;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;
            LimpiarCampos();
        }

        private void CargarUsuarioParaEdicion()
        {
            if (!PuedeProcesarClick()) return;
            if (dataGridViewUsuarios.SelectedRows.Count == 0) return;

            try
            {
                var fila = dataGridViewUsuarios.SelectedRows[0];
                usuarioIdSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);

                textBoxNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";

                if (dataGridViewUsuarios.Columns.Contains("Apellido_1")) textBoxApellido1.Text = fila.Cells["Apellido_1"].Value?.ToString() ?? "";
                else if (dataGridViewUsuarios.Columns.Contains("Apellido1")) textBoxApellido1.Text = fila.Cells["Apellido1"].Value?.ToString() ?? "";

                if (dataGridViewUsuarios.Columns.Contains("Apellido_2")) textBoxApellido2.Text = fila.Cells["Apellido_2"].Value?.ToString() ?? "";
                else if (dataGridViewUsuarios.Columns.Contains("Apellido2")) textBoxApellido2.Text = fila.Cells["Apellido2"].Value?.ToString() ?? "";

                string t = fila.Cells["Telefono"].Value?.ToString() ?? "";
                textBoxTelefono.Text = (t == "0") ? "" : t;

                modoEdicion = true;
                labelGuardarUsuario.Text = "Actualizar";
                textBoxNombre.Focus();
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
            finally { BloquearClicks(); }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!PuedeProcesarClick()) return;

            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BloquearClicks();
                return;
            }

            if (MessageBox.Show("¿Eliminar usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                BloquearClicks();
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["Id"].Value);
                MiControlador.EliminarUsuario(id);
                MessageBox.Show("Usuario eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); }
            finally { BloquearClicks(); }
        }

        #endregion

        #region Helpers y Limpieza

        private void CargarUsuarios()
        {
            if (MiControlador != null) MostrarEnGrid(MiControlador.ObtenerUsuarios());
        }

        private void MostrarEnGrid(DataTable dt)
        {
            dataGridViewUsuarios.DataSource = dt;
            dataGridViewUsuarios.BorderStyle = BorderStyle.None;
            dataGridViewUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewUsuarios.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewUsuarios.BackgroundColor = Color.White;
            dataGridViewUsuarios.RowHeadersVisible = false;
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido1.Clear();
            textBoxApellido2.Clear();
            textBoxTelefono.Clear();

            textBoxBuscarUsuario.Text = PLACEHOLDER_BUSCAR;
            textBoxBuscarUsuario.ForeColor = Color.Gray;

            modoEdicion = false;
            usuarioIdSeleccionado = 0;
            labelGuardarUsuario.Text = "Guardar";

            this.ActiveControl = labelListaUsuarios;
        }

        // Dejamos el método original del Designer por si Windows lo sigue buscando internamente
        private void labelAnadir_Click_Designer(object sender, EventArgs e)
        {
            BtnGuardar_Click(sender, e);
        }

        #endregion
    }
}
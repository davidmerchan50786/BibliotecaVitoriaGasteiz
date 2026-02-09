using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.vista
{
    public partial class FormUsuarios : Form
    {
        #region Singleton
        private static FormUsuarios formulario;

        public static FormUsuarios GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
            {
                formulario = new FormUsuarios();
            }
            return formulario;
        }
        #endregion

        public Controlador MiControlador { get; set; }
        private int usuarioIdSeleccionado = 0;
        private bool modoEdicion = false;

        private FormUsuarios()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            // Evento de búsqueda
            textBoxBuscarUsuario.TextChanged += TextBoxBuscar_TextChanged;
            
            // Eventos de botones
            panelButtonAnadir.Click += BtnGuardar_Click;
            labelAnadir.Click += BtnGuardar_Click;
            
            panelButtonEditar.Click += BtnNuevo_Click;
            labelEditar.Click += BtnNuevo_Click;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBuscarUsuario.Text) ||
                textBoxBuscarUsuario.Text == "Buscar usuario...")
            {
                CargarUsuarios();
                return;
            }

            try
            {
                DataTable dt = MiControlador.BuscarUsuarios(textBoxBuscarUsuario.Text);
                MostrarUsuariosEnGrid(dt);
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
                // Validar nombre
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNombre.Focus();
                    return;
                }

                // Validar apellido1
                if (string.IsNullOrWhiteSpace(textBoxApellido1.Text))
                {
                    MessageBox.Show("El primer apellido es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxApellido1.Focus();
                    return;
                }

                // Validar teléfono
                if (string.IsNullOrWhiteSpace(textBoxTelefono.Text))
                {
                    MessageBox.Show("El teléfono es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus();
                    return;
                }

                if (!int.TryParse(textBoxTelefono.Text, out int telefono))
                {
                    MessageBox.Show("El teléfono debe ser un número", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus();
                    return;
                }

                if (textBoxTelefono.Text.Length != 9)
                {
                    MessageBox.Show("El teléfono debe tener 9 dígitos", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus();
                    return;
                }

                // Crear objeto Usuario
                var usuario = new Usuario
                {
                    Nombre = textBoxNombre.Text.Trim(),
                    Apellido1 = textBoxApellido1.Text.Trim(),
                    Apellido2 = textBoxApellido2.Text.Trim(),
                    Telefono = telefono
                };

                if (modoEdicion)
                {
                    usuario.Id = usuarioIdSeleccionado;
                    MiControlador.ModificarUsuario(usuario);
                    MessageBox.Show("Usuario modificado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MiControlador.InsertarUsuario(usuario);
                    MessageBox.Show("Usuario guardado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();
                CargarUsuarios();
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

        private void CargarUsuarios()
        {
            try
            {
                DataTable dt = MiControlador.ObtenerUsuarios();
                MostrarUsuariosEnGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarUsuariosEnGrid(DataTable dt)
        {
            dataGridViewUsuarios.DataSource = dt;

            if (dataGridViewUsuarios.Columns.Count > 0)
            {
                dataGridViewUsuarios.Columns["ID"].HeaderText = "ID";
                dataGridViewUsuarios.Columns["ID"].Width = 50;
                dataGridViewUsuarios.Columns["Nombre"].HeaderText = "Nombre";
                dataGridViewUsuarios.Columns["Nombre"].Width = 120;
                dataGridViewUsuarios.Columns["Apellido_1"].HeaderText = "Primer Apellido";
                dataGridViewUsuarios.Columns["Apellido_1"].Width = 120;
                dataGridViewUsuarios.Columns["Apellido_2"].HeaderText = "Segundo Apellido";
                dataGridViewUsuarios.Columns["Apellido_2"].Width = 120;
                dataGridViewUsuarios.Columns["Telefono"].HeaderText = "Teléfono";
                dataGridViewUsuarios.Columns["Telefono"].Width = 100;
            }
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido1.Clear();
            textBoxApellido2.Clear();
            textBoxTelefono.Clear();
            textBoxBuscarUsuario.Text = "Buscar usuario...";

            modoEdicion = false;
            usuarioIdSeleccionado = 0;
            labelAnadir.Text = "Añadir";

            textBoxNombre.Focus();
        }

        private void textBoxBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            // Evento del designer (llama al real)
            TextBoxBuscar_TextChanged(sender, e);
        }

        private void labelAnadir_Click(object sender, EventArgs e)
        {
            // Evento del designer (llama al real)
            BtnGuardar_Click(sender, e);
        }
    }
}

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
    public partial class FormUsuarios : Form
    {
        #region Singleton

        private static FormUsuarios formulario;

        public static FormUsuarios GetInstance()
        {
            if (formulario == null)
            {
                formulario = new FormUsuarios();
            }
            return formulario;
        }

        #endregion

        public Controlador MiControlador { get; set; }

        private FormUsuarios()
        {
            InitializeComponent();
            ConfigurarEventos();
            ConfigurarPlaceholder();
        }

        private void ConfigurarEventos()
        {
            // Eventos de botones (panels + labels)
            panelGuardarUsuario.Click += PanelGuardarUsuario_Click;
            label1.Click += PanelGuardarUsuario_Click; // El label "Guardar"

            panelButtonAnadir.Click += PanelButtonAnadir_Click;
            labelAnadir.Click += PanelButtonAnadir_Click;

            panelButtonEditar.Click += PanelButtonEditar_Click;
            labelEditar.Click += PanelButtonEditar_Click;

            panelButtonEliminar.Click += PanelButtonEliminar_Click;
            labelEliminar.Click += PanelButtonEliminar_Click;
        }

        private void ConfigurarPlaceholder()
        {
            // Placeholder para el buscador
            textBoxBuscarUsuario.Enter += (s, e) =>
            {
                if (textBoxBuscarUsuario.Text == "Buscar usuario...")
                {
                    textBoxBuscarUsuario.Text = "";
                    textBoxBuscarUsuario.ForeColor = Color.White;
                }
            };

            textBoxBuscarUsuario.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxBuscarUsuario.Text))
                {
                    textBoxBuscarUsuario.Text = "Buscar usuario...";
                    textBoxBuscarUsuario.ForeColor = Color.Gray;
                }
            };
        }

        #region Eventos del diseñador (para evitar errores de compilación)

        // Estos métodos pueden estar registrados en el diseñador
        // Se incluyen para evitar errores de compilación

        private void textBoxBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            // Funcionalidad de búsqueda (opcional)
            // Puedes implementar filtrado de usuarios aquí
        }

        private void labelPanelApellidos_Click(object sender, EventArgs e)
        {
            // Evento de clic en label (opcional)
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Este evento llama al método principal de guardar
            PanelGuardarUsuario_Click(sender, e);
        }

        private void labelAnadir_Click(object sender, EventArgs e)
        {
            // Este evento llama al método principal de añadir
            PanelButtonAnadir_Click(sender, e);
        }

        private void labelEditar_Click(object sender, EventArgs e)
        {
            // Este evento llama al método principal de editar
            PanelButtonEditar_Click(sender, e);
        }

        private void labelEliminar_Click(object sender, EventArgs e)
        {
            // Este evento llama al método principal de eliminar
            PanelButtonEliminar_Click(sender, e);
        }

        #endregion

        #region Métodos de funcionalidad

        private void PanelGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBoxNombre.Text.Trim();
                string apellidos = textBoxApellidos.Text.Trim();
                string email = textBoxCorreo.Text.Trim();

                // Validaciones
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre es obligatorio", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNombre.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("El correo electrónico es obligatorio", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCorreo.Focus();
                    return;
                }

                // Validar formato de email básico
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("El formato del correo electrónico no es válido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCorreo.Focus();
                    return;
                }

                // Crear usuario
                var usuario = new Usuario
                {
                    Id = Datos.Usuarios.Count + 1,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Email = email,
                    Telefono = "", // Puedes agregar un campo si lo necesitas
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };

                // Guardar en la lista
                Datos.Usuarios.Add(usuario);

                MessageBox.Show($"Usuario '{usuario.NombreCompleto}' guardado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PanelButtonAnadir_Click(object sender, EventArgs e)
        {
            // Preparar formulario para añadir nuevo usuario
            LimpiarCampos();
            textBoxNombre.Focus();

            MessageBox.Show("Rellena los campos para añadir un nuevo usuario", "Añadir Usuario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanelButtonEditar_Click(object sender, EventArgs e)
        {
            // Funcionalidad de editar (por implementar)
            MessageBox.Show("Funcionalidad de edición pendiente de implementar", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanelButtonEliminar_Click(object sender, EventArgs e)
        {
            // Funcionalidad de eliminar (por implementar)
            MessageBox.Show("Funcionalidad de eliminación pendiente de implementar", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellidos.Clear();
            textBoxCorreo.Clear();
            textBoxBuscarUsuario.Text = "Buscar usuario...";
            textBoxBuscarUsuario.ForeColor = Color.Gray;
        }

        #endregion
    }
}
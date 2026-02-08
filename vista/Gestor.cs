using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaVitoriaGasteiz
{
    public partial class Gestor : Form
    {
        public Controlador miControlador = new Controlador();

        public Gestor()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            // Eventos de navegación
            labelLibros.Click += (s, e) => MostrarLibros();
            labelUsuarios.Click += (s, e) => MostrarUsuarios();
            labelPrestamos.Click += (s, e) => MostrarPrestamos();

            // Hover effects
            ConfigurarHoverMenu(labelLibros);
            ConfigurarHoverMenu(labelUsuarios);
            ConfigurarHoverMenu(labelPrestamos);

            // Mostrar vista inicial
            this.Load += (s, e) => MostrarLibros();
        }

        private void ConfigurarHoverMenu(Label label)
        {
            label.MouseEnter += (s, e) =>
            {
                if (label.Font.Style != FontStyle.Bold)
                    label.ForeColor = Color.FromArgb(200, 200, 200);
            };

            label.MouseLeave += (s, e) =>
            {
                if (label.Font.Style != FontStyle.Bold)
                    label.ForeColor = Color.White;
            };
        }

        private void MostrarLibros()
        {
            var form = FormLibros.GetInstance();
            form.MiControlador = this.miControlador;
            InsertarFormulario(form);
            ActualizarMenuNavegacion("Libros");
        }

        private void MostrarUsuarios()
        {
            var form = FormUsuarios.GetInstance();
            form.MiControlador = this.miControlador;
            InsertarFormulario(form);
            ActualizarMenuNavegacion("Usuarios");
        }

        private void MostrarPrestamos()
        {
            var form = FormPrestamos.GetInstance();
            form.MiControlador = this.miControlador;
            InsertarFormulario(form);
            ActualizarMenuNavegacion("Prestamos");
        }

        private void InsertarFormulario(Form formulario)
        {
            // Cerrar formularios hijos anteriores
            foreach (Form hijo in this.MdiChildren)
            {
                hijo.Close();
            }

            // Configurar y mostrar el nuevo formulario
            formulario.MdiParent = this;
            formulario.Dock = DockStyle.Fill;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Show();
        }

        private void ActualizarMenuNavegacion(string vistaActiva)
        {
            // Resetear todos los estilos
            labelUsuarios.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            labelLibros.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            labelPrestamos.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            // Marcar la vista activa en negrita
            switch (vistaActiva)
            {
                case "Usuarios":
                    labelUsuarios.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    break;
                case "Libros":
                    labelLibros.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    break;
                case "Prestamos":
                    labelPrestamos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    break;
            }
        }

        // NOTA: labelAyuntamiento_Click está en Gestor.Designer.cs
        // Por eso NO lo definimos aquí para evitar duplicación
    }
}

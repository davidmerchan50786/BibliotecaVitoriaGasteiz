using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.vista;
using BibliotecaVitoriaGasteiz.helpers;
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
    /// <summary>
    /// Ventana Principal (Gestor) - Punto de entrada de la aplicación
    /// 
    /// Este es el formulario principal que contiene:
    /// - Barra de navegación superior (Libros, Usuarios, Préstamos)
    /// - Área central donde se muestran los formularios hijos (FormLibros, FormUsuarios, FormPrestamos)
    /// 
    /// USO PATRÓN MDI:
    /// - Este es el formulario padre (IsMdiContainer = true en el diseñador)
    /// - Los demás formularios se abren dentro de este como hijos (MdiChildren)
    /// 
    /// IMPORTANTE: Aquí creo UNA ÚNICA instancia del Controlador (patrón MVC)
    /// y la comparto con todos los formularios hijos. Así todos trabajan con los mismos datos.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria Gasteiz
    /// </summary>
    public partial class Gestor : Form
    {
        // Controlador único compartido por todos los formularios
        // Lo creo aquí y lo paso a cada formulario hijo cuando se abre
        public Controlador miControlador = new Controlador();

        /// <summary>
        /// Constructor del Gestor
        /// 
        /// ORDEN DE EJECUCIÓN:
        /// 1. InitializeComponent() - Crea todos los controles del diseñador
        /// 2. DatabaseHelper.CorregirIDsInvalidos() - Soluciona problemas de la BD
        /// 3. ConfigurarEventos() - Conecta los clicks de los labels de navegación
        /// 
        /// La corrección de IDs al inicio fue clave para solucionar el problema
        /// que tenía con préstamos (usuarios y libros con ID = 0).
        /// </summary>
        public Gestor()
        {
            InitializeComponent();

            // Corrijo problemas de IDs inválidos en la BD al iniciar
            // Esto lo agregué después de tener problemas con SQLite
            DatabaseHelper.CorregirIDsInvalidos();

            ConfigurarEventos();
        }

        /// <summary>
        /// Configura todos los eventos de navegación y efectos visuales
        /// 
        /// Los Labels de navegación (labelLibros, labelUsuarios, labelPrestamos)
        /// actúan como botones gracias a los eventos Click que les asigno aquí.
        /// 
        /// También configuro efectos hover (cambio de color al pasar el ratón)
        /// para que sea más intuitivo.
        /// 
        /// Por defecto, al cargar la aplicación muestro FormLibros.
        /// </summary>
        private void ConfigurarEventos()
        {
            // Eventos de navegación - Click en los labels
            labelLibros.Click += (s, e) => MostrarLibros();
            labelUsuarios.Click += (s, e) => MostrarUsuarios();
            labelPrestamos.Click += (s, e) => MostrarPrestamos();

            // Efectos hover (cambio de color al pasar el ratón)
            // Esto hace que la navegación sea más visual e intuitiva
            ConfigurarHoverMenu(labelLibros);
            ConfigurarHoverMenu(labelUsuarios);
            ConfigurarHoverMenu(labelPrestamos);

            // Vista inicial: Mostrar FormLibros cuando se carga la aplicación
            this.Load += (s, e) => MostrarLibros();
        }

        /// <summary>
        /// Configura el efecto hover para un label del menú
        /// 
        /// Cuando el ratón entra:
        /// - Si NO está en negrita (no es el activo), cambio a gris claro
        /// 
        /// Cuando el ratón sale:
        /// - Si NO está en negrita, vuelvo a blanco
        /// 
        /// El que está en negrita es el activo y no cambia de color con el hover.
        /// Este efecto lo vi en aplicaciones profesionales y quise replicarlo.
        /// </summary>
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

        /// <summary>
        /// Muestra el formulario de gestión de Libros
        /// 
        /// Pasos:
        /// 1. Obtengo la instancia única de FormLibros (patrón Singleton)
        /// 2. Le paso el Controlador compartido
        /// 3. Lo inserto como hijo MDI dentro de este formulario
        /// 4. Actualizo el menú de navegación (pongo "Libros" en negrita)
        /// </summary>
        private void MostrarLibros()
        {
            var form = FormLibros.GetInstance();
            form.MiControlador = this.miControlador;  // Paso el controlador
            InsertarFormulario(form);
            ActualizarMenuNavegacion("Libros");
        }

        /// <summary>
        /// Muestra el formulario de gestión de Usuarios
        /// Funcionamiento idéntico a MostrarLibros()
        /// </summary>
        private void MostrarUsuarios()
        {
            var form = FormUsuarios.GetInstance();
            form.MiControlador = this.miControlador;
            InsertarFormulario(form);
            ActualizarMenuNavegacion("Usuarios");
        }

        /// <summary>
        /// Muestra el formulario de gestión de Préstamos
        /// Funcionamiento idéntico a MostrarLibros()
        /// </summary>
        private void MostrarPrestamos()
        {
            var form = FormPrestamos.GetInstance();
            form.MiControlador = this.miControlador;
            InsertarFormulario(form);
            ActualizarMenuNavegacion("Prestamos");
        }

        /// <summary>
        /// Inserta un formulario hijo dentro del Gestor (patrón MDI)
        /// 
        /// IMPORTANTE: Antes de mostrar el nuevo formulario, cierro todos los hijos anteriores.
        /// Así solo se ve un formulario a la vez (Libros O Usuarios O Préstamos).
        /// 
        /// Configuración MDI:
        /// - MdiParent = this: El formulario hijo se abre dentro del Gestor
        /// - Dock = Fill: Ocupa todo el espacio disponible
        /// - FormBorderStyle = None: Sin bordes, se ve integrado
        /// 
        /// </summary>
        private void InsertarFormulario(Form formulario)
        {
            // 1. Cerramos formularios que NO sean el que queremos abrir
            // Esto evita cerrar y reabrir el mismo si el usuario hace doble clic rápido
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo != formulario)
                {
                    hijo.Close();
                }
            }

            // 2. Si ya está abierto, solo lo traemos al frente
            if (formulario.Visible)
            {
                formulario.BringToFront();
            }
            else
            {
                // 3. Si no es visible (es nuevo o se cerró antes), lo configuramos
                formulario.MdiParent = this;
                formulario.Dock = DockStyle.Fill;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Show();
            }
        }
        /// <summary>
        /// Actualiza el estilo del menú de navegación
        /// 
        /// Pone en NEGRITA el label de la vista activa
        /// y deja en Regular los demás.
        /// 
        /// Así el usuario ve claramente en qué sección está.
        /// Este feedback visual es importante para la usabilidad.
        /// </summary>
        private void ActualizarMenuNavegacion(string vistaActiva)
        {
            // PASO 1: Resetear todos los estilos a Regular
            labelUsuarios.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            labelLibros.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            labelPrestamos.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            // PASO 2: Marcar la vista activa en negrita
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

        // --- EVENTOS DEL MENÚ DE LA BARRA SUPERIOR ---
        // Estos métodos corresponden a los MenuStrip (Archivo, Edición, etc.)
        // que están en la barra superior del diseñador

        /// <summary>
        /// Click en el menú "Usuarios" de la barra superior
        /// </summary>
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        /// <summary>
        /// Click en el menú "Libros" de la barra superior
        /// </summary>
        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarLibros();
        }

        /// <summary>
        /// Click en el menú "Préstamos" de la barra superior
        /// </summary>
        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPrestamos();
        }
    }
}
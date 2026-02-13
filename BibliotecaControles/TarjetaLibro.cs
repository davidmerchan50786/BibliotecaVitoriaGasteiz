using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaControles
{
    // Clase personalizada para el evento de ver detalles
    public class VerDetallesEventArgs : EventArgs
    {
        public int LibroId { get; set; }
    }

    /// <summary>
    /// Control de usuario que representa un libro en forma de tarjeta visual.
    /// </summary>
    public partial class TarjetaLibro : UserControl
    {
        // Propiedades públicas
        public int Id { get; set; }

        public string Titulo
        {
            get => labelTitulo.Text;
            set => labelTitulo.Text = value;
        }

        public string Escritor
        {
            get => labelEscritor.Text;
            set => labelEscritor.Text = value;
        }

        public bool Disponible
        {
            set
            {
                if (value) { labelEstado.Text = "Disponible"; labelEstado.ForeColor = Color.ForestGreen; }
                else { labelEstado.Text = "Prestado"; labelEstado.ForeColor = Color.Crimson; }
            }
        }

        // Evento personalizado
        public event EventHandler<VerDetallesEventArgs> OnVerDetalles;

        private DateTime ultimoClic = DateTime.MinValue;

        public TarjetaLibro()
        {
            InitializeComponent();
            ConfigurarSeguridadBotones();
        }

        /// <summary>
        /// Configura los eventos y asegura que los botones no cierren la ventana padre.
        /// </summary>
        private void ConfigurarSeguridadBotones()
        {
            // SOLUCIÓN TÉCNICA: Eliminar DialogResult de cualquier botón
            // Esto evita que el botón actúe como "Cancelar" o "Aceptar" en un formulario modal.
            foreach (Control c in this.Controls)
            {
                if (c is Button btn) btn.DialogResult = DialogResult.None;
            }
            try
            {
                if (buttonVerDetalles != null) buttonVerDetalles.DialogResult = DialogResult.None;
            }
            catch { }

            // Conectar eventos click
            this.Click += (s, e) => ProcesarClic();
            labelTitulo.Click += (s, e) => ProcesarClic();
            labelEscritor.Click += (s, e) => ProcesarClic();
            labelEstado.Click += (s, e) => ProcesarClic();
            try { buttonVerDetalles.Click += (s, e) => ProcesarClic(); } catch { }
        }

        private void ProcesarClic()
        {
            // Filtro anti-rebote (500ms)
            if ((DateTime.Now - ultimoClic).TotalMilliseconds < 500) return;
            ultimoClic = DateTime.Now;
            OnVerDetalles?.Invoke(this, new VerDetallesEventArgs { LibroId = this.Id });
        }

        private void buttonVerDetalles_Click(object sender, EventArgs e) => ProcesarClic();
        private void TarjetaLibro_MouseEnter(object sender, EventArgs e) { this.BackColor = Color.WhiteSmoke; this.Cursor = Cursors.Hand; }
        private void TarjetaLibro_MouseLeave(object sender, EventArgs e) { this.BackColor = Color.White; this.Cursor = Cursors.Default; }
    }
}
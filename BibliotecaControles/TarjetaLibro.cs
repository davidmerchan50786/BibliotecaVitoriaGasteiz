using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaControles
{
    public partial class TarjetaLibro : UserControl
    {
        private int id;

        // Evento público
        public event EventHandler<VerDetallesLibroEventArgs> verDetalles;

        public TarjetaLibro()
        {
            InitializeComponent();
        }

        // --- PROPIEDADES ---
        public int Id
        {
            get => id;
            set => id = value;
        }

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
                if (value)
                {
                    labelEstado.Text = "Disponible";
                    labelEstado.ForeColor = Color.Green;
                }
                else
                {
                    labelEstado.Text = "Prestado";
                    labelEstado.ForeColor = Color.Red;
                }
            }
        }

        // --- EVENTOS ---

        private void buttonVerDetalles_Click(object sender, EventArgs e)
        {
            
            if (this.verDetalles != null)
            {
                this.verDetalles(this, new VerDetallesLibroEventArgs { Id = this.Id });
            }
        }

        // Efectos visuales (Hover)
        private void TarjetaLibro_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(220, 220, 220);
        }

        private void TarjetaLibro_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void pictureBoxLibro_Click(object sender, EventArgs e)
        {
            buttonVerDetalles_Click(sender, e);
        }
    }

    public class VerDetallesLibroEventArgs : EventArgs
    {
        public int Id { get; set; }
    }
}
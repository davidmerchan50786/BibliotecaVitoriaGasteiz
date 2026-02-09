namespace BibliotecaControles
{
    partial class TarjetaLibro
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelContenido = new System.Windows.Forms.Panel();
            this.buttonVerDetalles = new System.Windows.Forms.Button();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelEscritor = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelContenido.Controls.Add(this.buttonVerDetalles);
            this.panelContenido.Controls.Add(this.labelEstado);
            this.panelContenido.Controls.Add(this.labelEscritor);
            this.panelContenido.Controls.Add(this.labelTitulo);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(10);
            this.panelContenido.Size = new System.Drawing.Size(250, 180);
            this.panelContenido.TabIndex = 0;
            // 
            // buttonVerDetalles
            // 
            this.buttonVerDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVerDetalles.BackColor = System.Drawing.Color.White;
            this.buttonVerDetalles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVerDetalles.FlatAppearance.BorderSize = 0;
            this.buttonVerDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerDetalles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerDetalles.ForeColor = System.Drawing.Color.Black;
            this.buttonVerDetalles.Location = new System.Drawing.Point(115, 135);
            this.buttonVerDetalles.Name = "buttonVerDetalles";
            this.buttonVerDetalles.Size = new System.Drawing.Size(125, 35);
            this.buttonVerDetalles.TabIndex = 3;
            this.buttonVerDetalles.Text = "Ver Detalles";
            this.buttonVerDetalles.UseVisualStyleBackColor = false;
            this.buttonVerDetalles.Click += new System.EventHandler(this.buttonVerDetalles_Click);
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.labelEstado.Location = new System.Drawing.Point(10, 95);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(77, 15);
            this.labelEstado.TabIndex = 2;
            this.labelEstado.Text = "✓ Disponible";
            // 
            // labelEscritor
            // 
            this.labelEscritor.AutoSize = true;
            this.labelEscritor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscritor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.labelEscritor.Location = new System.Drawing.Point(10, 70);
            this.labelEscritor.Name = "labelEscritor";
            this.labelEscritor.Size = new System.Drawing.Size(56, 15);
            this.labelEscritor.TabIndex = 1;
            this.labelEscritor.Text = "por Autor";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(10, 15);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(230, 50);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Título del Libro";
            // 
            // TarjetaLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelContenido);
            this.Name = "TarjetaLibro";
            this.Size = new System.Drawing.Size(250, 180);
            this.MouseEnter += new System.EventHandler(this.TarjetaLibro_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TarjetaLibro_MouseLeave);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelEscritor;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Button buttonVerDetalles;
    }
}
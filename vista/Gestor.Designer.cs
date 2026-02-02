using System;

namespace BibliotecaVitoriaGasteiz
{
    partial class Gestor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelPrestamos = new System.Windows.Forms.Label();
            this.labelLibros = new System.Windows.Forms.Label();
            this.labelUsuarios = new System.Windows.Forms.Label();
            this.labelAyuntamiento = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Black;
            this.panelHeader.Controls.Add(this.labelPrestamos);
            this.panelHeader.Controls.Add(this.labelLibros);
            this.panelHeader.Controls.Add(this.labelUsuarios);
            this.panelHeader.Controls.Add(this.labelAyuntamiento);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // labelPrestamos
            // 
            this.labelPrestamos.BackColor = System.Drawing.Color.Transparent;
            this.labelPrestamos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPrestamos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelPrestamos.ForeColor = System.Drawing.Color.White;
            this.labelPrestamos.Location = new System.Drawing.Point(720, 30);
            this.labelPrestamos.Name = "labelPrestamos";
            this.labelPrestamos.Size = new System.Drawing.Size(100, 25);
            this.labelPrestamos.TabIndex = 4;
            this.labelPrestamos.Text = "Prestamos";
            this.labelPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLibros
            // 
            this.labelLibros.BackColor = System.Drawing.Color.Transparent;
            this.labelLibros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLibros.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelLibros.ForeColor = System.Drawing.Color.White;
            this.labelLibros.Location = new System.Drawing.Point(620, 30);
            this.labelLibros.Name = "labelLibros";
            this.labelLibros.Size = new System.Drawing.Size(80, 25);
            this.labelLibros.TabIndex = 3;
            this.labelLibros.Text = "Libros";
            this.labelLibros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUsuarios
            // 
            this.labelUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.labelUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelUsuarios.ForeColor = System.Drawing.Color.White;
            this.labelUsuarios.Location = new System.Drawing.Point(520, 30);
            this.labelUsuarios.Name = "labelUsuarios";
            this.labelUsuarios.Size = new System.Drawing.Size(80, 25);
            this.labelUsuarios.TabIndex = 2;
            this.labelUsuarios.Text = "Usuarios";
            this.labelUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAyuntamiento
            // 
            this.labelAyuntamiento.AutoSize = true;
            this.labelAyuntamiento.BackColor = System.Drawing.Color.Transparent;
            this.labelAyuntamiento.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelAyuntamiento.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelAyuntamiento.ForeColor = System.Drawing.Color.White;
            this.labelAyuntamiento.Location = new System.Drawing.Point(80, 25);
            this.labelAyuntamiento.Name = "labelAyuntamiento";
            this.labelAyuntamiento.Size = new System.Drawing.Size(218, 20);
            this.labelAyuntamiento.TabIndex = 1;
            this.labelAyuntamiento.Text = "Ayuntamiento Vitoria-Gasteiz";
            this.labelAyuntamiento.Click += new System.EventHandler(this.labelAyuntamiento_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 15);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // Gestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "Gestor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca Vitoria-Gasteiz";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private void labelAyuntamiento_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelAyuntamiento;
        private System.Windows.Forms.Label labelUsuarios;
        private System.Windows.Forms.Label labelLibros;
        private System.Windows.Forms.Label labelPrestamos;
    }
}


namespace BibliotecaVitoriaGasteiz.vista
{
    partial class FormDetalleLibro
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelTituloPagina = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelPanelTitulo = new System.Windows.Forms.Label();
            this.panelEscritor = new System.Windows.Forms.Panel();
            this.textBoxEscritor = new System.Windows.Forms.TextBox();
            this.labelPanelEscritor = new System.Windows.Forms.Label();
            this.panelAnoEdicion = new System.Windows.Forms.Panel();
            this.textBoxAnoEdicion = new System.Windows.Forms.TextBox();
            this.labelPanelAnoEdicion = new System.Windows.Forms.Label();
            this.panelSinopsis = new System.Windows.Forms.Panel();
            this.textBoxSinopsis = new System.Windows.Forms.TextBox();
            this.labelPanelSinopsis = new System.Windows.Forms.Label();
            this.panelBtnEditar = new System.Windows.Forms.Panel();
            this.labelBtnEditar = new System.Windows.Forms.Label();
            this.panelBtnCancelar = new System.Windows.Forms.Panel();
            this.labelBtnCancelar = new System.Windows.Forms.Label();
            this.panelBtnEliminar = new System.Windows.Forms.Panel();
            this.labelBtnEliminar = new System.Windows.Forms.Label();
            this.panelEncabezado.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelEscritor.SuspendLayout();
            this.panelAnoEdicion.SuspendLayout();
            this.panelSinopsis.SuspendLayout();
            this.panelBtnEditar.SuspendLayout();
            this.panelBtnCancelar.SuspendLayout();
            this.panelBtnEliminar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.Black;
            this.panelEncabezado.Controls.Add(this.labelEstado);
            this.panelEncabezado.Controls.Add(this.labelTituloPagina);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelEncabezado.Size = new System.Drawing.Size(580, 80);
            this.panelEncabezado.TabIndex = 0;
            // 
            // labelEstado
            // 
            this.labelEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.labelEstado.Location = new System.Drawing.Point(430, 30);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(110, 21);
            this.labelEstado.TabIndex = 1;
            this.labelEstado.Text = "✓ Disponible";
            // 
            // labelTituloPagina
            // 
            this.labelTituloPagina.AutoSize = true;
            this.labelTituloPagina.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTituloPagina.ForeColor = System.Drawing.Color.White;
            this.labelTituloPagina.Location = new System.Drawing.Point(20, 25);
            this.labelTituloPagina.Name = "labelTituloPagina";
            this.labelTituloPagina.Size = new System.Drawing.Size(183, 30);
            this.labelTituloPagina.TabIndex = 0;
            this.labelTituloPagina.Text = "Detalle del Libro";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.White;
            this.panelTitulo.Controls.Add(this.textBoxTitulo);
            this.panelTitulo.Controls.Add(this.labelPanelTitulo);
            this.panelTitulo.Location = new System.Drawing.Point(25, 100);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.panelTitulo.Size = new System.Drawing.Size(530, 60);
            this.panelTitulo.TabIndex = 1;
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxTitulo.Location = new System.Drawing.Point(10, 30);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.ReadOnly = true;
            this.textBoxTitulo.Size = new System.Drawing.Size(510, 22);
            this.textBoxTitulo.TabIndex = 1;
            // 
            // labelPanelTitulo
            // 
            this.labelPanelTitulo.AutoSize = true;
            this.labelPanelTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelTitulo.Location = new System.Drawing.Point(10, 8);
            this.labelPanelTitulo.Name = "labelPanelTitulo";
            this.labelPanelTitulo.Size = new System.Drawing.Size(49, 15);
            this.labelPanelTitulo.TabIndex = 0;
            this.labelPanelTitulo.Text = "TÍTULO";
            // 
            // panelEscritor
            // 
            this.panelEscritor.BackColor = System.Drawing.Color.White;
            this.panelEscritor.Controls.Add(this.textBoxEscritor);
            this.panelEscritor.Controls.Add(this.labelPanelEscritor);
            this.panelEscritor.Location = new System.Drawing.Point(25, 170);
            this.panelEscritor.Name = "panelEscritor";
            this.panelEscritor.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.panelEscritor.Size = new System.Drawing.Size(350, 60);
            this.panelEscritor.TabIndex = 2;
            // 
            // textBoxEscritor
            // 
            this.textBoxEscritor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxEscritor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEscritor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxEscritor.Location = new System.Drawing.Point(10, 30);
            this.textBoxEscritor.Name = "textBoxEscritor";
            this.textBoxEscritor.ReadOnly = true;
            this.textBoxEscritor.Size = new System.Drawing.Size(330, 22);
            this.textBoxEscritor.TabIndex = 1;
            // 
            // labelPanelEscritor
            // 
            this.labelPanelEscritor.AutoSize = true;
            this.labelPanelEscritor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelEscritor.Location = new System.Drawing.Point(10, 8);
            this.labelPanelEscritor.Name = "labelPanelEscritor";
            this.labelPanelEscritor.Size = new System.Drawing.Size(63, 15);
            this.labelPanelEscritor.TabIndex = 0;
            this.labelPanelEscritor.Text = "ESCRITOR";
            // 
            // panelAnoEdicion
            // 
            this.panelAnoEdicion.BackColor = System.Drawing.Color.White;
            this.panelAnoEdicion.Controls.Add(this.textBoxAnoEdicion);
            this.panelAnoEdicion.Controls.Add(this.labelPanelAnoEdicion);
            this.panelAnoEdicion.Location = new System.Drawing.Point(385, 170);
            this.panelAnoEdicion.Name = "panelAnoEdicion";
            this.panelAnoEdicion.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.panelAnoEdicion.Size = new System.Drawing.Size(170, 60);
            this.panelAnoEdicion.TabIndex = 3;
            // 
            // textBoxAnoEdicion
            // 
            this.textBoxAnoEdicion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxAnoEdicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxAnoEdicion.Location = new System.Drawing.Point(10, 30);
            this.textBoxAnoEdicion.Name = "textBoxAnoEdicion";
            this.textBoxAnoEdicion.ReadOnly = true;
            this.textBoxAnoEdicion.Size = new System.Drawing.Size(150, 22);
            this.textBoxAnoEdicion.TabIndex = 1;
            // 
            // labelPanelAnoEdicion
            // 
            this.labelPanelAnoEdicion.AutoSize = true;
            this.labelPanelAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelAnoEdicion.Location = new System.Drawing.Point(10, 8);
            this.labelPanelAnoEdicion.Name = "labelPanelAnoEdicion";
            this.labelPanelAnoEdicion.Size = new System.Drawing.Size(102, 15);
            this.labelPanelAnoEdicion.TabIndex = 0;
            this.labelPanelAnoEdicion.Text = "AÑO DE EDICIÓN";
            // 
            // panelSinopsis
            // 
            this.panelSinopsis.BackColor = System.Drawing.Color.White;
            this.panelSinopsis.Controls.Add(this.textBoxSinopsis);
            this.panelSinopsis.Controls.Add(this.labelPanelSinopsis);
            this.panelSinopsis.Location = new System.Drawing.Point(25, 240);
            this.panelSinopsis.Name = "panelSinopsis";
            this.panelSinopsis.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.panelSinopsis.Size = new System.Drawing.Size(530, 150);
            this.panelSinopsis.TabIndex = 4;
            // 
            // textBoxSinopsis
            // 
            this.textBoxSinopsis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSinopsis.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxSinopsis.Location = new System.Drawing.Point(10, 30);
            this.textBoxSinopsis.Multiline = true;
            this.textBoxSinopsis.Name = "textBoxSinopsis";
            this.textBoxSinopsis.ReadOnly = true;
            this.textBoxSinopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSinopsis.Size = new System.Drawing.Size(510, 110);
            this.textBoxSinopsis.TabIndex = 1;
            // 
            // labelPanelSinopsis
            // 
            this.labelPanelSinopsis.AutoSize = true;
            this.labelPanelSinopsis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelSinopsis.Location = new System.Drawing.Point(10, 8);
            this.labelPanelSinopsis.Name = "labelPanelSinopsis";
            this.labelPanelSinopsis.Size = new System.Drawing.Size(61, 15);
            this.labelPanelSinopsis.TabIndex = 0;
            this.labelPanelSinopsis.Text = "SINOPSIS";
            // 
            // panelBtnEditar
            // 
            this.panelBtnEditar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBtnEditar.Controls.Add(this.labelBtnEditar);
            this.panelBtnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnEditar.Location = new System.Drawing.Point(25, 410);
            this.panelBtnEditar.Name = "panelBtnEditar";
            this.panelBtnEditar.Size = new System.Drawing.Size(167, 60);
            this.panelBtnEditar.TabIndex = 5;
            // 
            // labelBtnEditar
            // 
            this.labelBtnEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBtnEditar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelBtnEditar.ForeColor = System.Drawing.Color.White;
            this.labelBtnEditar.Location = new System.Drawing.Point(0, 0);
            this.labelBtnEditar.Name = "labelBtnEditar";
            this.labelBtnEditar.Size = new System.Drawing.Size(167, 60);
            this.labelBtnEditar.TabIndex = 0;
            this.labelBtnEditar.Text = "Editar";
            this.labelBtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBtnCancelar
            // 
            this.panelBtnCancelar.BackColor = System.Drawing.Color.Black;
            this.panelBtnCancelar.Controls.Add(this.labelBtnCancelar);
            this.panelBtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnCancelar.Location = new System.Drawing.Point(202, 410);
            this.panelBtnCancelar.Name = "panelBtnCancelar";
            this.panelBtnCancelar.Size = new System.Drawing.Size(173, 60);
            this.panelBtnCancelar.TabIndex = 6;
            // 
            // labelBtnCancelar
            // 
            this.labelBtnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBtnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelBtnCancelar.ForeColor = System.Drawing.Color.White;
            this.labelBtnCancelar.Location = new System.Drawing.Point(0, 0);
            this.labelBtnCancelar.Name = "labelBtnCancelar";
            this.labelBtnCancelar.Size = new System.Drawing.Size(173, 60);
            this.labelBtnCancelar.TabIndex = 0;
            this.labelBtnCancelar.Text = "Cerrar";
            this.labelBtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBtnEliminar
            // 
            this.panelBtnEliminar.BackColor = System.Drawing.Color.Crimson;
            this.panelBtnEliminar.Controls.Add(this.labelBtnEliminar);
            this.panelBtnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnEliminar.Location = new System.Drawing.Point(385, 410);
            this.panelBtnEliminar.Name = "panelBtnEliminar";
            this.panelBtnEliminar.Size = new System.Drawing.Size(170, 60);
            this.panelBtnEliminar.TabIndex = 7;
            // 
            // labelBtnEliminar
            // 
            this.labelBtnEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBtnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelBtnEliminar.ForeColor = System.Drawing.Color.White;
            this.labelBtnEliminar.Location = new System.Drawing.Point(0, 0);
            this.labelBtnEliminar.Name = "labelBtnEliminar";
            this.labelBtnEliminar.Size = new System.Drawing.Size(170, 60);
            this.labelBtnEliminar.TabIndex = 0;
            this.labelBtnEliminar.Text = "Eliminar";
            this.labelBtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDetalleLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(580, 485);
            this.Controls.Add(this.panelBtnEliminar);
            this.Controls.Add(this.panelBtnCancelar);
            this.Controls.Add(this.panelBtnEditar);
            this.Controls.Add(this.panelSinopsis);
            this.Controls.Add(this.panelAnoEdicion);
            this.Controls.Add(this.panelEscritor);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalleLibro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle del Libro";
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelEscritor.ResumeLayout(false);
            this.panelEscritor.PerformLayout();
            this.panelAnoEdicion.ResumeLayout(false);
            this.panelAnoEdicion.PerformLayout();
            this.panelSinopsis.ResumeLayout(false);
            this.panelSinopsis.PerformLayout();
            this.panelBtnEditar.ResumeLayout(false);
            this.panelBtnCancelar.ResumeLayout(false);
            this.panelBtnEliminar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelTituloPagina;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Label labelPanelTitulo;
        private System.Windows.Forms.Panel panelEscritor;
        private System.Windows.Forms.TextBox textBoxEscritor;
        private System.Windows.Forms.Label labelPanelEscritor;
        private System.Windows.Forms.Panel panelAnoEdicion;
        private System.Windows.Forms.TextBox textBoxAnoEdicion;
        private System.Windows.Forms.Label labelPanelAnoEdicion;
        private System.Windows.Forms.Panel panelSinopsis;
        private System.Windows.Forms.TextBox textBoxSinopsis;
        private System.Windows.Forms.Label labelPanelSinopsis;
        private System.Windows.Forms.Panel panelBtnEditar;
        private System.Windows.Forms.Label labelBtnEditar;
        private System.Windows.Forms.Panel panelBtnCancelar;
        private System.Windows.Forms.Label labelBtnCancelar;
        private System.Windows.Forms.Panel panelBtnEliminar;
        private System.Windows.Forms.Label labelBtnEliminar;
    }
}

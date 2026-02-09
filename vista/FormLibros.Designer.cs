using System;
using System.Windows.Forms;

namespace BibliotecaVitoriaGasteiz.vista
{
    partial class FormLibros
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
            this.panelBuscarBorder = new System.Windows.Forms.Panel();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelEscritor = new System.Windows.Forms.Panel();
            this.textBoxEscritor = new System.Windows.Forms.TextBox();
            this.labelEscritor = new System.Windows.Forms.Label();
            this.panelAnoEdicion = new System.Windows.Forms.Panel();
            this.textBoxAnoEdicion = new System.Windows.Forms.TextBox();
            this.labelAnoEdicion = new System.Windows.Forms.Label();
            this.panelSinopsis = new System.Windows.Forms.Panel();
            this.textBoxSinopsis = new System.Windows.Forms.TextBox();
            this.labelSinopsis = new System.Windows.Forms.Label();
            this.panelBotonGuardar = new System.Windows.Forms.Panel();
            this.labelGuardar = new System.Windows.Forms.Label();
            this.panelBotonNuevo = new System.Windows.Forms.Panel();
            this.labelNuevo = new System.Windows.Forms.Label();
            this.flowLayoutPanelLibros = new System.Windows.Forms.FlowLayoutPanel();
            this.labelListaLibros = new System.Windows.Forms.Label();
            this.panelBuscarBorder.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelEscritor.SuspendLayout();
            this.panelAnoEdicion.SuspendLayout();
            this.panelSinopsis.SuspendLayout();
            this.panelBotonGuardar.SuspendLayout();
            this.panelBotonNuevo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBuscarBorder
            // 
            this.panelBuscarBorder.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBuscarBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBuscarBorder.Controls.Add(this.textBoxBuscar);
            this.panelBuscarBorder.Location = new System.Drawing.Point(50, 12);
            this.panelBuscarBorder.Name = "panelBuscarBorder";
            this.panelBuscarBorder.Size = new System.Drawing.Size(884, 73);
            this.panelBuscarBorder.TabIndex = 0;
            this.panelBuscarBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBuscarBorder_Paint);
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.BackColor = System.Drawing.Color.Black;
            this.textBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscar.ForeColor = System.Drawing.Color.Transparent;
            this.textBoxBuscar.Location = new System.Drawing.Point(18, 21);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(850, 22);
            this.textBoxBuscar.TabIndex = 0;
            this.textBoxBuscar.Text = "Buscar Libro ...";
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.White;
            this.panelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitulo.Controls.Add(this.textBoxTitulo);
            this.panelTitulo.Controls.Add(this.labelTitulo);
            this.panelTitulo.Location = new System.Drawing.Point(50, 100);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(430, 70);
            this.panelTitulo.TabIndex = 1;
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitulo.Location = new System.Drawing.Point(10, 35);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(410, 20);
            this.textBoxTitulo.TabIndex = 1;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.Black;
            this.labelTitulo.Location = new System.Drawing.Point(10, 10);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(49, 15);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "TITULO";
            // 
            // panelEscritor
            // 
            this.panelEscritor.BackColor = System.Drawing.Color.White;
            this.panelEscritor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEscritor.Controls.Add(this.textBoxEscritor);
            this.panelEscritor.Controls.Add(this.labelEscritor);
            this.panelEscritor.Location = new System.Drawing.Point(500, 100);
            this.panelEscritor.Name = "panelEscritor";
            this.panelEscritor.Size = new System.Drawing.Size(434, 70);
            this.panelEscritor.TabIndex = 2;
            // 
            // textBoxEscritor
            // 
            this.textBoxEscritor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEscritor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEscritor.Location = new System.Drawing.Point(10, 35);
            this.textBoxEscritor.Name = "textBoxEscritor";
            this.textBoxEscritor.Size = new System.Drawing.Size(410, 20);
            this.textBoxEscritor.TabIndex = 1;
            // 
            // labelEscritor
            // 
            this.labelEscritor.AutoSize = true;
            this.labelEscritor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscritor.ForeColor = System.Drawing.Color.Black;
            this.labelEscritor.Location = new System.Drawing.Point(10, 10);
            this.labelEscritor.Name = "labelEscritor";
            this.labelEscritor.Size = new System.Drawing.Size(63, 15);
            this.labelEscritor.TabIndex = 0;
            this.labelEscritor.Text = "ESCRITOR";
            // 
            // panelAnoEdicion
            // 
            this.panelAnoEdicion.BackColor = System.Drawing.Color.White;
            this.panelAnoEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnoEdicion.Controls.Add(this.textBoxAnoEdicion);
            this.panelAnoEdicion.Controls.Add(this.labelAnoEdicion);
            this.panelAnoEdicion.Location = new System.Drawing.Point(50, 185);
            this.panelAnoEdicion.Name = "panelAnoEdicion";
            this.panelAnoEdicion.Size = new System.Drawing.Size(200, 70);
            this.panelAnoEdicion.TabIndex = 3;
            // 
            // textBoxAnoEdicion
            // 
            this.textBoxAnoEdicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAnoEdicion.Location = new System.Drawing.Point(10, 35);
            this.textBoxAnoEdicion.MaxLength = 4;
            this.textBoxAnoEdicion.Name = "textBoxAnoEdicion";
            this.textBoxAnoEdicion.Size = new System.Drawing.Size(180, 20);
            this.textBoxAnoEdicion.TabIndex = 1;
            // 
            // labelAnoEdicion
            // 
            this.labelAnoEdicion.AutoSize = true;
            this.labelAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnoEdicion.ForeColor = System.Drawing.Color.Black;
            this.labelAnoEdicion.Location = new System.Drawing.Point(10, 10);
            this.labelAnoEdicion.Name = "labelAnoEdicion";
            this.labelAnoEdicion.Size = new System.Drawing.Size(117, 15);
            this.labelAnoEdicion.TabIndex = 0;
            this.labelAnoEdicion.Text = "AÑO EDICIÓN (Opc)";
            // 
            // panelSinopsis
            // 
            this.panelSinopsis.BackColor = System.Drawing.Color.White;
            this.panelSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSinopsis.Controls.Add(this.textBoxSinopsis);
            this.panelSinopsis.Controls.Add(this.labelSinopsis);
            this.panelSinopsis.Location = new System.Drawing.Point(260, 185);
            this.panelSinopsis.Name = "panelSinopsis";
            this.panelSinopsis.Size = new System.Drawing.Size(674, 120);
            this.panelSinopsis.TabIndex = 4;
            // 
            // textBoxSinopsis
            // 
            this.textBoxSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSinopsis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSinopsis.Location = new System.Drawing.Point(10, 35);
            this.textBoxSinopsis.Multiline = true;
            this.textBoxSinopsis.Name = "textBoxSinopsis";
            this.textBoxSinopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSinopsis.Size = new System.Drawing.Size(650, 75);
            this.textBoxSinopsis.TabIndex = 1;
            this.textBoxSinopsis.TextChanged += new System.EventHandler(this.textBoxDescripcion_TextChanged);
            // 
            // labelSinopsis
            // 
            this.labelSinopsis.AutoSize = true;
            this.labelSinopsis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSinopsis.ForeColor = System.Drawing.Color.Black;
            this.labelSinopsis.Location = new System.Drawing.Point(10, 10);
            this.labelSinopsis.Name = "labelSinopsis";
            this.labelSinopsis.Size = new System.Drawing.Size(94, 15);
            this.labelSinopsis.TabIndex = 0;
            this.labelSinopsis.Text = "SINOPSIS (Opc)";
            // 
            // panelBotonGuardar
            // 
            this.panelBotonGuardar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBotonGuardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBotonGuardar.Controls.Add(this.labelGuardar);
            this.panelBotonGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBotonGuardar.Location = new System.Drawing.Point(50, 320);
            this.panelBotonGuardar.Name = "panelBotonGuardar";
            this.panelBotonGuardar.Size = new System.Drawing.Size(434, 50);
            this.panelBotonGuardar.TabIndex = 5;
            // 
            // labelGuardar
            // 
            this.labelGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuardar.ForeColor = System.Drawing.Color.White;
            this.labelGuardar.Location = new System.Drawing.Point(0, 0);
            this.labelGuardar.Name = "labelGuardar";
            this.labelGuardar.Size = new System.Drawing.Size(432, 48);
            this.labelGuardar.TabIndex = 1;
            this.labelGuardar.Text = "Guardar";
            this.labelGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBotonNuevo
            // 
            this.panelBotonNuevo.BackColor = System.Drawing.Color.Black;
            this.panelBotonNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBotonNuevo.Controls.Add(this.labelNuevo);
            this.panelBotonNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBotonNuevo.Location = new System.Drawing.Point(500, 320);
            this.panelBotonNuevo.Name = "panelBotonNuevo";
            this.panelBotonNuevo.Size = new System.Drawing.Size(434, 50);
            this.panelBotonNuevo.TabIndex = 6;
            // 
            // labelNuevo
            // 
            this.labelNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNuevo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNuevo.ForeColor = System.Drawing.Color.White;
            this.labelNuevo.Location = new System.Drawing.Point(0, 0);
            this.labelNuevo.Name = "labelNuevo";
            this.labelNuevo.Size = new System.Drawing.Size(432, 48);
            this.labelNuevo.TabIndex = 0;
            this.labelNuevo.Text = "Nuevo";
            this.labelNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelLibros
            // 
            this.flowLayoutPanelLibros.AutoScroll = true;
            this.flowLayoutPanelLibros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanelLibros.Location = new System.Drawing.Point(50, 415);
            this.flowLayoutPanelLibros.Name = "flowLayoutPanelLibros";
            this.flowLayoutPanelLibros.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelLibros.Size = new System.Drawing.Size(884, 300);
            this.flowLayoutPanelLibros.TabIndex = 7;
            // 
            // labelListaLibros
            // 
            this.labelListaLibros.AutoSize = true;
            this.labelListaLibros.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListaLibros.ForeColor = System.Drawing.Color.Black;
            this.labelListaLibros.Location = new System.Drawing.Point(50, 385);
            this.labelListaLibros.Name = "labelListaLibros";
            this.labelListaLibros.Size = new System.Drawing.Size(110, 20);
            this.labelListaLibros.TabIndex = 8;
            this.labelListaLibros.Text = "Lista de Libros";
            // 
            // FormLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 730);
            this.Controls.Add(this.labelListaLibros);
            this.Controls.Add(this.flowLayoutPanelLibros);
            this.Controls.Add(this.panelBotonNuevo);
            this.Controls.Add(this.panelBotonGuardar);
            this.Controls.Add(this.panelSinopsis);
            this.Controls.Add(this.panelAnoEdicion);
            this.Controls.Add(this.panelEscritor);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelBuscarBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLibros";
            this.Text = "Gestión de Libros";
            this.Load += new System.EventHandler(this.FormLibros_Load);
            this.panelBuscarBorder.ResumeLayout(false);
            this.panelBuscarBorder.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelEscritor.ResumeLayout(false);
            this.panelEscritor.PerformLayout();
            this.panelAnoEdicion.ResumeLayout(false);
            this.panelAnoEdicion.PerformLayout();
            this.panelSinopsis.ResumeLayout(false);
            this.panelSinopsis.PerformLayout();
            this.panelBotonGuardar.ResumeLayout(false);
            this.panelBotonNuevo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBuscarBorder;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Panel panelEscritor;
        private System.Windows.Forms.Label labelEscritor;
        private System.Windows.Forms.TextBox textBoxEscritor;
        private System.Windows.Forms.Panel panelAnoEdicion;
        private System.Windows.Forms.Label labelAnoEdicion;
        private System.Windows.Forms.TextBox textBoxAnoEdicion;
        private System.Windows.Forms.Panel panelSinopsis;
        private System.Windows.Forms.Label labelSinopsis;
        private System.Windows.Forms.TextBox textBoxSinopsis;
        private System.Windows.Forms.Panel panelBotonGuardar;
        private System.Windows.Forms.Label labelGuardar;
        private System.Windows.Forms.Panel panelBotonNuevo;
        private System.Windows.Forms.Label labelNuevo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLibros;
        private System.Windows.Forms.Label labelListaLibros;
    }
}

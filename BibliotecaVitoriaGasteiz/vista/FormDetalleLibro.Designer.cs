using System.Drawing;
using System.Windows.Forms;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTituloForm = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
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
            this.panelBtnEditar = new System.Windows.Forms.Panel();
            this.labelBtnEditar = new System.Windows.Forms.Label();
            this.panelBtnCancelar = new System.Windows.Forms.Panel();
            this.labelBtnCancelar = new System.Windows.Forms.Label();
            this.panelBtnEliminar = new System.Windows.Forms.Panel();
            this.labelBtnEliminar = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelEscritor.SuspendLayout();
            this.panelAnoEdicion.SuspendLayout();
            this.panelSinopsis.SuspendLayout();
            this.panelBtnEditar.SuspendLayout();
            this.panelBtnCancelar.SuspendLayout();
            this.panelBtnEliminar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Black;
            this.panelHeader.Controls.Add(this.labelTituloForm);
            this.panelHeader.Controls.Add(this.labelEstado);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTituloForm
            // 
            this.labelTituloForm.AutoSize = true;
            this.labelTituloForm.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloForm.ForeColor = System.Drawing.Color.White;
            this.labelTituloForm.Location = new System.Drawing.Point(20, 18);
            this.labelTituloForm.Name = "labelTituloForm";
            this.labelTituloForm.Size = new System.Drawing.Size(161, 25);
            this.labelTituloForm.TabIndex = 0;
            this.labelTituloForm.Text = "Detalles del Libro";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.labelEstado.Location = new System.Drawing.Point(550, 20);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(103, 20);
            this.labelEstado.TabIndex = 1;
            this.labelEstado.Text = "✓ Disponible";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.White;
            this.panelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitulo.Controls.Add(this.textBoxTitulo);
            this.panelTitulo.Controls.Add(this.labelTitulo);
            this.panelTitulo.Location = new System.Drawing.Point(30, 80);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(640, 70);
            this.panelTitulo.TabIndex = 1;
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitulo.Location = new System.Drawing.Point(15, 35);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.ReadOnly = true;
            this.textBoxTitulo.Size = new System.Drawing.Size(610, 20);
            this.textBoxTitulo.TabIndex = 1;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.Black;
            this.labelTitulo.Location = new System.Drawing.Point(15, 10);
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
            this.panelEscritor.Location = new System.Drawing.Point(30, 165);
            this.panelEscritor.Name = "panelEscritor";
            this.panelEscritor.Size = new System.Drawing.Size(420, 70);
            this.panelEscritor.TabIndex = 2;
            // 
            // textBoxEscritor
            // 
            this.textBoxEscritor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxEscritor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEscritor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEscritor.Location = new System.Drawing.Point(15, 35);
            this.textBoxEscritor.Name = "textBoxEscritor";
            this.textBoxEscritor.ReadOnly = true;
            this.textBoxEscritor.Size = new System.Drawing.Size(390, 20);
            this.textBoxEscritor.TabIndex = 1;
            // 
            // labelEscritor
            // 
            this.labelEscritor.AutoSize = true;
            this.labelEscritor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEscritor.ForeColor = System.Drawing.Color.Black;
            this.labelEscritor.Location = new System.Drawing.Point(15, 10);
            this.labelEscritor.Name = "labelEscritor";
            this.labelEscritor.Size = new System.Drawing.Size(68, 15);
            this.labelEscritor.TabIndex = 0;
            this.labelEscritor.Text = "ESCRITOR";
            // 
            // panelAnoEdicion
            // 
            this.panelAnoEdicion.BackColor = System.Drawing.Color.White;
            this.panelAnoEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnoEdicion.Controls.Add(this.textBoxAnoEdicion);
            this.panelAnoEdicion.Controls.Add(this.labelAnoEdicion);
            this.panelAnoEdicion.Location = new System.Drawing.Point(470, 165);
            this.panelAnoEdicion.Name = "panelAnoEdicion";
            this.panelAnoEdicion.Size = new System.Drawing.Size(200, 70);
            this.panelAnoEdicion.TabIndex = 3;
            // 
            // textBoxAnoEdicion
            // 
            this.textBoxAnoEdicion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxAnoEdicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAnoEdicion.Location = new System.Drawing.Point(15, 35);
            this.textBoxAnoEdicion.MaxLength = 4;
            this.textBoxAnoEdicion.Name = "textBoxAnoEdicion";
            this.textBoxAnoEdicion.ReadOnly = true;
            this.textBoxAnoEdicion.Size = new System.Drawing.Size(170, 20);
            this.textBoxAnoEdicion.TabIndex = 1;
            // 
            // labelAnoEdicion
            // 
            this.labelAnoEdicion.AutoSize = true;
            this.labelAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnoEdicion.ForeColor = System.Drawing.Color.Black;
            this.labelAnoEdicion.Location = new System.Drawing.Point(15, 10);
            this.labelAnoEdicion.Name = "labelAnoEdicion";
            this.labelAnoEdicion.Size = new System.Drawing.Size(96, 15);
            this.labelAnoEdicion.TabIndex = 0;
            this.labelAnoEdicion.Text = "AÑO EDICIÓN";
            // 
            // panelSinopsis
            // 
            this.panelSinopsis.BackColor = System.Drawing.Color.White;
            this.panelSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSinopsis.Controls.Add(this.textBoxSinopsis);
            this.panelSinopsis.Controls.Add(this.labelSinopsis);
            this.panelSinopsis.Location = new System.Drawing.Point(30, 250);
            this.panelSinopsis.Name = "panelSinopsis";
            this.panelSinopsis.Size = new System.Drawing.Size(640, 150);
            this.panelSinopsis.TabIndex = 4;
            // 
            // textBoxSinopsis
            // 
            this.textBoxSinopsis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSinopsis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSinopsis.Location = new System.Drawing.Point(15, 35);
            this.textBoxSinopsis.Multiline = true;
            this.textBoxSinopsis.Name = "textBoxSinopsis";
            this.textBoxSinopsis.ReadOnly = true;
            this.textBoxSinopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSinopsis.Size = new System.Drawing.Size(610, 105);
            this.textBoxSinopsis.TabIndex = 1;
            // 
            // labelSinopsis
            // 
            this.labelSinopsis.AutoSize = true;
            this.labelSinopsis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSinopsis.ForeColor = System.Drawing.Color.Black;
            this.labelSinopsis.Location = new System.Drawing.Point(15, 10);
            this.labelSinopsis.Name = "labelSinopsis";
            this.labelSinopsis.Size = new System.Drawing.Size(65, 15);
            this.labelSinopsis.TabIndex = 0;
            this.labelSinopsis.Text = "SINOPSIS";
            // 
            // panelBtnEditar
            // 
            this.panelBtnEditar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBtnEditar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBtnEditar.Controls.Add(this.labelBtnEditar);
            this.panelBtnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnEditar.Location = new System.Drawing.Point(30, 420);
            this.panelBtnEditar.Name = "panelBtnEditar";
            this.panelBtnEditar.Size = new System.Drawing.Size(200, 50);
            this.panelBtnEditar.TabIndex = 5;
            this.panelBtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // labelBtnEditar
            // 
            this.labelBtnEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBtnEditar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBtnEditar.ForeColor = System.Drawing.Color.White;
            this.labelBtnEditar.Location = new System.Drawing.Point(0, 0);
            this.labelBtnEditar.Name = "labelBtnEditar";
            this.labelBtnEditar.Size = new System.Drawing.Size(198, 48);
            this.labelBtnEditar.TabIndex = 0;
            this.labelBtnEditar.Text = "Editar";
            this.labelBtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // panelBtnCancelar
            // 
            this.panelBtnCancelar.BackColor = System.Drawing.Color.Black;
            this.panelBtnCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBtnCancelar.Controls.Add(this.labelBtnCancelar);
            this.panelBtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnCancelar.Location = new System.Drawing.Point(250, 420);
            this.panelBtnCancelar.Name = "panelBtnCancelar";
            this.panelBtnCancelar.Size = new System.Drawing.Size(200, 50);
            this.panelBtnCancelar.TabIndex = 6;
            this.panelBtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // labelBtnCancelar
            // 
            this.labelBtnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBtnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBtnCancelar.ForeColor = System.Drawing.Color.White;
            this.labelBtnCancelar.Location = new System.Drawing.Point(0, 0);
            this.labelBtnCancelar.Name = "labelBtnCancelar";
            this.labelBtnCancelar.Size = new System.Drawing.Size(198, 48);
            this.labelBtnCancelar.TabIndex = 0;
            this.labelBtnCancelar.Text = "Cerrar";
            this.labelBtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panelBtnEliminar
            // 
            this.panelBtnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.panelBtnEliminar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBtnEliminar.Controls.Add(this.labelBtnEliminar);
            this.panelBtnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBtnEliminar.Location = new System.Drawing.Point(470, 420);
            this.panelBtnEliminar.Name = "panelBtnEliminar";
            this.panelBtnEliminar.Size = new System.Drawing.Size(200, 50);
            this.panelBtnEliminar.TabIndex = 7;
            this.panelBtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // labelBtnEliminar
            // 
            this.labelBtnEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBtnEliminar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBtnEliminar.ForeColor = System.Drawing.Color.White;
            this.labelBtnEliminar.Location = new System.Drawing.Point(0, 0);
            this.labelBtnEliminar.Name = "labelBtnEliminar";
            this.labelBtnEliminar.Size = new System.Drawing.Size(198, 48);
            this.labelBtnEliminar.TabIndex = 0;
            this.labelBtnEliminar.Text = "Eliminar";
            this.labelBtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // FormDetalleLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(700, 490);
            this.Controls.Add(this.panelBtnEliminar);
            this.Controls.Add(this.panelBtnCancelar);
            this.Controls.Add(this.panelBtnEditar);
            this.Controls.Add(this.panelSinopsis);
            this.Controls.Add(this.panelAnoEdicion);
            this.Controls.Add(this.panelEscritor);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalleLibro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalles del Libro";
            this.Load += new System.EventHandler(this.FormDetalleLibro_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
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

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTituloForm;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelEscritor;
        private System.Windows.Forms.TextBox textBoxEscritor;
        private System.Windows.Forms.Label labelEscritor;
        private System.Windows.Forms.Panel panelAnoEdicion;
        private System.Windows.Forms.TextBox textBoxAnoEdicion;
        private System.Windows.Forms.Label labelAnoEdicion;
        private System.Windows.Forms.Panel panelSinopsis;
        private System.Windows.Forms.TextBox textBoxSinopsis;
        private System.Windows.Forms.Label labelSinopsis;
        private System.Windows.Forms.Panel panelBtnEditar;
        private System.Windows.Forms.Label labelBtnEditar;
        private System.Windows.Forms.Panel panelBtnCancelar;
        private System.Windows.Forms.Label labelBtnCancelar;
        private System.Windows.Forms.Panel panelBtnEliminar;
        private System.Windows.Forms.Label labelBtnEliminar;
    }
}

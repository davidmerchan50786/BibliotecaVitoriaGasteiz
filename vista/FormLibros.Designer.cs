using System;
using System.Windows.Forms;

namespace BibliotecaVitoriaGasteiz.vista
{
    partial class FormLibros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBuscarBorder = new System.Windows.Forms.Panel();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelAutor = new System.Windows.Forms.Panel();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.labelAutor = new System.Windows.Forms.Label();
            this.panelDescripcion = new System.Windows.Forms.Panel();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.panelBotonGuardar = new System.Windows.Forms.Panel();
            this.labelGuardar = new System.Windows.Forms.Label();
            this.pictureBoxGuardar = new System.Windows.Forms.PictureBox();
            this.panelBuscarBorder.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelAutor.SuspendLayout();
            this.panelDescripcion.SuspendLayout();
            this.panelBotonGuardar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuardar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBuscarBorder
            // 
            this.panelBuscarBorder.BackColor = System.Drawing.Color.Lime;
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
            this.textBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscar.ForeColor = System.Drawing.Color.Gray;
            this.textBoxBuscar.Location = new System.Drawing.Point(18, 21);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(880, 29);
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
            this.panelTitulo.Size = new System.Drawing.Size(430, 80);
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
            this.textBoxTitulo.Text = "el señor de los anillos";
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
            // panelAutor
            // 
            this.panelAutor.BackColor = System.Drawing.Color.White;
            this.panelAutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAutor.Controls.Add(this.textBoxAutor);
            this.panelAutor.Controls.Add(this.labelAutor);
            this.panelAutor.Location = new System.Drawing.Point(500, 100);
            this.panelAutor.Name = "panelAutor";
            this.panelAutor.Size = new System.Drawing.Size(430, 80);
            this.panelAutor.TabIndex = 2;
            // 
            // textBoxAutor
            // 
            this.textBoxAutor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAutor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAutor.Location = new System.Drawing.Point(10, 35);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(410, 20);
            this.textBoxAutor.TabIndex = 1;
            this.textBoxAutor.Text = "Tolkien";
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutor.ForeColor = System.Drawing.Color.Black;
            this.labelAutor.Location = new System.Drawing.Point(10, 10);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(48, 15);
            this.labelAutor.TabIndex = 0;
            this.labelAutor.Text = "AUTOR";
            // 
            // panelDescripcion
            // 
            this.panelDescripcion.BackColor = System.Drawing.Color.White;
            this.panelDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDescripcion.Controls.Add(this.textBoxDescripcion);
            this.panelDescripcion.Controls.Add(this.labelDescripcion);
            this.panelDescripcion.Location = new System.Drawing.Point(50, 195);
            this.panelDescripcion.Name = "panelDescripcion";
            this.panelDescripcion.Size = new System.Drawing.Size(880, 150);
            this.panelDescripcion.TabIndex = 3;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescripcion.Location = new System.Drawing.Point(10, 35);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescripcion.Size = new System.Drawing.Size(860, 100);
            this.textBoxDescripcion.TabIndex = 1;
            this.textBoxDescripcion.Text = "escribe descripcion";
            this.textBoxDescripcion.TextChanged += new System.EventHandler(this.textBoxDescripcion_TextChanged);
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcion.ForeColor = System.Drawing.Color.Black;
            this.labelDescripcion.Location = new System.Drawing.Point(10, 10);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(84, 15);
            this.labelDescripcion.TabIndex = 0;
            this.labelDescripcion.Text = "DESCRIPCION";
            // 
            // panelBotonGuardar
            // 
            this.panelBotonGuardar.BackColor = System.Drawing.Color.White;
            this.panelBotonGuardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBotonGuardar.Controls.Add(this.labelGuardar);
            this.panelBotonGuardar.Controls.Add(this.pictureBoxGuardar);
            this.panelBotonGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBotonGuardar.Location = new System.Drawing.Point(50, 370);
            this.panelBotonGuardar.Name = "panelBotonGuardar";
            this.panelBotonGuardar.Size = new System.Drawing.Size(880, 80);
            this.panelBotonGuardar.TabIndex = 4;
            // 
            // labelGuardar
            // 
            this.labelGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGuardar.Location = new System.Drawing.Point(440, 25);
            this.labelGuardar.Name = "labelGuardar";
            this.labelGuardar.Size = new System.Drawing.Size(100, 30);
            this.labelGuardar.TabIndex = 1;
            this.labelGuardar.Text = "Guardar";
            this.labelGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxGuardar
            // 
            this.pictureBoxGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.pictureBoxGuardar.Location = new System.Drawing.Point(380, 15);
            this.pictureBoxGuardar.Name = "pictureBoxGuardar";
            this.pictureBoxGuardar.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGuardar.TabIndex = 0;
            this.pictureBoxGuardar.TabStop = false;
            // 
            // FormLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelBotonGuardar);
            this.Controls.Add(this.panelDescripcion);
            this.Controls.Add(this.panelAutor);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelBuscarBorder);
            this.Name = "FormLibros";
            this.Text = "Gestión de Libros";
            this.Load += new System.EventHandler(this.FormLibros_Load);
            this.panelBuscarBorder.ResumeLayout(false);
            this.panelBuscarBorder.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelAutor.ResumeLayout(false);
            this.panelAutor.PerformLayout();
            this.panelDescripcion.ResumeLayout(false);
            this.panelDescripcion.PerformLayout();
            this.panelBotonGuardar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuardar)).EndInit();
            this.ResumeLayout(false);

        }

        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PanelBuscarBorder_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FormLibros_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panelBuscarBorder;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Panel panelAutor;
        private System.Windows.Forms.Label labelAutor;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.Panel panelDescripcion;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Panel panelBotonGuardar;
        private System.Windows.Forms.PictureBox pictureBoxGuardar;
        private System.Windows.Forms.Label labelGuardar;
    }
}
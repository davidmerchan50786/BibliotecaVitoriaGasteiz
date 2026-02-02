namespace BibliotecaVitoriaGasteiz.vista
{
    partial class FormPrestamos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewPrestamos = new System.Windows.Forms.DataGridView();
            this.ColumnTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumEjemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFechaPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAlertas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPrestamos
            // 
            this.dataGridViewPrestamos.AllowUserToAddRows = false;
            this.dataGridViewPrestamos.AllowUserToDeleteRows = false;
            this.dataGridViewPrestamos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPrestamos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPrestamos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrestamos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTitulo,
            this.ColumnISBN,
            this.ColumnNumEjemplar,
            this.ColumnFechaPrestamo,
            this.ColumnFechaDevolucion,
            this.ColumnUsuario,
            this.ColumnAlertas});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPrestamos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPrestamos.EnableHeadersVisualStyles = false;
            this.dataGridViewPrestamos.Location = new System.Drawing.Point(20, 40);
            this.dataGridViewPrestamos.Name = "dataGridViewPrestamos";
            this.dataGridViewPrestamos.ReadOnly = true;
            this.dataGridViewPrestamos.RowHeadersVisible = false;
            this.dataGridViewPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrestamos.Size = new System.Drawing.Size(960, 540);
            this.dataGridViewPrestamos.TabIndex = 0;
            this.dataGridViewPrestamos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPrestamos_CellContentClick);
            // 
            // ColumnTitulo
            // 
            this.ColumnTitulo.HeaderText = "Título";
            this.ColumnTitulo.Name = "ColumnTitulo";
            this.ColumnTitulo.ReadOnly = true;
            this.ColumnTitulo.Width = 150;
            // 
            // ColumnISBN
            // 
            this.ColumnISBN.HeaderText = "ISBN";
            this.ColumnISBN.Name = "ColumnISBN";
            this.ColumnISBN.ReadOnly = true;
            this.ColumnISBN.Width = 120;
            // 
            // ColumnNumEjemplar
            // 
            this.ColumnNumEjemplar.HeaderText = "nº  ejemplar";
            this.ColumnNumEjemplar.Name = "ColumnNumEjemplar";
            this.ColumnNumEjemplar.ReadOnly = true;
            // 
            // ColumnFechaPrestamo
            // 
            this.ColumnFechaPrestamo.HeaderText = "Fecha préstamo";
            this.ColumnFechaPrestamo.Name = "ColumnFechaPrestamo";
            this.ColumnFechaPrestamo.ReadOnly = true;
            this.ColumnFechaPrestamo.Width = 130;
            // 
            // ColumnFechaDevolucion
            // 
            this.ColumnFechaDevolucion.HeaderText = "Fecha Devolucion";
            this.ColumnFechaDevolucion.Name = "ColumnFechaDevolucion";
            this.ColumnFechaDevolucion.ReadOnly = true;
            this.ColumnFechaDevolucion.Width = 130;
            // 
            // ColumnUsuario
            // 
            this.ColumnUsuario.HeaderText = "Usuario";
            this.ColumnUsuario.Name = "ColumnUsuario";
            this.ColumnUsuario.ReadOnly = true;
            this.ColumnUsuario.Width = 150;
            // 
            // ColumnAlertas
            // 
            this.ColumnAlertas.HeaderText = "Alerta";
            this.ColumnAlertas.Name = "ColumnAlertas";
            this.ColumnAlertas.ReadOnly = true;
            this.ColumnAlertas.Width = 180;
            // 
            // FormPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.dataGridViewPrestamos);
            this.Name = "FormPrestamos";
            this.Text = "FormPrestamos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPrestamos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumEjemplar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFechaPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFechaDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlertas;
    }
}
namespace BibliotecaVitoriaGasteiz.vista
{
    partial class FormPrestamos
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.comboBoxLibros = new System.Windows.Forms.ComboBox();
            this.labelLibro = new System.Windows.Forms.Label();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.panelButtonPrestar = new System.Windows.Forms.Panel();
            this.labelPrestar = new System.Windows.Forms.Label();
            this.dataGridViewPrestamos = new System.Windows.Forms.DataGridView();
            this.labelPrestamosActivos = new System.Windows.Forms.Label();
            this.panelButtonDevolver = new System.Windows.Forms.Panel();
            this.labelDevolver = new System.Windows.Forms.Label();
            this.panelButtonPrestar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).BeginInit();
            this.panelButtonDevolver.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(60, 30);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(184, 25);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Realizar Préstamo";
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxUsuarios.FormattingEnabled = true;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(60, 100);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(420, 28);
            this.comboBoxUsuarios.TabIndex = 1;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelUsuario.Location = new System.Drawing.Point(60, 75);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(62, 19);
            this.labelUsuario.TabIndex = 2;
            this.labelUsuario.Text = "Usuario";
            // 
            // comboBoxLibros
            // 
            this.comboBoxLibros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLibros.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxLibros.FormattingEnabled = true;
            this.comboBoxLibros.Location = new System.Drawing.Point(500, 100);
            this.comboBoxLibros.Name = "comboBoxLibros";
            this.comboBoxLibros.Size = new System.Drawing.Size(420, 28);
            this.comboBoxLibros.TabIndex = 2;
            // 
            // labelLibro
            // 
            this.labelLibro.AutoSize = true;
            this.labelLibro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelLibro.Location = new System.Drawing.Point(500, 75);
            this.labelLibro.Name = "labelLibro";
            this.labelLibro.Size = new System.Drawing.Size(127, 19);
            this.labelLibro.TabIndex = 4;
            this.labelLibro.Text = "Libro (Disponible)";
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(60, 170);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerInicio.TabIndex = 3;
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelFechaInicio.Location = new System.Drawing.Point(60, 145);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(92, 19);
            this.labelFechaInicio.TabIndex = 6;
            this.labelFechaInicio.Text = "Fecha Inicio";
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFin.Location = new System.Drawing.Point(280, 170);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerFin.TabIndex = 4;
            // 
            // labelFechaFin
            // 
            this.labelFechaFin.AutoSize = true;
            this.labelFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelFechaFin.Location = new System.Drawing.Point(280, 145);
            this.labelFechaFin.Name = "labelFechaFin";
            this.labelFechaFin.Size = new System.Drawing.Size(73, 19);
            this.labelFechaFin.TabIndex = 8;
            this.labelFechaFin.Text = "Fecha Fin";
            // 
            // panelButtonPrestar
            // 
            this.panelButtonPrestar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelButtonPrestar.Controls.Add(this.labelPrestar);
            this.panelButtonPrestar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonPrestar.Location = new System.Drawing.Point(60, 220);
            this.panelButtonPrestar.Name = "panelButtonPrestar";
            this.panelButtonPrestar.Size = new System.Drawing.Size(420, 50);
            this.panelButtonPrestar.TabIndex = 5;
            // 
            // labelPrestar
            // 
            this.labelPrestar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPrestar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelPrestar.ForeColor = System.Drawing.Color.White;
            this.labelPrestar.Location = new System.Drawing.Point(0, 0);
            this.labelPrestar.Name = "labelPrestar";
            this.labelPrestar.Size = new System.Drawing.Size(420, 50);
            this.labelPrestar.TabIndex = 0;
            this.labelPrestar.Text = "Realizar Préstamo";
            this.labelPrestar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewPrestamos
            // 
            this.dataGridViewPrestamos.AllowUserToAddRows = false;
            this.dataGridViewPrestamos.AllowUserToDeleteRows = false;
            this.dataGridViewPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrestamos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrestamos.Location = new System.Drawing.Point(60, 330);
            this.dataGridViewPrestamos.Name = "dataGridViewPrestamos";
            this.dataGridViewPrestamos.ReadOnly = true;
            this.dataGridViewPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrestamos.Size = new System.Drawing.Size(860, 280);
            this.dataGridViewPrestamos.TabIndex = 7;
            // 
            // labelPrestamosActivos
            // 
            this.labelPrestamosActivos.AutoSize = true;
            this.labelPrestamosActivos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelPrestamosActivos.Location = new System.Drawing.Point(60, 295);
            this.labelPrestamosActivos.Name = "labelPrestamosActivos";
            this.labelPrestamosActivos.Size = new System.Drawing.Size(158, 21);
            this.labelPrestamosActivos.TabIndex = 11;
            this.labelPrestamosActivos.Text = "Préstamos Activos";
            // 
            // panelButtonDevolver
            // 
            this.panelButtonDevolver.BackColor = System.Drawing.Color.Black;
            this.panelButtonDevolver.Controls.Add(this.labelDevolver);
            this.panelButtonDevolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonDevolver.Location = new System.Drawing.Point(500, 220);
            this.panelButtonDevolver.Name = "panelButtonDevolver";
            this.panelButtonDevolver.Size = new System.Drawing.Size(420, 50);
            this.panelButtonDevolver.TabIndex = 6;
            // 
            // labelDevolver
            // 
            this.labelDevolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDevolver.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelDevolver.ForeColor = System.Drawing.Color.White;
            this.labelDevolver.Location = new System.Drawing.Point(0, 0);
            this.labelDevolver.Name = "labelDevolver";
            this.labelDevolver.Size = new System.Drawing.Size(420, 50);
            this.labelDevolver.TabIndex = 0;
            this.labelDevolver.Text = "Devolver Libro Seleccionado";
            this.labelDevolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 640);
            this.Controls.Add(this.panelButtonDevolver);
            this.Controls.Add(this.labelPrestamosActivos);
            this.Controls.Add(this.dataGridViewPrestamos);
            this.Controls.Add(this.panelButtonPrestar);
            this.Controls.Add(this.labelFechaFin);
            this.Controls.Add(this.dateTimePickerFin);
            this.Controls.Add(this.labelFechaInicio);
            this.Controls.Add(this.dateTimePickerInicio);
            this.Controls.Add(this.labelLibro);
            this.Controls.Add(this.comboBoxLibros);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.comboBoxUsuarios);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPrestamos";
            this.Text = "Gestión de Préstamos";
            this.Load += new System.EventHandler(this.FormPrestamos_Load);
            this.panelButtonPrestar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).EndInit();
            this.panelButtonDevolver.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.ComboBox comboBoxLibros;
        private System.Windows.Forms.Label labelLibro;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Label labelFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.Panel panelButtonPrestar;
        private System.Windows.Forms.Label labelPrestar;
        private System.Windows.Forms.DataGridView dataGridViewPrestamos;
        private System.Windows.Forms.Label labelPrestamosActivos;
        private System.Windows.Forms.Panel panelButtonDevolver;
        private System.Windows.Forms.Label labelDevolver;
    }
}

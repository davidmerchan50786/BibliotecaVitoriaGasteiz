namespace BibliotecaVitoriaGasteiz.vista
{
    partial class FormUsuarios
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
            this.textBoxBuscarUsuario = new System.Windows.Forms.TextBox();
            this.panelButtonAnadir = new System.Windows.Forms.Panel();
            this.labelAnadir = new System.Windows.Forms.Label();
            this.panelButtonEditar = new System.Windows.Forms.Panel();
            this.labelEditar = new System.Windows.Forms.Label();
            this.panelNombre = new System.Windows.Forms.Panel();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelPanelNombre = new System.Windows.Forms.Label();
            this.panelApellido1 = new System.Windows.Forms.Panel();
            this.textBoxApellido1 = new System.Windows.Forms.TextBox();
            this.labelPanelApellido1 = new System.Windows.Forms.Label();
            this.panelApellido2 = new System.Windows.Forms.Panel();
            this.textBoxApellido2 = new System.Windows.Forms.TextBox();
            this.labelPanelApellido2 = new System.Windows.Forms.Label();
            this.panelTelefono = new System.Windows.Forms.Panel();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.labelPanelTelefono = new System.Windows.Forms.Label();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.panelButtonAnadir.SuspendLayout();
            this.panelButtonEditar.SuspendLayout();
            this.panelNombre.SuspendLayout();
            this.panelApellido1.SuspendLayout();
            this.panelApellido2.SuspendLayout();
            this.panelTelefono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxBuscarUsuario
            // 
            this.textBoxBuscarUsuario.BackColor = System.Drawing.Color.Black;
            this.textBoxBuscarUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBuscarUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxBuscarUsuario.ForeColor = System.Drawing.Color.White;
            this.textBoxBuscarUsuario.Location = new System.Drawing.Point(60, 40);
            this.textBoxBuscarUsuario.Multiline = true;
            this.textBoxBuscarUsuario.Name = "textBoxBuscarUsuario";
            this.textBoxBuscarUsuario.Size = new System.Drawing.Size(860, 40);
            this.textBoxBuscarUsuario.TabIndex = 0;
            this.textBoxBuscarUsuario.Text = "Buscar usuario...";
            this.textBoxBuscarUsuario.TextChanged += new System.EventHandler(this.textBoxBuscarUsuario_TextChanged);
            // 
            // panelButtonAnadir
            // 
            this.panelButtonAnadir.BackColor = System.Drawing.Color.DarkCyan;
            this.panelButtonAnadir.Controls.Add(this.labelAnadir);
            this.panelButtonAnadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonAnadir.Location = new System.Drawing.Point(60, 320);
            this.panelButtonAnadir.Name = "panelButtonAnadir";
            this.panelButtonAnadir.Size = new System.Drawing.Size(420, 50);
            this.panelButtonAnadir.TabIndex = 5;
            // 
            // labelAnadir
            // 
            this.labelAnadir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAnadir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelAnadir.ForeColor = System.Drawing.Color.White;
            this.labelAnadir.Location = new System.Drawing.Point(0, 0);
            this.labelAnadir.Name = "labelAnadir";
            this.labelAnadir.Size = new System.Drawing.Size(420, 50);
            this.labelAnadir.TabIndex = 0;
            this.labelAnadir.Text = "Guardar";
            this.labelAnadir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAnadir.Click += new System.EventHandler(this.labelAnadir_Click);
            // 
            // panelButtonEditar
            // 
            this.panelButtonEditar.BackColor = System.Drawing.Color.Black;
            this.panelButtonEditar.Controls.Add(this.labelEditar);
            this.panelButtonEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonEditar.Location = new System.Drawing.Point(500, 320);
            this.panelButtonEditar.Name = "panelButtonEditar";
            this.panelButtonEditar.Size = new System.Drawing.Size(420, 50);
            this.panelButtonEditar.TabIndex = 6;
            // 
            // labelEditar
            // 
            this.labelEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEditar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEditar.ForeColor = System.Drawing.Color.White;
            this.labelEditar.Location = new System.Drawing.Point(0, 0);
            this.labelEditar.Name = "labelEditar";
            this.labelEditar.Size = new System.Drawing.Size(420, 50);
            this.labelEditar.TabIndex = 0;
            this.labelEditar.Text = "Nuevo";
            this.labelEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelNombre
            // 
            this.panelNombre.BackColor = System.Drawing.Color.White;
            this.panelNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNombre.Controls.Add(this.textBoxNombre);
            this.panelNombre.Controls.Add(this.labelPanelNombre);
            this.panelNombre.Location = new System.Drawing.Point(60, 110);
            this.panelNombre.Name = "panelNombre";
            this.panelNombre.Size = new System.Drawing.Size(420, 70);
            this.panelNombre.TabIndex = 1;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxNombre.Location = new System.Drawing.Point(10, 35);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(400, 20);
            this.textBoxNombre.TabIndex = 1;
            // 
            // labelPanelNombre
            // 
            this.labelPanelNombre.AutoSize = true;
            this.labelPanelNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelNombre.ForeColor = System.Drawing.Color.Black;
            this.labelPanelNombre.Location = new System.Drawing.Point(10, 10);
            this.labelPanelNombre.Name = "labelPanelNombre";
            this.labelPanelNombre.Size = new System.Drawing.Size(58, 15);
            this.labelPanelNombre.TabIndex = 0;
            this.labelPanelNombre.Text = "NOMBRE";
            // 
            // panelApellido1
            // 
            this.panelApellido1.BackColor = System.Drawing.Color.White;
            this.panelApellido1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelApellido1.Controls.Add(this.textBoxApellido1);
            this.panelApellido1.Controls.Add(this.labelPanelApellido1);
            this.panelApellido1.Location = new System.Drawing.Point(500, 110);
            this.panelApellido1.Name = "panelApellido1";
            this.panelApellido1.Size = new System.Drawing.Size(420, 70);
            this.panelApellido1.TabIndex = 2;
            // 
            // textBoxApellido1
            // 
            this.textBoxApellido1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxApellido1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxApellido1.Location = new System.Drawing.Point(10, 35);
            this.textBoxApellido1.Name = "textBoxApellido1";
            this.textBoxApellido1.Size = new System.Drawing.Size(400, 20);
            this.textBoxApellido1.TabIndex = 1;
            // 
            // labelPanelApellido1
            // 
            this.labelPanelApellido1.AutoSize = true;
            this.labelPanelApellido1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelApellido1.ForeColor = System.Drawing.Color.Black;
            this.labelPanelApellido1.Location = new System.Drawing.Point(10, 10);
            this.labelPanelApellido1.Name = "labelPanelApellido1";
            this.labelPanelApellido1.Size = new System.Drawing.Size(109, 15);
            this.labelPanelApellido1.TabIndex = 0;
            this.labelPanelApellido1.Text = "PRIMER APELLIDO";
            // 
            // panelApellido2
            // 
            this.panelApellido2.BackColor = System.Drawing.Color.White;
            this.panelApellido2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelApellido2.Controls.Add(this.textBoxApellido2);
            this.panelApellido2.Controls.Add(this.labelPanelApellido2);
            this.panelApellido2.Location = new System.Drawing.Point(60, 195);
            this.panelApellido2.Name = "panelApellido2";
            this.panelApellido2.Size = new System.Drawing.Size(640, 70);
            this.panelApellido2.TabIndex = 3;
            // 
            // textBoxApellido2
            // 
            this.textBoxApellido2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxApellido2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxApellido2.Location = new System.Drawing.Point(10, 35);
            this.textBoxApellido2.Name = "textBoxApellido2";
            this.textBoxApellido2.Size = new System.Drawing.Size(620, 20);
            this.textBoxApellido2.TabIndex = 1;
            // 
            // labelPanelApellido2
            // 
            this.labelPanelApellido2.AutoSize = true;
            this.labelPanelApellido2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelApellido2.ForeColor = System.Drawing.Color.Black;
            this.labelPanelApellido2.Location = new System.Drawing.Point(10, 10);
            this.labelPanelApellido2.Name = "labelPanelApellido2";
            this.labelPanelApellido2.Size = new System.Drawing.Size(182, 15);
            this.labelPanelApellido2.TabIndex = 0;
            this.labelPanelApellido2.Text = "SEGUNDO APELLIDO (Opcional)";
            // 
            // panelTelefono
            // 
            this.panelTelefono.BackColor = System.Drawing.Color.White;
            this.panelTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTelefono.Controls.Add(this.textBoxTelefono);
            this.panelTelefono.Controls.Add(this.labelPanelTelefono);
            this.panelTelefono.Location = new System.Drawing.Point(720, 195);
            this.panelTelefono.Name = "panelTelefono";
            this.panelTelefono.Size = new System.Drawing.Size(200, 70);
            this.panelTelefono.TabIndex = 4;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTelefono.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxTelefono.Location = new System.Drawing.Point(10, 35);
            this.textBoxTelefono.MaxLength = 9;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(180, 20);
            this.textBoxTelefono.TabIndex = 1;
            // 
            // labelPanelTelefono
            // 
            this.labelPanelTelefono.AutoSize = true;
            this.labelPanelTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelTelefono.ForeColor = System.Drawing.Color.Black;
            this.labelPanelTelefono.Location = new System.Drawing.Point(10, 10);
            this.labelPanelTelefono.Name = "labelPanelTelefono";
            this.labelPanelTelefono.Size = new System.Drawing.Size(65, 15);
            this.labelPanelTelefono.TabIndex = 0;
            this.labelPanelTelefono.Text = "TELÉFONO";
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(60, 390);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(860, 280);
            this.dataGridViewUsuarios.TabIndex = 7;
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 700);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.panelTelefono);
            this.Controls.Add(this.panelApellido2);
            this.Controls.Add(this.panelApellido1);
            this.Controls.Add(this.panelNombre);
            this.Controls.Add(this.panelButtonEditar);
            this.Controls.Add(this.panelButtonAnadir);
            this.Controls.Add(this.textBoxBuscarUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUsuarios";
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.panelButtonAnadir.ResumeLayout(false);
            this.panelButtonEditar.ResumeLayout(false);
            this.panelNombre.ResumeLayout(false);
            this.panelNombre.PerformLayout();
            this.panelApellido1.ResumeLayout(false);
            this.panelApellido1.PerformLayout();
            this.panelApellido2.ResumeLayout(false);
            this.panelApellido2.PerformLayout();
            this.panelTelefono.ResumeLayout(false);
            this.panelTelefono.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBuscarUsuario;
        private System.Windows.Forms.Panel panelButtonAnadir;
        private System.Windows.Forms.Label labelAnadir;
        private System.Windows.Forms.Panel panelButtonEditar;
        private System.Windows.Forms.Label labelEditar;
        private System.Windows.Forms.Panel panelNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelPanelNombre;
        private System.Windows.Forms.Panel panelApellido1;
        private System.Windows.Forms.TextBox textBoxApellido1;
        private System.Windows.Forms.Label labelPanelApellido1;
        private System.Windows.Forms.Panel panelApellido2;
        private System.Windows.Forms.TextBox textBoxApellido2;
        private System.Windows.Forms.Label labelPanelApellido2;
        private System.Windows.Forms.Panel panelTelefono;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label labelPanelTelefono;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
    }
}

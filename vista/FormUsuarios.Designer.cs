namespace BibliotecaVitoriaGasteiz.vista
{
    partial class FormUsuarios
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
            this.textBoxBuscarUsuario = new System.Windows.Forms.TextBox();
            this.panelSearchButton = new System.Windows.Forms.Panel();
            this.labelSearchButton = new System.Windows.Forms.Label();
            this.panelButtonAnadir = new System.Windows.Forms.Panel();
            this.labelAnadir = new System.Windows.Forms.Label();
            this.panelButtonEditar = new System.Windows.Forms.Panel();
            this.labelEditar = new System.Windows.Forms.Label();
            this.panelButtonEliminar = new System.Windows.Forms.Panel();
            this.labelEliminar = new System.Windows.Forms.Label();
            this.panelNombre = new System.Windows.Forms.Panel();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelPanelNombre = new System.Windows.Forms.Label();
            this.panelApellidos = new System.Windows.Forms.Panel();
            this.textBoxApellidos = new System.Windows.Forms.TextBox();
            this.labelPanelApellidos = new System.Windows.Forms.Label();
            this.panelCorreo = new System.Windows.Forms.Panel();
            this.textBoxCorreo = new System.Windows.Forms.TextBox();
            this.labelPanelCorreo = new System.Windows.Forms.Label();
            this.panelGuardarUsuario = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelYaTienesCuenta = new System.Windows.Forms.Label();
            this.labelIniciarSesion = new System.Windows.Forms.Label();
            this.panelSearchButton.SuspendLayout();
            this.panelButtonAnadir.SuspendLayout();
            this.panelButtonEditar.SuspendLayout();
            this.panelButtonEliminar.SuspendLayout();
            this.panelNombre.SuspendLayout();
            this.panelApellidos.SuspendLayout();
            this.panelCorreo.SuspendLayout();
            this.panelGuardarUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxBuscarUsuario
            // 
            this.textBoxBuscarUsuario.BackColor = System.Drawing.Color.Black;
            this.textBoxBuscarUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBuscarUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscarUsuario.ForeColor = System.Drawing.Color.White;
            this.textBoxBuscarUsuario.Location = new System.Drawing.Point(60, 40);
            this.textBoxBuscarUsuario.Multiline = true;
            this.textBoxBuscarUsuario.Name = "textBoxBuscarUsuario";
            this.textBoxBuscarUsuario.Size = new System.Drawing.Size(430, 40);
            this.textBoxBuscarUsuario.TabIndex = 0;
            this.textBoxBuscarUsuario.Text = "Buscar usuario...";
            this.textBoxBuscarUsuario.TextChanged += new System.EventHandler(this.textBoxBuscarUsuario_TextChanged);
            // 
            // panelSearchButton
            // 
            this.panelSearchButton.BackColor = System.Drawing.Color.Black;
            this.panelSearchButton.Controls.Add(this.labelSearchButton);
            this.panelSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelSearchButton.Location = new System.Drawing.Point(540, 38);
            this.panelSearchButton.Name = "panelSearchButton";
            this.panelSearchButton.Size = new System.Drawing.Size(380, 44);
            this.panelSearchButton.TabIndex = 1;
            // 
            // labelSearchButton
            // 
            this.labelSearchButton.AutoSize = true;
            this.labelSearchButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchButton.ForeColor = System.Drawing.Color.White;
            this.labelSearchButton.Location = new System.Drawing.Point(150, 10);
            this.labelSearchButton.Name = "labelSearchButton";
            this.labelSearchButton.Size = new System.Drawing.Size(51, 20);
            this.labelSearchButton.TabIndex = 0;
            this.labelSearchButton.Text = "search";
            this.labelSearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtonAnadir
            // 
            this.panelButtonAnadir.BackColor = System.Drawing.Color.DarkCyan;
            this.panelButtonAnadir.Controls.Add(this.labelAnadir);
            this.panelButtonAnadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonAnadir.Location = new System.Drawing.Point(60, 100);
            this.panelButtonAnadir.Name = "panelButtonAnadir";
            this.panelButtonAnadir.Size = new System.Drawing.Size(270, 40);
            this.panelButtonAnadir.TabIndex = 2;
            // 
            // labelAnadir
            // 
            this.labelAnadir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAnadir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnadir.ForeColor = System.Drawing.Color.White;
            this.labelAnadir.Location = new System.Drawing.Point(0, 0);
            this.labelAnadir.Name = "labelAnadir";
            this.labelAnadir.Size = new System.Drawing.Size(270, 40);
            this.labelAnadir.TabIndex = 0;
            this.labelAnadir.Text = "Añadir";
            this.labelAnadir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAnadir.Click += new System.EventHandler(this.labelAnadir_Click);
            // 
            // panelButtonEditar
            // 
            this.panelButtonEditar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelButtonEditar.Controls.Add(this.labelEditar);
            this.panelButtonEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonEditar.Location = new System.Drawing.Point(345, 100);
            this.panelButtonEditar.Name = "panelButtonEditar";
            this.panelButtonEditar.Size = new System.Drawing.Size(270, 40);
            this.panelButtonEditar.TabIndex = 3;
            // 
            // labelEditar
            // 
            this.labelEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEditar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditar.ForeColor = System.Drawing.Color.White;
            this.labelEditar.Location = new System.Drawing.Point(0, 0);
            this.labelEditar.Name = "labelEditar";
            this.labelEditar.Size = new System.Drawing.Size(270, 40);
            this.labelEditar.TabIndex = 0;
            this.labelEditar.Text = "Editar";
            this.labelEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtonEliminar
            // 
            this.panelButtonEliminar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelButtonEliminar.Controls.Add(this.labelEliminar);
            this.panelButtonEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonEliminar.Location = new System.Drawing.Point(630, 100);
            this.panelButtonEliminar.Name = "panelButtonEliminar";
            this.panelButtonEliminar.Size = new System.Drawing.Size(270, 40);
            this.panelButtonEliminar.TabIndex = 4;
            // 
            // labelEliminar
            // 
            this.labelEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEliminar.ForeColor = System.Drawing.Color.White;
            this.labelEliminar.Location = new System.Drawing.Point(0, 0);
            this.labelEliminar.Name = "labelEliminar";
            this.labelEliminar.Size = new System.Drawing.Size(270, 40);
            this.labelEliminar.TabIndex = 0;
            this.labelEliminar.Text = "Eliminar";
            this.labelEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelNombre
            // 
            this.panelNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNombre.Controls.Add(this.textBoxNombre);
            this.panelNombre.Controls.Add(this.labelPanelNombre);
            this.panelNombre.Location = new System.Drawing.Point(60, 160);
            this.panelNombre.Name = "panelNombre";
            this.panelNombre.Size = new System.Drawing.Size(420, 80);
            this.panelNombre.TabIndex = 5;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNombre.ForeColor = System.Drawing.Color.White;
            this.textBoxNombre.Location = new System.Drawing.Point(15, 38);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(390, 13);
            this.textBoxNombre.TabIndex = 1;
            this.textBoxNombre.Text = "David";
            // 
            // labelPanelNombre
            // 
            this.labelPanelNombre.AutoSize = true;
            this.labelPanelNombre.BackColor = System.Drawing.Color.Transparent;
            this.labelPanelNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelNombre.ForeColor = System.Drawing.Color.White;
            this.labelPanelNombre.Location = new System.Drawing.Point(15, 10);
            this.labelPanelNombre.Name = "labelPanelNombre";
            this.labelPanelNombre.Size = new System.Drawing.Size(58, 15);
            this.labelPanelNombre.TabIndex = 0;
            this.labelPanelNombre.Text = "NOMBRE";
            // 
            // panelApellidos
            // 
            this.panelApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelApellidos.Controls.Add(this.textBoxApellidos);
            this.panelApellidos.Controls.Add(this.labelPanelApellidos);
            this.panelApellidos.ForeColor = System.Drawing.Color.White;
            this.panelApellidos.Location = new System.Drawing.Point(500, 160);
            this.panelApellidos.Name = "panelApellidos";
            this.panelApellidos.Size = new System.Drawing.Size(400, 80);
            this.panelApellidos.TabIndex = 6;
            // 
            // textBoxApellidos
            // 
            this.textBoxApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.textBoxApellidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxApellidos.ForeColor = System.Drawing.Color.White;
            this.textBoxApellidos.Location = new System.Drawing.Point(15, 38);
            this.textBoxApellidos.Name = "textBoxApellidos";
            this.textBoxApellidos.Size = new System.Drawing.Size(390, 13);
            this.textBoxApellidos.TabIndex = 1;
            this.textBoxApellidos.Text = "Merchan Rivero";
            // 
            // labelPanelApellidos
            // 
            this.labelPanelApellidos.AutoSize = true;
            this.labelPanelApellidos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelApellidos.Location = new System.Drawing.Point(17, 11);
            this.labelPanelApellidos.Name = "labelPanelApellidos";
            this.labelPanelApellidos.Size = new System.Drawing.Size(69, 15);
            this.labelPanelApellidos.TabIndex = 0;
            this.labelPanelApellidos.Text = "APELLIDOS";
            this.labelPanelApellidos.Click += new System.EventHandler(this.labelPanelApellidos_Click);
            // 
            // panelCorreo
            // 
            this.panelCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelCorreo.Controls.Add(this.textBoxCorreo);
            this.panelCorreo.Controls.Add(this.labelPanelCorreo);
            this.panelCorreo.Location = new System.Drawing.Point(60, 255);
            this.panelCorreo.Name = "panelCorreo";
            this.panelCorreo.Size = new System.Drawing.Size(840, 80);
            this.panelCorreo.TabIndex = 7;
            // 
            // textBoxCorreo
            // 
            this.textBoxCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.textBoxCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCorreo.ForeColor = System.Drawing.Color.White;
            this.textBoxCorreo.Location = new System.Drawing.Point(15, 38);
            this.textBoxCorreo.Name = "textBoxCorreo";
            this.textBoxCorreo.Size = new System.Drawing.Size(390, 13);
            this.textBoxCorreo.TabIndex = 1;
            this.textBoxCorreo.Text = "david.merchan.50786@ikasle.egibide.org";
            // 
            // labelPanelCorreo
            // 
            this.labelPanelCorreo.AutoSize = true;
            this.labelPanelCorreo.BackColor = System.Drawing.Color.Transparent;
            this.labelPanelCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPanelCorreo.ForeColor = System.Drawing.Color.White;
            this.labelPanelCorreo.Location = new System.Drawing.Point(15, 10);
            this.labelPanelCorreo.Name = "labelPanelCorreo";
            this.labelPanelCorreo.Size = new System.Drawing.Size(135, 15);
            this.labelPanelCorreo.TabIndex = 0;
            this.labelPanelCorreo.Text = "CORREO ELECTRONICO";
            // 
            // panelGuardarUsuario
            // 
            this.panelGuardarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelGuardarUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGuardarUsuario.Controls.Add(this.label1);
            this.panelGuardarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelGuardarUsuario.Location = new System.Drawing.Point(60, 355);
            this.panelGuardarUsuario.Name = "panelGuardarUsuario";
            this.panelGuardarUsuario.Size = new System.Drawing.Size(840, 50);
            this.panelGuardarUsuario.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(838, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Guardar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelYaTienesCuenta
            // 
            this.labelYaTienesCuenta.AutoSize = true;
            this.labelYaTienesCuenta.ForeColor = System.Drawing.Color.Black;
            this.labelYaTienesCuenta.Location = new System.Drawing.Point(360, 420);
            this.labelYaTienesCuenta.Name = "labelYaTienesCuenta";
            this.labelYaTienesCuenta.Size = new System.Drawing.Size(120, 13);
            this.labelYaTienesCuenta.TabIndex = 9;
            this.labelYaTienesCuenta.Text = "¿Ya tienes una cuenta?";
            // 
            // labelIniciarSesion
            // 
            this.labelIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.labelIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelIniciarSesion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.labelIniciarSesion.Location = new System.Drawing.Point(60, 445);
            this.labelIniciarSesion.Name = "labelIniciarSesion";
            this.labelIniciarSesion.Size = new System.Drawing.Size(840, 30);
            this.labelIniciarSesion.TabIndex = 10;
            this.labelIniciarSesion.Text = "Iniciar sesión";
            this.labelIniciarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.labelIniciarSesion);
            this.Controls.Add(this.labelYaTienesCuenta);
            this.Controls.Add(this.panelGuardarUsuario);
            this.Controls.Add(this.panelCorreo);
            this.Controls.Add(this.panelApellidos);
            this.Controls.Add(this.panelNombre);
            this.Controls.Add(this.panelButtonEliminar);
            this.Controls.Add(this.panelButtonEditar);
            this.Controls.Add(this.panelButtonAnadir);
            this.Controls.Add(this.panelSearchButton);
            this.Controls.Add(this.textBoxBuscarUsuario);
            this.Name = "FormUsuarios";
            this.Text = "FormUsuarios";
            this.panelSearchButton.ResumeLayout(false);
            this.panelSearchButton.PerformLayout();
            this.panelButtonAnadir.ResumeLayout(false);
            this.panelButtonEditar.ResumeLayout(false);
            this.panelButtonEliminar.ResumeLayout(false);
            this.panelNombre.ResumeLayout(false);
            this.panelNombre.PerformLayout();
            this.panelApellidos.ResumeLayout(false);
            this.panelApellidos.PerformLayout();
            this.panelCorreo.ResumeLayout(false);
            this.panelCorreo.PerformLayout();
            this.panelGuardarUsuario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBuscarUsuario;
        private System.Windows.Forms.Panel panelSearchButton;
        private System.Windows.Forms.Label labelSearchButton;
        private System.Windows.Forms.Panel panelButtonAnadir;
        private System.Windows.Forms.Label labelAnadir;
        private System.Windows.Forms.Panel panelButtonEditar;
        private System.Windows.Forms.Label labelEditar;
        private System.Windows.Forms.Panel panelButtonEliminar;
        private System.Windows.Forms.Label labelEliminar;
        private System.Windows.Forms.Panel panelNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelPanelNombre;
        private System.Windows.Forms.Panel panelApellidos;
        private System.Windows.Forms.Label labelPanelApellidos;
        private System.Windows.Forms.TextBox textBoxApellidos;
        private System.Windows.Forms.Panel panelCorreo;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.Label labelPanelCorreo;
        private System.Windows.Forms.Panel panelGuardarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelYaTienesCuenta;
        private System.Windows.Forms.Label labelIniciarSesion;
    }
}
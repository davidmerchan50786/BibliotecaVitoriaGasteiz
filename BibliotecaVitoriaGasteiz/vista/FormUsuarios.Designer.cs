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
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.panelBuscarBorder = new System.Windows.Forms.Panel();
            this.textBoxBuscarUsuario = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelFila1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelNombre = new System.Windows.Forms.Panel();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelPanelNombre = new System.Windows.Forms.Label();
            this.panelApellido1 = new System.Windows.Forms.Panel();
            this.textBoxApellido1 = new System.Windows.Forms.TextBox();
            this.labelPanelApellido1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelFila2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelApellido2 = new System.Windows.Forms.Panel();
            this.textBoxApellido2 = new System.Windows.Forms.TextBox();
            this.labelPanelApellido2 = new System.Windows.Forms.Label();
            this.panelTelefono = new System.Windows.Forms.Panel();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.labelPanelTelefono = new System.Windows.Forms.Label();
            this.tableLayoutPanelBotones = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtonAnadir = new System.Windows.Forms.Panel();
            this.labelAnadir = new System.Windows.Forms.Label();
            this.panelButtonEditar = new System.Windows.Forms.Panel();
            this.labelEditar = new System.Windows.Forms.Label();
            this.labelListaUsuarios = new System.Windows.Forms.Label();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.panelBuscarBorder.SuspendLayout();
            this.tableLayoutPanelFila1.SuspendLayout();
            this.panelNombre.SuspendLayout();
            this.panelApellido1.SuspendLayout();
            this.tableLayoutPanelFila2.SuspendLayout();
            this.panelApellido2.SuspendLayout();
            this.panelTelefono.SuspendLayout();
            this.tableLayoutPanelBotones.SuspendLayout();
            this.panelButtonAnadir.SuspendLayout();
            this.panelButtonEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();

            this.tableLayoutPanelPrincipal.ColumnCount = 3;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelBuscarBorder, 1, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelFila1, 1, 1);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelFila2, 1, 2);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelBotones, 1, 3);
            this.tableLayoutPanelPrincipal.Controls.Add(this.labelListaUsuarios, 1, 4);
            this.tableLayoutPanelPrincipal.Controls.Add(this.dataGridViewUsuarios, 1, 5);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.tableLayoutPanelPrincipal.RowCount = 6;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // Fila 0: Buscador
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F)); // Fila 1: Nombre/Apellido1
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F)); // Fila 2: Apellido2/Telefono
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Fila 3: Botones (AUMENTADO A 80)
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Fila 4: Label Lista
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // Fila 5: Grid (Resto)
            this.tableLayoutPanelPrincipal.TabIndex = 0;

            this.panelBuscarBorder.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBuscarBorder.Controls.Add(this.textBoxBuscarUsuario);
            this.panelBuscarBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBuscarBorder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.panelBuscarBorder.Name = "panelBuscarBorder";
            this.panelBuscarBorder.Padding = new System.Windows.Forms.Padding(0);
            this.panelBuscarBorder.TabIndex = 0;

            this.textBoxBuscarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBuscarUsuario.BackColor = System.Drawing.Color.Black;
            this.textBoxBuscarUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBuscarUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxBuscarUsuario.ForeColor = System.Drawing.Color.White;
            this.textBoxBuscarUsuario.Location = new System.Drawing.Point(10, 16); // Centrado manual
            this.textBoxBuscarUsuario.Name = "textBoxBuscarUsuario";
            this.textBoxBuscarUsuario.Size = new System.Drawing.Size(766, 22);
            this.textBoxBuscarUsuario.TabIndex = 0;
            this.textBoxBuscarUsuario.Text = "Buscar usuario...";
            this.textBoxBuscarUsuario.TextChanged += new System.EventHandler(this.textBoxBuscarUsuario_TextChanged);

            this.tableLayoutPanelFila1.ColumnCount = 2;
            this.tableLayoutPanelFila1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFila1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFila1.Controls.Add(this.panelNombre, 0, 0);
            this.tableLayoutPanelFila1.Controls.Add(this.panelApellido1, 1, 0);
            this.tableLayoutPanelFila1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFila1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelFila1.Name = "tableLayoutPanelFila1";
            this.tableLayoutPanelFila1.RowCount = 1;
            this.tableLayoutPanelFila1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFila1.TabIndex = 1;

            this.panelNombre.BackColor = System.Drawing.Color.White;
            this.panelNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNombre.Controls.Add(this.textBoxNombre);
            this.panelNombre.Controls.Add(this.labelPanelNombre);
            this.panelNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNombre.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelNombre.Padding = new System.Windows.Forms.Padding(10);
            this.panelNombre.Name = "panelNombre";
            this.panelNombre.TabIndex = 0;

            this.textBoxNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxNombre.Location = new System.Drawing.Point(10, 35);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(360, 20);
            this.textBoxNombre.TabIndex = 1;

            this.labelPanelNombre.AutoSize = true;
            this.labelPanelNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelNombre.ForeColor = System.Drawing.Color.Black;
            this.labelPanelNombre.Location = new System.Drawing.Point(10, 10);
            this.labelPanelNombre.Name = "labelPanelNombre";
            this.labelPanelNombre.Size = new System.Drawing.Size(58, 15);
            this.labelPanelNombre.TabIndex = 0;
            this.labelPanelNombre.Text = "NOMBRE";

            this.panelApellido1.BackColor = System.Drawing.Color.White;
            this.panelApellido1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelApellido1.Controls.Add(this.textBoxApellido1);
            this.panelApellido1.Controls.Add(this.labelPanelApellido1);
            this.panelApellido1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApellido1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelApellido1.Padding = new System.Windows.Forms.Padding(10);
            this.panelApellido1.Name = "panelApellido1";
            this.panelApellido1.TabIndex = 1;

            this.textBoxApellido1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApellido1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxApellido1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxApellido1.Location = new System.Drawing.Point(10, 35);
            this.textBoxApellido1.Name = "textBoxApellido1";
            this.textBoxApellido1.Size = new System.Drawing.Size(360, 20);
            this.textBoxApellido1.TabIndex = 1;

            this.labelPanelApellido1.AutoSize = true;
            this.labelPanelApellido1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelApellido1.ForeColor = System.Drawing.Color.Black;
            this.labelPanelApellido1.Location = new System.Drawing.Point(10, 10);
            this.labelPanelApellido1.Name = "labelPanelApellido1";
            this.labelPanelApellido1.Size = new System.Drawing.Size(109, 15);
            this.labelPanelApellido1.TabIndex = 0;
            this.labelPanelApellido1.Text = "PRIMER APELLIDO";

            this.tableLayoutPanelFila2.ColumnCount = 2;
            this.tableLayoutPanelFila2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelFila2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelFila2.Controls.Add(this.panelApellido2, 0, 0);
            this.tableLayoutPanelFila2.Controls.Add(this.panelTelefono, 1, 0);
            this.tableLayoutPanelFila2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFila2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelFila2.Name = "tableLayoutPanelFila2";
            this.tableLayoutPanelFila2.RowCount = 1;
            this.tableLayoutPanelFila2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFila2.TabIndex = 2;

            this.panelApellido2.BackColor = System.Drawing.Color.White;
            this.panelApellido2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelApellido2.Controls.Add(this.textBoxApellido2);
            this.panelApellido2.Controls.Add(this.labelPanelApellido2);
            this.panelApellido2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApellido2.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelApellido2.Padding = new System.Windows.Forms.Padding(10);
            this.panelApellido2.Name = "panelApellido2";
            this.panelApellido2.TabIndex = 0;

            this.textBoxApellido2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxApellido2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxApellido2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxApellido2.Location = new System.Drawing.Point(10, 35);
            this.textBoxApellido2.Name = "textBoxApellido2";
            this.textBoxApellido2.Size = new System.Drawing.Size(510, 20);
            this.textBoxApellido2.TabIndex = 1;

            this.labelPanelApellido2.AutoSize = true;
            this.labelPanelApellido2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelApellido2.ForeColor = System.Drawing.Color.Black;
            this.labelPanelApellido2.Location = new System.Drawing.Point(10, 10);
            this.labelPanelApellido2.Name = "labelPanelApellido2";
            this.labelPanelApellido2.Size = new System.Drawing.Size(182, 15);
            this.labelPanelApellido2.TabIndex = 0;
            this.labelPanelApellido2.Text = "SEGUNDO APELLIDO (Opcional)";

            this.panelTelefono.BackColor = System.Drawing.Color.White;
            this.panelTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTelefono.Controls.Add(this.textBoxTelefono);
            this.panelTelefono.Controls.Add(this.labelPanelTelefono);
            this.panelTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTelefono.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelTelefono.Padding = new System.Windows.Forms.Padding(10);
            this.panelTelefono.Name = "panelTelefono";
            this.panelTelefono.TabIndex = 1;

            this.textBoxTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTelefono.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxTelefono.Location = new System.Drawing.Point(10, 35);
            this.textBoxTelefono.MaxLength = 9;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(200, 20);
            this.textBoxTelefono.TabIndex = 1;

            this.labelPanelTelefono.AutoSize = true;
            this.labelPanelTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPanelTelefono.ForeColor = System.Drawing.Color.Black;
            this.labelPanelTelefono.Location = new System.Drawing.Point(10, 10);
            this.labelPanelTelefono.Name = "labelPanelTelefono";
            this.labelPanelTelefono.Size = new System.Drawing.Size(65, 15);
            this.labelPanelTelefono.TabIndex = 0;
            this.labelPanelTelefono.Text = "TELÉFONO";

            this.tableLayoutPanelBotones.ColumnCount = 2;
            this.tableLayoutPanelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotones.Controls.Add(this.panelButtonAnadir, 0, 0);
            this.tableLayoutPanelBotones.Controls.Add(this.panelButtonEditar, 1, 0);
            this.tableLayoutPanelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBotones.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.tableLayoutPanelBotones.Name = "tableLayoutPanelBotones";
            this.tableLayoutPanelBotones.RowCount = 1;
            this.tableLayoutPanelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotones.TabIndex = 3;

            this.panelButtonAnadir.BackColor = System.Drawing.Color.DarkCyan;
            this.panelButtonAnadir.Controls.Add(this.labelAnadir);
            this.panelButtonAnadir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonAnadir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonAnadir.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelButtonAnadir.Name = "panelButtonAnadir";
            this.panelButtonAnadir.TabIndex = 0;

            this.labelAnadir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAnadir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelAnadir.ForeColor = System.Drawing.Color.White;
            this.labelAnadir.Location = new System.Drawing.Point(0, 0);
            this.labelAnadir.Name = "labelAnadir";
            this.labelAnadir.Size = new System.Drawing.Size(100, 23);
            this.labelAnadir.TabIndex = 0;
            this.labelAnadir.Text = "Guardar";
            this.labelAnadir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAnadir.Click += new System.EventHandler(this.labelAnadir_Click);

            this.panelButtonEditar.BackColor = System.Drawing.Color.Black;
            this.panelButtonEditar.Controls.Add(this.labelEditar);
            this.panelButtonEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonEditar.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelButtonEditar.Name = "panelButtonEditar";
            this.panelButtonEditar.TabIndex = 1;
 
            this.labelEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEditar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEditar.ForeColor = System.Drawing.Color.White;
            this.labelEditar.Location = new System.Drawing.Point(0, 0);
            this.labelEditar.Name = "labelEditar";
            this.labelEditar.Size = new System.Drawing.Size(100, 23);
            this.labelEditar.TabIndex = 0;
            this.labelEditar.Text = "Nuevo";
            this.labelEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelListaUsuarios.AutoSize = true;
            this.labelListaUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelListaUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelListaUsuarios.ForeColor = System.Drawing.Color.Black;
            this.labelListaUsuarios.Location = new System.Drawing.Point(3, 390);
            this.labelListaUsuarios.Name = "labelListaUsuarios";
            this.labelListaUsuarios.Size = new System.Drawing.Size(780, 50);
            this.labelListaUsuarios.TabIndex = 4;
            this.labelListaUsuarios.Text = "Lista de Usuarios";
            this.labelListaUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(3, 443);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(780, 234);
            this.dataGridViewUsuarios.TabIndex = 5;
 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 700);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUsuarios";
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.tableLayoutPanelPrincipal.PerformLayout();
            this.panelBuscarBorder.ResumeLayout(false);
            this.panelBuscarBorder.PerformLayout();
            this.tableLayoutPanelFila1.ResumeLayout(false);
            this.panelNombre.ResumeLayout(false);
            this.panelNombre.PerformLayout();
            this.panelApellido1.ResumeLayout(false);
            this.panelApellido1.PerformLayout();
            this.tableLayoutPanelFila2.ResumeLayout(false);
            this.panelApellido2.ResumeLayout(false);
            this.panelApellido2.PerformLayout();
            this.panelTelefono.ResumeLayout(false);
            this.panelTelefono.PerformLayout();
            this.tableLayoutPanelBotones.ResumeLayout(false);
            this.panelButtonAnadir.ResumeLayout(false);
            this.panelButtonEditar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFila1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFila2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBotones;
        private System.Windows.Forms.Panel panelBuscarBorder;
        private System.Windows.Forms.TextBox textBoxBuscarUsuario;
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
        private System.Windows.Forms.Panel panelButtonAnadir;
        private System.Windows.Forms.Label labelAnadir;
        private System.Windows.Forms.Panel panelButtonEditar;
        private System.Windows.Forms.Label labelEditar;
        private System.Windows.Forms.Label labelListaUsuarios;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
    }
}
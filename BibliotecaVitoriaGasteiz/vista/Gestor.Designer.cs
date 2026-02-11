namespace BibliotecaVitoriaGasteiz
{
    partial class Gestor
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.panelLogoNombre = new System.Windows.Forms.Panel();
            this.labelAyuntamiento = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.labelUsuarios = new System.Windows.Forms.Label();
            this.labelLibros = new System.Windows.Forms.Label();
            this.labelPrestamos = new System.Windows.Forms.Label();
            this.menuStripBarra = new System.Windows.Forms.MenuStrip();
            this.navegacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLineaSeparacion = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.panelLogoNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.flowLayoutPanelMenu.SuspendLayout();
            this.menuStripBarra.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.Black;
            this.panelHeader.Controls.Add(this.tableLayoutPanelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 29);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 80);
            this.panelHeader.TabIndex = 1;

            // tableLayoutPanelHeader (DIVISOR RESPONSIVO)
            this.tableLayoutPanelHeader.ColumnCount = 2;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHeader.Controls.Add(this.panelLogoNombre, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.flowLayoutPanelMenu, 1, 0);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 1;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.TabIndex = 0;

            // panelLogoNombre (Agrupador Izquierda)
            this.panelLogoNombre.Controls.Add(this.labelAyuntamiento);
            this.panelLogoNombre.Controls.Add(this.pictureBoxLogo);
            this.panelLogoNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogoNombre.Location = new System.Drawing.Point(3, 3);
            this.panelLogoNombre.Name = "panelLogoNombre";
            this.panelLogoNombre.Size = new System.Drawing.Size(486, 74);
            this.panelLogoNombre.TabIndex = 0;

            this.pictureBoxLogo.Image = global::BibliotecaVitoriaGasteiz.Properties.Resources.logo_biblio;
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;

            this.labelAyuntamiento.AutoSize = true;
            this.labelAyuntamiento.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelAyuntamiento.ForeColor = System.Drawing.Color.White;
            this.labelAyuntamiento.Location = new System.Drawing.Point(80, 27);
            this.labelAyuntamiento.Name = "labelAyuntamiento";
            this.labelAyuntamiento.Size = new System.Drawing.Size(218, 20);
            this.labelAyuntamiento.TabIndex = 1;
            this.labelAyuntamiento.Text = "Ayuntamiento Vitoria-Gasteiz";

            // flowLayoutPanelMenu (Agrupador Derecha - AUTOALINEADO)
            this.flowLayoutPanelMenu.Controls.Add(this.labelPrestamos);
            this.flowLayoutPanelMenu.Controls.Add(this.labelLibros);
            this.flowLayoutPanelMenu.Controls.Add(this.labelUsuarios);
            this.flowLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft; // De derecha a izquierda
            this.flowLayoutPanelMenu.Location = new System.Drawing.Point(495, 3);
            this.flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            this.flowLayoutPanelMenu.Padding = new System.Windows.Forms.Padding(0, 25, 20, 0);
            this.flowLayoutPanelMenu.Size = new System.Drawing.Size(486, 74);
            this.flowLayoutPanelMenu.TabIndex = 1;

            this.labelPrestamos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPrestamos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelPrestamos.ForeColor = System.Drawing.Color.White;
            this.labelPrestamos.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelPrestamos.Size = new System.Drawing.Size(100, 25);
            this.labelPrestamos.TabIndex = 4;
            this.labelPrestamos.Text = "Préstamos";
            this.labelPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelLibros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLibros.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelLibros.ForeColor = System.Drawing.Color.White;
            this.labelLibros.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelLibros.Size = new System.Drawing.Size(80, 25);
            this.labelLibros.TabIndex = 3;
            this.labelLibros.Text = "Libros";
            this.labelLibros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.labelUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelUsuarios.ForeColor = System.Drawing.Color.White;
            this.labelUsuarios.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelUsuarios.Size = new System.Drawing.Size(80, 25);
            this.labelUsuarios.TabIndex = 2;
            this.labelUsuarios.Text = "Usuarios";
            this.labelUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // menuStripBarra
            this.menuStripBarra.BackColor = System.Drawing.Color.Black;
            this.menuStripBarra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStripBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.navegacionToolStripMenuItem });
            this.menuStripBarra.Location = new System.Drawing.Point(0, 0);
            this.menuStripBarra.Name = "menuStripBarra";
            this.menuStripBarra.Size = new System.Drawing.Size(984, 27);
            this.menuStripBarra.TabIndex = 6;

            this.navegacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.librosToolStripMenuItem,
            this.prestamosToolStripMenuItem});
            this.navegacionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.navegacionToolStripMenuItem.Name = "navegacionToolStripMenuItem";
            this.navegacionToolStripMenuItem.Size = new System.Drawing.Size(92, 23);
            this.navegacionToolStripMenuItem.Text = "Navegacion";

            this.usuariosToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.usuariosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);

            this.librosToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.librosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.librosToolStripMenuItem.Text = "Libros";
            this.librosToolStripMenuItem.Click += new System.EventHandler(this.librosToolStripMenuItem_Click);

            this.prestamosToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.prestamosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.prestamosToolStripMenuItem.Name = "prestamosToolStripMenuItem";
            this.prestamosToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.prestamosToolStripMenuItem.Text = "Prestamos";
            this.prestamosToolStripMenuItem.Click += new System.EventHandler(this.prestamosToolStripMenuItem_Click);

            // panelLineaSeparacion
            this.panelLineaSeparacion.BackColor = System.Drawing.Color.White;
            this.panelLineaSeparacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLineaSeparacion.Location = new System.Drawing.Point(0, 27);
            this.panelLineaSeparacion.Name = "panelLineaSeparacion";
            this.panelLineaSeparacion.Size = new System.Drawing.Size(984, 2);
            this.panelLineaSeparacion.TabIndex = 8;

            // Gestor
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelLineaSeparacion);
            this.Controls.Add(this.menuStripBarra);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Gestor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca Vitoria-Gasteiz";
            this.panelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.panelLogoNombre.ResumeLayout(false);
            this.panelLogoNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.flowLayoutPanelMenu.ResumeLayout(false);
            this.menuStripBarra.ResumeLayout(false);
            this.menuStripBarra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        private System.Windows.Forms.Panel panelLogoNombre;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelAyuntamiento;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMenu;
        private System.Windows.Forms.Label labelUsuarios;
        private System.Windows.Forms.Label labelLibros;
        private System.Windows.Forms.Label labelPrestamos;
        private System.Windows.Forms.MenuStrip menuStripBarra;
        private System.Windows.Forms.ToolStripMenuItem navegacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamosToolStripMenuItem;
        private System.Windows.Forms.Panel panelLineaSeparacion;
    }
}
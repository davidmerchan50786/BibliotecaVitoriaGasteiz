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
            this.tableLayoutPanelLibroPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.panelBuscarBorder = new System.Windows.Forms.Panel();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelLibro = new System.Windows.Forms.TableLayoutPanel();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelEscritor = new System.Windows.Forms.Panel();
            this.textBoxEscritor = new System.Windows.Forms.TextBox();
            this.labelEscritor = new System.Windows.Forms.Label();
            this.tableLayoutPanelLibroAnyoSinopsis = new System.Windows.Forms.TableLayoutPanel();
            this.panelAnoEdicion = new System.Windows.Forms.Panel();
            this.textBoxAnoEdicion = new System.Windows.Forms.TextBox();
            this.labelAnoEdicion = new System.Windows.Forms.Label();
            this.panelSinopsis = new System.Windows.Forms.Panel();
            this.textBoxSinopsis = new System.Windows.Forms.TextBox();
            this.labelSinopsis = new System.Windows.Forms.Label();
            this.tableLayoutPanelBotones = new System.Windows.Forms.TableLayoutPanel();
            this.panelBotonGuardar = new System.Windows.Forms.Panel();
            this.labelGuardar = new System.Windows.Forms.Label();
            this.panelBotonNuevo = new System.Windows.Forms.Panel();
            this.labelNuevo = new System.Windows.Forms.Label();
            this.labelListaLibros = new System.Windows.Forms.Label();
            this.flowLayoutPanelLibros = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelLibroPrincipal.SuspendLayout();
            this.panelBuscarBorder.SuspendLayout();
            this.tableLayoutPanelLibro.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelEscritor.SuspendLayout();
            this.tableLayoutPanelLibroAnyoSinopsis.SuspendLayout();
            this.panelAnoEdicion.SuspendLayout();
            this.panelSinopsis.SuspendLayout();
            this.tableLayoutPanelBotones.SuspendLayout();
            this.panelBotonGuardar.SuspendLayout();
            this.panelBotonNuevo.SuspendLayout();
            this.SuspendLayout();
             
            this.tableLayoutPanelLibroPrincipal.ColumnCount = 3;
            this.tableLayoutPanelLibroPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelLibroPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelLibroPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelLibroPrincipal.Controls.Add(this.panelBuscarBorder, 1, 0);
            this.tableLayoutPanelLibroPrincipal.Controls.Add(this.tableLayoutPanelLibro, 1, 1);
            this.tableLayoutPanelLibroPrincipal.Controls.Add(this.tableLayoutPanelLibroAnyoSinopsis, 1, 2);
            this.tableLayoutPanelLibroPrincipal.Controls.Add(this.tableLayoutPanelBotones, 1, 3);
            this.tableLayoutPanelLibroPrincipal.Controls.Add(this.labelListaLibros, 1, 4);
            this.tableLayoutPanelLibroPrincipal.Controls.Add(this.flowLayoutPanelLibros, 1, 5);
            this.tableLayoutPanelLibroPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLibroPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLibroPrincipal.Name = "tableLayoutPanelLibroPrincipal";
            this.tableLayoutPanelLibroPrincipal.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.tableLayoutPanelLibroPrincipal.RowCount = 6;
            this.tableLayoutPanelLibroPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelLibroPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanelLibroPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanelLibroPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelLibroPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLibroPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLibroPrincipal.Size = new System.Drawing.Size(984, 730);
            this.tableLayoutPanelLibroPrincipal.TabIndex = 0;
             
            this.panelBuscarBorder.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBuscarBorder.Controls.Add(this.textBoxBuscar);
            this.panelBuscarBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBuscarBorder.Location = new System.Drawing.Point(98, 20);
            this.panelBuscarBorder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.panelBuscarBorder.Name = "panelBuscarBorder";
            this.panelBuscarBorder.Padding = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.panelBuscarBorder.Size = new System.Drawing.Size(787, 55);
            this.panelBuscarBorder.TabIndex = 0;
            this.panelBuscarBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBuscarBorder_Paint);
             
            this.textBoxBuscar.BackColor = System.Drawing.Color.Black;
            this.textBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxBuscar.ForeColor = System.Drawing.Color.White;
            this.textBoxBuscar.Location = new System.Drawing.Point(10, 15);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(767, 22);
            this.textBoxBuscar.TabIndex = 0;
            this.textBoxBuscar.Text = "Buscar Libro ...";
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
             
            this.tableLayoutPanelLibro.ColumnCount = 2;
            this.tableLayoutPanelLibro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLibro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLibro.Controls.Add(this.panelTitulo, 0, 0);
            this.tableLayoutPanelLibro.Controls.Add(this.panelEscritor, 1, 0);
            this.tableLayoutPanelLibro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLibro.Location = new System.Drawing.Point(98, 90);
            this.tableLayoutPanelLibro.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelLibro.Name = "tableLayoutPanelLibro";
            this.tableLayoutPanelLibro.RowCount = 1;
            this.tableLayoutPanelLibro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLibro.Size = new System.Drawing.Size(787, 80);
            this.tableLayoutPanelLibro.TabIndex = 1;
             
            this.panelTitulo.BackColor = System.Drawing.Color.White;
            this.panelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitulo.Controls.Add(this.textBoxTitulo);
            this.panelTitulo.Controls.Add(this.labelTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Padding = new System.Windows.Forms.Padding(10);
            this.panelTitulo.Size = new System.Drawing.Size(383, 80);
            this.panelTitulo.TabIndex = 0;
             
            this.textBoxTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxTitulo.Location = new System.Drawing.Point(10, 35);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(381, 20);
            this.textBoxTitulo.TabIndex = 1;
             
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.Black;
            this.labelTitulo.Location = new System.Drawing.Point(10, 10);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(49, 15);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "TITULO";
            this.labelTitulo.Click += new System.EventHandler(this.labelTitulo_Click);
             
            this.panelEscritor.BackColor = System.Drawing.Color.White;
            this.panelEscritor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEscritor.Controls.Add(this.textBoxEscritor);
            this.panelEscritor.Controls.Add(this.labelEscritor);
            this.panelEscritor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEscritor.Location = new System.Drawing.Point(403, 0);
            this.panelEscritor.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelEscritor.Name = "panelEscritor";
            this.panelEscritor.Padding = new System.Windows.Forms.Padding(10);
            this.panelEscritor.Size = new System.Drawing.Size(384, 80);
            this.panelEscritor.TabIndex = 1;
             
            this.textBoxEscritor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEscritor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEscritor.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxEscritor.Location = new System.Drawing.Point(10, 35);
            this.textBoxEscritor.Name = "textBoxEscritor";
            this.textBoxEscritor.Size = new System.Drawing.Size(382, 20);
            this.textBoxEscritor.TabIndex = 1;
             
            this.labelEscritor.AutoSize = true;
            this.labelEscritor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelEscritor.ForeColor = System.Drawing.Color.Black;
            this.labelEscritor.Location = new System.Drawing.Point(10, 10);
            this.labelEscritor.Name = "labelEscritor";
            this.labelEscritor.Size = new System.Drawing.Size(63, 15);
            this.labelEscritor.TabIndex = 0;
            this.labelEscritor.Text = "ESCRITOR";
             
            this.tableLayoutPanelLibroAnyoSinopsis.ColumnCount = 2;
            this.tableLayoutPanelLibroAnyoSinopsis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLibroAnyoSinopsis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelLibroAnyoSinopsis.Controls.Add(this.panelAnoEdicion, 0, 0);
            this.tableLayoutPanelLibroAnyoSinopsis.Controls.Add(this.panelSinopsis, 1, 0);
            this.tableLayoutPanelLibroAnyoSinopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLibroAnyoSinopsis.Location = new System.Drawing.Point(98, 180);
            this.tableLayoutPanelLibroAnyoSinopsis.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelLibroAnyoSinopsis.Name = "tableLayoutPanelLibroAnyoSinopsis";
            this.tableLayoutPanelLibroAnyoSinopsis.RowCount = 1;
            this.tableLayoutPanelLibroAnyoSinopsis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLibroAnyoSinopsis.Size = new System.Drawing.Size(787, 120);
            this.tableLayoutPanelLibroAnyoSinopsis.TabIndex = 2;
             
            this.panelAnoEdicion.BackColor = System.Drawing.Color.White;
            this.panelAnoEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnoEdicion.Controls.Add(this.textBoxAnoEdicion);
            this.panelAnoEdicion.Controls.Add(this.labelAnoEdicion);
            this.panelAnoEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnoEdicion.Location = new System.Drawing.Point(0, 0);
            this.panelAnoEdicion.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelAnoEdicion.Name = "panelAnoEdicion";
            this.panelAnoEdicion.Padding = new System.Windows.Forms.Padding(10);
            this.panelAnoEdicion.Size = new System.Drawing.Size(186, 120);
            this.panelAnoEdicion.TabIndex = 0;
             
            this.textBoxAnoEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAnoEdicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxAnoEdicion.Location = new System.Drawing.Point(10, 35);
            this.textBoxAnoEdicion.Name = "textBoxAnoEdicion";
            this.textBoxAnoEdicion.Size = new System.Drawing.Size(156, 20);
            this.textBoxAnoEdicion.TabIndex = 1;
             
            this.labelAnoEdicion.AutoSize = true;
            this.labelAnoEdicion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelAnoEdicion.ForeColor = System.Drawing.Color.Black;
            this.labelAnoEdicion.Location = new System.Drawing.Point(10, 10);
            this.labelAnoEdicion.Name = "labelAnoEdicion";
            this.labelAnoEdicion.Size = new System.Drawing.Size(117, 15);
            this.labelAnoEdicion.TabIndex = 0;
            this.labelAnoEdicion.Text = "AÑO EDICIÓN (Opc)";
             
            this.panelSinopsis.BackColor = System.Drawing.Color.White;
            this.panelSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSinopsis.Controls.Add(this.textBoxSinopsis);
            this.panelSinopsis.Controls.Add(this.labelSinopsis);
            this.panelSinopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSinopsis.Location = new System.Drawing.Point(206, 0);
            this.panelSinopsis.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelSinopsis.Name = "panelSinopsis";
            this.panelSinopsis.Padding = new System.Windows.Forms.Padding(10);
            this.panelSinopsis.Size = new System.Drawing.Size(581, 120);
            this.panelSinopsis.TabIndex = 1;
             
            this.textBoxSinopsis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSinopsis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxSinopsis.Location = new System.Drawing.Point(10, 35);
            this.textBoxSinopsis.Multiline = true;
            this.textBoxSinopsis.Name = "textBoxSinopsis";
            this.textBoxSinopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSinopsis.Size = new System.Drawing.Size(579, 98);
            this.textBoxSinopsis.TabIndex = 1;
            this.textBoxSinopsis.TextChanged += new System.EventHandler(this.textBoxDescripcion_TextChanged);
             
            this.labelSinopsis.AutoSize = true;
            this.labelSinopsis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelSinopsis.ForeColor = System.Drawing.Color.Black;
            this.labelSinopsis.Location = new System.Drawing.Point(10, 10);
            this.labelSinopsis.Name = "labelSinopsis";
            this.labelSinopsis.Size = new System.Drawing.Size(94, 15);
            this.labelSinopsis.TabIndex = 0;
            this.labelSinopsis.Text = "SINOPSIS (Opc)";
             
            this.tableLayoutPanelBotones.ColumnCount = 2;
            this.tableLayoutPanelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotones.Controls.Add(this.panelBotonGuardar, 0, 0);
            this.tableLayoutPanelBotones.Controls.Add(this.panelBotonNuevo, 1, 0);
            this.tableLayoutPanelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBotones.Location = new System.Drawing.Point(98, 310);
            this.tableLayoutPanelBotones.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.tableLayoutPanelBotones.Name = "tableLayoutPanelBotones";
            this.tableLayoutPanelBotones.RowCount = 1;
            this.tableLayoutPanelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBotones.Size = new System.Drawing.Size(787, 45);
            this.tableLayoutPanelBotones.TabIndex = 3;
            
            this.panelBotonGuardar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelBotonGuardar.Controls.Add(this.labelGuardar);
            this.panelBotonGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBotonGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotonGuardar.Location = new System.Drawing.Point(0, 0);
            this.panelBotonGuardar.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelBotonGuardar.Name = "panelBotonGuardar";
            this.panelBotonGuardar.Size = new System.Drawing.Size(383, 45);
            this.panelBotonGuardar.TabIndex = 0;
             
            this.labelGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelGuardar.ForeColor = System.Drawing.Color.White;
            this.labelGuardar.Location = new System.Drawing.Point(0, 0);
            this.labelGuardar.Name = "labelGuardar";
            this.labelGuardar.Size = new System.Drawing.Size(383, 45);
            this.labelGuardar.TabIndex = 0;
            this.labelGuardar.Text = "Guardar";
            this.labelGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            
            this.panelBotonNuevo.BackColor = System.Drawing.Color.Black;
            this.panelBotonNuevo.Controls.Add(this.labelNuevo);
            this.panelBotonNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBotonNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotonNuevo.Location = new System.Drawing.Point(403, 0);
            this.panelBotonNuevo.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelBotonNuevo.Name = "panelBotonNuevo";
            this.panelBotonNuevo.Size = new System.Drawing.Size(384, 45);
            this.panelBotonNuevo.TabIndex = 1;
             
            this.labelNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNuevo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelNuevo.ForeColor = System.Drawing.Color.White;
            this.labelNuevo.Location = new System.Drawing.Point(0, 0);
            this.labelNuevo.Name = "labelNuevo";
            this.labelNuevo.Size = new System.Drawing.Size(384, 45);
            this.labelNuevo.TabIndex = 0;
            this.labelNuevo.Text = "Nuevo";
            this.labelNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
             
            this.labelListaLibros.AutoSize = true;
            this.labelListaLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelListaLibros.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelListaLibros.ForeColor = System.Drawing.Color.Black;
            this.labelListaLibros.Location = new System.Drawing.Point(101, 370);
            this.labelListaLibros.Name = "labelListaLibros";
            this.labelListaLibros.Size = new System.Drawing.Size(781, 40);
            this.labelListaLibros.TabIndex = 5;
            this.labelListaLibros.Text = "Lista de Libros";
            this.labelListaLibros.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
             
            this.flowLayoutPanelLibros.AutoScroll = true;
            this.flowLayoutPanelLibros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanelLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelLibros.Location = new System.Drawing.Point(101, 413);
            this.flowLayoutPanelLibros.Name = "flowLayoutPanelLibros";
            this.flowLayoutPanelLibros.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelLibros.Size = new System.Drawing.Size(781, 294);
            this.flowLayoutPanelLibros.TabIndex = 4;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 730);
            this.Controls.Add(this.tableLayoutPanelLibroPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLibros";
            this.Text = "Gestión de Libros";
            this.Load += new System.EventHandler(this.FormLibros_Load);
            this.tableLayoutPanelLibroPrincipal.ResumeLayout(false);
            this.tableLayoutPanelLibroPrincipal.PerformLayout();
            this.panelBuscarBorder.ResumeLayout(false);
            this.panelBuscarBorder.PerformLayout();
            this.tableLayoutPanelLibro.ResumeLayout(false);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelEscritor.ResumeLayout(false);
            this.panelEscritor.PerformLayout();
            this.tableLayoutPanelLibroAnyoSinopsis.ResumeLayout(false);
            this.panelAnoEdicion.ResumeLayout(false);
            this.panelAnoEdicion.PerformLayout();
            this.panelSinopsis.ResumeLayout(false);
            this.panelSinopsis.PerformLayout();
            this.tableLayoutPanelBotones.ResumeLayout(false);
            this.panelBotonGuardar.ResumeLayout(false);
            this.panelBotonNuevo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLibroPrincipal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLibro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLibroAnyoSinopsis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBotones;
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
        private System.Windows.Forms.Label labelListaLibros;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLibros;
    }
}
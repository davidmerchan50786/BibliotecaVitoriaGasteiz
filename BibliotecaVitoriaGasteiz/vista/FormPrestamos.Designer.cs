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
            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanelFila1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.panelLibro = new System.Windows.Forms.Panel();
            this.comboBoxLibros = new System.Windows.Forms.ComboBox();
            this.labelLibro = new System.Windows.Forms.Label();
            this.tableLayoutPanelFila2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelFechaInicio = new System.Windows.Forms.Panel();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.panelFechaFin = new System.Windows.Forms.Panel();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.tableLayoutPanelBotones = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtonPrestar = new System.Windows.Forms.Panel();
            this.labelPrestar = new System.Windows.Forms.Label();
            this.panelButtonLimpiar = new System.Windows.Forms.Panel();
            this.labelLimpiar = new System.Windows.Forms.Label();
            this.panelButtonDevolver = new System.Windows.Forms.Panel();
            this.labelDevolver = new System.Windows.Forms.Label();
            this.labelPrestamosActivos = new System.Windows.Forms.Label();
            this.dataGridViewPrestamos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.tableLayoutPanelFila1.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            this.panelLibro.SuspendLayout();
            this.tableLayoutPanelFila2.SuspendLayout();
            this.panelFechaInicio.SuspendLayout();
            this.panelFechaFin.SuspendLayout();
            this.tableLayoutPanelBotones.SuspendLayout();
            this.panelButtonPrestar.SuspendLayout();
            this.panelButtonLimpiar.SuspendLayout();
            this.panelButtonDevolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPrincipal
            // 
            this.tableLayoutPanelPrincipal.ColumnCount = 3;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.labelTitulo, 1, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelFila1, 1, 1);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelFila2, 1, 2);
            this.tableLayoutPanelPrincipal.Controls.Add(this.tableLayoutPanelBotones, 1, 3);
            this.tableLayoutPanelPrincipal.Controls.Add(this.labelPrestamosActivos, 1, 4);
            this.tableLayoutPanelPrincipal.Controls.Add(this.dataGridViewPrestamos, 1, 5);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.tableLayoutPanelPrincipal.RowCount = 6;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(984, 640);
            this.tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelTitulo.Location = new System.Drawing.Point(101, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(781, 80);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Gestión de Préstamos";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelFila1
            // 
            this.tableLayoutPanelFila1.ColumnCount = 2;
            this.tableLayoutPanelFila1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFila1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFila1.Controls.Add(this.panelUsuario, 0, 0);
            this.tableLayoutPanelFila1.Controls.Add(this.panelLibro, 1, 0);
            this.tableLayoutPanelFila1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFila1.Location = new System.Drawing.Point(98, 80);
            this.tableLayoutPanelFila1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelFila1.Name = "tableLayoutPanelFila1";
            this.tableLayoutPanelFila1.RowCount = 1;
            this.tableLayoutPanelFila1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFila1.Size = new System.Drawing.Size(787, 70);
            this.tableLayoutPanelFila1.TabIndex = 1;
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.White;
            this.panelUsuario.Controls.Add(this.comboBoxUsuarios);
            this.panelUsuario.Controls.Add(this.labelUsuario);
            this.panelUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsuario.Location = new System.Drawing.Point(0, 0);
            this.panelUsuario.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Padding = new System.Windows.Forms.Padding(10);
            this.panelUsuario.Size = new System.Drawing.Size(383, 70);
            this.panelUsuario.TabIndex = 0;
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUsuarios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxUsuarios.FormattingEnabled = true;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(13, 29);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(360, 28);
            this.comboBoxUsuarios.TabIndex = 1;
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelUsuario.Location = new System.Drawing.Point(10, 7);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(61, 15);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "USUARIO";
            // 
            // panelLibro
            // 
            this.panelLibro.BackColor = System.Drawing.Color.White;
            this.panelLibro.Controls.Add(this.comboBoxLibros);
            this.panelLibro.Controls.Add(this.labelLibro);
            this.panelLibro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLibro.Location = new System.Drawing.Point(403, 0);
            this.panelLibro.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelLibro.Name = "panelLibro";
            this.panelLibro.Padding = new System.Windows.Forms.Padding(10);
            this.panelLibro.Size = new System.Drawing.Size(384, 70);
            this.panelLibro.TabIndex = 1;
            // 
            // comboBoxLibros
            // 
            this.comboBoxLibros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLibros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxLibros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLibros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxLibros.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxLibros.FormattingEnabled = true;
            this.comboBoxLibros.Location = new System.Drawing.Point(10, 29);
            this.comboBoxLibros.Name = "comboBoxLibros";
            this.comboBoxLibros.Size = new System.Drawing.Size(361, 28);
            this.comboBoxLibros.TabIndex = 1;
            // 
            // labelLibro
            // 
            this.labelLibro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLibro.AutoSize = true;
            this.labelLibro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelLibro.Location = new System.Drawing.Point(10, 7);
            this.labelLibro.Name = "labelLibro";
            this.labelLibro.Size = new System.Drawing.Size(122, 15);
            this.labelLibro.TabIndex = 0;
            this.labelLibro.Text = "LIBRO (DISPONIBLE)";
            // 
            // tableLayoutPanelFila2
            // 
            this.tableLayoutPanelFila2.ColumnCount = 4;
            this.tableLayoutPanelFila2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.5F));
            this.tableLayoutPanelFila2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.5F));
            this.tableLayoutPanelFila2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.5F));
            this.tableLayoutPanelFila2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.5F));
            this.tableLayoutPanelFila2.Controls.Add(this.panelFechaInicio, 0, 0);
            this.tableLayoutPanelFila2.Controls.Add(this.panelFechaFin, 1, 0);
            this.tableLayoutPanelFila2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFila2.Location = new System.Drawing.Point(98, 160);
            this.tableLayoutPanelFila2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelFila2.Name = "tableLayoutPanelFila2";
            this.tableLayoutPanelFila2.RowCount = 1;
            this.tableLayoutPanelFila2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFila2.Size = new System.Drawing.Size(787, 70);
            this.tableLayoutPanelFila2.TabIndex = 2;
            // 
            // panelFechaInicio
            // 
            this.panelFechaInicio.BackColor = System.Drawing.Color.White;
            this.panelFechaInicio.Controls.Add(this.dateTimePickerInicio);
            this.panelFechaInicio.Controls.Add(this.labelFechaInicio);
            this.panelFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFechaInicio.Location = new System.Drawing.Point(0, 0);
            this.panelFechaInicio.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelFechaInicio.Name = "panelFechaInicio";
            this.panelFechaInicio.Padding = new System.Windows.Forms.Padding(10);
            this.panelFechaInicio.Size = new System.Drawing.Size(182, 70);
            this.panelFechaInicio.TabIndex = 0;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerInicio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(10, 30);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(159, 27);
            this.dateTimePickerInicio.TabIndex = 1;
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelFechaInicio.Location = new System.Drawing.Point(10, 6);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(83, 15);
            this.labelFechaInicio.TabIndex = 0;
            this.labelFechaInicio.Text = "FECHA INICIO";
            // 
            // panelFechaFin
            // 
            this.panelFechaFin.BackColor = System.Drawing.Color.White;
            this.panelFechaFin.Controls.Add(this.dateTimePickerFin);
            this.panelFechaFin.Controls.Add(this.labelFechaFin);
            this.panelFechaFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFechaFin.Location = new System.Drawing.Point(202, 0);
            this.panelFechaFin.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelFechaFin.Name = "panelFechaFin";
            this.panelFechaFin.Padding = new System.Windows.Forms.Padding(10);
            this.panelFechaFin.Size = new System.Drawing.Size(182, 70);
            this.panelFechaFin.TabIndex = 1;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerFin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFin.Location = new System.Drawing.Point(13, 30);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(159, 27);
            this.dateTimePickerFin.TabIndex = 1;
            // 
            // labelFechaFin
            // 
            this.labelFechaFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFechaFin.AutoSize = true;
            this.labelFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelFechaFin.Location = new System.Drawing.Point(13, 6);
            this.labelFechaFin.Name = "labelFechaFin";
            this.labelFechaFin.Size = new System.Drawing.Size(65, 15);
            this.labelFechaFin.TabIndex = 0;
            this.labelFechaFin.Text = "FECHA FIN";
            // 
            // tableLayoutPanelBotones
            // 
            this.tableLayoutPanelBotones.ColumnCount = 3;
            this.tableLayoutPanelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanelBotones.Controls.Add(this.panelButtonPrestar, 0, 0);
            this.tableLayoutPanelBotones.Controls.Add(this.panelButtonLimpiar, 1, 0);
            this.tableLayoutPanelBotones.Controls.Add(this.panelButtonDevolver, 2, 0);
            this.tableLayoutPanelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBotones.Location = new System.Drawing.Point(98, 240);
            this.tableLayoutPanelBotones.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelBotones.Name = "tableLayoutPanelBotones";
            this.tableLayoutPanelBotones.RowCount = 1;
            this.tableLayoutPanelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelBotones.Size = new System.Drawing.Size(787, 70);
            this.tableLayoutPanelBotones.TabIndex = 3;
            // 
            // panelButtonPrestar
            // 
            this.panelButtonPrestar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelButtonPrestar.Controls.Add(this.labelPrestar);
            this.panelButtonPrestar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonPrestar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonPrestar.Location = new System.Drawing.Point(0, 0);
            this.panelButtonPrestar.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelButtonPrestar.Name = "panelButtonPrestar";
            this.panelButtonPrestar.Size = new System.Drawing.Size(257, 70);
            this.panelButtonPrestar.TabIndex = 0;
            // 
            // labelPrestar
            // 
            this.labelPrestar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPrestar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelPrestar.ForeColor = System.Drawing.Color.White;
            this.labelPrestar.Location = new System.Drawing.Point(0, 0);
            this.labelPrestar.Name = "labelPrestar";
            this.labelPrestar.Size = new System.Drawing.Size(257, 70);
            this.labelPrestar.TabIndex = 0;
            this.labelPrestar.Text = "Realizar Préstamo";
            this.labelPrestar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtonLimpiar
            // 
            this.panelButtonLimpiar.BackColor = System.Drawing.Color.Black;
            this.panelButtonLimpiar.Controls.Add(this.labelLimpiar);
            this.panelButtonLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonLimpiar.Location = new System.Drawing.Point(277, 0);
            this.panelButtonLimpiar.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelButtonLimpiar.Name = "panelButtonLimpiar";
            this.panelButtonLimpiar.Size = new System.Drawing.Size(239, 70);
            this.panelButtonLimpiar.TabIndex = 1;
            // 
            // labelLimpiar
            // 
            this.labelLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelLimpiar.ForeColor = System.Drawing.Color.White;
            this.labelLimpiar.Location = new System.Drawing.Point(0, 0);
            this.labelLimpiar.Name = "labelLimpiar";
            this.labelLimpiar.Size = new System.Drawing.Size(239, 70);
            this.labelLimpiar.TabIndex = 0;
            this.labelLimpiar.Text = "Limpiar";
            this.labelLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtonDevolver
            // 
            this.panelButtonDevolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panelButtonDevolver.Controls.Add(this.labelDevolver);
            this.panelButtonDevolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelButtonDevolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonDevolver.Location = new System.Drawing.Point(536, 0);
            this.panelButtonDevolver.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelButtonDevolver.Name = "panelButtonDevolver";
            this.panelButtonDevolver.Size = new System.Drawing.Size(251, 70);
            this.panelButtonDevolver.TabIndex = 2;
            // 
            // labelDevolver
            // 
            this.labelDevolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDevolver.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelDevolver.ForeColor = System.Drawing.Color.White;
            this.labelDevolver.Location = new System.Drawing.Point(0, 0);
            this.labelDevolver.Name = "labelDevolver";
            this.labelDevolver.Size = new System.Drawing.Size(251, 70);
            this.labelDevolver.TabIndex = 0;
            this.labelDevolver.Text = "Devolver Seleccionado";
            this.labelDevolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrestamosActivos
            // 
            this.labelPrestamosActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPrestamosActivos.AutoSize = true;
            this.labelPrestamosActivos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelPrestamosActivos.Location = new System.Drawing.Point(101, 325);
            this.labelPrestamosActivos.Name = "labelPrestamosActivos";
            this.labelPrestamosActivos.Size = new System.Drawing.Size(139, 20);
            this.labelPrestamosActivos.TabIndex = 4;
            this.labelPrestamosActivos.Text = "Préstamos Activos";
            this.labelPrestamosActivos.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dataGridViewPrestamos
            // 
            this.dataGridViewPrestamos.AllowUserToAddRows = false;
            this.dataGridViewPrestamos.AllowUserToDeleteRows = false;
            this.dataGridViewPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrestamos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPrestamos.Location = new System.Drawing.Point(101, 348);
            this.dataGridViewPrestamos.Name = "dataGridViewPrestamos";
            this.dataGridViewPrestamos.ReadOnly = true;
            this.dataGridViewPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrestamos.Size = new System.Drawing.Size(781, 269);
            this.dataGridViewPrestamos.TabIndex = 5;
            // 
            // FormPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(984, 640);
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPrestamos";
            this.Text = "Gestión de Préstamos";
            this.Load += new System.EventHandler(this.FormPrestamos_Load);
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.tableLayoutPanelPrincipal.PerformLayout();
            this.tableLayoutPanelFila1.ResumeLayout(false);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.panelLibro.ResumeLayout(false);
            this.panelLibro.PerformLayout();
            this.tableLayoutPanelFila2.ResumeLayout(false);
            this.panelFechaInicio.ResumeLayout(false);
            this.panelFechaInicio.PerformLayout();
            this.panelFechaFin.ResumeLayout(false);
            this.panelFechaFin.PerformLayout();
            this.tableLayoutPanelBotones.ResumeLayout(false);
            this.panelButtonPrestar.ResumeLayout(false);
            this.panelButtonLimpiar.ResumeLayout(false);
            this.panelButtonDevolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFila1;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFila2;
        private System.Windows.Forms.Panel panelFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Label labelFechaInicio;
        private System.Windows.Forms.Panel panelFechaFin;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBotones;
        private System.Windows.Forms.Panel panelButtonPrestar;
        private System.Windows.Forms.Label labelPrestar;
        private System.Windows.Forms.Panel panelButtonLimpiar;
        private System.Windows.Forms.Label labelLimpiar;
        private System.Windows.Forms.Panel panelButtonDevolver;
        private System.Windows.Forms.Label labelDevolver;
        private System.Windows.Forms.Label labelPrestamosActivos;
        private System.Windows.Forms.DataGridView dataGridViewPrestamos;
        private System.Windows.Forms.Panel panelLibro;
        private System.Windows.Forms.ComboBox comboBoxLibros;
        private System.Windows.Forms.Label labelLibro;
    }
}
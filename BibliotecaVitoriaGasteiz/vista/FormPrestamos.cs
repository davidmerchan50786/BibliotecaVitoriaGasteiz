using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Gestión de Préstamos
    /// 
    /// Esta es la interfaz donde los bibliotecarios pueden:
    /// - Realizar nuevos préstamos (seleccionar usuario, libro y fechas)
    /// - Ver la tabla de préstamos activos
    /// - Devolver libros prestados
    /// 
    /// El diseño visual fue una de las partes que más me gustó hacer.
    /// Uso paneles con colores corporativos (DarkCyan para "Realizar Préstamo",
    /// Negro para "Devolver") que quedan más profesionales que los botones estándar.
    /// 
    /// PATRÓN SINGLETON:
    /// Uso GetInstance() para que solo exista UNA instancia del formulario.
    /// Esto lo vi en los apuntes de clase y evita que se abran múltiples ventanas.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormPrestamos : Form
    {
        // Patrón Singleton
        private static FormPrestamos instancia;

        // El Controlador lo recibe desde Gestor.cs
        // Esto sigue el patrón MVC: la vista no crea su propio controlador,
        // se lo pasan desde fuera
        public Controlador MiControlador { get; set; }

        /// <summary>
        /// Método estático para obtener la única instancia del formulario
        /// Si no existe o se cerró, crea una nueva
        /// </summary>
        public static FormPrestamos GetInstance()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormPrestamos();
            }
            return instancia;
        }

        /// <summary>
        /// Constructor privado (para el patrón Singleton)
        /// Inicializa los componentes del diseñador y conecta los eventos de los botones
        /// </summary>
        private FormPrestamos()
        {
            InitializeComponent();

            // Conecto los eventos de los botones manualmente
            // Los botones realmente son Paneles con Labels dentro (diseño personalizado)
            panelButtonPrestar.Click += BtnRealizarPrestamo_Click;
            labelPrestar.Click += BtnRealizarPrestamo_Click;

            panelButtonDevolver.Click += BtnDevolver_Click;
            labelDevolver.Click += BtnDevolver_Click;
        }

        /// <summary>
        /// Evento Load: Se ejecuta cuando el formulario se carga por primera vez
        /// 
        /// Aquí cargo los datos iniciales:
        /// - Lista de usuarios (para el ComboBox)
        /// - Lista de libros disponibles (para el ComboBox)
        /// - Tabla de préstamos activos
        /// 
        /// También inicializo las fechas:
        /// - Fecha inicio: HOY
        /// - Fecha fin: HOY + 14 días (2 semanas de préstamo por defecto)
        /// </summary>
        private void FormPrestamos_Load(object sender, EventArgs e)
        {
            // Solo inicializo fechas aquí
            // Los datos se cargan en OnVisibleChanged (más abajo) para evitar errores
            // de que MiControlador sea null
            try
            {
                dateTimePickerInicio.Value = DateTime.Now;
                dateTimePickerFin.Value = DateTime.Now.AddDays(14);
            }
            catch
            {
                // Si hay algún error con los DateTimePickers, lo ignoro
            }
        }

        /// <summary>
        /// Carga la lista de usuarios en el ComboBox
        /// 
        /// IMPORTANTE: Configuración del ComboBox
        /// - DataSource: De dónde vienen los datos (DataTable)
        /// - DisplayMember: Qué columna se MUESTRA al usuario ("Nombre")
        /// - ValueMember: Qué columna se usa como VALOR ("ID")
        /// 
        /// Cuando el usuario selecciona "Juan", internamente el ComboBox
        /// devuelve el ID del usuario (ej: 3), no el texto "Juan".
        /// 
        /// Al principio me dio problemas porque no entendía la diferencia
        /// entre DisplayMember y ValueMember. Lo aprendí de la documentación de Microsoft.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerTodosUsuarios();

                // Limpio el ComboBox antes de llenarlo
                comboBoxUsuarios.DataSource = null;
                comboBoxUsuarios.Items.Clear();

                // Configuro el ComboBox
                comboBoxUsuarios.DataSource = dt;
                comboBoxUsuarios.DisplayMember = "Nombre";  // Lo que VE el usuario
                comboBoxUsuarios.ValueMember = "ID";        // El valor REAL (ID)

                // -1 = ninguno seleccionado por defecto
                comboBoxUsuarios.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga solo los libros DISPONIBLES en el ComboBox
        /// 
        /// No tiene sentido mostrar libros ya prestados, por eso llamo a
        /// ObtenerLibrosDisponibles() en vez de ObtenerLibros().
        /// 
        /// Configuración igual que CargarUsuarios:
        /// - DisplayMember: "Titulo" (lo que ve el usuario)
        /// - ValueMember: "ID" (el valor real)
        /// </summary>
        private void CargarLibrosDisponibles()
        {
            try
            {
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerLibrosDisponibles();

                comboBoxLibros.DataSource = null;
                comboBoxLibros.Items.Clear();

                comboBoxLibros.DataSource = dt;
                comboBoxLibros.DisplayMember = "Titulo";
                comboBoxLibros.ValueMember = "ID";

                comboBoxLibros.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga la tabla de préstamos activos en el DataGridView
        /// 
        /// Esta tabla muestra los libros que están actualmente prestados
        /// con información legible: nombre del usuario, título del libro, fechas.
        /// 
        /// Las columnas vienen del SQL con INNER JOIN que hice en RepoPrestamo:
        /// - ID, Usuario, Libro, Fecha_Inicio, Fecha_Fin
        /// 
        /// Oculto las columnas ID_Usuario e ID_Libro porque son IDs internos
        /// que no aportan nada al usuario final.
        /// </summary>
        private void CargarPrestamosActivos()
        {
            try
            {
                if (MiControlador == null) return;

                DataTable dt = MiControlador.ObtenerPrestamosActivos();

                // Asigno los datos al DataGridView
                dataGridViewPrestamos.DataSource = dt;

                // Configuro las columnas solo si hay datos
                if (dataGridViewPrestamos.Columns.Count > 0)
                {
                    // Cambio los encabezados para que sean más claros
                    if (dataGridViewPrestamos.Columns.Contains("ID"))
                    {
                        dataGridViewPrestamos.Columns["ID"].HeaderText = "ID Préstamo";
                        dataGridViewPrestamos.Columns["ID"].Width = 80;
                    }

                    // La columna "Usuario" viene del INNER JOIN (Nombre + Apellidos concatenados)
                    if (dataGridViewPrestamos.Columns.Contains("Usuario"))
                    {
                        dataGridViewPrestamos.Columns["Usuario"].HeaderText = "Usuario";
                        dataGridViewPrestamos.Columns["Usuario"].Width = 150;
                    }

                    // La columna "Libro" viene del INNER JOIN (Titulo del libro)
                    if (dataGridViewPrestamos.Columns.Contains("Libro"))
                    {
                        dataGridViewPrestamos.Columns["Libro"].HeaderText = "Libro";
                        dataGridViewPrestamos.Columns["Libro"].Width = 200;
                    }

                    if (dataGridViewPrestamos.Columns.Contains("Fecha_Inicio"))
                    {
                        dataGridViewPrestamos.Columns["Fecha_Inicio"].HeaderText = "Fecha Inicio";
                        dataGridViewPrestamos.Columns["Fecha_Inicio"].Width = 100;
                    }

                    if (dataGridViewPrestamos.Columns.Contains("Fecha_Fin"))
                    {
                        dataGridViewPrestamos.Columns["Fecha_Fin"].HeaderText = "Fecha Fin";
                        dataGridViewPrestamos.Columns["Fecha_Fin"].Width = 100;
                    }

                    // Oculto los IDs internos (no son útiles visualmente)
                    if (dataGridViewPrestamos.Columns.Contains("ID_Usuario"))
                        dataGridViewPrestamos.Columns["ID_Usuario"].Visible = false;
                    if (dataGridViewPrestamos.Columns.Contains("ID_Libro"))
                        dataGridViewPrestamos.Columns["ID_Libro"].Visible = false;
                }

                // Quito la selección por defecto
                dataGridViewPrestamos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón "Realizar Préstamo" - Click
        /// 
        /// Esta es la función principal del formulario.
        /// Valida TODO antes de realizar el préstamo:
        /// 
        /// VALIDACIONES:
        /// 1. Que haya un usuario seleccionado
        /// 2. Que haya un libro seleccionado
        /// 3. Que los IDs sean válidos (> 0)
        /// 4. Que la fecha fin sea posterior a la fecha inicio
        /// 
        /// Si todo es correcto:
        /// - Llama al Controlador para realizar el préstamo
        /// - Recarga los datos (libros disponibles y préstamos activos)
        /// - Limpia el formulario para un nuevo préstamo
        /// 
        /// Al principio tuve problemas porque los IDs eran 0, pero lo solucioné
        /// con DatabaseHelper que corrige esos casos al inicio.
        /// </summary>
        private void BtnRealizarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIÓN 0: Verificar que MiControlador existe
                if (MiControlador == null)
                {
                    MessageBox.Show("Error: Controlador no inicializado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // VALIDACIÓN 1: Usuario seleccionado
                if (comboBoxUsuarios.SelectedIndex == -1 || comboBoxUsuarios.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxUsuarios.Focus();
                    return;
                }

                // VALIDACIÓN 2: Libro seleccionado
                if (comboBoxLibros.SelectedIndex == -1 || comboBoxLibros.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un libro", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxLibros.Focus();
                    return;
                }

                // Obtengo los IDs desde los ComboBox
                // SelectedValue devuelve el ValueMember (que es "ID")
                int idUsuario = Convert.ToInt32(comboBoxUsuarios.SelectedValue);
                int idLibro = Convert.ToInt32(comboBoxLibros.SelectedValue);

                // VALIDACIÓN 3: ID de usuario válido
                if (idUsuario < 0)
                {
                    MessageBox.Show($"ID de usuario no válido: {idUsuario}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // VALIDACIÓN 4: ID de libro válido
                if (idLibro < 0)
                {
                    MessageBox.Show($"ID de libro no válido: {idLibro}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtengo las fechas de los DateTimePickers
                DateTime fechaInicio = dateTimePickerInicio.Value.Date;
                DateTime fechaFin = dateTimePickerFin.Value.Date;

                // VALIDACIÓN 5: Fecha fin posterior a fecha inicio
                if (fechaFin <= fechaInicio)
                {
                    MessageBox.Show("La fecha de fin debe ser posterior a la fecha de inicio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTimePickerFin.Focus();
                    return;
                }

                // SI LLEGAMOS AQUÍ, TODO ES VÁLIDO
                // Llamo al Controlador para realizar el préstamo
                MiControlador.RealizarPrestamo(idUsuario, idLibro, fechaInicio, fechaFin);

                MessageBox.Show("Préstamo realizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizo la interfaz
                CargarLibrosDisponibles();  // El libro prestado ya no aparecerá
                CargarPrestamosActivos();   // El nuevo préstamo aparecerá en la tabla
                LimpiarFormulario();        // Limpio para un nuevo préstamo
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar préstamo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón "Devolver Libro Seleccionado" - Click
        /// 
        /// Para devolver un libro:
        /// 1. El usuario selecciona una fila en la tabla de préstamos activos
        /// 2. Click en "Devolver"
        /// 3. Confirma la devolución
        /// 4. El sistema actualiza el préstamo y marca el libro como disponible
        /// 
        /// El libro vuelve a aparecer en el ComboBox de libros disponibles.
        /// </summary>
        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (MiControlador == null)
                {
                    MessageBox.Show("Error: Controlador no inicializado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifico que haya una fila seleccionada
                if (dataGridViewPrestamos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un préstamo para devolver", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtengo el ID del préstamo desde la fila seleccionada
                int idPrestamo = Convert.ToInt32(dataGridViewPrestamos.SelectedRows[0].Cells["ID"].Value);

                // Pido confirmación al usuario
                DialogResult result = MessageBox.Show(
                    "¿Está seguro de que desea marcar este libro como devuelto?",
                    "Confirmar devolución",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Llamo al Controlador para devolver el libro
                    MiControlador.DevolverLibro(idPrestamo);

                    MessageBox.Show("Libro devuelto correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizo la interfaz
                    CargarLibrosDisponibles();  // El libro vuelve a estar disponible
                    CargarPrestamosActivos();   // El préstamo desaparece de la tabla
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver libro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia el formulario después de realizar un préstamo
        /// Deja todo listo para realizar otro préstamo nuevo
        /// </summary>
        private void LimpiarFormulario()
        {
            comboBoxUsuarios.SelectedIndex = -1;   // Ningún usuario seleccionado
            comboBoxLibros.SelectedIndex = -1;     // Ningún libro seleccionado
            dateTimePickerInicio.Value = DateTime.Now;              // Hoy
            dateTimePickerFin.Value = DateTime.Now.AddDays(14);     // +14 días
        }

        /// <summary>
        /// Evento TextChanged del TextBox de búsqueda
        /// Lo dejé para futuras mejoras (filtrar préstamos por texto)
        /// Por ahora no lo uso
        /// </summary>
        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtro opcional - no implementado aún
        }

        /// <summary>
        /// Este método se ejecuta cuando el formulario se hace visible
        /// 
        /// IMPORTANTE: Aquí cargo los datos en vez de en FormPrestamos_Load
        /// porque cuando se ejecuta Load, MiControlador aún puede ser null.
        /// 
        /// OnVisibleChanged se ejecuta DESPUÉS de que Gestor.cs asigne MiControlador,
        /// así que aquí sí está disponible.
        /// 
        /// Este problema de timing me costó entenderlo al principio con el MVC.
        /// </summary>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            // Solo cargo datos si el formulario es visible Y tengo controlador
            if (this.Visible && MiControlador != null)
            {
                CargarUsuarios();
                CargarLibrosDisponibles();
                CargarPrestamosActivos();
            }
        }
    }
}
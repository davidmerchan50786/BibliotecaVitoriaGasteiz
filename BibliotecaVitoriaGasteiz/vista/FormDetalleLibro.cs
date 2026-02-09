using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaVitoriaGasteiz.controlador;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.vista
{
    /// <summary>
    /// Formulario de Detalle de Libro
    /// 
    /// Se abre cuando se hace click en "Ver Detalles" de una TarjetaLibro.
    /// 
    /// FUNCIONALIDADES:
    /// - Visualizar todos los datos de un libro (incluida la sinopsis completa)
    /// - Editar los datos del libro
    /// - Eliminar el libro de la base de datos
    /// - Ver el estado actual (Disponible / Prestado)
    /// 
    /// MODOS:
    /// 1. Modo Visualización (por defecto):
    ///    - Campos en ReadOnly (no se pueden editar)
    ///    - Botón "Editar" visible
    ///    - Botón "Cerrar" visible
    ///    - Botón "Eliminar" habilitado
    /// 
    /// 2. Modo Edición (al hacer click en "Editar"):
    ///    - Campos editables (fondo blanco)
    ///    - Botón "Editar" cambia a "Guardar"
    ///    - Botón "Cerrar" cambia a "Cancelar"
    ///    - Botón "Eliminar" deshabilitado (para evitar clicks accidentales)
    /// 
    /// IMPORTANTE: LibroId = -1 por defecto
    /// Esto permite que ID = 0 sea válido (solución al problema de IDs en SQLite)
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public partial class FormDetalleLibro : Form
    {
        // Controlador compartido (lo recibe desde FormLibros)
        public Controlador MiControlador { get; set; }

        // ID del libro a mostrar
        // Inicializo a -1 para que el 0 sea válido (problema de SQLite que tuve)
        public int LibroId { get; set; } = -1;

        // Evento que se dispara cuando se modifica o elimina el libro
        // FormLibros se suscribe a este evento para recargar la lista
        public event EventHandler LibroModificado;

        // Variable de estado para saber si estamos editando
        private bool modoEdicion = false;

        /// <summary>
        /// Constructor
        /// Conecto manualmente el evento Load
        /// </summary>
        public FormDetalleLibro()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormDetalleLibro_Load);
        }

        /// <summary>
        /// Evento Load: Se ejecuta al abrir el formulario
        /// 
        /// VALIDACIONES INICIALES:
        /// 1. MiControlador no puede ser null
        /// 2. LibroId no puede ser -1 (valor por defecto)
        /// 
        /// Si algo falla, cierro el formulario para evitar errores.
        /// 
        /// Al principio validaba contra 0, pero eso impedía ver libros con ID = 0.
        /// Por eso cambié la validación a -1.
        /// </summary>
        private void FormDetalleLibro_Load(object sender, EventArgs e)
        {
            // Validación: necesito Controlador y un ID válido
            if (MiControlador == null || LibroId == -1)
            {
                MessageBox.Show($"Error: Datos incompletos (Controlador: {MiControlador != null}, ID: {LibroId})");
                this.Close();
                return;
            }

            // Cargo los datos del libro desde la BD
            CargarDatosLibro();

            // Por defecto inicio en modo visualización (no editable)
            DeshabilitarEdicion();
        }

        /// <summary>
        /// Carga los datos del libro desde la base de datos
        /// y los muestra en los controles del formulario
        /// 
        /// IMPORTANTE: El estado (Disponible/Prestado) se muestra
        /// con un label de color:
        /// - Verde "✓ Disponible" si Disponible = 1
        /// - Rojo "✗ Prestado" si Disponible = 0
        /// 
        /// Esto es más visual que un simple checkbox.
        /// </summary>
        private void CargarDatosLibro()
        {
            try
            {
                // Busco el libro por su ID
                DataTable dt = MiControlador.BuscarLibroPorId(LibroId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Cargo los datos en los TextBox
                    textBoxTitulo.Text = row["Titulo"].ToString();
                    textBoxEscritor.Text = row["Escritor"].ToString();

                    // Año de edición (puede ser NULL)
                    if (row["Ano_Edicion"] != DBNull.Value)
                        textBoxAnoEdicion.Text = row["Ano_Edicion"].ToString();
                    else
                        textBoxAnoEdicion.Text = "";

                    // Sinopsis (puede ser NULL)
                    textBoxSinopsis.Text = row["Sinopsis"] != DBNull.Value ?
                                          row["Sinopsis"].ToString() : "";

                    // Estado: Disponible o Prestado
                    // En SQLite: 0 = false (prestado), 1 = true (disponible)
                    bool disponible = false;
                    if (row["Disponible"] != DBNull.Value)
                    {
                        disponible = Convert.ToInt32(row["Disponible"]) == 1;
                    }

                    // Muestro el estado con color
                    labelEstado.Text = disponible ? "✓ Disponible" : "✗ Prestado";
                    labelEstado.ForeColor = disponible ? Color.Green : Color.Red;
                }
                else
                {
                    // El libro no existe en la BD
                    MessageBox.Show($"No se encontró el libro con ID {LibroId} en la base de datos.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer datos: {ex.Message}");
            }
        }

        /// <summary>
        /// Botón "Editar" / "Guardar" - Click
        /// 
        /// COMPORTAMIENTO DUAL:
        /// - Si NO estamos editando: Habilita la edición
        /// - Si estamos editando: Guarda los cambios
        /// 
        /// El texto del botón cambia según el modo:
        /// - Modo visualización: "Editar"
        /// - Modo edición: "Guardar"
        /// </summary>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
                GuardarCambios();
            else
                HabilitarEdicion();
        }

        /// <summary>
        /// Guarda los cambios realizados en el formulario
        /// 
        /// Validación mínima: El título no puede estar vacío.
        /// 
        /// IMPORTANTE: Mantengo el estado Disponible original.
        /// No se puede cambiar desde aquí (solo desde la lógica de préstamos).
        /// Esto evita inconsistencias en la BD.
        /// </summary>
        private void GuardarCambios()
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(textBoxTitulo.Text)) return;

                // Año de edición (opcional)
                int? ano = null;
                if (int.TryParse(textBoxAnoEdicion.Text, out int a))
                    ano = a;

                // Mantengo el estado Disponible original
                // (lo leo del labelEstado, no permito cambiarlo aquí)
                bool disp = labelEstado.Text.Contains("Disponible");

                // Creo el objeto Libro con los datos modificados
                var libro = new Libro
                {
                    Id = this.LibroId,
                    Titulo = textBoxTitulo.Text,
                    Escritor = textBoxEscritor.Text,
                    AnoEdicion = ano,
                    Sinopsis = textBoxSinopsis.Text,
                    Disponible = disp
                };

                // Guardo en la BD
                MiControlador.ModificarLibro(libro);
                MessageBox.Show("Libro guardado correctamente.");

                // Disparo el evento para que FormLibros recargue la lista
                LibroModificado?.Invoke(this, EventArgs.Empty);

                // Vuelvo a modo visualización
                DeshabilitarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        /// <summary>
        /// Botón "Cancelar" / "Cerrar" - Click
        /// 
        /// COMPORTAMIENTO DUAL:
        /// - Si estamos editando: Cancela los cambios y recarga los datos originales
        /// - Si NO estamos editando: Cierra el formulario
        /// </summary>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                CargarDatosLibro();  // Recargo datos originales (descarto cambios)
                DeshabilitarEdicion();
            }
            else
                this.Close();  // Cierro el formulario
        }

        /// <summary>
        /// Botón "Eliminar" - Click
        /// 
        /// Elimina el libro de la base de datos después de pedir confirmación.
        /// 
        /// IMPORTANTE: Solo funciona en modo visualización.
        /// En modo edición este botón está deshabilitado para evitar clicks accidentales.
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Pido confirmación
            if (MessageBox.Show("¿Eliminar este libro?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Elimino el libro de la BD
                MiControlador.EliminarLibro(LibroId);

                // Disparo el evento para que FormLibros recargue la lista
                LibroModificado?.Invoke(this, EventArgs.Empty);

                // Cierro el formulario
                this.Close();
            }
        }

        /// <summary>
        /// Habilita el modo edición
        /// 
        /// CAMBIOS VISUALES:
        /// - Campos editables (fondo blanco)
        /// - Botón "Editar" → "Guardar"
        /// - Botón "Cerrar" → "Cancelar"
        /// - Botón "Eliminar" deshabilitado
        /// </summary>
        private void HabilitarEdicion()
        {
            modoEdicion = true;
            SetReadOnly(false, Color.White);
            if (labelBtnEditar != null)
                labelBtnEditar.Text = "Guardar";
            if (labelBtnCancelar != null)
                labelBtnCancelar.Text = "Cancelar";
            if (panelBtnEliminar != null)
                panelBtnEliminar.Enabled = false;
        }

        /// <summary>
        /// Deshabilita el modo edición (vuelve a modo visualización)
        /// 
        /// CAMBIOS VISUALES:
        /// - Campos de solo lectura (fondo gris claro)
        /// - Botón "Guardar" → "Editar"
        /// - Botón "Cancelar" → "Cerrar"
        /// - Botón "Eliminar" habilitado
        /// </summary>
        private void DeshabilitarEdicion()
        {
            modoEdicion = false;
            SetReadOnly(true, Color.WhiteSmoke);
            if (labelBtnEditar != null)
                labelBtnEditar.Text = "Editar";
            if (labelBtnCancelar != null)
                labelBtnCancelar.Text = "Cerrar";
            if (panelBtnEliminar != null)
                panelBtnEliminar.Enabled = true;
        }

        /// <summary>
        /// Cambia el estado ReadOnly y el color de fondo de los campos
        /// 
        /// Esta función auxiliar evita repetir código.
        /// Aplica los cambios a todos los TextBox a la vez.
        /// 
        /// @param activado: true = ReadOnly (no editable), false = Editable
        /// @param fondo: Color de fondo de los campos
        /// </summary>
        private void SetReadOnly(bool activado, Color fondo)
        {
            textBoxTitulo.ReadOnly = activado;
            textBoxTitulo.BackColor = fondo;

            textBoxEscritor.ReadOnly = activado;
            textBoxEscritor.BackColor = fondo;

            textBoxAnoEdicion.ReadOnly = activado;
            textBoxAnoEdicion.BackColor = fondo;

            textBoxSinopsis.ReadOnly = activado;
            textBoxSinopsis.BackColor = fondo;
        }
    }
}
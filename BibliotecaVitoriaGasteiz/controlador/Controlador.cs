using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    /// <summary>
    /// Controlador principal del sistema - Patrón MVC
    /// 
    /// Esta clase actúa como "Fachada" o punto de entrada único para la lógica de negocio.
    /// Coordina la comunicación entre las Vistas (Formularios) y los Modelos (Datos).
    /// 
    /// RESPONSABILIDADES:
    /// - Instanciar los controladores específicos (Libros, Usuarios, Préstamos).
    /// - Delegar las peticiones de la interfaz al controlador correspondiente.
    /// - Centralizar la lógica para que todos los formularios compartan la misma instancia.
    /// 
    /// El Gestor (ventana principal) crea UNA instancia de este Controlador y la pasa
    /// a los formularios hijos.
    /// 
    /// Desarrollador: David
    /// Proyecto: Gestión de biblioteca del Ayuntamiento de Vitoria-Gasteiz
    /// </summary>
    public class Controlador
    {
        // Instancias de los controladores específicos o repositorios
        // En este diseño simplificado, instanciamos directamente los Repositorios/Controladores específicos
        private LibroControlador libroControlador;
        private UsuarioControlador usuarioControlador;
        private PrestamoControlador prestamoControlador;

        /// <summary>
        /// Constructor: Inicializa los submódulos del sistema.
        /// </summary>
        public Controlador()
        {
            libroControlador = new LibroControlador();
            usuarioControlador = new UsuarioControlador();
            prestamoControlador = new PrestamoControlador();
        }

        // ═══════════════════════════════════════════════════════════════════════
        #region Métodos de Gestión de Libros

        /// <summary>
        /// Registra un nuevo libro en el sistema.
        /// 
        /// NOTA SOBRE EL NOMBRE:
        /// Este método se llama 'SumarLibro' para mantener la compatibilidad con el código
        /// existente en FormLibros.cs (donde se llama así en el evento Click).
        /// Internamente delega en 'Insertar'.
        /// </summary>
        /// <param name="libro">Objeto Libro con los datos a insertar.</param>
        public void SumarLibro(Libro libro)
        {
            libroControlador.Insertar(libro);
        }

        /// <summary>
        /// Actualiza los datos de un libro existente.
        /// </summary>
        /// <param name="libro">Objeto Libro con los datos modificados e ID válido.</param>
        public void ModificarLibro(Libro libro)
        {
            libroControlador.Modificar(libro);
        }

        /// <summary>
        /// Elimina un libro del catálogo.
        /// </summary>
        /// <param name="id">Identificador del libro a borrar.</param>
        public void EliminarLibro(int id)
        {
            libroControlador.Eliminar(id);
        }

        /// <summary>
        /// Recupera el listado completo de libros.
        /// </summary>
        /// <returns>DataTable para enlazar al DataGridView.</returns>
        public DataTable ObtenerLibros()
        {
            return libroControlador.ObtenerTodos();
        }

        /// <summary>
        /// Recupera solo los libros que están disponibles para ser prestados.
        /// Utilizado para llenar el ComboBox en la pantalla de Préstamos.
        /// </summary>
        /// <returns>DataTable filtrado por Disponible=1.</returns>
        public DataTable ObtenerLibrosDisponibles()
        {
            return libroControlador.ObtenerDisponibles();
        }

        /// <summary>
        /// Busca libros que coincidan con un criterio de búsqueda (Título o Autor).
        /// </summary>
        /// <param name="termino">Texto introducido por el usuario.</param>
        /// <returns>DataTable con los resultados.</returns>
        public DataTable BuscarLibros(string termino)
        {
            return libroControlador.Buscar(termino);
        }

        /// <summary>
        /// Cambia el estado de un libro (Prestado/Disponible).
        /// Se invoca automáticamente desde la lógica de préstamos.
        /// </summary>
        public void CambiarDisponibilidadLibro(int id, bool disponible)
        {
            libroControlador.CambiarDisponibilidad(id, disponible);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Métodos de Gestión de Usuarios

        /// <summary>
        /// Registra un nuevo usuario (lector) en la biblioteca.
        /// </summary>
        public void InsertarUsuario(Usuario usuario)
        {
            usuarioControlador.Insertar(usuario);
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        public void ModificarUsuario(Usuario usuario)
        {
            usuarioControlador.Modificar(usuario);
        }

        /// <summary>
        /// Da de baja a un usuario del sistema.
        /// </summary>
        public void EliminarUsuario(int id)
        {
            usuarioControlador.Eliminar(id);
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        public DataTable ObtenerUsuarios()
        {
            return usuarioControlador.ObtenerTodos();
        }

        /// <summary>
        /// Alias para ObtenerUsuarios().
        /// Mantenido por compatibilidad con llamadas específicas desde FormPrestamos.
        /// </summary>
        public DataTable ObtenerTodosUsuarios()
        {
            return usuarioControlador.ObtenerTodos();
        }

        /// <summary>
        /// Busca usuarios por nombre o apellidos.
        /// </summary>
        public DataTable BuscarUsuarios(string termino)
        {
            return usuarioControlador.Buscar(termino);
        }

        /// <summary>
        /// Busca un usuario por su número de teléfono.
        /// </summary>
        public DataTable BuscarUsuarioPorTelefono(int telefono)
        {
            return usuarioControlador.BuscarPorTelefono(telefono);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Métodos de Gestión de Préstamos

        /// <summary>
        /// Registra un nuevo préstamo.
        /// Internamente también marca el libro como NO disponible.
        /// </summary>
        /// <param name="prestamo">Objeto Prestamo completo.</param>
        public void RealizarPrestamo(Prestamo prestamo)
        {
            prestamoControlador.RealizarPrestamo(prestamo);
        }

        /// <summary>
        /// Sobrecarga: Facilita crear un préstamo pasando datos sueltos.
        /// Convierte las fechas de DateTime a String (formato ISO) para SQLite.
        /// </summary>
        public void RealizarPrestamo(int idUsuario, int idLibro, DateTime fechaInicio, DateTime fechaFin)
        {
            Prestamo prestamo = new Prestamo
            {
                IdUsuario = idUsuario,
                IdLibro = idLibro,
                FechaInicio = fechaInicio.ToString("yyyy-MM-dd"), // Formato estándar SQL
                FechaFin = fechaFin.ToString("yyyy-MM-dd")
            };
            prestamoControlador.RealizarPrestamo(prestamo);
        }

        /// <summary>
        /// Registra la devolución de un libro.
        /// Internamente actualiza la fecha de fin y marca el libro como DISPONIBLE.
        /// </summary>
        public void DevolverLibro(int idPrestamo)
        {
            prestamoControlador.DevolverLibro(idPrestamo);
        }

        /// <summary>
        /// Elimina un registro de préstamo (gestión administrativa).
        /// </summary>
        public void EliminarPrestamo(int id)
        {
            prestamoControlador.Eliminar(id);
        }

        /// <summary>
        /// Obtiene el historial completo de préstamos.
        /// </summary>
        public DataTable ObtenerPrestamos()
        {
            return prestamoControlador.ObtenerTodos();
        }

        #endregion
    }
}
using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    /// <summary>
    /// Controlador principal del sistema - Patrón MVC
    /// 
    /// Esta clase agrupa todos los controladores específicos (Libros, Usuarios, Préstamos)
    /// siguiendo el patrón Modelo-Vista-Controlador que vimos en clase.
    /// 
    /// Al principio me costó entender el patrón MVC, pero la idea es:
    /// - MODELO: Gestiona los datos (clases Libro, Usuario, Prestamo y sus Repositorios)
    /// - VISTA: Muestra la interfaz al usuario (FormLibros, FormUsuarios, FormPrestamos)
    /// - CONTROLADOR: Coordina entre Modelo y Vista (esta clase)
    /// 
    /// El Gestor (ventana principal) crea UNA instancia de este Controlador y la comparte
    /// con todos los formularios para que todos trabajen con los mismos datos.
    /// 
    /// Desarrollador: David
    /// Proyecto: Gestión de biblioteca del Ayuntamiento de Vitoria-Gasteiz
    /// Referencia: Apuntes de clase sobre MVC
    /// </summary>
    public class Controlador
    {
        // Controladores específicos para cada entidad del sistema
        private LibroControlador libroControlador;
        private UsuarioControlador usuarioControlador;
        private PrestamoControlador prestamoControlador;

        /// <summary>
        /// Constructor: Inicializo los tres controladores específicos
        /// </summary>
        public Controlador()
        {
            libroControlador = new LibroControlador();
            usuarioControlador = new UsuarioControlador();
            prestamoControlador = new PrestamoControlador();
        }

        #region Métodos de Libros
        // Todos estos métodos delegan el trabajo al LibroControlador
        // Esta separación facilita el mantenimiento del código

        /// <summary>
        /// Inserta un nuevo libro en la base de datos
        /// </summary>
        public void InsertarLibro(Libro libro)
        {
            libroControlador.Insertar(libro);
        }

        /// <summary>
        /// Modifica un libro existente
        /// </summary>
        public void ModificarLibro(Libro libro)
        {
            libroControlador.Modificar(libro);
        }

        /// <summary>
        /// Elimina un libro por su ID
        /// </summary>
        public void EliminarLibro(int id)
        {
            libroControlador.Eliminar(id);
        }

        /// <summary>
        /// Obtiene todos los libros de la biblioteca
        /// </summary>
        public DataTable ObtenerLibros()
        {
            return libroControlador.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene solo los libros disponibles para préstamo (Disponible = 1)
        /// Usado en el ComboBox de FormPrestamos
        /// </summary>
        public DataTable ObtenerLibrosDisponibles()
        {
            return libroControlador.ObtenerDisponibles();
        }

        /// <summary>
        /// Busca un libro específico por su ID
        /// Usado en FormDetalleLibro para mostrar la información completa
        /// </summary>
        public DataTable BuscarLibroPorId(int id)
        {
            return libroControlador.BuscarPorId(id);
        }

        /// <summary>
        /// Busca libros que coincidan con el término de búsqueda
        /// Busca tanto en el título como en el nombre del escritor
        /// </summary>
        public DataTable BuscarLibros(string termino)
        {
            return libroControlador.Buscar(termino);
        }

        /// <summary>
        /// Cambia la disponibilidad de un libro (disponible/prestado)
        /// Se llama automáticamente al realizar o devolver un préstamo
        /// </summary>
        public void CambiarDisponibilidadLibro(int id, bool disponible)
        {
            libroControlador.CambiarDisponibilidad(id, disponible);
        }

        #endregion

        #region Métodos de Usuarios
        // Métodos para gestionar usuarios de la biblioteca

        /// <summary>
        /// Inserta un nuevo usuario
        /// </summary>
        public void InsertarUsuario(Usuario usuario)
        {
            usuarioControlador.Insertar(usuario);
        }

        /// <summary>
        /// Modifica un usuario existente
        /// </summary>
        public void ModificarUsuario(Usuario usuario)
        {
            usuarioControlador.Modificar(usuario);
        }

        /// <summary>
        /// Elimina un usuario por su ID
        /// </summary>
        public void EliminarUsuario(int id)
        {
            usuarioControlador.Eliminar(id);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados
        /// </summary>
        public DataTable ObtenerUsuarios()
        {
            return usuarioControlador.ObtenerTodos();
        }

        /// <summary>
        /// Alias de ObtenerUsuarios() - Lo necesito en FormPrestamos
        /// Creé este método adicional porque el ComboBox de usuarios
        /// llamaba a este nombre específicamente
        /// </summary>
        public DataTable ObtenerTodosUsuarios()
        {
            return usuarioControlador.ObtenerTodos();
        }

        /// <summary>
        /// Busca un usuario específico por su ID
        /// </summary>
        public DataTable BuscarUsuarioPorId(int id)
        {
            return usuarioControlador.BuscarPorId(id);
        }

        /// <summary>
        /// Busca usuarios que coincidan con el término
        /// Busca en nombre, apellido_1 y apellido_2
        /// </summary>
        public DataTable BuscarUsuarios(string termino)
        {
            return usuarioControlador.Buscar(termino);
        }

        /// <summary>
        /// Busca un usuario por su número de teléfono
        /// </summary>
        public DataTable BuscarUsuarioPorTelefono(int telefono)
        {
            return usuarioControlador.BuscarPorTelefono(telefono);
        }

        #endregion

        #region Métodos de Préstamos
        // La lógica de préstamos fue la parte que más me gustó desarrollar
        // Gestiona todo el ciclo: prestar libro -> marcar como no disponible -> devolver -> volver a disponible

        /// <summary>
        /// Realiza un préstamo recibiendo un objeto Prestamo completo
        /// </summary>
        public void RealizarPrestamo(Prestamo prestamo)
        {
            prestamoControlador.RealizarPrestamo(prestamo);
        }

        /// <summary>
        /// SOBRECARGA: Realiza un préstamo con parámetros individuales
        /// 
        /// Creé esta sobrecarga porque en FormPrestamos tengo los datos por separado
        /// (usuario seleccionado, libro seleccionado, fechas de los DateTimePickers)
        /// y es más cómodo pasarlos así que crear el objeto Prestamo manualmente.
        /// 
        /// Aquí convierto los DateTime a string en formato dd/MM/yyyy porque
        /// en la BD guardo las fechas como texto (lo vi en los apuntes de SQLite)
        /// </summary>
        public void RealizarPrestamo(int idUsuario, int idLibro, DateTime fechaInicio, DateTime fechaFin)
        {
            Prestamo prestamo = new Prestamo
            {
                IdUsuario = idUsuario,
                IdLibro = idLibro,
                FechaInicio = fechaInicio.ToString("dd/MM/yyyy"),
                FechaFin = fechaFin.ToString("dd/MM/yyyy")
            };
            prestamoControlador.RealizarPrestamo(prestamo);
        }

        /// <summary>
        /// Devuelve un libro prestado
        /// Actualiza la fecha de fin del préstamo y marca el libro como disponible
        /// </summary>
        public void DevolverLibro(int idPrestamo)
        {
            prestamoControlador.DevolverLibro(idPrestamo);
        }

        /// <summary>
        /// Modifica un préstamo existente
        /// </summary>
        public void ModificarPrestamo(Prestamo prestamo)
        {
            prestamoControlador.Modificar(prestamo);
        }

        /// <summary>
        /// Elimina un préstamo
        /// También devuelve el libro (lo marca como disponible) si estaba prestado
        /// </summary>
        public void EliminarPrestamo(int id)
        {
            prestamoControlador.Eliminar(id);
        }

        /// <summary>
        /// Obtiene todos los préstamos registrados
        /// </summary>
        public DataTable ObtenerPrestamos()
        {
            return prestamoControlador.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene solo los préstamos activos (libros actualmente prestados)
        /// Se usa en FormPrestamos para mostrar la tabla de préstamos en curso
        /// </summary>
        public DataTable ObtenerPrestamosActivos()
        {
            return prestamoControlador.ObtenerActivos();
        }

        /// <summary>
        /// Busca un préstamo específico por su ID
        /// </summary>
        public DataTable BuscarPrestamoPorId(int id)
        {
            return prestamoControlador.BuscarPorId(id);
        }

        /// <summary>
        /// Busca todos los préstamos de un libro específico
        /// Útil para ver el historial de préstamos de un libro
        /// </summary>
        public DataTable BuscarPrestamosPorLibro(int idLibro)
        {
            return prestamoControlador.BuscarPorLibro(idLibro);
        }

        /// <summary>
        /// Busca todos los préstamos de un usuario específico
        /// Útil para ver el historial de préstamos de un usuario
        /// </summary>
        public DataTable BuscarPrestamosPorUsuario(int idUsuario)
        {
            return prestamoControlador.BuscarPorUsuario(idUsuario);
        }

        #endregion
    }
}
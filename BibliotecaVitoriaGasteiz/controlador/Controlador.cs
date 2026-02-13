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
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria Gasteiz
    /// </summary>
    public class Controlador
    {
        // Instancias de los controladores específicos o repositorios
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

        public void SumarLibro(Libro libro)
        {
            libroControlador.Insertar(libro);
        }

        public void ModificarLibro(Libro libro)
        {
            libroControlador.Modificar(libro);
        }

        public void EliminarLibro(int id)
        {
            libroControlador.Eliminar(id);
        }

        public DataTable ObtenerLibros()
        {
            return libroControlador.ObtenerTodos();
        }

        public DataTable ObtenerLibrosDisponibles()
        {
            return libroControlador.ObtenerDisponibles();
        }

        public DataTable BuscarLibros(string termino)
        {
            return libroControlador.Buscar(termino);
        }

        public DataTable BuscarLibroPorId(int id)
        {
            return libroControlador.BuscarPorId(id);
        }

        public void CambiarDisponibilidadLibro(int id, bool disponible)
        {
            libroControlador.CambiarDisponibilidad(id, disponible);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Métodos de Gestión de Usuarios

        public void InsertarUsuario(Usuario usuario)
        {
            usuarioControlador.Insertar(usuario);
        }

        public void ModificarUsuario(Usuario usuario)
        {
            usuarioControlador.Modificar(usuario);
        }

        public void EliminarUsuario(int id)
        {
            usuarioControlador.Eliminar(id);
        }

        public DataTable ObtenerUsuarios()
        {
            return usuarioControlador.ObtenerTodos();
        }

        public DataTable ObtenerTodosUsuarios()
        {
            return usuarioControlador.ObtenerTodos();
        }

        public DataTable BuscarUsuarios(string termino)
        {
            return usuarioControlador.Buscar(termino);
        }

        public DataTable BuscarUsuarioPorTelefono(int telefono)
        {
            return usuarioControlador.BuscarPorTelefono(telefono);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════════════
        #region Métodos de Gestión de Préstamos

        public void RealizarPrestamo(Prestamo prestamo)
        {
            prestamoControlador.RealizarPrestamo(prestamo);
        }

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

        public void DevolverLibro(int idPrestamo)
        {
            prestamoControlador.DevolverLibro(idPrestamo);
        }

        public void EliminarPrestamo(int id)
        {
            prestamoControlador.Eliminar(id);
        }

        /// <summary>
        /// Obtiene el historial completo de préstamos (Devueltos y Activos).
        /// </summary>
        public DataTable ObtenerPrestamos()
        {
            return prestamoControlador.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene SOLO los préstamos que están en curso actualmente.
        /// Utilizado para el DataGrid de la vista FormPrestamos para que no salgan los "fantasmas" devueltos.
        /// </summary>
        public DataTable ObtenerPrestamosActivos()
        {
            return prestamoControlador.ObtenerActivos();
        }

        #endregion
    }
}
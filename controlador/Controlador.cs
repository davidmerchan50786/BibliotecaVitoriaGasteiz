using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    /// <summary>
    /// Controlador principal que agrupa todos los controladores del sistema
    /// </summary>
    public class Controlador
    {
        private LibroControlador libroControlador;
        private UsuarioControlador usuarioControlador;
        private PrestamoControlador prestamoControlador;

        public Controlador()
        {
            libroControlador = new LibroControlador();
            usuarioControlador = new UsuarioControlador();
            prestamoControlador = new PrestamoControlador();
        }

        #region Métodos de Libros

        public void InsertarLibro(Libro libro)
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

        public DataTable BuscarLibroPorId(int id)
        {
            return libroControlador.BuscarPorId(id);
        }

        public DataTable BuscarLibros(string termino)
        {
            return libroControlador.Buscar(termino);
        }

        public void CambiarDisponibilidadLibro(int id, bool disponible)
        {
            libroControlador.CambiarDisponibilidad(id, disponible);
        }

        #endregion

        #region Métodos de Usuarios

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

        public DataTable BuscarUsuarioPorId(int id)
        {
            return usuarioControlador.BuscarPorId(id);
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

        #region Métodos de Préstamos

        public void RealizarPrestamo(Prestamo prestamo)
        {
            prestamoControlador.RealizarPrestamo(prestamo);
        }

        public void DevolverLibro(int idPrestamo)
        {
            prestamoControlador.DevolverLibro(idPrestamo);
        }

        public void ModificarPrestamo(Prestamo prestamo)
        {
            prestamoControlador.Modificar(prestamo);
        }

        public void EliminarPrestamo(int id)
        {
            prestamoControlador.Eliminar(id);
        }

        public DataTable ObtenerPrestamos()
        {
            return prestamoControlador.ObtenerTodos();
        }

        public DataTable ObtenerPrestamosActivos()
        {
            return prestamoControlador.ObtenerActivos();
        }

        public DataTable BuscarPrestamoPorId(int id)
        {
            return prestamoControlador.BuscarPorId(id);
        }

        public DataTable BuscarPrestamosPorLibro(int idLibro)
        {
            return prestamoControlador.BuscarPorLibro(idLibro);
        }

        public DataTable BuscarPrestamosPorUsuario(int idUsuario)
        {
            return prestamoControlador.BuscarPorUsuario(idUsuario);
        }

        #endregion
    }
}

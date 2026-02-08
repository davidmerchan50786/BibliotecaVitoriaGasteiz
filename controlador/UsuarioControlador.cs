using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    public class UsuarioControlador
    {
        private RepositorioUsuario repo;

        public UsuarioControlador()
        {
            repo = new RepositorioUsuario();
        }

        public void Insertar(Usuario usuario)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.Apellido1))
                throw new Exception("El primer apellido es obligatorio");

            if (usuario.Telefono <= 0)
                throw new Exception("El teléfono no es válido");

            // Validar formato de teléfono (9 dígitos)
            string telefonoStr = usuario.Telefono.ToString();
            if (telefonoStr.Length != 9)
                throw new Exception("El teléfono debe tener 9 dígitos");

            repo.Insertar(usuario);
        }

        public void Modificar(Usuario usuario)
        {
            if (usuario.Id <= 0)
                throw new Exception("ID de usuario no válido");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.Apellido1))
                throw new Exception("El primer apellido es obligatorio");

            if (usuario.Telefono <= 0)
                throw new Exception("El teléfono no es válido");

            // Validar formato de teléfono (9 dígitos)
            string telefonoStr = usuario.Telefono.ToString();
            if (telefonoStr.Length != 9)
                throw new Exception("El teléfono debe tener 9 dígitos");

            repo.Modificar(usuario);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("ID de usuario no válido");

            // Verificar si el usuario tiene préstamos activos
            // (esto se podría mejorar con una consulta a la tabla de préstamos)

            repo.Eliminar(id);
        }

        public DataTable ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public DataTable BuscarPorId(int id)
        {
            if (id <= 0)
                throw new Exception("ID de usuario no válido");

            return repo.BuscarPorId(id);
        }

        public DataTable Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return repo.ObtenerTodos();

            return repo.Buscar(termino);
        }

        public DataTable BuscarPorTelefono(int telefono)
        {
            if (telefono <= 0)
                throw new Exception("Teléfono no válido");

            return repo.BuscarPorTelefono(telefono);
        }
    }
}

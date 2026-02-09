using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    public class LibroControlador
    {
        private RepositorioLibro repo;

        public LibroControlador()
        {
            repo = new RepositorioLibro();
        }

        public void Insertar(Libro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new Exception("El título es obligatorio");

            if (string.IsNullOrWhiteSpace(libro.Escritor))
                throw new Exception("El escritor es obligatorio");

            if (libro.AnoEdicion.HasValue)
            {
                if (libro.AnoEdicion.Value < 1 || libro.AnoEdicion.Value > DateTime.Now.Year + 1)
                    throw new Exception("El año de edición no es válido");
            }

            repo.Insertar(libro);
        }

        public void Modificar(Libro libro)
        {
            if (libro.Id < 0)
                throw new Exception("ID de libro no válido");

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new Exception("El título es obligatorio");

            if (string.IsNullOrWhiteSpace(libro.Escritor))
                throw new Exception("El escritor es obligatorio");

            if (libro.AnoEdicion.HasValue)
            {
                if (libro.AnoEdicion.Value < 1 || libro.AnoEdicion.Value > DateTime.Now.Year + 1)
                    throw new Exception("El año de edición no es válido");
            }

            repo.Modificar(libro);
        }

        public void Eliminar(int id)
        {
            if (id < 0)
                throw new Exception("ID de libro no válido");

            repo.Eliminar(id);
        }

        public DataTable ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public DataTable ObtenerDisponibles()
        {
            return repo.ObtenerDisponibles();
        }

        public DataTable BuscarPorId(int id)
        {
            if (id < 0)
                throw new Exception("ID de libro no válido");

            return repo.BuscarPorId(id);
        }

        public DataTable Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return repo.ObtenerTodos();

            return repo.Buscar(termino);
        }

        public void CambiarDisponibilidad(int id, bool disponible)
        {
            if (id < 0)
                throw new Exception("ID de libro no válido");

            repo.CambiarDisponibilidad(id, disponible);
        }
    }
}
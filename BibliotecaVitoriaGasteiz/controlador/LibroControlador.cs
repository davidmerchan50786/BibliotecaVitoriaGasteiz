using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    /// <summary>
    /// Controlador de Libros - Lógica de negocio
    /// 
    /// Valida las reglas de negocio específicas de los libros antes de enviarlos
    /// a la base de datos.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria Gasteiz
    /// </summary>
    public class LibroControlador
    {
        private RepositorioLibro repo;

        public LibroControlador()
        {
            repo = new RepositorioLibro();
        }

        /// <summary>
        /// Inserta un nuevo libro aplicando validaciones estrictas.
        /// 
        /// VALIDACIÓN DINÁMICA DEL AÑO:
        /// A diferencia de los usuarios, aquí comprobamos el año actual del sistema
        /// (DateTime.Now.Year). Permitimos hasta el año actual + 1 para abarcar 
        /// libros en preventa o ediciones que salen a principios del año siguiente.
        /// </summary>
        public void Insertar(Libro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new Exception("El título es obligatorio");

            if (string.IsNullOrWhiteSpace(libro.Escritor))
                throw new Exception("El escritor es obligatorio");

            // Ano_Edicion es int? (nullable). Solo lo validamos si el usuario lo ha rellenado.
            if (libro.Ano_Edicion.HasValue)
            {
                // Validación contra el reloj del sistema actual
                if (libro.Ano_Edicion.Value < 1 || libro.Ano_Edicion.Value > DateTime.Now.Year + 1)
                    throw new Exception("El año de edición no es válido");
            }

            repo.Insertar(libro);
        }

        /// <summary>
        /// Modifica un libro existente.
        /// 
        /// MANEJO DE IDs (-1 vs 0):
        /// (libro.ID < 0)
        /// Esto es un reflejo de la batalla técnica inicial donde usábamos "-1" como mi
        /// estado nulo/seguro para los IDs tras los problemas con sqlite_sequence.
        /// </summary>
        public void Modificar(Libro libro)
        {
            if (libro.ID < 0)
                throw new Exception("ID de libro no válido");

            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new Exception("El título es obligatorio");

            if (string.IsNullOrWhiteSpace(libro.Escritor))
                throw new Exception("El escritor es obligatorio");

            if (libro.Ano_Edicion.HasValue)
            {
                if (libro.Ano_Edicion.Value < 1 || libro.Ano_Edicion.Value > DateTime.Now.Year + 1)
                    throw new Exception("El año de edición no es válido");
            }

            repo.Modificar(libro);
        }

        public void Eliminar(int id)
        {
            if (id < 0) throw new Exception("ID de libro no válido");
            repo.Eliminar(id);
        }

        // Métodos de delegación directa al repositorio
        public DataTable ObtenerTodos() => repo.ObtenerTodos();
        public DataTable ObtenerDisponibles() => repo.ObtenerDisponibles();

        /// <summary>
        /// Búsqueda flexible. Si el usuario borra la caja de texto, 
        /// devolvemos el catálogo completo automáticamente.
        /// </summary>
        public DataTable Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return repo.ObtenerTodos();

            return repo.Buscar(termino);
        }

        public DataTable BuscarPorId(int id)
        {
            if (id < 0) throw new Exception("ID de libro no válido");
            return repo.BuscarPorId(id);
        }

        public void CambiarDisponibilidad(int id, bool disponible)
        {
            if (id < 0) throw new Exception("ID de libro no válido");
            repo.CambiarDisponibilidad(id, disponible);
        }
    }
}
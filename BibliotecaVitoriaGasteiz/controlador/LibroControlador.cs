using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    /// <summary>
    /// Controlador de Libros - Lógica de negocio
    /// 
    /// Esta clase intermedia entre la Vista (FormLibros) y el Modelo (RepositorioLibro).
    /// 
    /// Su responsabilidad principal es VALIDAR:
    /// - Que los datos sean correctos antes de guardarlos
    /// - Que se cumplan las reglas de negocio
    /// 
    /// Siguiendo el patrón MVC de los apuntes de clase:
    /// - La VISTA (FormLibros) llama a estos métodos
    /// - Este CONTROLADOR valida y coordina
    /// - El REPOSITORIO ejecuta las consultas SQL
    /// 
    /// Al principio me costó entender esta separación, pero ahora veo que
    /// mantiene el código más organizado y fácil de mantener.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public class LibroControlador
    {
        // Repositorio para acceder a los datos
        private RepositorioLibro repo;

        /// <summary>
        /// Constructor: Inicializo el repositorio
        /// </summary>
        public LibroControlador()
        {
            repo = new RepositorioLibro();
        }

        /// <summary>
        /// Inserta un nuevo libro en la biblioteca
        /// 
        /// VALIDACIONES (muy importantes):
        /// 1. Título obligatorio
        /// 2. Escritor obligatorio
        /// 3. Año de edición (si se proporciona):
        ///    - Debe ser >= 1 (no tiene sentido un año 0 o negativo)
        ///    - Debe ser <= año actual + 1 (permito un año de adelanto para libros próximos)
        /// 
        /// Si alguna validación falla, lanzo una Exception con un mensaje claro.
        /// FormLibros captura estas excepciones y las muestra al usuario.
        /// 
        /// Estas validaciones las aprendí de los apuntes de clase sobre buenas prácticas.
        /// </summary>
        public void Insertar(Libro libro)
        {
            // VALIDACIÓN 1: Título obligatorio
            if (string.IsNullOrWhiteSpace(libro.Titulo))
                throw new Exception("El título es obligatorio");

            // VALIDACIÓN 2: Escritor obligatorio
            if (string.IsNullOrWhiteSpace(libro.Escritor))
                throw new Exception("El escritor es obligatorio");

            // VALIDACIÓN 3: Año de edición (si existe)
            if (libro.AnoEdicion.HasValue)
            {
                // Año debe ser >= 1 y <= año actual + 1
                if (libro.AnoEdicion.Value < 1 || libro.AnoEdicion.Value > DateTime.Now.Year + 1)
                    throw new Exception("El año de edición no es válido");
            }

            // Si llegamos aquí, todo es válido
            repo.Insertar(libro);
        }

        /// <summary>
        /// Modifica un libro existente
        /// 
        /// Validaciones idénticas a Insertar(), pero además verifico
        /// que el ID del libro sea válido (>= 0).
        /// 
        /// NOTA: Uso >= 0 porque tuve problemas con libros con ID = 0
        /// y por eso en LibroControlador acepto 0 como válido,
        /// aunque en PrestamoControlador uso > 0.
        /// Esto lo corregí con DatabaseHelper que renumera los IDs inválidos.
        /// </summary>
        public void Modificar(Libro libro)
        {
            // VALIDACIÓN EXTRA: ID válido
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

        /// <summary>
        /// Elimina un libro de la biblioteca
        /// 
        /// VALIDACIÓN: Solo verifico que el ID sea válido.
        /// 
        /// IMPORTANTE: No verifico si el libro tiene préstamos activos.
        /// Esto podría mejorarse en el futuro para evitar eliminar libros
        /// que están prestados o tienen historial de préstamos.
        /// </summary>
        public void Eliminar(int id)
        {
            if (id < 0)
                throw new Exception("ID de libro no válido");

            repo.Eliminar(id);
        }

        /// <summary>
        /// Obtiene todos los libros de la biblioteca
        /// No necesita validaciones, simplemente delega al repositorio
        /// </summary>
        public DataTable ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene solo los libros disponibles para préstamo
        /// 
        /// Este método es el que uso en FormPrestamos para llenar
        /// el ComboBox de libros que se pueden prestar.
        /// </summary>
        public DataTable ObtenerDisponibles()
        {
            return repo.ObtenerDisponibles();
        }

        /// <summary>
        /// Busca un libro específico por su ID
        /// Validación: El ID debe ser >= 0
        /// </summary>
        public DataTable BuscarPorId(int id)
        {
            if (id < 0)
                throw new Exception("ID de libro no válido");

            return repo.BuscarPorId(id);
        }

        /// <summary>
        /// Busca libros por término de búsqueda (Título o Escritor)
        /// 
        /// Si el término está vacío, devuelvo todos los libros.
        /// Esto permite que el campo de búsqueda funcione bien:
        /// - Usuario escribe: filtra resultados
        /// - Usuario borra todo: muestra todos los libros
        /// </summary>
        public DataTable Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return repo.ObtenerTodos();

            return repo.Buscar(termino);
        }

        /// <summary>
        /// Cambia la disponibilidad de un libro
        /// 
        /// Este método se llama desde PrestamoControlador:
        /// - Al realizar un préstamo: CambiarDisponibilidad(id, false)
        /// - Al devolver un libro: CambiarDisponibilidad(id, true)
        /// 
        /// La validación solo verifica que el ID sea válido.
        /// </summary>
        public void CambiarDisponibilidad(int id, bool disponible)
        {
            if (id < 0)
                throw new Exception("ID de libro no válido");

            repo.CambiarDisponibilidad(id, disponible);
        }
    }
}
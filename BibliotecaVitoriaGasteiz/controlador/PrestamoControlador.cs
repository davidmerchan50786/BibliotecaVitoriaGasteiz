using System;
using System.Data;
using System.Globalization;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    /// <summary>
    /// Controlador de Préstamos - Gestiona toda la lógica de negocio de préstamos
    /// 
    /// Esta fue la parte que más me gustó desarrollar del proyecto.
    /// Aquí está toda la lógica para:
    /// - Validar que se pueda realizar un préstamo
    /// - Marcar libros como no disponibles al prestarlos
    /// - Devolver libros y marcarlos como disponibles de nuevo
    /// 
    /// Aplico el patrón MVC que vimos en clase:
    /// - Este controlador NO accede directamente a la BD
    /// - Usa el RepositorioPrestamo (capa de datos) para las consultas
    /// - También usa RepositorioLibro para cambiar disponibilidad
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public class PrestamoControlador
    {
        // Repositorios para acceder a los datos
        private RepositorioPrestamo repo;
        private RepositorioLibro repoLibro;

        /// <summary>
        /// Constructor: Inicializo los repositorios que necesito
        /// </summary>
        public PrestamoControlador()
        {
            repo = new RepositorioPrestamo();
            repoLibro = new RepositorioLibro();
        }

        /// <summary>
        /// Realiza un nuevo préstamo de libro
        /// 
        /// Esta es la función más importante del módulo de préstamos.
        /// Antes de insertar el préstamo en la BD, hago todas las validaciones necesarias:
        /// 1. Verifico que los IDs sean válidos
        /// 2. Compruebo que el libro existe
        /// 3. Verifico que el libro esté disponible (no prestado a otro usuario)
        /// 4. Valido que las fechas estén completas
        /// 
        /// Si todo está correcto:
        /// - Inserto el préstamo en la tabla Prestamos
        /// - Marco el libro como NO disponible (Disponible = 0)
        /// 
        /// Aprendí de los apuntes de clase que es mejor validar TODO antes de modificar la BD,
        /// así evito datos inconsistentes.
        /// </summary>
        public void RealizarPrestamo(Prestamo prestamo)
        {
            // VALIDACIÓN 1: ID de libro válido
            // Uso <= 0 porque los IDs en SQLite empiezan en 1
            if (prestamo.IdLibro <= 0)
                throw new Exception("ID de libro no válido");

            // VALIDACIÓN 2: ID de usuario válido
            if (prestamo.IdUsuario <= 0)
                throw new Exception("ID de usuario no válido");

            // VALIDACIÓN 3: Verificar que el libro existe y está disponible
            // Consulto la tabla Libros para obtener el registro completo
            DataTable dtLibro = repoLibro.BuscarPorId(prestamo.IdLibro);
            if (dtLibro.Rows.Count == 0)
                throw new Exception("El libro no existe");

            // Compruebo el campo Disponible (0 = prestado, 1 = disponible)
            // En SQLite los booleanos se guardan como INTEGER (0/1)
            bool disponible = Convert.ToBoolean(dtLibro.Rows[0]["Disponible"]);
            if (!disponible)
                throw new Exception("El libro no está disponible para préstamo");

            // VALIDACIÓN 4: Fechas obligatorias
            // Las fechas vienen como string en formato "dd/MM/yyyy" desde el Controlador
            if (string.IsNullOrWhiteSpace(prestamo.FechaInicio))
                throw new Exception("La fecha de inicio es obligatoria");

            if (string.IsNullOrWhiteSpace(prestamo.FechaFin))
                throw new Exception("La fecha de fin es obligatoria");

            // SI LLEGAMOS AQUÍ, TODO ES VÁLIDO

            // PASO 1: Insertar el préstamo en la BD
            repo.Insertar(prestamo);

            // PASO 2: Marcar el libro como NO disponible
            // Esto es fundamental: si no hago esto, el libro podría prestarse múltiples veces
            repoLibro.CambiarDisponibilidad(prestamo.IdLibro, false);
        }

        /// <summary>
        /// Devuelve un libro prestado
        /// 
        /// Cuando un usuario devuelve un libro:
        /// 1. Actualizo la fecha_fin del préstamo con la fecha actual
        /// 2. Marco el libro como disponible de nuevo (Disponible = 1)
        /// 
        /// Al principio pensé en eliminar el préstamo, pero es mejor mantenerlo
        /// para tener un historial completo de todos los préstamos realizados.
        /// </summary>
        public void DevolverLibro(int idPrestamo)
        {
            // Validación básica
            if (idPrestamo <= 0)
                throw new Exception("ID de préstamo no válido");

            // PASO 1: Obtengo los datos del préstamo actual
            // Necesito saber qué libro fue prestado para marcarlo como disponible
            DataTable dtPrestamo = repo.BuscarPorId(idPrestamo);
            if (dtPrestamo.Rows.Count == 0)
                throw new Exception("El préstamo no existe");

            int idLibro = Convert.ToInt32(dtPrestamo.Rows[0]["ID_Libro"]);

            // PASO 2: Actualizo el préstamo con la fecha de devolución actual
            // Mantengo todos los datos originales pero cambio Fecha_Fin a HOY
            Prestamo prestamo = new Prestamo
            {
                Id = idPrestamo,
                IdLibro = idLibro,
                IdUsuario = Convert.ToInt32(dtPrestamo.Rows[0]["ID_Usuario"]),
                FechaInicio = dtPrestamo.Rows[0]["Fecha_Inicio"].ToString(),
                FechaFin = DateTime.Now.ToString("dd/MM/yyyy")  // Fecha de hoy
            };

            repo.Modificar(prestamo);

            // PASO 3: Marcar el libro como disponible de nuevo
            // Ahora otro usuario puede prestarlo
            repoLibro.CambiarDisponibilidad(idLibro, true);
        }

        /// <summary>
        /// Modifica un préstamo existente
        /// Permite cambiar fechas o reasignar a otro usuario/libro
        /// (Aunque en la práctica no lo uso mucho en la interfaz)
        /// </summary>
        public void Modificar(Prestamo prestamo)
        {
            // Validaciones básicas
            if (prestamo.Id <= 0)
                throw new Exception("ID de préstamo no válido");

            if (prestamo.IdLibro <= 0)
                throw new Exception("ID de libro no válido");

            if (prestamo.IdUsuario <= 0)
                throw new Exception("ID de usuario no válido");

            if (string.IsNullOrWhiteSpace(prestamo.FechaInicio))
                throw new Exception("La fecha de inicio es obligatoria");

            if (string.IsNullOrWhiteSpace(prestamo.FechaFin))
                throw new Exception("La fecha de fin es obligatoria");

            repo.Modificar(prestamo);
        }

        /// <summary>
        /// Elimina un préstamo de la base de datos
        /// 
        /// Si el libro aún estaba marcado como prestado, lo devuelvo automáticamente
        /// para mantener la consistencia de los datos.
        /// 
        /// Esto evita que un libro quede "bloqueado" como no disponible
        /// si alguien borra un préstamo por error.
        /// </summary>
        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("ID de préstamo no válido");

            // PASO 1: Obtengo los datos del préstamo antes de eliminarlo
            // Necesito saber qué libro estaba prestado
            DataTable dtPrestamo = repo.BuscarPorId(id);
            if (dtPrestamo.Rows.Count > 0)
            {
                int idLibro = Convert.ToInt32(dtPrestamo.Rows[0]["ID_Libro"]);

                // PASO 2: Si el libro NO está disponible, lo marco como disponible
                // Esto evita que quede "colgado" como prestado sin préstamo activo
                DataTable dtLibro = repoLibro.BuscarPorId(idLibro);
                if (dtLibro.Rows.Count > 0)
                {
                    bool disponible = Convert.ToBoolean(dtLibro.Rows[0]["Disponible"]);
                    if (!disponible)
                    {
                        repoLibro.CambiarDisponibilidad(idLibro, true);
                    }
                }
            }

            // PASO 3: Elimino el préstamo
            repo.Eliminar(id);
        }

        /// <summary>
        /// Obtiene todos los préstamos registrados en el sistema
        /// Incluye préstamos antiguos ya devueltos
        /// </summary>
        public DataTable ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene solo los préstamos activos (libros actualmente prestados)
        /// 
        /// Un préstamo está activo cuando el libro correspondiente
        /// tiene Disponible = 0 en la tabla Libros.
        /// 
        /// Este método es el que uso en FormPrestamos para mostrar
        /// la tabla de préstamos en curso.
        /// </summary>
        public DataTable ObtenerActivos()
        {
            return repo.ObtenerActivos();
        }

        /// <summary>
        /// Busca un préstamo específico por su ID
        /// </summary>
        public DataTable BuscarPorId(int id)
        {
            if (id <= 0)
                throw new Exception("ID de préstamo no válido");

            return repo.BuscarPorId(id);
        }

        /// <summary>
        /// Busca todos los préstamos de un libro específico
        /// Útil para ver el historial completo de un libro
        /// </summary>
        public DataTable BuscarPorLibro(int idLibro)
        {
            if (idLibro <= 0)
                throw new Exception("ID de libro no válido");

            return repo.BuscarPorLibro(idLibro);
        }

        /// <summary>
        /// Busca todos los préstamos de un usuario específico
        /// Útil para ver qué libros ha sacado un usuario
        /// </summary>
        public DataTable BuscarPorUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("ID de usuario no válido");

            return repo.BuscarPorUsuario(idUsuario);
        }
    }
}
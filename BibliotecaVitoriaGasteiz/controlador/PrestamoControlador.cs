using System;
using System.Data;
using System.Globalization;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    public class PrestamoControlador
    {
        private RepositorioPrestamo repo;
        private RepositorioLibro repoLibro;

        public PrestamoControlador()
        {
            repo = new RepositorioPrestamo();
            repoLibro = new RepositorioLibro();
        }

        public void RealizarPrestamo(Prestamo prestamo)
        {
            // Validaciones de negocio
            if (prestamo.IdLibro <= 0)
                throw new Exception("ID de libro no válido");

            if (prestamo.IdUsuario <= 0)
                throw new Exception("ID de usuario no válido");

            // Verificar que el libro esté disponible
            DataTable dtLibro = repoLibro.BuscarPorId(prestamo.IdLibro);
            if (dtLibro.Rows.Count == 0)
                throw new Exception("El libro no existe");

            bool disponible = Convert.ToBoolean(dtLibro.Rows[0]["Disponible"]);
            if (!disponible)
                throw new Exception("El libro no está disponible para préstamo");

            // Validar fechas
            if (string.IsNullOrWhiteSpace(prestamo.FechaInicio))
                throw new Exception("La fecha de inicio es obligatoria");

            if (string.IsNullOrWhiteSpace(prestamo.FechaFin))
                throw new Exception("La fecha de fin es obligatoria");

            // Insertar préstamo
            repo.Insertar(prestamo);

            // Cambiar disponibilidad del libro a false
            repoLibro.CambiarDisponibilidad(prestamo.IdLibro, false);
        }

        public void DevolverLibro(int idPrestamo)
        {
            if (idPrestamo <= 0)
                throw new Exception("ID de préstamo no válido");

            // Obtener datos del préstamo
            DataTable dtPrestamo = repo.BuscarPorId(idPrestamo);
            if (dtPrestamo.Rows.Count == 0)
                throw new Exception("El préstamo no existe");

            int idLibro = Convert.ToInt32(dtPrestamo.Rows[0]["ID_Libro"]);

            // Actualizar fecha de fin del préstamo
            Prestamo prestamo = new Prestamo
            {
                Id = idPrestamo,
                IdLibro = idLibro,
                IdUsuario = Convert.ToInt32(dtPrestamo.Rows[0]["ID_Usuario"]),
                FechaInicio = dtPrestamo.Rows[0]["Fecha_Inicio"].ToString(),
                FechaFin = DateTime.Now.ToString("dd/MM/yyyy")
            };

            repo.Modificar(prestamo);

            // Cambiar disponibilidad del libro a true
            repoLibro.CambiarDisponibilidad(idLibro, true);
        }

        public void Modificar(Prestamo prestamo)
        {
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

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("ID de préstamo no válido");

            // Obtener datos del préstamo antes de eliminar
            DataTable dtPrestamo = repo.BuscarPorId(id);
            if (dtPrestamo.Rows.Count > 0)
            {
                int idLibro = Convert.ToInt32(dtPrestamo.Rows[0]["ID_Libro"]);

                // Si el libro no está disponible, devolverlo
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

            repo.Eliminar(id);
        }

        public DataTable ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public DataTable ObtenerActivos()
        {
            return repo.ObtenerActivos();
        }

        public DataTable BuscarPorId(int id)
        {
            if (id <= 0)
                throw new Exception("ID de préstamo no válido");

            return repo.BuscarPorId(id);
        }

        public DataTable BuscarPorLibro(int idLibro)
        {
            if (idLibro <= 0)
                throw new Exception("ID de libro no válido");

            return repo.BuscarPorLibro(idLibro);
        }

        public DataTable BuscarPorUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("ID de usuario no válido");

            return repo.BuscarPorUsuario(idUsuario);
        }
    }
}

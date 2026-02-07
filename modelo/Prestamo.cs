using System;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public class Prestamo
    {
        public Prestamo() { }

        public Prestamo(int idLibro, int idUsuario, string fechaInicio, string fechaFin)
        {
            this.IdLibro = idLibro;
            this.IdUsuario = idUsuario;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
        }

        public Prestamo(int id, int idLibro, int idUsuario, string fechaInicio, string fechaFin)
        {
            this.Id = id;
            this.IdLibro = idLibro;
            this.IdUsuario = idUsuario;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
        }

        public int Id { get; set; }
        public int IdLibro { get; set; }
        public int IdUsuario { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        // Para mostrar en la vista (se llenan con JOIN en consultas)
        public string TituloLibro { get; set; }
        public string NombreUsuario { get; set; }
    }
}

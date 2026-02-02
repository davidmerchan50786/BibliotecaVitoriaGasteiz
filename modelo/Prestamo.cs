using System;

namespace Proyecto_compartido_biblioteca.modelo
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

        public int Id { get; set; }
        public int IdLibro { get; set; }
        public int IdUsuario { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        //para mostrar en la vista (se llenan con JOIN)
        public string TituloLibro { get; set; }
        public string NombreUsuario { get; set; }
    }
}
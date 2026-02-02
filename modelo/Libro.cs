using System;

namespace Proyecto_compartido_biblioteca.modelo
{
    public class Libro
    {
        public Libro() { }

        public Libro(string titulo, string escritor, int? anoEdicion, string sinopsis, bool disponible)
        {
            this.Titulo = titulo;
            this.Escritor = escritor;
            this.AnoEdicion = anoEdicion;
            this.Sinopsis = sinopsis;
            this.Disponible = disponible;
        }

        public Libro(int id, string titulo, string escritor, int? anoEdicion, string sinopsis, bool disponible)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Escritor = escritor;
            this.AnoEdicion = anoEdicion;
            this.Sinopsis = sinopsis;
            this.Disponible = disponible;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Escritor { get; set; }
        public int? AnoEdicion { get; set; }
        public string Sinopsis { get; set; }
        public bool Disponible { get; set; }
    }
}
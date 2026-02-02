using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
        public int NumeroEjemplares { get; set; }
        public int EjemplaresDisponibles { get; set; }
    }
}

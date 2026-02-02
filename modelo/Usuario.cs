using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellidos}";

        public Usuario()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BibliotecaVitoriaGasteiz.modelo
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int UsuarioId { get; set; }
        public int NumeroEjemplar { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
        public string Estado { get; set; }

        // Navegación
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }

        // Propiedades calculadas
        public int DiasRetraso
        {
            get
            {
                if (Estado != "Activo") return 0;
                return DateTime.Now > FechaDevolucionEsperada
                    ? (DateTime.Now - FechaDevolucionEsperada).Days
                    : 0;
            }
        }

        public string MensajeAlerta
        {
            get
            {
                if (Estado != "Activo") return Estado;
                if (DiasRetraso > 0) return $"Retraso de {DiasRetraso} días";
                return "En plazo";
            }
        }

        public Prestamo()
        {
            FechaPrestamo = DateTime.Now;
            FechaDevolucionEsperada = DateTime.Now.AddDays(14);
            Estado = "Activo";
        }
    }
}

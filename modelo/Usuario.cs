using System;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string nombre, string apellido1, string apellido2, int telefono)
        {
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
            this.Telefono = telefono;
        }

        public Usuario(int id, string nombre, string apellido1, string apellido2, int telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
            this.Telefono = telefono;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Telefono { get; set; }

        // Para mostrar nombre completo en vistas
        public string NombreCompleto => $"{Nombre} {Apellido1} {Apellido2}".Trim();
    }
}

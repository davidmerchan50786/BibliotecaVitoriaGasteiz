using System;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Modelo que representa un Usuario en el sistema.
    /// 
    /// Mapea la tabla 'Usuarios' de SQLite.
    /// 
    /// DIFERENCIAS CON LIBRO:
    /// - Incorpora lógica de presentación directamente en el modelo a través 
    ///   de la propiedad 'NombreCompleto', lo que descarga a las vistas de 
    ///   hacer concatenaciones.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria-Gasteiz
    /// </summary>
    public class Usuario
    {
        public Usuario() { }

        // Constructor para INSERTAR (sin ID)
        public Usuario(string nombre, string apellido1, string apellido2, int telefono)
        {
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
            this.Telefono = telefono;
        }

        // Constructor para LEER/MODIFICAR (con ID)
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

        // El Apellido2 puede ser nulo en BD, en C# lo manejamos como un string que puede estar vacío
        public string Apellido2 { get; set; }
        public int Telefono { get; set; }

        /// <summary>
        /// Propiedad calculada (Solo lectura).
        /// No existe en la base de datos. Se genera al vuelo usando interpolación de strings ($"").
        /// El método .Trim() final es crucial: si Apellido2 está vacío, evita que quede 
        /// un espacio en blanco feo al final del nombre en la interfaz.
        /// </summary>
        public string NombreCompleto => $"{Nombre} {Apellido1} {Apellido2}".Trim();
    }
}
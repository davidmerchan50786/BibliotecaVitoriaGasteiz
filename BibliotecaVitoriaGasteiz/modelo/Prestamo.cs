using System;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Modelo que representa un Préstamo en el sistema.
    /// 
    /// Mapea la tabla 'Prestamos' de SQLite, pero además actúa como DTO 
    /// (Data Transfer Object) para la interfaz.
    /// 
    /// DIFERENCIAS CLAVE:
    /// 1. FECHAS: Se manejan como 'string' (TEXT en SQLite) en lugar de 'DateTime'. 
    ///    Esto simplifica la inserción y lectura directa según el formato "dd/MM/yyyy".
    /// 2. CAMPOS VIRTUALES: Contiene propiedades que NO existen en su tabla, 
    ///    sino que se rellenan con los JOINs de Libros y Usuarios.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria-Gasteiz
    /// </summary>
    public class Prestamo
    {
        public Prestamo() { }

        // Constructor para INSERTAR (sin ID)
        public Prestamo(int idLibro, int idUsuario, string fechaInicio, string fechaFin)
        {
            this.IdLibro = idLibro;
            this.IdUsuario = idUsuario;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
        }

        // Constructor para LEER/MODIFICAR (con ID)
        public Prestamo(int id, int idLibro, int idUsuario, string fechaInicio, string fechaFin)
        {
            this.Id = id;
            this.IdLibro = idLibro;
            this.IdUsuario = idUsuario;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
        }

        public int Id { get; set; }

        // Claves foráneas (Foreign Keys)
        public int IdLibro { get; set; }
        public int IdUsuario { get; set; }

        // Las fechas en SQLite se suelen guardar como TEXT. 
        // Mantenerlas como string en C# evita problemas de parseo si el formato es consistente.
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        /// <summary>
        /// CAMPOS PARA LA VISTA (No mapean directamente a columnas de la tabla Prestamos)
        /// 
        /// Estos campos se rellenan exclusivamente cuando el Repositorio hace un 
        /// SELECT con INNER JOIN. Permiten mostrar datos legibles en el DataGridView 
        /// en lugar de mostrar simplemente "ID_Libro: 4".
        /// </summary>
        public string TituloLibro { get; set; }
        public string NombreUsuario { get; set; }
    }
}
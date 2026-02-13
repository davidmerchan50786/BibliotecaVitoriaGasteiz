using System;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Modelo que representa un Libro en el sistema.
    /// 
    /// Esta clase mapea la estructura
    /// de la tabla 'Libros' de la base de datos SQLite.
    /// 
    /// CORRECCIÓN DE ERRORES:
    /// He ajustado los nombres de las propiedades (ID, Ano_Edicion) para que
    /// coincidan EXACTAMENTE con las columnas de la base de datos y evitar
    /// los errores de compilación que tenía antes.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria-Gasteiz
    /// </summary>
    public class Libro
    {
        // Constructor vacío necesario para la serialización y creación básica.
        public Libro() { }

        // Constructor para INSERTAR un nuevo libro (sin ID).
        // El ID se genera automáticamente en la base de datos (AUTOINCREMENT).
        
        public Libro(string titulo, string escritor, int? ano_edicion, string sinopsis, bool disponible)
        {
            this.Titulo = titulo;
            this.Escritor = escritor;
            this.Ano_Edicion = ano_edicion;
            this.Sinopsis = sinopsis;
            this.Disponible = disponible;
        }

        // Constructor para LEER/MODIFICAR un libro existente (con ID).
        // Se usa cuando recuperamos datos desde la BD para mostrarlos en el DataGridView.
        
        public Libro(int id, string titulo, string escritor, int? ano_edicion, string sinopsis, bool disponible)
        {
            this.ID = id;
            this.Titulo = titulo;
            this.Escritor = escritor;
            this.Ano_Edicion = ano_edicion;
            this.Sinopsis = sinopsis;
            this.Disponible = disponible;
        }

        // Identificador único del libro (Primary Key)
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Escritor { get; set; }

        // Año de edición. Es nullable (int?) porque la BD permite NULL.
        public int? Ano_Edicion { get; set; }

        public string Sinopsis { get; set; }

        /// <summary>
        /// Estado del libro.
        /// En C# es bool (true/false), pero en SQLite se guarda como INTEGER (1/0).
        /// El repo se encarga de esta conversión.
        /// </summary>
        public bool Disponible { get; set; }

    }
}
using System;

namespace BibliotecaVitoriaGasteiz.modelo
{
    /// <summary>
    /// Modelo que representa un Libro en el sistema.
    /// 
    /// Esta clase es un POCO (Plain Old CLR Object) que mapea la estructura
    /// de la tabla 'Libros' de la base de datos SQLite.
    /// 
    /// CORRECCIÓN DE ERRORES:
    /// He ajustado los nombres de las propiedades (ID, Ano_Edicion) para que
    /// coincidan EXACTAMENTE con las columnas de la base de datos y evitar
    /// los errores de compilación que tenía antes.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public class Libro
    {
        // ???????????????????????????????????????????????????????????????????????
        #region Constructores

        /// <summary>
        /// Constructor vacío necesario para la serialización y creación básica.
        /// </summary>
        public Libro() { }

        /// <summary>
        /// Constructor para INSERTAR un nuevo libro (sin ID).
        /// El ID se genera automáticamente en la base de datos (AUTOINCREMENT).
        /// </summary>
        /// <param name="titulo">Título del libro (Obligatorio)</param>
        /// <param name="escritor">Autor del libro (Obligatorio)</param>
        /// <param name="ano_edicion">Año de publicación (Opcional, puede ser null)</param>
        /// <param name="sinopsis">Breve descripción (Opcional)</param>
        /// <param name="disponible">Estado inicial (true = disponible)</param>
        public Libro(string titulo, string escritor, int? ano_edicion, string sinopsis, bool disponible)
        {
            this.Titulo = titulo;
            this.Escritor = escritor;
            this.Ano_Edicion = ano_edicion;
            this.Sinopsis = sinopsis;
            this.Disponible = disponible;
        }

        /// <summary>
        /// Constructor para LEER/MODIFICAR un libro existente (con ID).
        /// Se usa cuando recuperamos datos desde la BD para mostrarlos en el DataGridView.
        /// </summary>
        public Libro(int id, string titulo, string escritor, int? ano_edicion, string sinopsis, bool disponible)
        {
            this.ID = id;
            this.Titulo = titulo;
            this.Escritor = escritor;
            this.Ano_Edicion = ano_edicion;
            this.Sinopsis = sinopsis;
            this.Disponible = disponible;
        }

        #endregion

        // ???????????????????????????????????????????????????????????????????????
        #region Propiedades (Mapeo BD)

        /// <summary>
        /// Identificador único del libro (Primary Key).
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Título de la obra.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Autor o escritor del libro.
        /// </summary>
        public string Escritor { get; set; }

        /// <summary>
        /// Año de edición. Es nullable (int?) porque la BD permite NULL.
        /// </summary>
        public int? Ano_Edicion { get; set; }

        /// <summary>
        /// Sinopsis o resumen del contenido.
        /// </summary>
        public string Sinopsis { get; set; }

        /// <summary>
        /// Estado del libro.
        /// En C# es bool (true/false), pero en SQLite se guarda como INTEGER (1/0).
        /// El repositorio se encarga de esta conversión.
        /// </summary>
        public bool Disponible { get; set; }

        #endregion
    }
}
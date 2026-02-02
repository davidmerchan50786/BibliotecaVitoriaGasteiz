using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVitoriaGasteiz.modelo;




namespace BibliotecaVitoriaGasteiz.controlador
{
    public class Controlador
    {
        public void InsertarLibro(string titulo, string autor)
        {
            if (string.IsNullOrEmpty(titulo))
                throw new Exception("El título es obligatorio");

            if (string.IsNullOrEmpty(autor))
                throw new Exception("El autor es obligatorio");

            Datos.Libros.Add(new Libro
            {
                Titulo = titulo,
                Autor = autor,
                Disponible = true
            });
        }

        public void InsertarUsuario(string nombre, string email)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("El nombre es obligatorio");

            Datos.Usuarios.Add(new Usuario
            {
                Nombre = nombre,
                Email = email
            });
        }

        public void CargarDatosIniciales()
        {
            Datos.CargarDatosIniciales();
        }
    }
}
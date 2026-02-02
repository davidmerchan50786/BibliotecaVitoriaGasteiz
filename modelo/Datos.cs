using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVitoriaGasteiz.modelo
{
    public static class Datos
    {
        public static List<Libro> Libros = new List<Libro>();
        public static List<Usuario> Usuarios = new List<Usuario>();
        public static List<Prestamo> Prestamos = new List<Prestamo>();

        public static void CargarDatosIniciales()
        {
            CargarLibros();
            CargarUsuarios();
            CargarPrestamos();
        }

        private static void CargarLibros()
        {
            // Literatura clásica española
            Libros.Add(new Libro
            {
                Id = 1,
                Titulo = "Don Quijote de la Mancha",
                Autor = "Miguel de Cervantes",
                ISBN = "978-84-376-0494-7",
                Descripcion = "La obra cumbre de la literatura española. Las aventuras del ingenioso hidalgo manchego y su fiel escudero Sancho Panza.",
                Disponible = true,
                NumeroEjemplares = 8,
                EjemplaresDisponibles = 5
            });

            Libros.Add(new Libro
            {
                Id = 2,
                Titulo = "La Regenta",
                Autor = "Leopoldo Alas 'Clarín'",
                ISBN = "978-84-376-1876-0",
                Descripcion = "Obra maestra del realismo español. La historia de Ana Ozores en la Vetusta del siglo XIX.",
                Disponible = true,
                NumeroEjemplares = 4,
                EjemplaresDisponibles = 3
            });

            // Literatura vasca
            Libros.Add(new Libro
            {
                Id = 3,
                Titulo = "Obabakoak",
                Autor = "Bernardo Atxaga",
                ISBN = "978-84-204-8280-0",
                Descripcion = "Colección de relatos del escritor vasco más internacional. Una obra que entrelaza historias con maestría.",
                Disponible = true,
                NumeroEjemplares = 6,
                EjemplaresDisponibles = 4
            });

            Libros.Add(new Libro
            {
                Id = 4,
                Titulo = "Patria",
                Autor = "Fernando Aramburu",
                ISBN = "978-84-8383-075-2",
                Descripcion = "Novela sobre el terrorismo y sus consecuencias en el País Vasco. Un retrato humano y conmovedor.",
                Disponible = false,
                NumeroEjemplares = 10,
                EjemplaresDisponibles = 0
            });

            Libros.Add(new Libro
            {
                Id = 5,
                Titulo = "El hijo del acordeonista",
                Autor = "Bernardo Atxaga",
                ISBN = "978-84-204-6892-7",
                Descripcion = "Una historia ambientada en California, Nevada y el País Vasco que explora la identidad y las raíces.",
                Disponible = true,
                NumeroEjemplares = 5,
                EjemplaresDisponibles = 3
            });

            // Literatura internacional
            Libros.Add(new Libro
            {
                Id = 6,
                Titulo = "El principito",
                Autor = "Antoine de Saint-Exupéry",
                ISBN = "978-84-204-8565-8",
                Descripcion = "Fábula mítica y relato filosófico que cuestiona la relación del ser humano con su prójimo y con el mundo.",
                Disponible = true,
                NumeroEjemplares = 12,
                EjemplaresDisponibles = 8
            });

            Libros.Add(new Libro
            {
                Id = 7,
                Titulo = "1984",
                Autor = "George Orwell",
                ISBN = "978-84-9759-682-5",
                Descripcion = "Distopía visionaria sobre el totalitarismo y la manipulación de la verdad. Una obra más relevante que nunca.",
                Disponible = true,
                NumeroEjemplares = 7,
                EjemplaresDisponibles = 4
            });

            Libros.Add(new Libro
            {
                Id = 8,
                Titulo = "Cien años de soledad",
                Autor = "Gabriel García Márquez",
                ISBN = "978-84-376-0494-7",
                Descripcion = "La saga de la familia Buendía en Macondo. Obra cumbre del realismo mágico latinoamericano.",
                Disponible = true,
                NumeroEjemplares = 9,
                EjemplaresDisponibles = 6
            });

            // Historia y cultura vasca
            Libros.Add(new Libro
            {
                Id = 9,
                Titulo = "Historia del País Vasco",
                Autor = "Fernando García de Cortázar",
                ISBN = "978-84-8383-920-5",
                Descripcion = "Recorrido completo por la historia vasca desde sus orígenes hasta la actualidad.",
                Disponible = true,
                NumeroEjemplares = 5,
                EjemplaresDisponibles = 4
            });

            Libros.Add(new Libro
            {
                Id = 10,
                Titulo = "Vitoria-Gasteiz: Capital del Green",
                Autor = "Luis Ángel Sanz",
                ISBN = "978-84-9082-345-1",
                Descripcion = "Un recorrido por la ciudad que fue Capital Verde Europea 2012. Arquitectura, naturaleza y sostenibilidad.",
                Disponible = true,
                NumeroEjemplares = 8,
                EjemplaresDisponibles = 7
            });

            // Literatura contemporánea
            Libros.Add(new Libro
            {
                Id = 11,
                Titulo = "La sombra del viento",
                Autor = "Carlos Ruiz Zafón",
                ISBN = "978-84-08-04690-4",
                Descripcion = "Misterio y aventura en la Barcelona de posguerra. El inicio de la saga del Cementerio de los Libros Olvidados.",
                Disponible = true,
                NumeroEjemplares = 6,
                EjemplaresDisponibles = 2
            });

            Libros.Add(new Libro
            {
                Id = 12,
                Titulo = "Tokio Blues",
                Autor = "Haruki Murakami",
                ISBN = "978-84-8310-854-1",
                Descripcion = "Una historia de amor, pérdida y búsqueda de identidad en el Japón de los años 60.",
                Disponible = false,
                NumeroEjemplares = 4,
                EjemplaresDisponibles = 0
            });

            // Ciencia y divulgación
            Libros.Add(new Libro
            {
                Id = 13,
                Titulo = "Sapiens: De animales a dioses",
                Autor = "Yuval Noah Harari",
                ISBN = "978-84-9992-525-1",
                Descripcion = "Una breve historia de la humanidad que cuestiona todo lo que sabíamos sobre nosotros mismos.",
                Disponible = true,
                NumeroEjemplares = 8,
                EjemplaresDisponibles = 5
            });

            Libros.Add(new Libro
            {
                Id = 14,
                Titulo = "Cosmos",
                Autor = "Carl Sagan",
                ISBN = "978-84-08-00647-3",
                Descripcion = "Un viaje por el universo que cambió nuestra forma de ver el cosmos y nuestro lugar en él.",
                Disponible = true,
                NumeroEjemplares = 5,
                EjemplaresDisponibles = 4
            });

            // Literatura juvenil
            Libros.Add(new Libro
            {
                Id = 15,
                Titulo = "Harry Potter y la piedra filosofal",
                Autor = "J.K. Rowling",
                ISBN = "978-84-9838-336-3",
                Descripcion = "El inicio de la saga del joven mago que conquistó al mundo entero. Magia, amistad y aventura.",
                Disponible = true,
                NumeroEjemplares = 15,
                EjemplaresDisponibles = 10
            });
        }

        private static void CargarUsuarios()
        {
            // Usuarios de diferentes perfiles
            Usuarios.Add(new Usuario
            {
                Id = 1,
                Nombre = "Iker",
                Apellidos = "Aguirre Fernández",
                Email = "iker.aguirre@vitoria-gasteiz.org",
                Telefono = "945123456",
                FechaRegistro = new DateTime(2023, 3, 15),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 2,
                Nombre = "Amaia",
                Apellidos = "Etxeberria Zubieta",
                Email = "amaia.etxeberria@gmail.com",
                Telefono = "945234567",
                FechaRegistro = new DateTime(2023, 5, 20),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 3,
                Nombre = "Mikel",
                Apellidos = "López Arana",
                Email = "mikel.lopez@hotmail.com",
                Telefono = "945345678",
                FechaRegistro = new DateTime(2023, 7, 10),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 4,
                Nombre = "Leire",
                Apellidos = "Gómez Garrido",
                Email = "leire.gomez@euskalnet.net",
                Telefono = "945456789",
                FechaRegistro = new DateTime(2023, 9, 5),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 5,
                Nombre = "Jon",
                Apellidos = "Martínez Urrutia",
                Email = "jon.martinez@yahoo.es",
                Telefono = "945567890",
                FechaRegistro = new DateTime(2024, 1, 12),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 6,
                Nombre = "Nerea",
                Apellidos = "Saenz de Lacuesta",
                Email = "nerea.saenz@outlook.com",
                Telefono = "945678901",
                FechaRegistro = new DateTime(2024, 2, 28),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 7,
                Nombre = "Aitor",
                Apellidos = "Ibáñez Goikoetxea",
                Email = "aitor.ibanez@egibide.org",
                Telefono = "945789012",
                FechaRegistro = new DateTime(2024, 4, 8),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 8,
                Nombre = "Maite",
                Apellidos = "Rodríguez Alonso",
                Email = "maite.rodriguez@gmail.com",
                Telefono = "945890123",
                FechaRegistro = new DateTime(2024, 6, 15),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 9,
                Nombre = "Unai",
                Apellidos = "García Mendizábal",
                Email = "unai.garcia@ucam.edu",
                Telefono = "945901234",
                FechaRegistro = new DateTime(2024, 8, 22),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 10,
                Nombre = "Ainara",
                Apellidos = "Sánchez Ortiz",
                Email = "ainara.sanchez@icloud.com",
                Telefono = "945012345",
                FechaRegistro = new DateTime(2024, 10, 30),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 11,
                Nombre = "Gorka",
                Apellidos = "Pérez Aranzabal",
                Email = "gorka.perez@live.com",
                Telefono = "945112345",
                FechaRegistro = new DateTime(2024, 11, 18),
                Activo = true
            });

            Usuarios.Add(new Usuario
            {
                Id = 12,
                Nombre = "Ane",
                Apellidos = "Fernández Berasategi",
                Email = "ane.fernandez@proton.me",
                Telefono = "945223456",
                FechaRegistro = new DateTime(2025, 1, 5),
                Activo = true
            });
        }

        private static void CargarPrestamos()
        {
            // Préstamos activos
            Prestamos.Add(new Prestamo
            {
                Id = 1,
                LibroId = 4,
                UsuarioId = 1,
                NumeroEjemplar = 3,
                FechaPrestamo = new DateTime(2025, 12, 20),
                FechaDevolucionEsperada = new DateTime(2026, 1, 3),
                FechaDevolucionReal = null,
                Estado = "Activo",
                Libro = Libros.Find(l => l.Id == 4),
                Usuario = Usuarios.Find(u => u.Id == 1)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 2,
                LibroId = 4,
                UsuarioId = 3,
                NumeroEjemplar = 5,
                FechaPrestamo = new DateTime(2025, 12, 28),
                FechaDevolucionEsperada = new DateTime(2026, 1, 11),
                FechaDevolucionReal = null,
                Estado = "Activo",
                Libro = Libros.Find(l => l.Id == 4),
                Usuario = Usuarios.Find(u => u.Id == 3)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 3,
                LibroId = 12,
                UsuarioId = 5,
                NumeroEjemplar = 2,
                FechaPrestamo = new DateTime(2026, 1, 2),
                FechaDevolucionEsperada = new DateTime(2026, 1, 16),
                FechaDevolucionReal = null,
                Estado = "Activo",
                Libro = Libros.Find(l => l.Id == 12),
                Usuario = Usuarios.Find(u => u.Id == 5)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 4,
                LibroId = 11,
                UsuarioId = 7,
                NumeroEjemplar = 4,
                FechaPrestamo = new DateTime(2026, 1, 5),
                FechaDevolucionEsperada = new DateTime(2026, 1, 19),
                FechaDevolucionReal = null,
                Estado = "Activo",
                Libro = Libros.Find(l => l.Id == 11),
                Usuario = Usuarios.Find(u => u.Id == 7)
            });

            // Préstamo con retraso leve
            Prestamos.Add(new Prestamo
            {
                Id = 5,
                LibroId = 1,
                UsuarioId = 2,
                NumeroEjemplar = 6,
                FechaPrestamo = new DateTime(2025, 12, 15),
                FechaDevolucionEsperada = new DateTime(2025, 12, 29),
                FechaDevolucionReal = null,
                Estado = "Activo",
                Libro = Libros.Find(l => l.Id == 1),
                Usuario = Usuarios.Find(u => u.Id == 2)
            });

            // Préstamo con retraso importante
            Prestamos.Add(new Prestamo
            {
                Id = 6,
                LibroId = 11,
                UsuarioId = 4,
                NumeroEjemplar = 1,
                FechaPrestamo = new DateTime(2025, 12, 1),
                FechaDevolucionEsperada = new DateTime(2025, 12, 15),
                FechaDevolucionReal = null,
                Estado = "Activo",
                Libro = Libros.Find(l => l.Id == 11),
                Usuario = Usuarios.Find(u => u.Id == 4)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 7,
                LibroId = 6,
                UsuarioId = 9,
                NumeroEjemplar = 8,
                FechaPrestamo = new DateTime(2026, 1, 8),
                FechaDevolucionEsperada = new DateTime(2026, 1, 22),
                FechaDevolucionReal = null,
                Estado = "Activo",
                Libro = Libros.Find(l => l.Id == 6),
                Usuario = Usuarios.Find(u => u.Id == 9)
            });

            // Préstamos devueltos (historial)
            Prestamos.Add(new Prestamo
            {
                Id = 8,
                LibroId = 6,
                UsuarioId = 1,
                NumeroEjemplar = 3,
                FechaPrestamo = new DateTime(2025, 11, 10),
                FechaDevolucionEsperada = new DateTime(2025, 11, 24),
                FechaDevolucionReal = new DateTime(2025, 11, 22),
                Estado = "Devuelto",
                Libro = Libros.Find(l => l.Id == 6),
                Usuario = Usuarios.Find(u => u.Id == 1)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 9,
                LibroId = 8,
                UsuarioId = 6,
                NumeroEjemplar = 2,
                FechaPrestamo = new DateTime(2025, 11, 5),
                FechaDevolucionEsperada = new DateTime(2025, 11, 19),
                FechaDevolucionReal = new DateTime(2025, 11, 25),
                Estado = "Devuelto con retraso",
                Libro = Libros.Find(l => l.Id == 8),
                Usuario = Usuarios.Find(u => u.Id == 6)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 10,
                LibroId = 15,
                UsuarioId = 8,
                NumeroEjemplar = 12,
                FechaPrestamo = new DateTime(2025, 12, 12),
                FechaDevolucionEsperada = new DateTime(2025, 12, 26),
                FechaDevolucionReal = new DateTime(2025, 12, 24),
                Estado = "Devuelto",
                Libro = Libros.Find(l => l.Id == 15),
                Usuario = Usuarios.Find(u => u.Id == 8)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 11,
                LibroId = 13,
                UsuarioId = 10,
                NumeroEjemplar = 1,
                FechaPrestamo = new DateTime(2025, 12, 18),
                FechaDevolucionEsperada = new DateTime(2026, 1, 1),
                FechaDevolucionReal = new DateTime(2025, 12, 30),
                Estado = "Devuelto",
                Libro = Libros.Find(l => l.Id == 13),
                Usuario = Usuarios.Find(u => u.Id == 10)
            });

            Prestamos.Add(new Prestamo
            {
                Id = 12,
                LibroId = 7,
                UsuarioId = 11,
                NumeroEjemplar = 3,
                FechaPrestamo = new DateTime(2025, 11, 28),
                FechaDevolucionEsperada = new DateTime(2025, 12, 12),
                FechaDevolucionReal = new DateTime(2025, 12, 10),
                Estado = "Devuelto",
                Libro = Libros.Find(l => l.Id == 7),
                Usuario = Usuarios.Find(u => u.Id == 11)
            });
        }
    }
}

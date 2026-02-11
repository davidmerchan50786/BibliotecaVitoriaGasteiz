using System;
using System.Data;
using BibliotecaVitoriaGasteiz.modelo;

namespace BibliotecaVitoriaGasteiz.controlador
{
    /// <summary>
    /// Controlador de Usuarios - Lógica de negocio
    /// 
    /// Esta clase intermedia entre la Vista (FormUsuarios) y el Modelo (RepositorioUsuario).
    /// 
    /// Su responsabilidad principal es VALIDAR los datos de los usuarios:
    /// - Nombre y Apellido_1 obligatorios
    /// - Teléfono con formato español (9 dígitos exactos)
    /// 
    /// VALIDACIÓN IMPORTANTE DEL TELÉFONO:
    /// En España, los teléfonos tienen 9 dígitos:
    /// - Móviles: empiezan por 6 o 7 (ej: 612345678)
    /// - Fijos: empiezan por 9 (ej: 945123456)
    /// 
    /// Esta validación la vi en ejemplos de la documentación de Microsoft
    /// y en los apuntes de clase sobre validación de formularios.
    /// 
    /// Siguiendo el patrón MVC:
    /// - VISTA (FormUsuarios) → llama a estos métodos
    /// - CONTROLADOR (esta clase) → valida
    /// - REPOSITORIO → ejecuta SQL
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public class UsuarioControlador
    {
        // Repositorio para acceder a los datos
        private RepositorioUsuario repo;

        /// <summary>
        /// Constructor: Inicializo el repositorio
        /// </summary>
        public UsuarioControlador()
        {
            repo = new RepositorioUsuario();
        }

        /// <summary>
        /// Inserta un nuevo usuario en la biblioteca
        /// 
        /// VALIDACIONES DE NEGOCIO:
        /// 
        /// 1. Nombre obligatorio
        ///    - No puede estar vacío o ser solo espacios
        /// 
        /// 2. Apellido_1 obligatorio
        ///    - En España, el primer apellido es obligatorio legalmente
        ///    - Apellido_2 es opcional
        /// 
        /// 3. Teléfono válido
        ///    - Debe ser mayor que 0 (no puede ser negativo o cero)
        ///    - Debe tener exactamente 9 dígitos (formato español)
        /// 
        /// Si alguna validación falla, lanzo una Exception con un mensaje claro.
        /// FormUsuarios captura estas excepciones y las muestra al usuario.
        /// 
        /// Estas validaciones son fundamentales para mantener la calidad
        /// de los datos en la base de datos.
        /// </summary>
        public void Insertar(Usuario usuario)
        {
            // VALIDACIÓN 1: Nombre obligatorio
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio");

            // VALIDACIÓN 2: Primer apellido obligatorio
            if (string.IsNullOrWhiteSpace(usuario.Apellido1))
                throw new Exception("El primer apellido es obligatorio");

            // VALIDACIÓN 3: Teléfono válido (no puede ser 0 o negativo)
            if (usuario.Telefono <= 0)
                throw new Exception("El teléfono no es válido");

            // VALIDACIÓN 4: Formato de teléfono (9 dígitos exactos)
            // Convierto el número a string para contar los dígitos
            string telefonoStr = usuario.Telefono.ToString();
            if (telefonoStr.Length != 9)
                throw new Exception("El teléfono debe tener 9 dígitos");

            // Si llegamos aquí, todo es válido
            repo.Insertar(usuario);
        }

        /// <summary>
        /// Modifica un usuario existente
        /// 
        /// Validaciones idénticas a Insertar(), pero además verifico
        /// que el ID del usuario sea válido (> 0).
        /// 
        /// Aquí uso > 0 (no >= 0) porque en UsuarioControlador decidí
        /// no aceptar ID = 0 como válido, a diferencia de LibroControlador.
        /// Esto es consistente con el resto del código de usuarios.
        /// </summary>
        public void Modificar(Usuario usuario)
        {
            // VALIDACIÓN EXTRA: ID válido
            if (usuario.Id <= 0)
                throw new Exception("ID de usuario no válido");

            // Mismas validaciones que Insertar
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(usuario.Apellido1))
                throw new Exception("El primer apellido es obligatorio");

            if (usuario.Telefono <= 0)
                throw new Exception("El teléfono no es válido");

            // Validación de formato (9 dígitos)
            string telefonoStr = usuario.Telefono.ToString();
            if (telefonoStr.Length != 9)
                throw new Exception("El teléfono debe tener 9 dígitos");

            repo.Modificar(usuario);
        }

        /// <summary>
        /// Elimina un usuario de la biblioteca
        /// 
        /// VALIDACIÓN: Solo verifico que el ID sea válido.
        /// 
        /// MEJORA FUTURA (comentario del código):
        /// Sería bueno verificar si el usuario tiene préstamos activos
        /// antes de eliminarlo. Esto evitaría problemas de integridad.
        /// 
        /// Por ahora, confío en que DatabaseHelper.LimpiarPrestamosHuerfanos()
        /// limpiará cualquier préstamo huérfano si se elimina un usuario.
        /// </summary>
        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("ID de usuario no válido");

            // Verificar si el usuario tiene préstamos activos
            // (esto se podría mejorar con una consulta a la tabla de préstamos)

            repo.Eliminar(id);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados
        /// No necesita validaciones, simplemente delega al repositorio
        /// </summary>
        public DataTable ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        /// <summary>
        /// Busca un usuario específico por su ID
        /// 
        /// VALIDACIÓN: El ID debe ser > 0
        /// 
        /// Se usa cuando necesito información de un usuario concreto,
        /// por ejemplo para mostrarlo en un formulario de detalle.
        /// </summary>
        public DataTable BuscarPorId(int id)
        {
            if (id <= 0)
                throw new Exception("ID de usuario no válido");

            return repo.BuscarPorId(id);
        }

        /// <summary>
        /// Busca usuarios por término de búsqueda (Nombre, Apellido_1 o Apellido_2)
        /// 
        /// Si el término está vacío, devuelvo todos los usuarios.
        /// Esto permite que el campo de búsqueda funcione bien:
        /// - Usuario escribe: filtra resultados
        /// - Usuario borra todo: muestra todos los usuarios
        /// 
        /// Esta lógica la repliqué de LibroControlador.Buscar()
        /// para mantener consistencia en toda la aplicación.
        /// </summary>
        public DataTable Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return repo.ObtenerTodos();

            return repo.Buscar(termino);
        }

        /// <summary>
        /// Busca un usuario por su número de teléfono
        /// 
        /// VALIDACIÓN: El teléfono debe ser > 0
        /// 
        /// Útil para verificar si un teléfono ya está registrado
        /// o para buscar usuarios por su número.
        /// 
        /// NOTA: No valido aquí el formato de 9 dígitos porque
        /// este método también se podría usar para buscar teléfonos
        /// incompletos durante debugging.
        /// </summary>
        public DataTable BuscarPorTelefono(int telefono)
        {
            if (telefono <= 0)
                throw new Exception("Teléfono no válido");

            return repo.BuscarPorTelefono(telefono);
        }
    }
}
# Sistema de Gestión - Biblioteca Vitoria-Gasteiz

![Logo Biblioteca](https://via.placeholder.com/800x200/008B8B/FFFFFF?text=Biblioteca+Vitoria-Gasteiz)

## Índice
1. [Guía de Estilos (UI/UX)](#1-guía-de-estilos-uiux)
2. [Componentes Reutilizables](#2-componentes-reutilizables)
3. [Pantallas y Prototipado](#3-pantallas-y-prototipado)
4. [Manual de Usuario](#4-manual-de-usuario)
5. [Informe Técnico de Desarrollo](#5-informe-técnico-de-desarrollo)

---

## 1. Guía de Estilos (UI/UX)
El diseño visual de la aplicación está pensado para ser moderno, limpio y amigable, alejándose de los formularios grises tradicionales de Windows y acercándose a una experiencia de aplicación web responsiva.

###  Colores
La paleta está inspirada en tonos sobrios institucionales, priorizando la legibilidad (WCAG):
* **Acento Principal (DarkCyan - `#008B8B`):** Botones principales ("Guardar", "Prestar"), bordes de campos de búsqueda activos y elementos de selección.
* **Fondo General (LightGray - `#D3D3D3`):** Fondo de la aplicación para reducir la fatiga visual.
* **Fondo de Paneles (White - `#FFFFFF`):** Tarjetas de libros, contenedores de texto y modales.
* **Texto Principal (Black - `#000000`):** Lectura principal y datos de base de datos.
* **Texto Secundario (Gray/Silver - `#808080`):** Placeholders de búsqueda y etiquetas de campos (TÍTULO, ESCRITOR).
* **Acción Destructiva (Crimson - `#DC143C`):** Botones de "Eliminar" y alertas de error.
* **Estados (LimeGreen `#32CD32` / Crimson):** Indicadores visuales de "Disponible" o "Prestado".

###  Tipografía
Se utiliza la familia **Segoe UI** por su legibilidad nativa en sistemas Windows:
* **Títulos de Formulario:** Segoe UI Bold, 14pt (Blanco sobre fondo negro).
* **Etiquetas de Input:** Segoe UI Bold, 9pt (Mayúsculas, color secundario).
* **Cuerpo / Textos de Input:** Segoe UI Regular, 11pt - 12pt.
* **Botones:** Segoe UI Bold, 11pt - 12pt (Centrado).

###  Iconos y Logo
* **Logo:** Escudo simplificado del Ayuntamiento de Vitoria-Gasteiz situado en la esquina superior izquierda del menú de navegación.
* **Iconos:** Estilo "Flat" y minimalista. Se utilizan para acompañar las opciones del menú lateral (Libros, Usuarios, Préstamos) y en los campos de búsqueda (lupa).

---

## 2. Componentes Reutilizables
Para mantener la **homogeneidad** exigida en el proyecto, se han diseñado componentes base que se repiten en todas las vistas:

* **Botones Redondeados (Custom Panels):** En lugar del botón estándar de WinForms, se usan `Panels` con un radio de 20px (renderizados con `GraphicsPath` y AntiAlias). El texto se centra usando `Dock = Fill` en una etiqueta interna.
* **Barra de Título (Header):** Panel superior negro de 60px de altura, anclado al inicio (`Dock = Top`), con texto blanco en Bold. Sirve para ubicar al usuario ("Detalles del Libro", "Gestión de Usuarios").
* **Cajas de Entrada (Inputs):** Paneles blancos con borde redondeado de 15px, un `Padding` interno generoso y una etiqueta en mayúsculas en la parte superior. El `TextBox` real tiene fondo transparente/WhiteSmoke y carece de bordes nativos.
* **Tarjeta de Libro (`ucLibro`):** * *Control de Usuario* personalizado.
    * Dimensiones mínimas: 700x45 px.
    * Estructura: `TableLayoutPanel` que alinea Título, Autor, Estado visual (punto verde/rojo) y el botón de acción "Ver Detalles".

---

## 3. Pantallas y Prototipado
El flujo de navegación está centralizado en un Gestor principal (`MainView`).

1.  **Pantalla Contenedora (Gestor):** Menú lateral izquierdo oscuro con las 3 opciones principales. Un panel central vacío donde se inyectan las vistas secundarias.
2.  **Pantalla Catálogo de Libros:** Barra de búsqueda superior, lista dinámica de `ucLibro` en un `FlowLayoutPanel` (responsivo al estirar la ventana) y botón flotante/superior para añadir nuevo libro.
3.  **Pantalla Detalles / Edición (Modal):** Formularios con `TableLayoutPanel` dividido en porcentajes (33%). Muestra los detalles completos y los botones de acción en la parte inferior.
4.  **Pantalla Gestión de Usuarios/Préstamos:** Buscador superior y un `DataGridView` limpio (sin bordes 3D, colores alternos) en la parte inferior.

---

## 4. Manual de Usuario

Bienvenido al sistema de gestión de la Biblioteca de Vitoria-Gasteiz. Esta herramienta está diseñada para ser intuitiva y rápida.

###  1. Gestión de Libros
* **Buscar un libro:** En la pestaña "Libros", utiliza la barra superior para buscar por título o autor. La lista se actualizará en tiempo real.
* **Ver Detalles:** Haz clic en el botón de la tarjeta del libro para ver su sinopsis completa y estado actual.
* **Añadir/Editar:** Pulsa "Añadir Libro" para registrar uno nuevo. Las validaciones impedirán que guardes un libro sin título o con un año de edición futuro.

###  2. Gestión de Usuarios
* **Registrar un usuario:** Navega a "Usuarios". Rellena los datos en las cajas blancas. El sistema exige Nombre, Primer Apellido y un Teléfono válido de 9 dígitos exactos. Pulsa "Guardar".
* **Modificar/Eliminar:** Busca al usuario, selecciona su registro y pulsa "Editar". Si pulsas "Eliminar", el usuario desaparecerá del sistema (siempre que no tenga préstamos pendientes).

###  3. Gestión de Préstamos
* **Realizar Préstamo:** Ve a la pestaña de "Préstamos". Selecciona un Usuario y un Libro Disponible. Automáticamente se generarán las fechas y el libro pasará a estado *Prestado* (rojo).
* **Devolver Libro:** En la tabla de préstamos activos, selecciona el préstamo y pulsa "Devolver". El sistema registrará la fecha actual de devolución y el libro volverá a estar *Disponible* (verde) en el catálogo.

---

## 5. Informe Técnico de Desarrollo
*(Nota del autor: A continuación se detalla el proceso de desarrollo y las resoluciones técnicas aplicadas para cumplir con los requisitos de la entrega).*

**1. El punto de partida: La arquitectura MVC y los 3 Proyectos**
El mayor reto fue adaptar el código a la estructura estricta de tres proyectos pedida en el enunciado (`BibliotecaControles`, `BibliotecaSQLite` y `BibliotecaApp`). Al separar la lógica, las vistas y los controles, los *namespaces* colisionaron. Me enfrenté a constantes `NullReferenceException` por errores en el orden de instanciación del MVC (intentar acceder al controlador antes de inyectarlo en la vista, un fallo analizado en los ejercicios de clase). Tras varias sesiones de depuración, logré un desacoplamiento total: las vistas no tocan una sola línea de la base de datos.

**2. SQLite y la consistencia de los IDs**
Basándome en el `SQLiteHelper.cs` proporcionado, logré una conexión estable. Sin embargo, al borrar y reinsertar datos, los IDs se descontrolaban (saltos, ID=0), rompiendo las claves foráneas de los préstamos. Resolví esto aplicando teoría de bases de datos: forcé el reseteo de la tabla interna `sqlite_sequence` mediante un `DELETE` en el script inicial, logrando un `AUTOINCREMENT` perfecto y predecible.

**3. Diseño Responsivo y Anti-Aliasing**
Para cumplir con los criterios de "Responsividad" y "Diseño", implementé múltiples contenedores `TableLayoutPanel` con ajustes de `Anchor` y `Dock`. Los formularios se adaptan a cualquier tamaño de pantalla sin deformar el texto. 
El mayor esfuerzo visual fue eliminar los "dientes de sierra" de los paneles con bordes redondeados. Desarrollé un método *Helper* que fuerza `SmoothingMode.AntiAlias` e invalida el control (`Invalidate()`) en el evento `Resize` para repintar las curvas en alta calidad en tiempo real.

**4. Controles Personalizados y Eventos**
El catálogo se construyó utilizando el control personalizado `ucLibro` (basado en el ejercicio de los empleados). Para mantener el aislamiento del MVC, implementé eventos personalizados (`EditarLibroEventArgs`). Al pulsar un botón en la tarjeta, esta emite un evento con el ID del libro, y es el formulario principal quien lo escucha y ejecuta la lógica, evitando código espagueti.

**5. Conclusión de la entrega**
El proyecto es estable, no presenta cuelgues (crashes) y valida estrictamente todos los datos antes de inyectarlos en la base de datos. He incluido las librerías DLL compiladas en la entrega para garantizar que no existan problemas de dependencias al ejecutar la solución en otros equipos.
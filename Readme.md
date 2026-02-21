# Sistema de Gestión de Biblioteca - Ayuntamiento de Vitoria-Gasteiz

![Estado](https://img.shields.io/badge/Estado-Entregado-success)
![Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-MVC-orange)

**Desarrollado por:** David Merchan Rivero  
**Institución:** Egibide - Centro de Arriaga  
**Curso:** 3º DAM Nocturno (2025-2026)  
**Asignatura:** Desarrollo de Interfaces  
**Profesora:** Maider Díaz Salinas  
**Fecha de entrega:** 8 de febrero de 2026  
**Ubicación:** Vitoria-Gasteiz (estudiante de Alsasua, Navarra)

---

## 📖 La Historia Real de Este Proyecto

Este README no es un documento técnico perfecto. Es la historia real de cómo construí esta aplicación, con sus problemas, sus noches sin dormir, y todo lo que aprendí en el proceso.

### El Contexto

Este proyecto es el trabajo final de la asignatura **Desarrollo de Interfaces** del segundo curso de DAM. Teníamos que crear una aplicación de escritorio en C# usando Windows Forms, arquitectura MVC, y controles personalizados. Suena simple, ¿verdad? Pues no lo fue.

### Lo Que Pasó Realmente: El Caos de los Tres Proyectos

Desde el domingo antes de la entrega hasta el viernes a las 22:00, prácticamente viví en este proyecto. Dormí poco y mal. Cuatro horas seguidas como mucho. Luego me despertaba a las 3 de la madrugada pensando en un error de compilación y me levantaba a probar una solución que, muchas veces, no funcionaba.

**¿Por qué tanto drama?** Porque este proyecto NO fue lineal. Fue un proceso caótico que involucró **TRES versiones diferentes** antes de llegar a la versión final funcional.

#### Proyecto 1: El Intento por Mi Cuenta (Basado en Figma)

**Semanas antes de recibir el enunciado oficial**, diseñé en Figma mi propia versión de una biblioteca y empecé a programarla por mi cuenta. Interfaz visual MUY trabajada (dark theme, tarjetas de libros bonitas), diseño completamente personalizado, base de datos SQLite funcional.

**El problema:** Cuando recibí el enunciado oficial, me di cuenta que mi proyecto NO cumplía con los requisitos técnicos. Faltaba el UserControl obligatorio, la arquitectura MVC no estaba bien separada.

#### Proyecto 2: Empezando de Cero Siguiendo el Enunciado

Creé un proyecto NUEVO desde cero siguiendo al pie de la letra los requisitos. Estructura MVC correcta, UserControl TarjetaLibro implementado, seguía los ejercicios de la profesora Maider.

**El problema:** Funcionaba, pero extrañaba el diseño visual que había logrado en el Proyecto 1.

#### El Primer Caos: Mezclar Proyecto 1 + Proyecto 2

**Decisión fatal:** "¿Y si junto lo mejor de ambos?"

Copié las vistas (FormLibros, FormUsuarios, etc.) del Proyecto 1 e intenté pegarlas en la estructura MVC del Proyecto 2. Los namespaces no coincidían. Las referencias a controles estaban rotas. El Controlador del Proyecto 2 esperaba una cosa, las vistas del Proyecto 1 otra.

**Resultado:** `NullReferenceException` por todas partes, eventos que se disparaban dos veces, código que compilaba pero crasheaba al ejecutar. **6 HORAS de debugging** con breakpoints en cada línea hasta entender que estaba intentando usar el `MiControlador` antes de haberlo instanciado en el `Gestor`.

**Lección dolorosa:** "No mezcles dos proyectos con arquitecturas diferentes sin un plan claro. Es como intentar trasplantar un corazón sin anestesia."

#### Proyecto 3: El Repo Antiguo que Resucité

A mitad de semana, frustrado con la mezcla, recordé que tenía un **repo antiguo de un intento anterior de biblioteca** de hace meses. Tenía código que ya no entendía, usaba librerías descargadas de GitHub (MaterialSkin, otros componentes), base de datos con estructura diferente.

**Decisión (mala):** "Lo voy a mezclar con el proyecto bueno a ver si sale algo"

#### El Segundo Caos: Mezclar Proyecto Bueno + Repo Antiguo

Cloné el repo antiguo. Copié carpetas completas (modelo, vista, helpers). Las pegué en el proyecto que ya tenía medio funcionando. **Visual Studio explotó.**

**Problemas encontrados:**

**1. Librerías duplicadas:**
- MaterialSkin.dll (del repo antiguo)
- System.Data.SQLite.dll (duplicado, versiones diferentes)
- Helpers personalizados con nombres iguales pero código diferente

**Resultado:** Conflictos de nombres, referencias rotas, DLL hell.

**2. Código fantasma:**
- Métodos `modoEdicion` que ya no usaba
- Clases `Datos.cs` con listas en memoria (ya no necesarias porque tenía BBDD)
- Eventos conectados a controles que había borrado

Ejemplo real del error:
```csharp
// En FormLibros, había esto:
private void btnGuardar_Click(object sender, EventArgs e)
{
    if (modoEdicion) // ← Variable que YA NO EXISTÍA
    {
        ModificarLibro();
    }
}
```

Error: `'modoEdicion' no existe en el contexto actual`

**3. Namespaces en conflicto:**
- Del repo antiguo: `using Biblioteca.Modelo;`
- Del proyecto bueno: `using BibliotecaVitoriaGasteiz.modelo;`

Clases con nombres iguales (`Libro.cs`) en namespaces diferentes. El compilador no sabía cuál usar.

**4. Bases de datos incompatibles:**
- Repo antiguo: Campos `ISBN`, `Autor`, `Email`
- Proyecto bueno: Campos `Titulo`, `Escritor`, `Telefono`

Intenté usar el `RepositorioLibros.cs` del repo antiguo con la BBDD del proyecto bueno → Crasheaba porque buscaba campos que no existían.

#### La Depuración del Infierno

**Miércoles 3 AM:**
- No compilaba
- 47 errores de referencias
- UserControl1.cs fantasma que no encontraba
- BibliotecaControles.csproj con referencias a archivos borrados

**Proceso de limpieza (6 horas):**

1. **Eliminar librerías del repo antiguo** - Borré MaterialSkin.dll, desinstalé paquetes NuGet duplicados, reinstalé SOLO System.Data.SQLite limpio

2. **Eliminar código fantasma** - Busqué TODOS los `modoEdicion` y los borré, eliminé la clase `Datos.cs`, borré métodos sin llamadas

3. **Arreglar namespaces** - Decidí: `BibliotecaVitoriaGasteiz.modelo` para TODO. Buscar y reemplazar en TODA la solución

4. **Limpiar archivos del proyecto** - Editar BibliotecaControles.csproj manualmente, quitar `<Compile Include="UserControl1.cs" />` que no existía

5. **Sincronizar BBDD con modelos** - Verificar estructura exacta de Biblioteca.db, reescribir `Libro.cs`, `Usuario.cs`, `Prestamo.cs` con campos correctos

#### La Versión Final: Lo Que Funciona Ahora

**Qué dejé:**
- Estructura MVC del Proyecto 2 (correcta)
- Diseño visual del Proyecto 1 (bonito)
- Código limpio sin fantasmas

**Qué tiré:**
- TODO el código del repo antiguo
- Librerías externas innecesarias
- Métodos duplicados o sin uso

**Lección más importante:**
> "A veces hay que tener el valor de BORRAR código en el que invertiste horas. Si no encaja, no encaja. Mejor empezar de cero que arrastrar código zombi."

### Las Decisiones Polémicas

#### Subir las librerías al repositorio
Sí, lo sé. No se debe hacer. Pero después de pelearme dos días intentando juntar ambas versiones del proyecto y ver cómo explotaba por referencias rotas, entré en pánico. No quería que al clonar el proyecto saltara "dll not found" después de tantos días de trabajo.

Fue una decisión emocional, de miedo, no técnica. **Error técnico, sí. Comprensible emocionalmente, también.**

#### El modo oscuro que no está
Lo dejé fuera. Después de la paliza de depurar el "Frankenstein" de los dos proyectos, prioricé que no crasheara. Que un préstamo se registrara sin tirar una excepción. El modo oscuro puede esperar a la versión 2.0.

---

## 🏗️ Lo Que Construí

### Arquitectura

```
BibliotecaVitoriaGasteiz/
├── BibliotecaControles/          # Proyecto de controles personalizados
│   └── TarjetaLibro.cs           # UserControl para visualizar libros
├── BibliotecaVitoriaGasteiz/     # Proyecto principal
│   ├── modelo/                   # Modelos de datos
│   │   ├── Libro.cs
│   │   ├── Usuario.cs
│   │   ├── Prestamo.cs
│   │   ├── SQLiteHelper.cs       # De ls profesora, namespace adaptado
│   │   └── repositorio/          # Patrón Repository
│   │       ├── RepositorioLibros.cs
│   │       ├── RepositorioUsuarios.cs
│   │       └── RepositorioPrestamos.cs
│   ├── controlador/              # Lógica de negocio
│   │   └── Controlador.cs
│   ├── vista/                    # Formularios
│   │   ├── Gestor.cs             # Formulario principal (MDI)
│   │   ├── FormLibros.cs         # Gestión de libros
│   │   ├── FormUsuarios.cs       # Gestión de usuarios
│   │   ├── FormPrestamos.cs      # Gestión de préstamos
│   │   └── FormDetalleLibro.cs   # Vista/edición de libro
│   └── helpers/
│       └── UIHelper.cs           # Bordes redondeados, anti-aliasing
└── Biblioteca.db                 # De la profesora, Base de datos SQLite
```

### Funcionalidades Implementadas

✅ **Gestión de Libros**
- CRUD completo (Crear, Leer, Actualizar, Eliminar)
- Búsqueda en tiempo real
- Visualización con tarjetas (TarjetaLibro UserControl)
- Edición in-situ con FormDetalleLibro

✅ **Gestión de Usuarios**
- Alta, modificación y eliminación
- Validación de teléfonos (formato español)
- Prevención de duplicados

✅ **Gestión de Préstamos**
- Registro de préstamos con fechas
- Devolución de libros
- Control de disponibilidad automático
- Prevención de errores (ComboBox sin preselección)

✅ **Interfaz de Usuario**
- Dark theme consistente
- Bordes redondeados con anti-aliasing
- Sistema anti-rebote (Debounce) para evitar dobles clics
- Responsividad con TableLayoutPanel
- Placeholders en textboxes

---

## 🧠 Lo Que Aprendí (A Base de Golpes)

### 1. El Infierno de los IDs en SQLite
Mi primer problema serio. Al borrar y crear libros, SQLite me devolvía IDs en 0 o saltaba números. Esto rompía los préstamos porque no encontraban al usuario o al libro.

**Solución:** Tuve que leer el PDF de SQLite del profesor, entender cómo funcionaba `sqlite_sequence`, y meter un `DELETE FROM sqlite_sequence` en el script de inicialización.

**Fuente:** PDF del profesor + StackOverflow para entender el reseteo de secuencias.

### 2. Los Eventos Fantasma
El bug más escurridizo. Al guardar un usuario, me saltaba el MessageBox de éxito. Al darle "Aceptar", me lanzaba OTRO MessageBox diciendo "Faltan datos". Me volvía loco.

**El problema:** Mi diseño de botones (Label encima de Panel) provocaba que un clic físico disparase los dos eventos casi a la vez. Peor aún: Windows Forms encola los clics mientras el MessageBox está bloqueando la pantalla. Cuando el primero terminaba y limpiaba los campos, el segundo clic (atrapado en la cola) se ejecutaba y encontraba las cajas vacías.

**Solución intentada 1:** Semáforos booleanos (`isProcesando`). No funcionó porque la cola de mensajes de Windows actúa DESPUÉS de liberar el booleano.

**Solución final:** Debounce basado en tiempo. Un `DateTime tiempoDesbloqueo` que bloquea nuevos clics hasta 1 segundo después de cerrar el mensaje.

**Fuente:** Mis propios apuntes de Programación + prueba y error durante HORAS.

### 3. La Batalla con los UserControls
Crear el `TarjetaLibro` fue mi primer contacto serio con UserControls. Sufrí para que el flujo de tarjetas fuera responsivo con `FlowLayoutPanel`.

**Inspiración:** Proyectos de GitHub como MaterialSkin. No copié código, pero imité cómo separaban los paneles para que las sombras y bordes se vieran limpios.

**Fuente:** PDF "Controles Personalizados" del profesor + ejemplos de GitHub + mis apuntes de "Interfaces de Usuario".

### 4. Responsividad: La Barra de Búsqueda
En el diseñador se veía bien, pero al maximizar la pantalla, el TextBox se quedaba enano en una esquina. Pelear con `Anchor` y `Dock` desde el diseñador visual rompía otras cosas.

**Solución:** Tomar control por código. Creé `HacerBuscadorResponsivo()` en `UIHelper` que quita las anclas rígidas, pone `Anchor = Left | Right`, y mediante matemáticas recalcula los píxeles cada vez que salta el evento `Resize`.

**Fuente:** Prueba y error + conocimientos de matemáticas básicas.

### 5. Código Fantasma
Mi formulario de Libros tenía lógica de edición (`modoEdicion`) que era código zombi. Había copiado la estructura del formulario de Usuarios, pero en mi diseño final, la edición de libros se hacía en `FormDetalleLibro`.

Tuve que ser autocrítico, borrar ese código muerto, y transformar el panel izquierdo para que sirviera solo para altas nuevas.

**Lección:** No copies y pegues sin pensar. Adapta el código a TU diseño.

---

## 💻 Tecnologías y Herramientas

- **Lenguaje:** C# (.NET Framework 4.7.2)
- **UI Framework:** Windows Forms
- **Arquitectura:** MVC (Modelo-Vista-Controlador)
- **Base de Datos:** SQLite 3
- **Patrón de Datos:** Repository Pattern
- **IDE:** Visual Studio 2022 Community
- **Control de Versiones:** Git + GitHub
- **Diseño:** Figma (evaluación anterior)

---

## 🗄️ Base de Datos

### Estructura

**TABLA LIBROS**
- `ID` (INTEGER) - Clave primaria
- `Titulo` (TEXT) - NOT NULL
- `Escritor` (TEXT) - NOT NULL  *(¡Nota: se llama "Escritor", no "Autor"!)*
- `Ano_Edicion` (INTEGER) - Nullable
- `Sinopsis` (TEXT)
- `Disponible` (INTEGER) - 0 o 1

**TABLA USUARIOS**
- `ID` (INTEGER) - Clave primaria
- `Nombre` (TEXT) - NOT NULL
- `Apellido_1` (TEXT) - NOT NULL
- `Apellido_2` (TEXT)
- `Telefono` (NUMERIC) - NOT NULL

**TABLA PRESTAMOS**
- `ID` (INTEGER) - Clave primaria
- `ID_Libro` (INTEGER) - Foreign key a LIBROS
- `ID_Usuario` (INTEGER) - Foreign key a USUARIOS
- `Fecha_Inicio` (TEXT) - Formato: dd/MM/yyyy
- `Fecha_Fin` (TEXT) - Formato: dd/MM/yyyy

### Decisión de Diseño: No DELETE en Devoluciones

Cuando devuelves un libro, NO hago `DELETE` en préstamos. Hago `UPDATE` cambiando `Fecha_Fin` y marcando `Disponible = 1` en el libro.

**¿Por qué?** Para mantener un historial completo. Si alguna vez el ayuntamiento quiere estadísticas ("¿cuántos libros prestó el usuario X en 2025?"), los datos están ahí.

---

## 🎨 Decisiones de Diseño

### Dark Theme
Elegí un tema oscuro porque:
1. Es más moderno
2. Reduce la fatiga visual (importante cuando llevas 12 horas programando)
3. Los colores primarios destacan mejor sobre fondo oscuro

**Paleta de Colores:**
- Fondo principal: `Color.FromArgb(45, 45, 48)`
- Texto: `Color.White`, `Color.FromArgb(180, 180, 180)`
- Bordes activos: `Color.Lime`
- Acentos: `Color.FromArgb(200, 220, 255)`

### Bordes Redondeados con UIHelper
Los bordes redondeados se veían fatal, con "dientes de sierra". 

**Solución:** `SmoothingMode.AntiAlias` de `System.Drawing`. El truco maestro lo saqué de CodeProject: forzar el redibujado en el evento `Resize`. Sin esto, al estirar la ventana, los bordes se deformaban.

### Prevención de Errores Humanos
En FormPréstamos, los ComboBox preseleccionan el primer elemento por defecto. Esto era PELIGROSO: si el bibliotecario le daba a "Realizar Préstamo" sin mirar, adjudicaría el primer libro al primer usuario.

**Solución:** `SelectedIndex = -1` al cargar datos. Obliga a elegir conscientemente.

---

## 📚 Fuentes de Conocimiento

Todo lo que usé está documentado en `DOSSIER_FUENTES.md`, pero aquí un resumen:

### Código de Profesora (Base)
- `SQLiteHelper.cs` con sus 4 métodos estáticos
- PDF "Controles Personalizados"
- PDF "SQLite"
- Ejercicios: `ejercicio6-formulariosCompuestos`, `empresa_conBBDD`

### Documentación Oficial
- MSDN para `TableLayoutPanel`, `Anchor`, `Dock`
- SQLite official docs para AUTOINCREMENT y sqlite_sequence

### Comunidad
- StackOverflow para el reseteo de `sqlite_sequence`
- CodeProject para el `SmoothingMode.AntiAlias` y el truco del `Invalidate()` en `Resize`
- GitHub (MaterialSkin) para inspiración visual de paneles

### Mis Propios Apuntes
- Apuntes de "Programación" para la lógica de validación
- Apuntes de "Diseño de Interfaces" para `FlowLayoutPanel`
- Apuntes de "Bases de Datos y Acceso a datos" para la estructura de tablas

---

## 🐛 Problemas Conocidos

1. **Modo oscuro no implementado dinámicamente**: Los colores están hardcodeados. Para un modo claro, habría que crear una clase `Tema.cs`.

2. **Validación de fechas limitada**: El sistema acepta fechas de fin anteriores a fechas de inicio si el usuario las escribe directamente (aunque los DateTimePicker lo previenen).

3. **Sin paginación**: Si hay 1000 libros, carga los 1000 en el FlowLayoutPanel. Con muchos registros, podría ser lento.

4. **Librerías en el repositorio**: Sí, está mal. Pero fue una decisión de pánico para asegurar que funcionara en tu máquina.

---

## 🚀 Cómo Ejecutar el Proyecto

### Requisitos
- Windows 7 o superior
- .NET Framework 4.7.2 o superior
- Visual Studio 2022 Community (o superior)

### Pasos

1. **Clonar el repositorio:**
```bash
git clone https://github.com/davidmerchan50786/BibliotecaVitoriaGasteiz.git
cd BibliotecaVitoriaGasteiz
```

2. **Abrir la solución:**
```bash
# Doble clic en BibliotecaVitoriaGasteiz.sln
```

3. **Restaurar paquetes NuGet:**
- Visual Studio lo hará automáticamente
- Si no: `Herramientas` → `Administrador de paquetes NuGet` → `Restaurar paquetes`

4. **Verificar Biblioteca.db:**
- Click derecho en `Biblioteca.db`
- Propiedades:
  - `Acción de compilación`: Contenido
  - `Copiar en directorio de salida`: Copiar siempre

5. **Compilar y ejecutar:**
```bash
F5 (Debug)
Ctrl+F5 (Sin depuración)
```

---

## 📖 Manual de Usuario

El manual completo está en `MANUAL_USUARIO.pdf`. Incluye:
- Portada profesional
- Índice completo
- Explicación de cada funcionalidad con capturas
- Solución de problemas comunes
- Glosario de términos
- Datos de contacto

---

## 🎓 Lo Que Este Proyecto Me Enseñó

### Técnicamente
- **MVC no es solo separar archivos**: Es entender que las Vistas son "tontas" y solo muestran/recogen datos.
- **Los eventos en Windows Forms son traicioneros**: La cola de mensajes puede guardarte clics para ejecutarlos después.
- **SQLite es simple pero tiene sus trampas**: Los IDs autoincrement no siempre funcionan como esperas.
- **El código visual es código**: `UIHelper` me enseñó que incluso el dibujo de bordes necesita arquitectura.

### Personalmente
- **El pánico no ayuda**: Subir las librerías al repo fue pánico. No resolvió nada real.
- **El código limpio importa**: El "código fantasma" me costó días de depuración.
- **Documentar mientras programas vale oro**: Esta historia real la pude escribir porque fui anotando problemas.
- **No mezcles dos versiones del mismo proyecto**: Hazlo bien la primera vez o acepta reescribir.

### Sobre el Proceso
Este proyecto me demostró que **programar no es escribir código**. Es:
1. Entender el problema
2. Diseñar la solución
3. Implementar (la parte "fácil")
4. Depurar (la parte DURA)
5. Refactorizar
6. Documentar

Y que a veces, el código que más orgulloso te hace (el sistema anti-rebote) nace de 6 horas de frustración con un bug que ni sabías que existía.

---

## 🤝 Agradecimientos

- **A la profesora Maider Díaz Salinas (Egibide - Arriaga)**: Por proporcionar el `SQLiteHelper.cs`, los PDFs de clase y los ejercicios de ejemplo que sirvieron como base para el proyecto.
- **A StackOverflow**: Por las explicaciones sobre `sqlite_sequence` y conversión de tipos en SQLite.
- **A CodeProject**: Por el artículo sobre bordes redondeados con `GraphicsPath`.
- **A mi yo de las 3 AM**: Por no rendirte cuando las cosas no compilaban.

---

## 📄 Licencia

Este proyecto es un trabajo académico para Egibide - Centro de Arriaga (3º DAM Nocturno).  
© 2026 David - Todos los derechos reservados.

---

## 📞 Contacto

- **Estudiante:** David Merchan Rivero
- **Institución:** Egibide - Centro de Arriaga
- **Curso:** 3º DAM Nocturno
- **Asignatura:** Desarrollo de Interfaces
- **Profesora:** Maider Díaz Salinas
- **Ubicación:** Alsasua, Navarra
- **GitHub:** [davidmerchan50786](https://github.com/davidmerchan50786)

---

**Nota final:** Este proyecto llegó tarde. Sí. Pero llegó completo, funcional, y con cada línea de código tocada, depurada y rehecha por mí. No es perfecto, pero es MÍO, y funciona de lujo.

*Escrito entre enero y febrero de 2026, y terminado después de una semana intensa de código, café, y muy poco sueño.*

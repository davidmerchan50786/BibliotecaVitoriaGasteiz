# 📖 MANUAL DE USUARIO COMPLETO - Sistema de Gestión de Biblioteca

**Proyecto:** Sistema de Gestión de Biblioteca - Ayuntamiento de Vitoria-Gasteiz  
**Autor:** David Merchan Rivero  
**Institución:** Egibide - Centro de Arriaga (3º DAM Nocturno)  
**Profesora:** Maider Díaz Salinas  
**Asignatura:** Desarrollo de Interfaces  
**Herramienta:** Visual Studio 2022 Community  
**Fecha:** Febrero 2026

---

## 📑 ÍNDICE

1. [Introducción](#introducción)
2. [La Historia Real del Desarrollo](#la-historia-real-del-desarrollo)
3. [Requisitos del Sistema](#requisitos-del-sistema)
4. [Instalación](#instalación)
5. [Guía de Usuario Final](#guía-de-usuario-final)
6. [Detalles Técnicos Implementados](#detalles-técnicos-implementados)
7. [Solución de Problemas](#solución-de-problemas)
8. [Glosario](#glosario)
9. [Contacto y Soporte](#contacto-y-soporte)

---

## 📖 INTRODUCCIÓN

Este sistema permite gestionar el catálogo de libros, usuarios y préstamos de la Biblioteca Municipal de Vitoria-Gasteiz mediante una interfaz de escritorio moderna y funcional desarrollada en Windows Forms con arquitectura MVC.

### Características principales:
- ✅ Gestión completa de libros (alta, edición, eliminación, búsqueda)
- ✅ Gestión de usuarios de la biblioteca
- ✅ Sistema de préstamos y devoluciones
- ✅ Interfaz oscura moderna con bordes redondeados
- ✅ Búsqueda en tiempo real
- ✅ Validaciones exhaustivas
- ✅ Responsividad completa

---

## 🎭 LA HISTORIA REAL DEL DESARROLLO

### El Caos de los Tres Proyectos

Este proyecto NO fue lineal. Fue un proceso caótico que involucró **tres versiones diferentes** antes de llegar a la versión final funcional.

#### **Proyecto 1: El Intento por Mi Cuenta (Basado en Figma)**

**Cuándo:** Semanas antes de recibir el enunciado oficial  
**Qué hice:** Diseñé en Figma mi propia versión de una biblioteca y empecé a programarla por mi cuenta.

**Características:**
- Interfaz visual MUY trabajada (dark theme, tarjetas de libros bonitas)
- Diseño completamente personalizado
- NO seguía ninguna estructura MVC formal
- Base de datos SQLite funcional
- Formularios con diseño responsive

**Problema:** Cuando recibí el enunciado oficial, me di cuenta que mi proyecto NO cumplía con los requisitos técnicos (faltaba el UserControl obligatorio, la arquitectura MVC no estaba bien separada).

---

#### **Proyecto 2: Empezando de Cero Siguiendo el Enunciado**

**Cuándo:** Al recibir el enunciado oficial  
**Qué hice:** Creé un proyecto NUEVO desde cero siguiendo al pie de la letra los requisitos.

**Características:**
- Estructura MVC correcta (Modelo/Vista/Controlador)
- UserControl TarjetaLibro implementado
- Seguía los ejercicios de la profesora Maider
- Funcional pero visualmente BÁSICO (sin el diseño bonito del Proyecto 1)

**Problema:** Este proyecto funcionaba, pero extrañaba el diseño visual que había logrado en el Proyecto 1.

---

#### **El Primer Caos: Mezclar Proyecto 1 + Proyecto 2**

**Decisión fatal:** "¿Y si junto lo mejor de ambos?"

**Proceso:**
1. Copié las vistas (FormLibros, FormUsuarios, etc.) del Proyecto 1
2. Intenté pegarlas en la estructura MVC del Proyecto 2
3. Los namespaces no coincidían
4. Las referencias a controles estaban rotas
5. El Controlador del Proyecto 2 esperaba una cosa, las vistas del Proyecto 1 otra

**Resultado:** 
- `NullReferenceException` por todas partes
- Eventos que se disparaban dos veces
- Código que compilaba pero crasheaba al ejecutar
- **6 HORAS de debugging** con breakpoints en cada línea

**Qué aprendí:**
> "No mezcles dos proyectos con arquitecturas diferentes sin un plan claro. Es como intentar trasplantar un corazón sin anestesia."

---

#### **Proyecto 3: El Repo Antiguo que Resucité**

**Cuándo:** A mitad de semana, frustrado con la mezcla  
**Qué hice:** Recordé que tenía un repo antiguo de un intento anterior de biblioteca.

**Características:**
- Era de hace meses
- Tenía código que ya no entendía
- Usaba librerías que había descargado de GitHub (MaterialSkin, otros componentes)
- Base de datos con estructura diferente

**Decisión (mala):** "Mezcle parte del repositorio de un proyecto con parte de otro que era un intento fallido sin darme cuenta e hize varios commits & push"

---

#### **El Segundo Caos: Mezclar Proyecto Bueno + Repo Antiguo**

**Qué pasó:**
1. Cloné el repo antiguo
2. Copié carpetas completas (modelo, vista, helpers)
3. Las pegué en el proyecto que ya tenía medio funcionando
4. Visual Studio explotó

**Problemas encontrados:**

**1. Librerías duplicadas:**
```
- MaterialSkin.dll (del repo antiguo)
- System.Data.SQLite.dll (duplicado, versiones diferentes)
- Helpers personalizados con nombres iguales pero código diferente
```

**Resultado:** Conflictos de nombres, referencias rotas, infierno dll.

**2. Código fantasma:**
- Métodos `modoEdicion` que ya no usaba
- Clases `Datos.cs` con listas en memoria (ya no necesarias porque tenía BBDD)
- Eventos conectados a controles que había borrado

**Síntomas:**
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
```
Del repo antiguo: using Biblioteca.Modelo;
Del proyecto bueno: using BibliotecaVitoriaGasteiz.modelo;
```

Clases con nombres iguales (`Libro.cs`) en namespaces diferentes. El compilador no sabía cuál usar.

**4. Bases de datos incompatibles:**
- Repo antiguo: Campos `ISBN`, `Autor`, `Email`
- Proyecto bueno: Campos `Titulo`, `Escritor`, `Telefono`

Intenté usar el `RepositorioLibros.cs` del repo antiguo con la BBDD del proyecto bueno → Crasheaba porque buscaba campos que no existían.

---

#### **La Depuración del Infierno**

**Miércoles 3 AM:**
- No compilaba
- 47 errores de referencias
- UserControl1.cs fantasma que no encontraba
- BibliotecaControles.csproj con referencias a archivos borrados

**Proceso de limpieza (6 horas):**

1. **Eliminar librerías del repo antiguo:**
   - Borré MaterialSkin.dll
   - Desinstalé paquetes NuGet duplicados
   - Reinstalé SOLO System.Data.SQLite limpio

2. **Eliminar código fantasma:**
   - Busqué TODOS los `modoEdicion` y los borré
   - Eliminé la clase `Datos.cs` (ya no la usaba)
   - Borré métodos sin llamadas (DetectarCódigoMuerto)

3. **Arreglar namespaces:**
   - Decidí: `BibliotecaVitoriaGasteiz.modelo` para TODO
   - Buscar y reemplazar en TODA la solución
   - Verificar referencias en cada archivo .cs

4. **Limpiar archivos del proyecto:**
   - Editar BibliotecaControles.csproj manualmente
   - Quitar `<Compile Include="UserControl1.cs" />` que no existía
   - Añadir `<Compile Include="TarjetaLibro.cs" />` correctamente

5. **Sincronizar BBDD con modelos:**
   - Verificar estructura exacta de Biblioteca.db
   - Reescribir `Libro.cs`, `Usuario.cs`, `Prestamo.cs` con campos correctos
   - Probar cada método del repositorio UNO POR UNO

---

#### **La Versión Final: Lo Que Funciona Ahora**

**Qué dejé:**
- Estructura MVC del Proyecto 2 (correcta)
- Diseño visual del Proyecto 1 (bonito)
- Código limpio sin fantasmas

**Qué eliminé:**
- TODO el código del repo antiguo
- Librerías externas innecesarias
- Métodos duplicados o sin uso

**Lección más importante:**
> "A veces hay que tener el valor de BORRAR código en el que invertiste horas. Si no encaja, no encaja. Mejor empezar de cero que arrastrar código zombi."

---

## 💻 REQUISITOS DEL SISTEMA

### Software necesario:
- **Sistema Operativo:** Windows 7 o superior
- **.NET Framework:** 4.7.2 o superior
- **Visual Studio:** 2022 Community (o superior)
- **Espacio en disco:** Mínimo 50 MB

### Archivos del proyecto:
```
BibliotecaVitoriaGasteiz/
├── BibliotecaControles/        # UserControl personalizado
├── BibliotecaVitoriaGasteiz/   # Proyecto principal
│   ├── modelo/
│   ├── vista/
│   ├── controlador/
│   ├── helpers/
│   └── Biblioteca.db           # Base de datos SQLite
└── BibliotecaVitoriaGasteiz.sln
```

---

## 🚀 INSTALACIÓN

### Método 1: Desde Visual Studio

1. **Clonar repositorio:**
```bash
git clone https://github.com/davidmerchan50786/BibliotecaVitoriaGasteiz.git
cd BibliotecaVitoriaGasteiz
```

2. **Abrir solución:**
   - Doble clic en `BibliotecaVitoriaGasteiz.sln`
   - Visual Studio 2022 Community se abrirá automáticamente

3. **Restaurar paquetes NuGet:**
   - Visual Studio detectará automáticamente la falta de `System.Data.SQLite`
   - Clic derecho en la solución → "Restaurar paquetes NuGet"
   - Esperar a que descargue

4. **Verificar Biblioteca.db:**
   - En el Explorador de Soluciones, localizar `Biblioteca.db`
   - Click derecho → Propiedades
   - **Acción de compilación:** Contenido
   - **Copiar en directorio de salida:** Copiar siempre

5. **Compilar:**
   - `Build` → `Rebuild Solution` (Ctrl+Shift+B)
   - Debe compilar sin errores

6. **Ejecutar:**
   - `Debug` → `Start Debugging` (F5)
   - La aplicación se abrirá

---

## 👤 GUÍA DE USUARIO FINAL

### Inicio de la Aplicación

Al ejecutar la aplicación, se abre el **Gestor** (formulario MDI principal) con tres opciones en el menú:

```
┌─────────────────────────────────────┐
│ Biblioteca Vitoria-Gasteiz          │
├─────────────────────────────────────┤
│ [Libros] [Usuarios] [Préstamos]     │
├─────────────────────────────────────┤
│                                     │
│     (Área de trabajo vacía)         │
│                                     │
└─────────────────────────────────────┘
```

---

### 📚 GESTIÓN DE LIBROS

#### Ver catálogo completo

1. Clic en botón **"Libros"** del menú principal
2. Se abre FormLibros con:
   - Barra de búsqueda en la parte superior
   - Tarjetas de libros en un panel scrollable
   - Panel izquierdo para dar de alta libros nuevos

**Aspecto visual:**
```
┌────────────────────────────────────────────────┐
│ [Buscar: ____________]                         │
├────────────────────────────────────────────────┤
│ ┌──────────┐  ┌──────────┐  ┌──────────┐      │
│ │ Libro 1  │  │ Libro 2  │  │ Libro 3  │      │
│ │ Título   │  │ Título   │  │ Título   │      │
│ │ Autor    │  │ Autor    │  │ Autor    │      │
│ │[Detalles]│  │[Detalles]│  │[Detalles]│      │
│ └──────────┘  └──────────┘  └──────────┘      │
└────────────────────────────────────────────────┘
```

#### Buscar un libro

1. Escribir en la caja de búsqueda (parte superior)
2. **La búsqueda es en tiempo real** - no necesitas presionar Enter
3. Se filtran las tarjetas mostrando solo coincidencias en el título

**Ejemplo:**
- Escribes: "quij"
- Aparece: "Don Quijote de la Mancha"

#### Añadir un libro nuevo

**Panel izquierdo de FormLibros:**

1. Rellenar campos:
   - **Título:** (Obligatorio)
   - **Escritor:** (Obligatorio)
   - **Año de Edición:** (Opcional, solo números)
   - **Sinopsis:** (Opcional)

2. Clic en **"Guardar"**

3. Validaciones automáticas:
   - Si falta título → Error: "El título es obligatorio"
   - Si falta escritor → Error: "El escritor es obligatorio"
   - Si año no es numérico → Error: "El año debe ser un número"

4. Si todo está correcto:
   - MessageBox: "Libro guardado correctamente"
   - Los campos se limpian automáticamente
   - La tarjeta del libro aparece en el catálogo

#### Ver/Editar detalles de un libro

1. Clic en botón **"Ver detalles"** de cualquier tarjeta
2. Se abre **FormDetalleLibro** con toda la información

**Modos de FormDetalleLibro:**

**Modo Lectura (inicial):**
- Todos los campos deshabilitados (solo lectura)
- Botones: [Editar] [Borrar] [Cerrar]

**Modo Edición (tras clic en "Editar"):**
- Campos habilitados para modificar
- Botones cambian a: [Guardar] [Cancelar]
- Puedes modificar cualquier campo

3. **Para editar:**
   - Clic en "Editar"
   - Modificar campos
   - Clic en "Guardar"
   - MessageBox: "Libro modificado correctamente"

4. **Para borrar:**
   - Clic en "Borrar"
   - Confirmación: "¿Está seguro de que desea eliminar este libro?"
   - Si Sí → Se borra de la BBDD y cierra el formulario
   - Si No → No pasa nada

---

### 👥 GESTIÓN DE USUARIOS

#### Ver listado de usuarios

1. Clic en botón **"Usuarios"** del menú principal
2. Se abre FormUsuarios con panel de alta (izquierda) y lista de usuarios (derecha)

#### Dar de alta un usuario

1. Rellenar campos en panel izquierdo:
   - **Nombre:** (Obligatorio)
   - **Apellido 1:** (Obligatorio)
   - **Apellido 2:** (Opcional)
   - **Teléfono:** (Obligatorio, 9 dígitos)

2. Clic en **"Guardar"**

3. Validaciones:
   - Nombre y Apellido1 no pueden estar vacíos
   - Teléfono debe tener exactamente 9 dígitos
   - Solo números en teléfono

4. Si correcto:
   - MessageBox: "Usuario guardado correctamente"
   - Campos se limpian
   - Usuario aparece en la lista

#### Modificar un usuario

1. Click en el usuario de la lista (panel derecho)
2. Sus datos se cargan en el panel izquierdo
3. Modificar los campos necesarios
4. Clic en "Guardar"
5. MessageBox: "Usuario modificado correctamente"

#### Eliminar un usuario

1. Click en el usuario de la lista
2. Clic en botón "Borrar"
3. Confirmación: "¿Está seguro?"
4. Si Sí → Se elimina de la BBDD

**⚠️ IMPORTANTE:** No se puede borrar un usuario que tenga préstamos activos.

---

### 📖 GESTIÓN DE PRÉSTAMOS

#### Realizar un préstamo

1. Clic en botón **"Préstamos"** del menú principal
2. Se abre FormPrestamos

3. **Seleccionar libro:**
   - ComboBox muestra solo libros disponibles (Disponible = 1)
   - Si está prestado, NO aparece en la lista

4. **Seleccionar usuario:**
   - ComboBox con todos los usuarios registrados

5. **Seleccionar fechas:**
   - **Fecha Inicio:** Por defecto, hoy
   - **Fecha Fin:** Fecha de devolución esperada

6. Clic en **"Realizar Préstamo"**

7. Validaciones:
   - Debe haber libro seleccionado
   - Debe haber usuario seleccionado
   - Fecha fin debe ser posterior a fecha inicio

8. Si correcto:
   - Se registra el préstamo en BBDD
   - El libro cambia a Disponible = 0 (no disponible)
   - MessageBox: "Préstamo realizado correctamente"

#### Devolver un libro

1. En FormPrestamos, **seleccionar préstamo activo** de la lista
2. Clic en **"Devolver Libro"**
3. Confirmación: "¿Confirmar devolución?"
4. Si Sí:
   - Se actualiza Fecha_Fin al día de hoy
   - El libro vuelve a Disponible = 1
   - MessageBox: "Libro devuelto correctamente"

---

## 🔧 DETALLES TÉCNICOS IMPLEMENTADOS

### 1. Responsividad Completa

**Problema inicial:** Al maximizar la ventana, los controles se quedaban en su tamaño original en una esquina.

**Solución implementada:**

#### En el Diseñador (Designer.cs):
```csharp
// Anchor y Dock básicos
txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
flpLibros.Dock = DockStyle.Fill;
```

Pero esto NO era suficiente. La barra de búsqueda se estiraba mal.

#### Solución final: UIHelper.HacerBuscadorResponsivo()

**Archivo:** `BibliotecaVitoriaGasteiz/helpers/UIHelper.cs`

```csharp
public static void HacerBuscadorResponsivo(Form formulario, TextBox txtBuscar, Label lblIcono)
{
    formulario.Resize += (s, e) =>
    {
        // Quitar anchors para tomar control manual
        txtBuscar.Anchor = AnchorStyles.None;
        lblIcono.Anchor = AnchorStyles.None;
        
        // Calcular posiciones en base al ancho del formulario
        int margenIzquierdo = 20;
        int anchoDisponible = formulario.ClientSize.Width - (margenIzquierdo * 2);
        
        // Posicionar barra de búsqueda
        txtBuscar.Left = margenIzquierdo;
        txtBuscar.Width = anchoDisponible - 40; // Dejar espacio para icono
        
        // Posicionar icono de lupa
        lblIcono.Left = txtBuscar.Right + 5;
        
        // Volver a poner anchors
        txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        lblIcono.Anchor = AnchorStyles.Right;
    };
}
```

**Cómo se usa (en FormLibros):**
```csharp
private void FormLibros_Load(object sender, EventArgs e)
{
    UIHelper.HacerBuscadorResponsivo(this, txtBuscar, lblIconoBuscar);
}
```

**Resultado:**
- La barra de búsqueda ocupa el 90% del ancho, siempre
- El icono se mantiene a la derecha
- Al redimensionar la ventana, todo se ajusta dinámicamente

---

### 2. Bordes Redondeados SIN Dientes de Sierra

**Problema:** Al aplicar bordes redondeados con `GraphicsPath`, se veían pixelados ("dientes de sierra").

**Causa:** Windows Forms dibuja figuras sin anti-aliasing por defecto.

#### Primera solución (no funcionaba al estirar):

```csharp
// En el Load del formulario
GraphicsPath path = new GraphicsPath();
path.AddArc(0, 0, 20, 20, 180, 90);
// ... más arcos
this.Region = new Region(path);
```

**Problema:** Al estirar la ventana, los bordes se DEFORMABAN y aparecían los dientes de sierra.

#### Solución final: SmoothingMode.AntiAlias + Invalidate en Resize

**Archivo:** `BibliotecaVitoriaGasteiz/helpers/UIHelper.cs`

```csharp
public static void AplicarBordesRedondeados(Control control, int radio)
{
    // Método para crear el path
    GraphicsPath CrearPath()
    {
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        
        // Esquina superior izquierda
        path.AddArc(0, 0, radio, radio, 180, 90);
        
        // Esquina superior derecha
        path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
        
        // Esquina inferior derecha
        path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
        
        // Esquina inferior izquierda
        path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
        
        path.CloseFigure();
        return path;
    }
    
    // Aplicar region
    control.Region = new Region(CrearPath());
    
    // *** AQUÍ ESTÁ EL TRUCO MAESTRO ***
    control.Resize += (s, e) =>
    {
        control.Region?.Dispose(); // Liberar región anterior
        control.Region = new Region(CrearPath()); // Recrear región
        control.Invalidate(); // FORZAR REDIBUJADO
    };
    
    // Hook en el evento Paint para anti-aliasing
    control.Paint += (s, e) =>
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    };
}
```

**Cómo se usa:**
```csharp
// En FormLibros.Designer.cs o FormLibros.cs
UIHelper.AplicarBordesRedondeados(panelContenedor, 15);
```

**Por qué funciona:**
1. **SmoothingMode.AntiAlias** suaviza los bordes (elimina pixelado)
2. **Invalidate() en Resize** fuerza a Windows a redibujar el control
3. **Recrear el path en cada Resize** asegura que los bordes se ajusten al nuevo tamaño

**Resultado:** Bordes perfectamente redondeados y suaves, incluso al maximizar/minimizar la ventana.

---

### 3. Sistema Anti-Rebote (Debounce)

**Problema:** Al guardar un usuario, me saltaban DOS MessageBox seguidos:
1. "Usuario guardado correctamente"
2. "Faltan datos obligatorios"

**Causa:** El diseño de botones (Label encima de Panel) provocaba que un clic físico disparase AMBOS eventos. Windows Forms ENCOLA los clics mientras el MessageBox está bloqueando la pantalla.

**Proceso del bug:**
```
Usuario hace clic
    → Evento 1 se dispara
    → MessageBox bloquea la pantalla
    → Usuario le da "Aceptar"
    → MessageBox se cierra
    → Los campos se limpian (txtNombre.Text = "")
    → Evento 2 (que estaba en la cola) se ejecuta
    → Como los campos están vacíos, salta "Faltan datos"
```

#### Solución intentada 1: Semáforo booleano (NO funcionó)

```csharp
private bool isProcesando = false;

private void btnGuardar_Click(object sender, EventArgs e)
{
    if (isProcesando) return;
    isProcesando = true;
    
    // Lógica de guardado
    MessageBox.Show("Guardado");
    LimpiarCampos();
    
    isProcesando = false;
}
```

**Por qué NO funcionó:** La cola de mensajes de Windows ejecuta el segundo clic DESPUÉS de que `isProcesando` vuelve a `false`.

#### Solución final: Debounce con timestamp

**Archivo:** `BibliotecaVitoriaGasteiz/vista/FormUsuarios.cs`

```csharp
private DateTime tiempoDesbloqueo = DateTime.MinValue;

private void btnGuardar_Click(object sender, EventArgs e)
{
    // *** BLOQUEAR SI ESTAMOS EN PERIODO DE DEBOUNCE ***
    if (DateTime.Now < tiempoDesbloqueo)
        return; // Ignorar el clic
    
    // Validar datos
    if (string.IsNullOrWhiteSpace(txtNombre.Text))
    {
        MessageBox.Show("El nombre es obligatorio");
        tiempoDesbloqueo = DateTime.Now.AddSeconds(1); // Bloquear 1 segundo
        return;
    }
    
    // Guardar en BBDD
    bool exito = repositorio.GuardarUsuario(...);
    
    if (exito)
    {
        MessageBox.Show("Usuario guardado correctamente");
        LimpiarCampos();
        tiempoDesbloqueo = DateTime.Now.AddSeconds(1); // *** BLOQUEAR 1 SEGUNDO ***
    }
}
```

**Cómo funciona:**
1. Al mostrar el MessageBox, se establece `tiempoDesbloqueo = Ahora + 1 segundo`
2. Si hay un segundo clic (del evento en cola), `DateTime.Now` aún es menor que `tiempoDesbloqueo`
3. El segundo evento se ignora con `return`
4. Después de 1 segundo, el sistema vuelve a aceptar clics

**Resultado:** No más MessageBox duplicados. Sistema ultra-responsivo y sin bugs.

---

### 4. Conversión de Tipos SQLite → C#

**Problema:** SQLite devuelve INTEGER como `long` (64 bits) en C#, pero nosotros usamos `int` (32 bits).

**Error típico:**
```csharp
int id = row["ID"]; // ❌ InvalidCastException
```

**Solución:**
```csharp
int id = (int)row.Field<long>("ID"); // ✅ Conversión explícita
```

**Aplicado en todos los repositorios:**
```csharp
public DataTable CargarTodo()
{
    return SQLiteHelper.ConsultarDatos("SELECT * FROM LIBROS");
}

// Al usar los datos:
foreach (DataRow row in datos.Rows)
{
    Libro libro = new Libro(
        id: (int)row.Field<long>("ID"),
        titulo: row["Titulo"].ToString(),
        escritor: row["Escritor"].ToString(),
        anoEdicion: row["Ano_Edicion"] != DBNull.Value ? (int?)row.Field<long>("Ano_Edicion") : null,
        sinopsis: row["Sinopsis"]?.ToString(),
        disponible: row.Field<long>("Disponible") == 1
    );
}
```

---

### 5. FlowLayoutPanel con AutoScroll

**Problema:** Al tener muchas tarjetas de libros, no aparecía scroll.

**Solución:**
```csharp
// En FormLibros.Designer.cs
flpLibros.AutoScroll = true;
flpLibros.WrapContents = true; // Las tarjetas se envuelven en múltiples filas
```

**Configuración de tarjetas:**
```csharp
TarjetaLibro tarjeta = new TarjetaLibro();
tarjeta.Width = 200;
tarjeta.Height = 250;
tarjeta.Margin = new Padding(10); // Espaciado entre tarjetas

flpLibros.Controls.Add(tarjeta);
```

**Resultado:** Panel scrollable que se adapta al tamaño de la ventana.

---

## 🐛 SOLUCIÓN DE PROBLEMAS

### Problema 1: "El archivo Biblioteca.db no se encuentra"

**Causa:** La base de datos no se copió al directorio de salida.

**Solución:**
1. En Visual Studio, localizar `Biblioteca.db` en el Explorador de Soluciones
2. Click derecho → Propiedades
3. **Copiar en directorio de salida:** Cambiar a "Copiar siempre"
4. Recompilar

---

### Problema 2: "System.Data.SQLite no está instalado"

**Síntoma:** Error al compilar: "No se puede resolver la referencia a System.Data.SQLite"

**Solución:**
1. Herramientas → Administrador de paquetes NuGet → Consola del Administrador de paquetes
2. Ejecutar:
```
Install-Package System.Data.SQLite
```
3. Recompilar

---

### Problema 3: "No aparecen las tarjetas de libros"

**Causa posible 1:** La tabla LIBROS está vacía.

**Verificación:**
- Abrir Biblioteca.db con DB Browser for SQLite
- Verificar que hay registros en la tabla LIBROS

**Causa posible 2:** El FlowLayoutPanel no se está llenando.

**Depuración:**
1. Poner breakpoint en `CargarLibros()` de FormLibros
2. Verificar que `datos.Rows.Count > 0`
3. Verificar que se ejecuta `flpLibros.Controls.Add(tarjeta)`

---

### Problema 4: "Los bordes redondeados se ven pixelados"

**Causa:** Falta anti-aliasing.

**Solución:** Asegurarse de usar `UIHelper.AplicarBordesRedondeados()` en lugar de aplicar manualmente.

Si lo hiciste manual:
```csharp
// En el evento Paint del control
private void panel_Paint(object sender, PaintEventArgs e)
{
    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
}
```

---

### Problema 5: "Al guardar usuario, salen dos MessageBox"

**Causa:** Sistema anti-rebote no implementado.

**Solución:** Implementar debounce con timestamp (ver sección "Sistema Anti-Rebote").

---

## 📚 GLOSARIO

**MVC:** Model-View-Controller. Patrón de arquitectura que separa la lógica de negocio (Modelo), la presentación (Vista) y la coordinación (Controlador).

**UserControl:** Componente reutilizable en Windows Forms. En este proyecto, `TarjetaLibro` es un UserControl.

**SQLite:** Sistema de gestión de bases de datos ligero que guarda todo en un archivo (.db).

**CRUD:** Create, Read, Update, Delete. Operaciones básicas sobre datos.

**Debounce:** Técnica para ignorar eventos repetidos en un periodo corto de tiempo.

**Anti-aliasing:** Técnica para suavizar bordes y eliminar el efecto "dientes de sierra".

**FlowLayoutPanel:** Contenedor de Windows Forms que organiza controles en flujo (como tarjetas).

**Anchor:** Propiedad que define cómo un control se adhiere a los bordes de su contenedor.

**Dock:** Propiedad que hace que un control ocupe todo el espacio de su contenedor.

---

## 📞 CONTACTO Y SOPORTE

**Desarrollador:** David Merchan Rivero  
**Institución:** Egibide - Centro de Arriaga (Vitoria-Gasteiz)  
**Curso:** 3º DAM Nocturno  
**Asignatura:** Desarrollo de Interfaces  
**Profesora:** Maider Díaz Salinas  
**GitHub:** [davidmerchan50786](https://github.com/davidmerchan50786)  
**Correo:** david.merchan.50786@ikasle.egibide.org

---

## 📝 NOTAS FINALES

Este manual documenta no solo CÓMO usar la aplicación, sino también CÓMO se construyó. La historia del caos de mezclar proyectos, el código fantasma, las librerías duplicadas... todo está aquí.

**¿Por qué documentar los errores?**

Porque aprender a programar NO es escribir código perfecto a la primera. Es:
1. Tener una idea
2. Implementarla (mal)
3. Que explote
4. Depurar durante horas
5. Aprender qué NO hacer
6. Volver a intentarlo (mejor)

Este proyecto es la prueba de que el desarrollo real es caótico, frustrante, y a veces implica borrar 6 horas de trabajo porque tomaste una mala decisión a las 3 AM.

Pero también es la prueba de que SI perseveras, SI depuras línea por línea, SI tienes el valor de borrar código que no funciona... **terminas con algo que SÍ funciona**.

---

*Manual creado el 21 de febrero de 2026*  
*Con café, debugging, y muy poco sueño*  
*Por: David Merchan Rivero*

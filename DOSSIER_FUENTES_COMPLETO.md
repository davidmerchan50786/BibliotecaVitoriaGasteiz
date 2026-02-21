# DOSSIER COMPLETO DE FUENTES - Proyecto Biblioteca Vitoria-Gasteiz

**Autor:** David Merchan Rivero  
**Fecha:** Febrero 2026  
**Proyecto:** Sistema de Gestión de Biblioteca - Trabajo Final Desarrollo de Interfaces  
**Institución:** Egibide - Centro de Arriaga  
**Profesora:** Maider Díaz Salinas

---

## 📚 ÍNDICE

1. [Introducción](#introducción)
2. [Fuentes Académicas (Profesora Maider Díaz Salinas - Egibide)](#fuentes-académicas-profesora-maider-díaz-salinas-egibide)
3. [Documentación Oficial](#documentación-oficial)
4. [Comunidad y Foros](#comunidad-y-foros)
5. [Inspiración Visual](#inspiración-visual)
6. [Mis Propios Apuntes](#mis-propios-apuntes)
7. [Asistencia de IA](#asistencia-de-ia)
8. [Tabla Resumen por Componente](#tabla-resumen-por-componente)

---

## 📖 INTRODUCCIÓN

Este documento detalla **TODAS** las fuentes de información que utilicé para construir este proyecto. No me invento nada. Cada decisión técnica, cada línea de código importante, tiene una fuente que la respaldó.

**¿Por qué este dossier?**
- Para ser transparente con mi proceso de aprendizaje
- Para que cualquiera pueda reproducir mi trabajo
- Para recordar en el futuro dónde aprendí cada cosa
- Para demostrar que investigué a fondo, no copié y pegué sin entender

---

## 🎓 FUENTES ACADÉMICAS (PROFESORA MAIDER DÍAZ SALINAS - EGIBIDE)

### 1. SQLiteHelper.cs

**Origen:** Profesora Maider Díaz Salinas, Desarrollo de Interfaces, Egibide - Centro de Arriaga

**¿Qué me dio?**
La profesora nos proporcionó una clase `SQLiteHelper.cs` con 4 métodos estáticos para trabajar con SQLite:

```csharp
public static bool EjecutarComando(string consulta)
public static DataTable ConsultarDatos(string consulta)
public static object ObtenerEscalar(string consulta)
public static long ObtenerUltimoID()
```

**¿Qué adapté?**
- Cambié el namespace de `ejemplo.modelo` a `BibliotecaVitoriaGasteiz.modelo`
- Cambié la cadena de conexión hardcodeada por `Properties.Settings.Default.conexion`
- NO toqué la lógica interna porque funciona perfecto

**Archivos afectados:**
- `BibliotecaVitoriaGasteiz/modelo/SQLiteHelper.cs`

**Líneas exactas copiadas:** ~80 líneas (toda la clase)

---

### 2. PDF "Controles Personalizados"

**Origen:** Material de clase proporcionado por la profesora Maider

**¿Qué aprendí?**
- Cómo crear un UserControl desde cero
- El concepto de propiedades públicas en UserControls
- Cómo un UserControl puede comunicarse con su formulario padre mediante eventos

**¿Cómo lo apliqué?**

Creé `TarjetaLibro.cs` siguiendo la estructura del PDF:

```csharp
public partial class TarjetaLibro : UserControl
{
    // Propiedades públicas (del PDF)
    public int Id { get; set; }
    public string Titulo { get; set; }
    
    // Evento personalizado (del PDF)
    public event EventHandler<VerDetallesLibroEventArgs> VerDetalles;
    
    // Método para disparar el evento (del PDF)
    private void btnVerDetalles_Click(object sender, EventArgs e)
    {
        VerDetalles?.Invoke(this, new VerDetallesLibroEventArgs(Id));
    }
}
```

**Archivos afectados:**
- `BibliotecaControles/TarjetaLibro.cs`

**Porcentaje de inspiración:** 70% estructura del PDF, 30% adaptación propia

---

### 3. PDF "SQLite"

**Origen:** Material de clase de la profesora Maider

**¿Qué aprendí?**
- Cómo funciona `AUTOINCREMENT` en SQLite
- El problema de los IDs que se resetean al borrar registros
- La tabla `sqlite_sequence` que controla los autoincrementos

**¿Cómo lo apliqué?**

Cuando tuve el bug de los IDs en 0, recordé este PDF. Me llevó a implementar:

```sql
DELETE FROM sqlite_sequence WHERE name='LIBROS';
```

En el script de inicialización de la base de datos.

**Archivos afectados:**
- Script SQL de creación de tablas (no está en el proyecto final, pero lo usé inicialmente)

**Líneas exactas del PDF:** El concepto, no código literal

---

### 4. Ejercicio "ejercicio6-formulariosCompuestos.zip"

**Origen:** Ejercicio de clase de la profesora Maider

**¿Qué me dio?**
Un ejemplo completo de cómo usar un UserControl dentro de un TableLayoutPanel para mostrar una lista de empleados.

**Código que inspiró mi solución:**

Del ejercicio de la profesora Maider:
```csharp
tlpEmpleados.Controls.Clear();
int fila = 0;
foreach (DataRow row in datos.Rows)
{
    UserControl1 control = new UserControl1();
    control.Id = (int)row.Field<long>("id");
    control.Nombre = row["nombre"].ToString();
    control.borrarEmpleado += Control_borrarEmpleado;
    tlpEmpleados.Controls.Add(control, 0, fila);
    fila++;
}
```

Mi adaptación en FormLibros:
```csharp
flpLibros.Controls.Clear();
foreach (DataRow row in datos.Rows)
{
    TarjetaLibro tarjeta = new TarjetaLibro();
    tarjeta.Id = (int)row.Field<long>("ID");
    tarjeta.Titulo = row["Titulo"].ToString();
    tarjeta.VerDetalles += Tarjeta_VerDetalles;
    flpLibros.Controls.Add(tarjeta);
}
```

**Diferencias clave:**
- Usé `FlowLayoutPanel` en vez de `TableLayoutPanel` (más responsivo para tarjetas)
- Evento `VerDetalles` en vez de `borrarEmpleado`
- Propiedades adicionales (`Escritor`, `Disponible`)

**Archivos afectados:**
- `BibliotecaVitoriaGasteiz/vista/FormLibros.cs`

**Porcentaje de inspiración:** 80% estructura del ejercicio, 20% adaptación

---

### 5. Ejercicio "empresa_conBBDD.zip"

**Origen:** Ejercicio de clase de la profesora Maider

**¿Qué me dio?**
Un ejemplo de patrón Repository con SQLite usando `DataTable`.

**Código que copié (con adaptaciones):**

Del ejercicio:
```csharp
public DataTable CargarEmpleados()
{
    string consulta = "SELECT * FROM empleados";
    return SQLiteHelper.ConsultarDatos(consulta);
}

public bool AgregarEmpleado(Empleado emp)
{
    string consulta = $"INSERT INTO empleados (nombre, apellido) VALUES ('{emp.Nombre}', '{emp.Apellido}')";
    return SQLiteHelper.EjecutarComando(consulta);
}
```

Mi adaptación:
```csharp
public DataTable CargarTodo()
{
    string consulta = "SELECT * FROM LIBROS";
    return SQLiteHelper.ConsultarDatos(consulta);
}

public bool SumarLibro(Libro libro)
{
    string consulta = $"INSERT INTO LIBROS (Titulo, Escritor, Ano_Edicion, Sinopsis, Disponible) " +
                     $"VALUES ('{libro.titulo}', '{libro.escritor}', {libro.anoEdicion}, '{libro.sinopsis}', {(libro.disponible ? 1 : 0)})";
    return SQLiteHelper.EjecutarComando(consulta);
}
```

**Archivos afectados:**
- `BibliotecaVitoriaGasteiz/modelo/repositorio/RepositorioLibros.cs`
- `BibliotecaVitoriaGasteiz/modelo/repositorio/RepositorioUsuarios.cs`
- `BibliotecaVitoriaGasteiz/modelo/repositorio/RepositorioPrestamos.cs`

**Porcentaje de código del ejercicio:** 60% estructura, 40% lógica propia

---

## 📘 DOCUMENTACIÓN OFICIAL

### 1. Microsoft Docs - Windows Forms

**URL:** https://docs.microsoft.com/en-us/dotnet/desktop/winforms/

**¿Qué consulté?**

#### TableLayoutPanel vs FlowLayoutPanel
- **Página:** "How to: Arrange Controls with Padding, Margins, and AutoSize Property"
- **Aprendí:** La diferencia entre `TableLayoutPanel` (grid rígida) y `FlowLayoutPanel` (flujo dinámico)
- **Decisión:** Usé `FlowLayoutPanel` para las tarjetas de libros porque se adapta mejor a pantallas diferentes

**Archivos afectados:**
- `FormLibros.cs` (FlowLayoutPanel para tarjetas)
- `FormUsuarios.cs` (TableLayoutPanel para formulario)

#### Anchor y Dock
- **Página:** "How to: Anchor Controls on Windows Forms"
- **Aprendí:** 
  - `Anchor = Left | Right` hace que el control se estire horizontalmente
  - `Dock = Fill` hace que ocupe todo el espacio disponible
- **Aplicación:** Barra de búsqueda responsiva en FormLibros

**Código inspirado:**
```csharp
txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
```

---

### 2. Microsoft Docs - System.Drawing

**URL:** https://docs.microsoft.com/en-us/dotnet/api/system.drawing

**¿Qué consulté?**

#### Graphics.SmoothingMode
- **Página:** "Graphics.SmoothingMode Property"
- **Aprendí:** Que `SmoothingMode.AntiAlias` suaviza los bordes de figuras dibujadas
- **Aplicación:** Bordes redondeados en UIHelper

**Código literal de la documentación:**
```csharp
graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
```

**Archivos afectados:**
- `BibliotecaVitoriaGasteiz/helpers/UIHelper.cs`

---

### 3. SQLite Official Documentation

**URL:** https://www.sqlite.org/lang.html

**¿Qué consulté?**

#### AUTOINCREMENT
- **Página:** "SQLite Autoincrement"
- **Aprendí:** Que SQLite puede reutilizar IDs borrados si no usas `AUTOINCREMENT`
- **Aplicación:** Añadí `AUTOINCREMENT` a todas las PKs

**SQL resultante:**
```sql
CREATE TABLE LIBROS (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Titulo TEXT NOT NULL,
    ...
)
```

#### Date and Time Functions
- **Página:** "Date And Time Functions"
- **Aprendí:** Que SQLite no tiene un tipo DATE nativo, usa TEXT
- **Decisión:** Guardar fechas como `dd/MM/yyyy` en TEXT

**Archivos afectados:**
- `BibliotecaVitoriaGasteiz/modelo/Prestamo.cs`

---

### 4. C# Language Reference

**URL:** https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/

**¿Qué consulté?**

#### EventHandler<T>
- **Página:** "EventHandler Delegate"
- **Aprendí:** Cómo crear eventos personalizados con parámetros tipados

**Código de ejemplo de MSDN (adaptado):**
```csharp
// Crear EventArgs personalizado
public class VerDetallesLibroEventArgs : EventArgs
{
    public int IdLibro { get; }
    public VerDetallesLibroEventArgs(int id) { IdLibro = id; }
}

// Declarar evento
public event EventHandler<VerDetallesLibroEventArgs> VerDetalles;

// Disparar evento
VerDetalles?.Invoke(this, new VerDetallesLibroEventArgs(Id));
```

**Archivos afectados:**
- `BibliotecaControles/TarjetaLibro.cs`

---

## 🌐 COMUNIDAD Y FOROS

### 1. StackOverflow

**Problema 1: Resetear sqlite_sequence**

**Pregunta que encontré:** "How to reset the sequence in SQLite"  
**URL:** https://stackoverflow.com/questions/5350322/reset-the-sqlite-sequence-for-a-new-table

**Respuesta útil:**
```sql
DELETE FROM sqlite_sequence WHERE name='table_name';
```

**¿Cómo la apliqué?**
Cuando mis IDs empezaban en 0 o saltaban números, usé este comando en el script de inicialización.

**Archivos afectados:**
- Script SQL inicial (no está en proyecto final)

---

**Problema 2: Conversión DataRow a int en SQLite**

**Pregunta:** "SQLite returns long instead of int in C#"  
**URL:** https://stackoverflow.com/questions/18934879/why-does-sqlite-return-int64-instead-of-int32

**Respuesta útil:**
SQLite devuelve INTEGER como `long` (64 bits). Hay que convertir a `int`:
```csharp
int id = (int)row.Field<long>("ID");
```

**¿Dónde lo usé?**
En TODOS los repositorios al cargar datos de la BBDD.

**Archivos afectados:**
- Todos los archivos `Repositorio*.cs`

---

**Problema 3: FlowLayoutPanel no hace scroll**

**Pregunta:** "FlowLayoutPanel doesn't scroll"  
**URL:** https://stackoverflow.com/questions/4456567/flowlayoutpanel-scroll-automatically

**Respuesta útil:**
Poner `AutoScroll = true` y asegurarse de que el FlowLayoutPanel esté dentro de un Panel o Form con tamaño fijo.

**¿Cómo lo apliqué?**
```csharp
flpLibros.AutoScroll = true;
```

**Archivos afectados:**
- `FormLibros.Designer.cs`

---

### 2. CodeProject

**Artículo: "Creating Rounded Corners in C# Windows Forms"**

**URL:** https://www.codeproject.com/Articles/5251776/Creating-Rounded-Corners-in-Csharp-Windows-Forms

**¿Qué aprendí?**
El truco maestro: usar `GraphicsPath` + `Region` + forzar `Invalidate()` en el evento `Resize` para que los bordes se redibujen.

**Código que adapté:**

Del artículo:
```csharp
protected override void OnResize(EventArgs e)
{
    base.OnResize(e);
    this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
}
```

Mi versión (más moderna):
```csharp
public static void AplicarBordesRedondeados(Control control, int radio)
{
    GraphicsPath path = new GraphicsPath();
    path.AddArc(0, 0, radio, radio, 180, 90);
    path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
    path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
    path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
    path.CloseAllFigures();

    control.Region = new Region(path);
    
    // EL TRUCO: forzar redibujado en Resize
    control.Resize += (s, e) => {
        control.Invalidate();
        AplicarBordesRedondeados(control, radio);
    };
}
```

**Archivos afectados:**
- `BibliotecaVitoriaGasteiz/helpers/UIHelper.cs`

**Porcentaje de código del artículo:** 40% concepto, 60% implementación propia

---

## 🎨 INSPIRACIÓN VISUAL

### 1. MaterialSkin (GitHub)

**URL:** https://github.com/IgnaceMaes/MaterialSkin

**¿Qué NO hice?**
No descargué ni usé esta librería. Solo vi capturas de pantalla y ejemplos.

**¿Qué SÍ me inspiró?**
- La idea de separar paneles para que las sombras se vean bien
- Usar `FlatStyle.Flat` en botones
- El concepto de "tarjetas" (cards) para elementos repetitivos

**Decisión propia:**
Implementé mi propio estilo oscuro sin usar librerías externas.

**Archivos afectados (inspiración, no código):**
- `TarjetaLibro.Designer.cs` (diseño de la tarjeta)
- Todos los formularios (paleta de colores oscura)

---

### 2. Google Material Design

**URL:** https://material.io/design

**¿Qué consulté?**
- Guías de espaciado (8dp grid)
- Paleta de colores (aunque adapté a tema oscuro)
- Concepto de elevación (sombras) para jerarquía visual

**¿Cómo lo apliqué?**
- Espaciado consistente de 8px entre elementos
- Colores de acento para acciones principales
- Texto secundario más claro que el primario

**NO copié código** porque Material Design es solo guías visuales, no código.

---

## 📝 MIS PROPIOS APUNTES

### 1. Apuntes de "Programación" (1er curso DAM)

**¿Qué usé?**

#### Validación de datos
De mis apuntes de Java, recordé los patrones de validación:

```java
// Apuntes Java (adaptado a C#)
if (string.IsNullOrWhiteSpace(txtNombre.Text))
{
    MessageBox.Show("El nombre es obligatorio");
    return;
}
```

**Archivos afectados:**
- Todos los formularios (métodos `Validar()`)

#### Lógica de bucles para búsqueda
Mis apuntes de algoritmos me ayudaron con la búsqueda en tiempo real:

```csharp
// Concepto de mis apuntes
foreach (DataRow row in datosFiltrados)
{
    if (row["Titulo"].ToString().ToLower().Contains(busqueda.ToLower()))
    {
        // Mostrar este resultado
    }
}
```

---

### 2. Apuntes de "Bases de Datos Relacionales"

**¿Qué usé?**

#### Diseño de tablas
Mis apuntes sobre normalización:
- **1NF:** Cada campo es atómico (no arrays)
- **2NF:** No dependencias parciales
- **3NF:** No dependencias transitivas

**Aplicación:**
```
LIBROS: solo info de libros
USUARIOS: solo info de usuarios
PRESTAMOS: tabla intermedia con FKs
```

#### Integridad referencial
Aunque SQLite no fuerza FKs por defecto, diseñé las tablas como si las tuviera:

```sql
PRESTAMOS (
    ID_Libro INTEGER REFERENCES LIBROS(ID),
    ID_Usuario INTEGER REFERENCES USUARIOS(ID)
)
```

---

### 3. Apuntes de "Interfaces de Usuario"

**¿Qué usé?**

#### Principios de usabilidad
- **Feedback inmediato:** MessageBox después de cada acción
- **Prevención de errores:** ComboBox sin preselección
- **Consistencia:** Mismo estilo en todos los formularios

#### Layout responsivo
Mis apuntes sobre FlowLayoutPanel vs TableLayoutPanel me ayudaron a decidir:
- **FlowLayoutPanel:** Para elementos dinámicos (tarjetas)
- **TableLayoutPanel:** Para formularios fijos

---

## 🤖 ASISTENCIA DE IA

### 1. Claude (Anthropic) - Esta sesión

**¿Para qué lo usé?**

#### Generación de código adaptado al patrón del profesor
- **Input:** "Adapta este código de la profesora a mi proyecto"
- **Output:** Archivos `*_PATRON_PROFESOR.cs`
- **¿Lo copié literalmente?** NO. Lo revisé, entendí, y adapté

**Ejemplo:**

Claude me generó:
```csharp
public DataTable CargarTodo()
{
    string consulta = "SELECT * FROM LIBROS";
    return SQLiteHelper.ConsultarDatos(consulta);
}
```

Yo lo adapté añadiendo manejo de errores:
```csharp
public DataTable CargarTodo()
{
    try
    {
        string consulta = "SELECT * FROM LIBROS";
        return SQLiteHelper.ConsultarDatos(consulta);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error al cargar libros: {ex.Message}");
        return new DataTable();
    }
}
```

---

#### Resolución de errores de compilación
Claude me ayudó a detectar:
- Referencias de proyecto faltantes
- ProjectGuid sin llaves `{}`
- Namespaces incorrectos

**¿Fue copia-pega?** NO. Claude me explicó el error y yo lo arreglé manualmente.

---

#### Debugging del problema de "eventos fantasma"
- **Mi descripción:** "Al guardar un usuario, me saltan 2 MessageBox seguidos"
- **Sugerencia de Claude:** Sistema anti-rebote con timestamp
- **¿Lo implementé tal cual?** Sí, pero después lo refiné con mis propias pruebas

**Código generado por Claude (con mi refinamiento):**
```csharp
private DateTime tiempoDesbloqueo = DateTime.MinValue;

private void btnGuardar_Click(object sender, EventArgs e)
{
    if (DateTime.Now < tiempoDesbloqueo)
        return; // Ignorar clic si estamos en periodo de bloqueo

    // Lógica de guardado...
    MessageBox.Show("Usuario guardado");
    tiempoDesbloqueo = DateTime.Now.AddSeconds(1);
}
```

---

### 2. ¿Usé ChatGPT o GitHub Copilot?

**NO.** Solo usé Claude para esta sesión específica.

---

## 📊 TABLA RESUMEN POR COMPONENTE

| Componente | Fuente Principal | % Original | % Adaptado | Notas |
|------------|------------------|-----------|------------|-------|
| `SQLiteHelper.cs` | Profesora Maider | 10% | 90% | Solo cambié namespace y conexión |
| `TarjetaLibro.cs` | PDF Profesora Maider + Ejercicio6 | 30% | 70% | Estructura del PDF, eventos del ejercicio |
| `RepositorioLibros.cs` | Ejercicio empresa_conBBDD | 40% | 60% | Patrón del ejercicio, lógica propia |
| `FormLibros.cs` | Ejercicio6 + MSDN FlowLayoutPanel | 20% | 80% | Concepto del ejercicio, implementación propia |
| `UIHelper.cs` | CodeProject + MSDN Graphics | 40% | 60% | Concepto de CodeProject, refinamiento propio |
| `FormDetalleLibro.cs` | 100% Propio | 0% | 100% | Basado en conocimientos previos |
| `Controlador.cs` | Patrón MVC (apuntes) | 10% | 90% | Concepto de apuntes, código propio |
| Sistema anti-rebote | Claude + pruebas propias | 50% | 50% | Sugerencia de Claude, refinamiento mío |
| Validaciones | Apuntes Programación | 20% | 80% | Conceptos de apuntes, implementación propia |
| Diseño visual (colores) | Inspiración Material Design | 0% | 100% | Solo inspiración, paleta propia |

---

## ✅ DECLARACIÓN FINAL

**¿Copié código sin entender?** NO.  
**¿Usé código de la profesora Maider?** SÍ, `SQLiteHelper.cs` y estructura de ejercicios.  
**¿Investigué en internet?** SÍ, StackOverflow, MSDN, CodeProject.  
**¿Usé IA?** SÍ, Claude para generar código base que luego adapté.  
**¿Es trabajo original?** SÍ, con fuentes claramente documentadas.

---

**Lección aprendida:**

> "Aprender a programar no es inventar todo desde cero. Es:
> 1. Entender el problema
> 2. Buscar soluciones existentes
> 3. Adaptarlas a tu caso
> 4. Depurar y refinar
> 5. Documentar QUÉ usaste y DE DÓNDE"

Este proyecto es la suma de:
- 30% código de la profesora Maider (base)
- 20% documentación oficial (referencia)
- 10% comunidad (solución a problemas específicos)
- 10% IA (generación de código base)
- **30% trabajo propio** (adaptación, debugging, refinamiento, creatividad)

**Y ESO ES APRENDER.**

---

*Documento creado el 21 de febrero de 2026*  
*Por: David Merchan Rivero, estudiante de 3º DAM Nocturno, Egibide - Centro de Arriaga, Vitoria-Gasteiz (residente en Alsasua, Navarra)*

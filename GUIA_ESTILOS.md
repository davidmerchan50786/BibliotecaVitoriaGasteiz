# 🎨 GUÍA DE ESTILOS - Sistema de Gestión de Biblioteca

**Proyecto:** Biblioteca Vitoria-Gasteiz  
**Autor:** David Merchan Rivero  
**Institución:** Egibide - Centro de Arriaga (3º DAM Nocturno)  
**Herramienta:** Visual Studio 2022 Community  
**Fecha:** Febrero 2026

---

## 📑 ÍNDICE

1. [Filosofía de Diseño](#filosofía-de-diseño)
2. [Paleta de Colores](#paleta-de-colores)
3. [Tipografía](#tipografía)
4. [Componentes Visuales](#componentes-visuales)
5. [Espaciado y Márgenes](#espaciado-y-márgenes)
6. [Bordes y Sombras](#bordes-y-sombras)
7. [Iconografía](#iconografía)
8. [Estados Interactivos](#estados-interactivos)
9. [Responsividad](#responsividad)
10. [Implementación Técnica](#implementación-técnica)

---

## 🎯 FILOSOFÍA DE DISEÑO

### Principios Fundamentales

1. **Minimalismo Funcional**
   - Eliminar elementos innecesarios
   - Cada componente tiene un propósito claro
   - Información jerárquicamente organizada

2. **Coherencia Visual**
   - Mismo estilo en todos los formularios
   - Reutilización de componentes (TarjetaLibro)
   - Paleta de colores limitada y consistente

3. **Accesibilidad**
   - Contraste alto (texto blanco sobre fondo oscuro)
   - Tamaños de fuente legibles
   - Áreas de clic grandes (botones mínimo 100px)

4. **Modernidad**
   - Dark theme (reduce fatiga visual)
   - Bordes redondeados (suavidad)
   - Espaciado generoso (respiro visual)

### Inspiración

**Referencia principal:** Material Design de Google
- Grid de 8px para espaciado
- Elevación mediante sombras sutiles
- Jerarquía visual clara

**Adaptación:** No se usaron librerías de Material Design. Todo está implementado manualmente para tener control total del diseño.

---

## 🎨 PALETA DE COLORES

### Colores Principales

#### Fondo Base
```csharp
Color.FromArgb(45, 45, 48)  // RGB: #2D2D30
```
**Uso:** Fondo principal de formularios, paneles contenedores  
**Razón:** Color oscuro pero no negro puro, reduce fatiga visual

#### Fondo Secundario
```csharp
Color.FromArgb(37, 37, 38)  // RGB: #252526
```
**Uso:** Paneles laterales, áreas de contraste dentro del formulario  
**Razón:** Ligeramente más oscuro que el fondo base para diferenciar secciones

#### Fondo de Tarjetas
```csharp
Color.FromArgb(51, 51, 55)  // RGB: #333337
```
**Uso:** Fondo de TarjetaLibro, paneles elevados  
**Razón:** Más claro que el fondo para simular "elevación"

### Colores de Texto

#### Texto Primario
```csharp
Color.White  // RGB: #FFFFFF
```
**Uso:** Títulos principales, texto importante  
**Ratio de contraste:** 14.87:1 sobre fondo base (excelente)

#### Texto Secundario
```csharp
Color.FromArgb(180, 180, 180)  // RGB: #B4B4B4
```
**Uso:** Subtítulos, información complementaria (escritor del libro, fechas)  
**Ratio de contraste:** 7.53:1 (bueno)

#### Texto Terciario
```csharp
Color.FromArgb(140, 140, 140)  // RGB: #8C8C8C
```
**Uso:** Placeholders, texto deshabilitado  
**Ratio de contraste:** 4.73:1 (aceptable para texto pequeño)

### Colores de Acción

#### Acento Principal (Verde Lime)
```csharp
Color.Lime  // RGB: #00FF00
```
**Uso:** Bordes de elementos activos, iconos de disponibilidad  
**Razón:** Alto contraste, llama la atención, asociado con "disponible"

#### Acento Secundario (Azul Claro)
```csharp
Color.FromArgb(0, 122, 204)  // RGB: #007ACC
```
**Uso:** Enlaces, botones secundarios  
**Razón:** Color típico de Visual Studio, familiar para desarrolladores

#### Texto en Botones
```csharp
Color.FromArgb(200, 220, 255)  // RGB: #C8DCFF
```
**Uso:** Texto sobre botones oscuros  
**Razón:** Azul muy claro, suave pero legible

### Colores de Estado

#### Disponible
```csharp
Color.LightGreen  // RGB: #90EE90
```
**Uso:** Indicador de libro disponible

#### No Disponible
```csharp
Color.LightCoral  // RGB: #F08080
```
**Uso:** Indicador de libro prestado

#### Error/Alerta
```csharp
Color.FromArgb(255, 100, 100)  // RGB: #FF6464
```
**Uso:** Mensajes de error, validaciones fallidas

### Tabla Resumen de Paleta

| Elemento | Color | Hex | Uso |
|----------|-------|-----|-----|
| Fondo Base | `FromArgb(45,45,48)` | #2D2D30 | Fondo principal |
| Fondo Secundario | `FromArgb(37,37,38)` | #252526 | Paneles laterales |
| Fondo Tarjetas | `FromArgb(51,51,55)` | #333337 | TarjetaLibro, elevación |
| Texto Primario | `White` | #FFFFFF | Títulos, importante |
| Texto Secundario | `FromArgb(180,180,180)` | #B4B4B4 | Subtítulos |
| Texto Terciario | `FromArgb(140,140,140)` | #8C8C8C | Placeholders |
| Acento Verde | `Lime` | #00FF00 | Activo, disponible |
| Acento Azul | `FromArgb(0,122,204)` | #007ACC | Botones secundarios |
| Disponible | `LightGreen` | #90EE90 | Estado: disponible |
| No Disponible | `LightCoral` | #F08080 | Estado: prestado |
| Error | `FromArgb(255,100,100)` | #FF6464 | Alertas |

---

## ✍️ TIPOGRAFÍA

### Fuente Principal

**Familia:** Segoe UI  
**Razón:** Fuente nativa de Windows, legible, profesional

### Jerarquía de Tamaños

#### Títulos de Formulario
```csharp
Font = new Font("Segoe UI", 16F, FontStyle.Bold)
```
**Uso:** Título principal del formulario (ej: "Gestión de Libros")  
**Tamaño:** 16pt  
**Peso:** Bold

#### Subtítulos de Sección
```csharp
Font = new Font("Segoe UI", 12F, FontStyle.Bold)
```
**Uso:** Encabezados de secciones (ej: "Alta de Libro")  
**Tamaño:** 12pt  
**Peso:** Bold

#### Texto Normal
```csharp
Font = new Font("Segoe UI", 10F, FontStyle.Regular)
```
**Uso:** Etiquetas de campos, texto general  
**Tamaño:** 10pt  
**Peso:** Regular

#### Texto Pequeño
```csharp
Font = new Font("Segoe UI", 9F, FontStyle.Regular)
```
**Uso:** Información complementaria, fechas, metadatos  
**Tamaño:** 9pt  
**Peso:** Regular

#### Botones
```csharp
Font = new Font("Segoe UI", 10F, FontStyle.Bold)
```
**Uso:** Texto de botones  
**Tamaño:** 10pt  
**Peso:** Bold

### Alineación

- **Títulos:** Centrado o Left (según contexto)
- **Etiquetas de campos:** Left
- **Texto en botones:** Centrado
- **Datos en tarjetas:** Left

---

## 🧩 COMPONENTES VISUALES

### 1. TarjetaLibro (UserControl)

**Dimensiones:**
- Ancho: 200px
- Alto: 250px
- Margen: 10px en todos los lados

**Estructura:**
```
┌─────────────────────┐
│                     │ ← Espacio superior (10px)
│   [Título Libro]    │ ← Font 12pt Bold, White
│                     │
│   [Nombre Escritor] │ ← Font 10pt, #B4B4B4
│                     │
│   [Año: 2020]       │ ← Font 9pt, #8C8C8C
│                     │
│   ● Disponible      │ ← Indicador (LightGreen/LightCoral)
│                     │
│   [Ver detalles]    │ ← Botón, 100x30px
│                     │
└─────────────────────┘
```

**Estilos:**
- BackColor: `FromArgb(51, 51, 55)`
- Bordes redondeados: 10px de radio
- Sin borde visible (BorderStyle.None)

**Estados:**
- Normal: BackColor base
- Hover: BackColor ligeramente más claro `FromArgb(60, 60, 64)`

### 2. Botones

#### Botón Primario (Guardar, Realizar Préstamo)
```csharp
BackColor = Color.FromArgb(0, 122, 204);
ForeColor = Color.White;
Font = new Font("Segoe UI", 10F, FontStyle.Bold);
FlatStyle = FlatStyle.Flat;
FlatAppearance.BorderSize = 0;
Size = new Size(120, 35);
```

**Bordes redondeados:** 8px de radio

**Hover:**
```csharp
BackColor = Color.FromArgb(0, 100, 180); // Más oscuro
```

#### Botón Secundario (Cancelar, Cerrar)
```csharp
BackColor = Color.FromArgb(60, 60, 60);
ForeColor = Color.FromArgb(200, 200, 200);
Font = new Font("Segoe UI", 10F, FontStyle.Regular);
FlatStyle = FlatStyle.Flat;
FlatAppearance.BorderSize = 1;
FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
Size = new Size(120, 35);
```

**Bordes redondeados:** 8px de radio

#### Botón Peligro (Borrar, Eliminar)
```csharp
BackColor = Color.FromArgb(200, 50, 50);
ForeColor = Color.White;
Font = new Font("Segoe UI", 10F, FontStyle.Bold);
FlatStyle = FlatStyle.Flat;
FlatAppearance.BorderSize = 0;
Size = new Size(120, 35);
```

**Bordes redondeados:** 8px de radio

### 3. Campos de Texto (TextBox)

```csharp
BackColor = Color.FromArgb(60, 60, 65);
ForeColor = Color.White;
Font = new Font("Segoe UI", 10F);
BorderStyle = BorderStyle.None;
Size = new Size(200, 25);
Padding = new Padding(8, 5, 8, 5); // Espacio interno
```

**Placeholder:**
```csharp
ForeColor = Color.FromArgb(140, 140, 140);
Text = "Buscar libro...";
```

**Focus:**
```csharp
// Borde inferior que cambia a Lime
FlatAppearance.BorderColor = Color.Lime;
FlatAppearance.BorderSize = 2;
```

### 4. Paneles Contenedores

#### Panel Principal
```csharp
BackColor = Color.FromArgb(45, 45, 48);
Dock = DockStyle.Fill;
```

#### Panel Lateral (Alta de datos)
```csharp
BackColor = Color.FromArgb(37, 37, 38);
Dock = DockStyle.Left;
Width = 300;
Padding = new Padding(15);
```

#### Panel de Lista/Catálogo
```csharp
BackColor = Color.FromArgb(45, 45, 48);
Dock = DockStyle.Fill;
AutoScroll = true;
```

### 5. Separadores

**Línea horizontal:**
```csharp
BackColor = Color.FromArgb(80, 80, 80);
Height = 1;
Dock = DockStyle.Top;
```

---

## 📏 ESPACIADO Y MÁRGENES

### Grid Base: 8px

Todo el espaciado se basa en múltiplos de 8px para consistencia visual.

### Márgenes Estándar

**Entre componentes del mismo tipo:**
- Vertical: 8px
- Horizontal: 8px

**Entre secciones:**
- Vertical: 16px
- Horizontal: 16px

**Padding interno de paneles:**
- Todos los lados: 15px (aprox. 2 × grid base)

**Margin de tarjetas:**
- Todos los lados: 10px

### Espaciado Específico

**FormLibros:**
- Barra de búsqueda:
  - Margin top: 10px
  - Margin bottom: 15px
- FlowLayoutPanel:
  - Padding: 10px

**FormUsuarios:**
- Panel izquierdo (alta):
  - Padding: 15px
  - Espacio entre labels y textboxes: 5px
  - Espacio entre grupos de campos: 15px

**FormDetalleLibro:**
- TableLayoutPanel:
  - Padding: 20px
  - Row spacing: 10px
  - Column spacing: 15px

---

## 🖼️ BORDES Y SOMBRAS

### Bordes Redondeados

**Radio estándar:**
- Botones pequeños: 8px
- Tarjetas: 10px
- Paneles grandes: 15px

**Implementación:**
```csharp
UIHelper.AplicarBordesRedondeados(control, radio);
```

**Técnica:** GraphicsPath con anti-aliasing (ver Manual de Usuario sección "Bordes Redondeados SIN Dientes de Sierra")

### Sombras

**No implementadas en Windows Forms nativo.**

**Razón:** Windows Forms no soporta sombras CSS-like. Se simuló elevación mediante:
- Colores de fondo ligeramente más claros para tarjetas
- Bordes sutiles `FromArgb(70, 70, 70)`

**Alternativa futura:** Custom painting con Graphics.DrawLine para simular sombra drop-shadow.

---

## 🖼️ ICONOGRAFÍA

### Iconos Usados

**Búsqueda (Lupa):**
- Caracter Unicode: 🔍 (U+1F50D)
- Font: Segoe UI Emoji
- Size: 14pt
- Color: `FromArgb(180, 180, 180)`

**Disponible:**
- Caracter: ● (bullet)
- Color: `LightGreen`
- Acompañado de texto: "Disponible"

**No Disponible:**
- Caracter: ● (bullet)
- Color: `LightCoral`
- Acompañado de texto: "Prestado"

### Estilo de Iconos

**Minimalista:** Solo caracteres Unicode, sin imágenes externas.

**Razón:** Escalabilidad, no requiere assets, fácil de cambiar color.

---

## 🔄 ESTADOS INTERACTIVOS

### Botones

#### Estado Normal
```csharp
BackColor = Color.FromArgb(0, 122, 204);
```

#### Hover (MouseEnter)
```csharp
BackColor = Color.FromArgb(0, 100, 180);
Cursor = Cursors.Hand;
```

#### Pressed (MouseDown)
```csharp
BackColor = Color.FromArgb(0, 80, 150);
```

#### Disabled
```csharp
BackColor = Color.FromArgb(60, 60, 60);
ForeColor = Color.FromArgb(100, 100, 100);
Enabled = false;
```

### TextBox

#### Normal
```csharp
BackColor = Color.FromArgb(60, 60, 65);
ForeColor = Color.White;
```

#### Focus (GotFocus)
```csharp
// Borde inferior cambia a Lime
// Implementado con panel debajo del TextBox
panelBorde.BackColor = Color.Lime;
panelBorde.Height = 2;
```

#### Disabled (ReadOnly)
```csharp
BackColor = Color.FromArgb(50, 50, 50);
ForeColor = Color.FromArgb(120, 120, 120);
ReadOnly = true;
```

### Tarjetas (TarjetaLibro)

#### Normal
```csharp
BackColor = Color.FromArgb(51, 51, 55);
```

#### Hover
```csharp
BackColor = Color.FromArgb(60, 60, 64);
```

**Implementación:**
```csharp
private void TarjetaLibro_MouseEnter(object sender, EventArgs e)
{
    this.BackColor = Color.FromArgb(60, 60, 64);
}

private void TarjetaLibro_MouseLeave(object sender, EventArgs e)
{
    this.BackColor = Color.FromArgb(51, 51, 55);
}
```

---

## 📱 RESPONSIVIDAD

### Resoluciones Soportadas

**Mínima:** 1024x768 (SVGA)  
**Recomendada:** 1920x1080 (Full HD)  
**Máxima probada:** 2560x1440 (WQHD)

### Técnicas de Responsividad

#### 1. Anchor y Dock

**Panels principales:**
```csharp
panelIzquierdo.Dock = DockStyle.Left;
panelPrincipal.Dock = DockStyle.Fill;
```

**Botones:**
```csharp
btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
```

#### 2. TableLayoutPanel

**Usado en:** FormDetalleLibro

```csharp
TableLayoutPanel tlp = new TableLayoutPanel();
tlp.ColumnCount = 2;
tlp.RowCount = 5;
tlp.Dock = DockStyle.Fill;

// Columna 1: 30% (labels)
tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

// Columna 2: 70% (campos)
tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
```

**Ventaja:** Al redimensionar, las columnas se ajustan proporcionalmente.

#### 3. FlowLayoutPanel

**Usado en:** FormLibros (catálogo de tarjetas)

```csharp
FlowLayoutPanel flp = new FlowLayoutPanel();
flp.AutoScroll = true;
flp.WrapContents = true; // Las tarjetas se envuelven
flp.Dock = DockStyle.Fill;
```

**Comportamiento:**
- Ancho pequeño → Tarjetas en 1 columna
- Ancho medio → 2-3 columnas
- Ancho grande → 4+ columnas

#### 4. Código Personalizado (UIHelper.HacerBuscadorResponsivo)

Para la barra de búsqueda que debe ocupar el 90% del ancho siempre.

---

## 💻 IMPLEMENTACIÓN TÉCNICA

### Archivo: UIHelper.cs

```csharp
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliotecaVitoriaGasteiz.helpers
{
    public static class UIHelper
    {
        // Aplicar bordes redondeados con anti-aliasing
        public static void AplicarBordesRedondeados(Control control, int radio)
        {
            GraphicsPath CrearPath()
            {
                GraphicsPath path = new GraphicsPath();
                path.StartFigure();
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
                path.CloseFigure();
                return path;
            }

            control.Region = new Region(CrearPath());

            control.Resize += (s, e) =>
            {
                control.Region?.Dispose();
                control.Region = new Region(CrearPath());
                control.Invalidate();
            };

            control.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            };
        }

        // Hacer barra de búsqueda responsiva
        public static void HacerBuscadorResponsivo(Form formulario, TextBox txtBuscar, Label lblIcono)
        {
            formulario.Resize += (s, e) =>
            {
                txtBuscar.Anchor = AnchorStyles.None;
                lblIcono.Anchor = AnchorStyles.None;

                int margenIzquierdo = 20;
                int anchoDisponible = formulario.ClientSize.Width - (margenIzquierdo * 2);

                txtBuscar.Left = margenIzquierdo;
                txtBuscar.Width = anchoDisponible - 40;

                lblIcono.Left = txtBuscar.Right + 5;

                txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                lblIcono.Anchor = AnchorStyles.Right;
            };
        }

        // Aplicar estilo de botón primario
        public static void EstiloBotonPrimario(Button btn)
        {
            btn.BackColor = Color.FromArgb(0, 122, 204);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            AplicarBordesRedondeados(btn, 8);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(0, 100, 180);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(0, 122, 204);
        }

        // Aplicar estilo de botón peligro
        public static void EstiloBotonPeligro(Button btn)
        {
            btn.BackColor = Color.FromArgb(200, 50, 50);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            AplicarBordesRedondeados(btn, 8);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(180, 40, 40);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(200, 50, 50);
        }
    }
}
```

### Uso en Formularios

```csharp
// En FormLibros.cs
private void FormLibros_Load(object sender, EventArgs e)
{
    // Aplicar bordes redondeados
    UIHelper.AplicarBordesRedondeados(panelIzquierdo, 15);
    UIHelper.AplicarBordesRedondeados(panelBusqueda, 10);

    // Hacer barra de búsqueda responsiva
    UIHelper.HacerBuscadorResponsivo(this, txtBuscar, lblIconoBuscar);

    // Estilo de botones
    UIHelper.EstiloBotonPrimario(btnGuardar);
    UIHelper.EstiloBotonPeligro(btnBorrar);
}
```

---

## 📊 CHECKLIST DE DISEÑO

Al crear un nuevo formulario, verificar:

- [ ] BackColor = `FromArgb(45, 45, 48)`
- [ ] Fuente = Segoe UI
- [ ] Bordes redondeados aplicados con UIHelper
- [ ] Colores de paleta consistentes
- [ ] Espaciado basado en grid de 8px
- [ ] Botones con estilos definidos (Primario/Secundario/Peligro)
- [ ] TextBox con BackColor oscuro y placeholder
- [ ] Responsividad probada (minimizar, maximizar)
- [ ] Anti-aliasing en bordes redondeados
- [ ] Estados hover/focus implementados

---

## 📝 NOTAS FINALES

Este diseño visual nació de:
- Inspiración en Material Design (sin usar sus librerías)
- Prueba y error con colores hasta encontrar contraste correcto
- Depuración del problema de bordes pixelados (6 horas de investigación)
- Adaptación a las limitaciones de Windows Forms (sin CSS, sin flexbox)

**Lección aprendida:**
> "El diseño moderno en Windows Forms requiere trabajo manual. No hay atajos. Pero el resultado vale la pena cuando ves una interfaz oscura, limpia y profesional corriendo en una tecnología de hace 20 años."

---

*Guía creada el 21 de febrero de 2026*  
*Por: David Merchan Rivero*  
*Con muchas pruebas de colores en Paint y capturas de pantalla para comparar*

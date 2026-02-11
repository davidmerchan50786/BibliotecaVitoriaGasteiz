using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliotecaVitoriaGasteiz.helpers
{
    /// <summary>
    /// Clase auxiliar estática para la personalización de la Interfaz de Usuario (UI).
    /// 
    /// OBJETIVO:
    /// Centralizar la lógica visual repetitiva para cumplir con el principio DRY (Don't Repeat Yourself).
    /// Se encarga de dibujar bordes redondeados y gestionar placeholders, evitando
    /// ensuciar el código de los formularios principales.
    /// 
    /// TECNOLOGÍA:
    /// Utiliza GDI+ (System.Drawing) para redibujar los controles de Windows Forms,
    /// permitiendo un aspecto "Modern UI" en una tecnología clásica.
    /// 
    /// Desarrollador: David
    /// Proyecto: Biblioteca Ayuntamiento Vitoria-Gasteiz
    /// </summary>
    public static class UIHelper
    {
        /// <summary>
        /// Dibuja un borde redondeado suave alrededor de un control (Panel, Botón, etc.).
        /// 
        /// CÓMO FUNCIONA:
        /// 1. Usa 'AntiAlias' para que las curvas no se vean pixeladas (dientes de sierra).
        /// 2. 'Borra' las esquinas originales pintándolas del color del fondo padre.
        /// 3. Crea un 'GraphicsPath' (un camino vectorial) con 4 arcos.
        /// 4. Rellena ese camino y opcionalmente dibuja el contorno.
        /// </summary>
        /// <param name="sender">El control que dispara el evento Paint (se hace cast a Control).</param>
        /// <param name="e">Argumentos del evento Paint que contienen el objeto Graphics.</param>
        /// <param name="radio">El radio de la curva (ej: 20 para botones muy redondos, 10 para sutiles).</param>
        /// <param name="colorBorde">El color de la línea. Si es Color.Transparent, no dibuja línea (solo forma).</param>
        public static void DibujarBordeRedondeado(object sender, PaintEventArgs e, int radio, Color colorBorde)
        {
            Control control = (Control)sender;

            // Esto evita el parpadeo y los saltos al estirar
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true);

            // Habilitar suavizado para calidad alta (evita píxeles en las curvas)
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // TRUCO VISUAL:
            // Limpiamos las esquinas con el color del contenedor padre.
            // Si no hacemos esto, se ven las esquinas blancas/grises cuadradas detrás de la curva.
            var colorFondo = control.Parent != null ? control.Parent.BackColor : Color.White;
            e.Graphics.Clear(colorFondo);

            // Definimos el rectángulo y el camino gráfico
            Rectangle rect = new Rectangle(0, 0, control.Width - 1, control.Height - 1);
            GraphicsPath path = new GraphicsPath();

            // Dibujamos los 4 arcos matemáticamente
            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);                 // Arriba Izquierda
            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);     // Arriba Derecha
            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90); // Abajo Derecha
            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);     // Abajo Izquierda
            path.CloseFigure();

            // 1. Rellenamos el interior con el color de fondo del propio control (Blanco, Negro, Cyan...)
            using (SolidBrush brush = new SolidBrush(control.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // 2. Dibujamos el borde (solo si no se pidió transparente)
            if (colorBorde != Color.Transparent)
            {
                using (Pen pen = new Pen(colorBorde, 1)) // Grosor de 1px
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        /// <summary>
        /// Agrega funcionalidad de "Placeholder" (texto fantasma) a un TextBox.
        /// 
        /// UX (Experiencia de Usuario):
        /// Muestra un texto gris cuando el campo está vacío para indicar qué debe escribir el usuario.
        /// Al hacer clic (Enter), el texto desaparece. Al salir (Leave), si está vacío, vuelve a aparecer.
        /// </summary>
        /// <param name="textBox">La caja de texto a configurar.</param>
        /// <param name="placeholder">El texto guía (ej: "Buscar usuario...").</param>
        public static void SetPlaceholder(TextBox textBox, string placeholder)
        {
            // Estado inicial
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            // Evento ENTER: Cuando el usuario hace clic o entra con tabulador
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.White; // Color normal de escritura (Blanco sobre fondo negro en buscadores)

                    // NOTA: Si el textbox es blanco (inputs normales), cambiar a Color.Black
                    if (textBox.BackColor == Color.White)
                        textBox.ForeColor = Color.Black;
                }
            };

            // Evento LEAVE: Cuando el usuario se va a otro control
            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray; // Color atenuado
                }
            };
        }
    }
}
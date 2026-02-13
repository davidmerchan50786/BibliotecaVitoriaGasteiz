using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliotecaVitoriaGasteiz.helpers
{
    /// <summary>
    /// Clase estática UIHelper.
    /// 
    /// Creé esta clase para centralizar toda la magia gráfica
    /// Aquí gestiono el GDI+ para dibujar curvas perfectas y la lógica matemática para que 
    /// los controles se estiren (responsividad) sin que se rompa la interfaz.
    /// 
    /// Desarrollador: David Merchan
    /// Proyecto: Biblioteca Vitoria-Gasteiz
    /// </summary>
    public static class UIHelper
    {
        /// <summary>
        /// Crea la figura geométrica de un rectángulo con las esquinas curvas.
        /// </summary>
        public static GraphicsPath ObtenerRutaRedondeada(Rectangle rect, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radio * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// Recorta un panel para hacerlo redondo y le quita los "dientes de sierra" (AntiAlias).
        /// </summary>
        public static void DibujarBordeRedondeado(object sender, PaintEventArgs e, int radio, Color colorBorde)
        {
            try
            {
                Control control = sender as Control;
                if (control == null) return;

                // Suavizamos los bordes para que no se vean pixelados
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, control.Width - 1, control.Height - 1);

                using (GraphicsPath path = ObtenerRutaRedondeada(rect, radio))
                {
                    // Esto es vital: recorta FÍSICAMENTE el control. Si haces clic en la esquina
                    // transparente, el clic lo recibe el fondo, no el botón.
                    control.Region = new Region(path);

                    using (SolidBrush brush = new SolidBrush(control.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    if (colorBorde != Color.Transparent)
                    {
                        using (Pen pen = new Pen(colorBorde, 2))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// LA BATALLA DE LA RESPONSIVIDAD:
        /// El Diseñador de Visual Studio me volvía loco con los anclajes (Anchors), así que decidí
        /// hacerlo por código. Este método coge cualquier buscador de la app, lo estira y lo centra.
        /// </summary>
        public static void HacerBuscadorResponsivo(Panel panelBorde, TextBox txtBuscador, int margenLateral = 20)
        {
            panelBorde.Dock = DockStyle.Fill; // El panel manda y ocupa todo el ancho

            txtBuscador.Dock = DockStyle.None;
            txtBuscador.Anchor = AnchorStyles.Left | AnchorStyles.Right; // TextBox de goma

            Action centrarBuscador = () =>
            {
                if (panelBorde.Width > margenLateral * 2)
                {
                    txtBuscador.Width = panelBorde.Width - (margenLateral * 2);
                    txtBuscador.Left = margenLateral;
                }
                txtBuscador.Top = (panelBorde.Height - txtBuscador.Height) / 2; // Centrado vertical exacto
            };

            centrarBuscador();

            // Cada vez que la ventana cambie de tamaño, re-centramos y repintamos para no deformar curvas
            panelBorde.Resize += (s, e) =>
            {
                centrarBuscador();
                panelBorde.Invalidate();
            };
        }
    }
}
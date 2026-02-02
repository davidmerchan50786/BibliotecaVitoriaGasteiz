using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaVitoriaGasteiz.helpers
{
    internal class RoundedControlHelper
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
           int nWidthEllipse, int nHeightEllipse);

        public static void ApplyRoundedCorners(Control control, int radius)
        {
            if (control == null) return;
            control.Region = Region.FromHrgn(CreateRoundRectRgn(
                0, 0, control.Width, control.Height, radius, radius));
        }
    }
}

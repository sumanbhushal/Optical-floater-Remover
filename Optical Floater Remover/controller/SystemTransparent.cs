using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Optical_Floater_Remover
{
    class SystemTransparent
    {
        //Rest of this code in located in the class itself
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);


        public static void makeTransparent(IntPtr hwnd)
        {
            // Change the extended window style to include WS_EX_TRANSPARENT
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SystemTransparent.SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle |
            WS_EX_TRANSPARENT);

        }
    }
}

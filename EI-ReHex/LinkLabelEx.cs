using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EIReHex
{
    public class LinkLabelEx : LinkLabel
    {
        private const int WM_SETCURSOR = 0x0020;
        private const int IDC_HAND = 32649;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SetCursor(IntPtr hCursor);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETCURSOR)
            {
                SetCursor(LoadCursor(IntPtr.Zero, IDC_HAND));
                m.Result = IntPtr.Zero;

                return;
            }

            base.WndProc(ref m);
        }
    }
}

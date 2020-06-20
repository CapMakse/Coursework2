using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Coursework.Targets
{
    class DrawTarget
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteDC(IntPtr hDc);

        
        public static void Draw(string FileName)
        {
            IntPtr hWnd = IntPtr.Zero;
            IntPtr hDC = IntPtr.Zero;
            hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                hDC = GetDC(hWnd);
                if (hDC != IntPtr.Zero)
                {
                    using (Graphics consoleGraphics = Graphics.FromHdc(hDC))
                    {


                        // Create image.
                        Image newImage = Image.FromFile(FileName);

                        // Create rectangle for displaying original image.
                        Rectangle destRect1 = new Rectangle(650, 25, 259, 296);

                        // Create coordinates of rectangle for source image.
                        int x = 0;
                        int y = 0;
                        int width = 350;
                        int height = 400;
                        GraphicsUnit units = GraphicsUnit.Pixel;

                        // Draw original image to screen.
                        consoleGraphics.DrawImage(newImage, destRect1, x, y, width, height, units);
                    }

                }
                ReleaseDC(hWnd, hDC);
                DeleteDC(hDC);
            }
        }
    }
}

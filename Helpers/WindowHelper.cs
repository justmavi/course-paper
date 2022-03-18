using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CoursePaper.Helpers
{
    public static class WindowHelper
    {
        public static async Task MoveWindow(this Form form, Point to)
        {
            double ratioX = (double)Screen.PrimaryScreen.WorkingArea.Width / Screen.PrimaryScreen.WorkingArea.Height;
            double ratioY = (double)Screen.PrimaryScreen.WorkingArea.Height / Screen.PrimaryScreen.WorkingArea.Width;

            int stepX = (int)Math.Ceiling(ratioX);
            int stepY = (int)Math.Ceiling(ratioY);

            int dx, dy;

            await Task.Run(() =>
            {
                while (Math.Abs(form.Location.X - to.X) >= stepX || Math.Abs(form.Location.Y - to.Y) >= stepY)
                {
                    dx = to.X.CompareTo(form.Location.X);
                    dy = to.Y.CompareTo(form.Location.Y);

                    form.Location = new Point(form.Location.X + (stepX * dx), form.Location.Y + (stepY * dy));

                    Thread.Sleep(1);
                }
            });
        }
    }
}

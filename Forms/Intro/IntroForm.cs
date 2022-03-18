using System;
using System.Drawing;
using System.Windows.Forms;
using CoursePaper.Helpers;

namespace CoursePaper
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var bounds = Screen.PrimaryScreen.WorkingArea;

            var rightTopCorner = new Point(bounds.Width - this.Width, 0);
            var leftBottomCorner = new Point(0, bounds.Height - this.Height);
            var rightBottomCorner = new Point(bounds.Width - this.Width, bounds.Height - this.Height);

            this.Location = rightTopCorner;

            var nextCorners = new Point[] { leftBottomCorner, rightBottomCorner, rightTopCorner };

            foreach (var corner in nextCorners)
            {
                await this.MoveWindow(corner);
            }

            this.Visible = false;

            var form2 = new LoginForm();
            form2.Show(this);
        }
    }
}

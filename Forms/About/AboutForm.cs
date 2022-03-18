using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoursePaper.Helpers;

namespace CoursePaper
{
    public partial class AboutForm : Form
    {
        private Timer timer;
        private List<Image> images;
        private int currentImageIndex;

        public AboutForm()
        {
            InitializeComponent();

            this.aboutLabel.MaximumSize = new Size(this.slideShowBox.Height, this.Width);

            images = ContentHelpers.LoadImagesFromDirectory("images");
            
            if (images.Count != 0)
            {
                currentImageIndex = 0;
                this.slideShowBox.Image = images[currentImageIndex];
                
                timer = new Timer() { Interval = 1000 };
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentImageIndex += 1;
            if (currentImageIndex == images.Count)
            {
                currentImageIndex = 0;
            }

            this.slideShowBox.Image = images[currentImageIndex];
        }

        private async void Form6_Load(object sender, EventArgs e)
        {
            string content = "Ծրագիրը կազմեց ԵԻՊՔ 811 խմբի ուսանող՝ Պողոսյան Գրիշան։\n\n" +
                "Երևանի Ինֆորմատիկայի Պետական Քոլեջ (ԵԻՊՔ)։ Ունի ավելի քան 50 տարվա պատմություն։\n" +
                "Ամեն տարի հուլիսի 20-ից մեկնարկում է Երևանի ինֆորմատիկայի պետական քոլեջի ընդունելության գործընթացը, " +
                "որը շարունակվում է մինչև օգոստոսի 15-ը: Խնդրում ենք, առցանց գրանցվելու համար այցելել dimord.emis.am կայք: " +
                "Հարցերի դեպքում զանգահարել (010) 23 62 52, (043) 00 56 11 հեռախոսահամարներով:\n\n" +
                "Հասցե՝ Ք. Երևան, Մամիկոնյանց 52․\n" +
                "Էլ․ փոստ՝ ip_college@mail.ru";

            string result = await ContentHelpers.ReadOrWrite("about.txt", content);

            this.aboutLabel.Text = result;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

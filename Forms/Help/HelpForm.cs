using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoursePaper.Helpers;

namespace CoursePaper
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            this.infoLabel.MaximumSize = new Size(this.Width - 25, this.Height - 50);
        }

        private void closeHelpFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            string content = "Ծրագիրը գտնում է Ձեր մուտքագրած թվին համապատասխան թվանշանը Ֆիբոնաչիի շարքում\n\n" +
                              "Ծրագիրը միացնելիս բացվում է փոքր ներկայացման պատուհան, որի փակվելուց հետո բացվում է մեկ այլ պատուհան՝ մուտքի պատուհանը\n" +
                              "Անհրաժեշտ է մուտքագրել ճիշտ մուտքանունն ու գաղտնաբառը, որպեսզի հնարավոր լինի հայտնվել ծրագրի գլխավոր ինտերֆեյսում\n" +
                              "Մուտքանունն ու գաղտնաբառր պետք է համընկնեն\n\n" +
                              "Գխավոր ինտերֆեյսում պետք է մուտքագրել անհրաժեշտ տվյալները և սեղմել «Հաշվել», որից հետո կհայտնվի պատասխանը\n\n" +
                              "\t\tԾրագրի հեղինակ՝ Պողոսյան Գրիշա: Խումբ՝ 811";

            string result = await ContentHelpers.ReadOrWrite("help.txt", content);

            if (string.IsNullOrEmpty(result))
            {
                this.Close();
                MessageBox.Show("Մենք չենք կարող Ձեզ օգնել", "Ուփս", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.infoLabel.Text = result;
        }
    }
}

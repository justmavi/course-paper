using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CoursePaper.Helpers;
using CoursePaper.Types;

namespace CoursePaper
{
    public partial class TipsForm : Form
    {
        private int currentTipIndex;
        private string[] tipLines;
        private List<Tip> tips; 

        public int CurrentTipIndex { get => currentTipIndex; }
        public string[] TipLines { get => tipLines; }
        public List<Tip> Tips { get => tips; }


        public TipsForm()
        {
            InitializeComponent();
        }

        private async void Form5_Load(object sender, EventArgs e)
        {
            string content = "#Գնում ենք կինո\nՎերցրու ընկերներիդ և գնացեք միասին ֆիլմ դիտելու։ Այսօր շատ լավ եղանակ է լինելու, կարող եք և քայլել մի փոքր։\n\n" +
                "#Ֆուտբոլային խաղ\nՓնտրիր մոտակա օրերի ամենահետաքրքիր հանդիպումը և հրավիրիր ընկերներիդ միասին դիտելու։ Վստահ եմ, որ շատ լավ կանցնի\n\n" +
                "#Գաղտնի Սանտա\nԱռաջարկիր ընկերներիդ միասին խաղալ «Գաղտնի Սանտա»։";

            string result = await ContentHelpers.ReadOrWrite("tips.txt", content);
            this.tipLines = result.Split(new string[] { "\n\n" }, StringSplitOptions.None);

            this.tips = tipLines.Select(line => ContentHelpers.ParseTipFromLine(line)).ToList();

            this.SetTip(tips.FirstOrDefault());

            this.currentTipIndex = 0;
        }

        private void nextTipButton_Click(object sender, EventArgs e)
        {
            if (this.currentTipIndex == tips.Count - 1)
            {
                this.currentTipIndex = 0;
            }
            else
            {
                this.currentTipIndex += 1;
            }

            Tip tip = this.tips[this.currentTipIndex];
            this.SetTip(tip);
        }

        private void prevTipButton_Click(object sender, EventArgs e)
        {
            if (this.currentTipIndex == 0)
            {
                this.currentTipIndex = tips.Count - 1;
            }
            else
            {
                this.currentTipIndex -= 1;
            }

            Tip tip = this.tips[this.currentTipIndex];
            this.SetTip(tip);
        }

        private void firstTipButton_Click(object sender, EventArgs e)
        {
            this.currentTipIndex = 0;

            Tip tip = this.tips[this.currentTipIndex];
            this.SetTip(tip);
        }

        private void lastTipButton_Click(object sender, EventArgs e)
        {
            if (this.tips.Count != 0)
            {
                this.currentTipIndex = this.tips.Count - 1;
            }

            Tip tip = this.tips[this.currentTipIndex];
            this.SetTip(tip);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

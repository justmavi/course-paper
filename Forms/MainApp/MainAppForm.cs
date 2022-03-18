using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CoursePaper.Helpers;

namespace CoursePaper
{
    public partial class MainAppForm : Form
    {
        internal Dictionary<string, Label> currencyRateLabels;
        private Timer dateTimeTimer;
        private DateTime launchTime;
        private DateTime todayLaunchTime;

        private static readonly int maxInputNumber = 907;

        public MainAppForm()
        {
            this.launchTime = this.todayLaunchTime = DateTime.Now;

            InitializeComponent();
            this.FormClosing += onClosing;

            this.currencyRateLabels = new Dictionary<string, Label>
            {
                ["USD"] = this.usdRateLabel,
                ["EUR"] = this.eurRateLabel,
                ["RUB"] = this.rubRateLabel,
                ["GEL"] = this.gelRateLabel
            };

            this.dateTimeTimer = new Timer { Interval = 1000 };
            this.dateTimeTimer.Tick += DateTimeTimer_Tick;

            this.calculatorToolStripMenuItem.Checked = true;
            this.advancedToolStripMenuItem.Checked = true;
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            if (now.Hour == 0 && now.Minute == 0 && now.Second == 0) this.todayLaunchTime = now;

            var allWorkedTime = now - this.launchTime;
            var todayWorkedTime = now - this.todayLaunchTime;

            this.todayWorkedTimeLabel.Text = new TimeSpan(todayWorkedTime.Hours, todayWorkedTime.Minutes, todayWorkedTime.Seconds).ToString();
            this.allTimeWorkedLabel.Text = new TimeSpan(allWorkedTime.Days, allWorkedTime.Hours, allWorkedTime.Minutes, allWorkedTime.Seconds).ToString();
        
            this.UpdateTime();
        }

        private void programmNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "\tԿուրսային աշխատանք\n     Երևանի Ինֆորմատիկայի Պետական Քոլեջ\nԱվելի մանրամասն՝ «Օգնություն» պատուհանում", 
                "Ինֆո", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
           );
        }

        private void dayTipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TipsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Դուք իրո՞ք ցանկանում եք փակել ծրագիրը", "Հաստատում", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }

        private void helpWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HelpForm();
            form.MdiParent = this;
            form.Show();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.MdiParent = this;
            form.Show();
        }

        private void onClosing(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void MainAppForm_Load(object sender, EventArgs e)
        {
            this.UpdateTime();

            this.launchDateLabel.Text = this.launchTime.ToString("dd/MM/yyyy");
            this.launchTimeLabel.Text = this.launchTime.ToString("HH:mm:ss");

            this.dateTimeTimer.Start();

            await this.UpdateCurrencies();
        }

        private void numInputButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button is null) return;
            if (this.inputBox.Text.Length + 1 > this.inputBox.MaxLength) return;
            if (button.Text == "0")
            {
                if (string.IsNullOrEmpty(this.inputBox.Text) || int.Parse(this.inputBox.Text) <= 0) return;
            }

            this.inputBox.Text += button.Text;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text = string.Empty;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.inputBox.Text.Length == 0) return;

            this.inputBox.Text = this.inputBox.Text.Substring(0, this.inputBox.Text.Length - 1);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.inputBox.Text, out int number) && number > 0 && number <= maxInputNumber)
            {
                var fibonacci = ContentHelpers.GetFibonacci(number);

                if (!(fibonacci is null))
                {
                    this.resultLabel.Text = fibonacci.Result.ToString();
                    this.resultNumberLabel.Text = fibonacci.Number.ToString();

                    this.resultGroupBox.Visible =
                    this.resultToolStripMenuItem.Checked = true;
                }
                else
                {
                    MessageBox.Show("Տեղի է ունեցել չնախատեսված խնդիր", 
                        "Խնդիր",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show("Դուք ներմուծել եք սխալ թիվ։ Փորձեք նորից" + 
                    $"\n\nՄինիմում՝ 1\nՄաքսիմում՝ {maxInputNumber}", 
                    "Սխալ", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                ); 
            }
        }

        private void inputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '0')
            {
                if (string.IsNullOrEmpty(this.inputBox.Text) || int.Parse(this.inputBox.Text) <= 0)
                {
                    e.Handled = true;
                }
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.calcBox.Visible = !this.calcBox.Visible;
            this.calculatorToolStripMenuItem.Checked = this.calcBox.Visible;
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.infoGroupBox.Visible = !this.infoGroupBox.Visible;
            this.advancedToolStripMenuItem.Checked = this.infoGroupBox.Visible;
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.resultLabel.Text == "-1")
            {
                MessageBox.Show("Դուք դեռ չեք կատարել ոչ մի հաշվարկ", "Սխալ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.resultGroupBox.Visible = !this.resultGroupBox.Visible;
                this.resultToolStripMenuItem.Checked = this.resultGroupBox.Visible;
            }
        }

        private void closeAllChildsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var child in this.MdiChildren)
            {
                child.Close();
            }
        }
    }
}

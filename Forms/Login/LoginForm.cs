using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursePaper
{
    public partial class LoginForm : Form
    {
        private readonly string appPassword = "admin";
        public string Password { get => appPassword; }

        public LoginForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;

            if (username == string.Empty || password != appPassword)
            {
                this.invalidPasswordMessage.Visible = true;
                return;
            }

            this.Visible = false;

            var form3 = new MainAppForm();
            form3.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

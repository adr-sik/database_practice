using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mas_project.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = ValidateCredentials();
            if (username != null)
            {
                DialogResult = DialogResult.OK;
                MainForm.username = username;
                Close();
            }
            else
            {
                label3.Text = "Invalid credentials. Please try again.";
            }
        }

        private string ValidateCredentials()
        {
            if ((textBox1.Text == "user" && textBox2.Text == "user") || (textBox1.Text == "owner" && textBox2.Text == "owner")) 
            {
                return textBox1.Text;
            }
            return null;
        }
    }
}

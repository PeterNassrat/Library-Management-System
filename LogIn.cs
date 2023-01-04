using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class LogIn : Form
    {
        public static LogIn instance;
        HomePage homeP;
        public LogIn()
        {
            InitializeComponent();
            instance = this;
            homeP = new HomePage();
        }

        private void PressLogin_Click(object sender, EventArgs e)
        {

        }

        private void PressLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                string userName = Login_UserName.Text;
                string userPass = Login_UserPassword.Text;
                if(!checkOnString(userName) || !checkOnString(userPass))
                {
                    MessageBox.Show("Fill empty fields");
                }
                else
                {
                    if(userName == "admin" && userPass == "admin")
                    {
                        MessageBox.Show("Welcome");
                        this.Hide();
                        Login_UserName.Text = "";
                        Login_UserPassword.Text = "";
                        Login_UserName.Focus();
                        HomePage.instance.Show();
                    }
                    else
                    {
                        MessageBox.Show("The username or password is invalid");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public Boolean checkOnString(string str)
        {
            Boolean b = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void Login_UserName_TextChanged(object sender, EventArgs e)
        {
            Login_UserName.Focus();
        }

        private void LogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PressLogin_Click_1(sender, e);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_UserPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

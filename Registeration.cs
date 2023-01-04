using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Management_System
{
    public partial class Registeration : Form
    {
        public static Registeration instance;
        public int currentClient;
        BuyPage buy;
        public ArrayList clients;
        public Registeration()
        {
            InitializeComponent();
            instance = this;
            buy = new BuyPage();
            clients = new ArrayList();
            currentClient = 0;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            CName.Text = "";
            CName.Focus();
            CPhone.Text = "";
            CEmail.Text = "";
            this.Hide();
            HomePage.instance.Show();
        }

        private void RegisterOperation_Click(object sender, EventArgs e)
        {
            try
            {
                string cName = CName.Text;
                string cPhone = CPhone.Text;
                string cEmail = CEmail.Text;
                if(CheckOnString(cName) && CheckOnString(cPhone))
                {
                    if (CheckOnPhone(cPhone))
                    {
                        if ((!CheckOnString(cEmail)) || CheckOnEmail(cEmail))
                        {
                            int cID = GetClientID(cName);
                            if(cID != -1)
                            {
                                currentClient = cID;
                            }
                            else
                            {
                                currentClient = clients.Count / 3;
                                clients.Add(cName);
                                clients.Add(cPhone);
                                clients.Add(cEmail);
                            }
                            this.Hide();
                            CName.Text = "";
                            CName.Focus();
                            CPhone.Text = "";
                            CEmail.Text = "";
                            BuyPage.instance.Show();
                        }
                        else
                        {
                            MessageBox.Show("Enter valid email address");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter valid phone number");
                    }
                }
                else
                {
                    MessageBox.Show("Fill empty fields");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        bool CheckOnString(string str)
        {
            Boolean b = false;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        bool CheckOnPhone(string str)
        {
            if(str.Length == 11)
            {
                if (str[0] == '0' && str[1] == '1' && (str[2] == '0' || str[2] == '1' || str[2] == '2' || str[2] == '5'))
                {
                    bool b = true;
                    for(int i = 3; i < str.Length; i++)
                    {
                        if (!(str[i] <= '9' && str[i] >= '0'))
                        {
                            b = false; break;
                        }
                    }
                    if (b)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool CheckOnEmail(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private void CName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RegisterOperation_Click(sender, e);
            }
        }

        int GetClientID(string cName)
        {
            for(int i = 0; i < clients.Count; i+=2)
            {
                if (clients[i].ToString() == cName)
                {
                    return i / 3;
                }
            }
            return -1;
        }
    }
}

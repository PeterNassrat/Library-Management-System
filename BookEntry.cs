using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{

    public partial class BookEntry : Form
    {
        public static BookEntry instance;
        public ArrayList books;
        public BookEntry()
        {
            InitializeComponent();
            instance = this;
            books = new ArrayList();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            this.Hide();
            BName.Text = "";
            BName.Focus();
            BPrice.Text = "";
            BookQuan.Value = 0;
            HomePage.instance.Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RegisterOperation_Click(sender, e);
            }
        }

        private void RegisterOperation_Click(object sender, EventArgs e)
        {
            try
            {
                string bName = BName.Text;
                float bPrice;
                int bQuan = (int)BookQuan.Value;
                try
                {
                    bPrice = float.Parse(BPrice.Text);
                    if (CheckOnString(bName))
                    {
                        if (bQuan > 0)
                        {
                            books.Add(bName);
                            books.Add(bQuan);
                            books.Add(bPrice);
                            MessageBox.Show("Book added successfully");
                            this.Hide();
                            BName.Text = "";
                            BName.Focus();
                            BPrice.Text = "";
                            BookQuan.Value = 0;
                            HomePage.instance.Show();
                        }
                        else
                        {
                            MessageBox.Show("Book quantity should be 1 at least");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill the empty fields");
                    }
                }
                catch
                {
                    MessageBox.Show("Eter a valid price");
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
        public void GiveNewValue(object value, int ID)
        {
            books[ID] = value;
        }
    }
}

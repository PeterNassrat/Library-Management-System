using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections;
using System.Security.AccessControl;


namespace Library_Management_System
{
    public partial class BuyPage : Form
    {
        public static BuyPage instance;
        ArrayList books;
        ArrayList client;
        public ArrayList operations;
        public BuyPage()
        {
            InitializeComponent();
            instance = this;
            operations = new ArrayList();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            this.Hide();
            comboBox1.Text = "";
            comboBox1.Focus();
            AvQuan.Text = "";
            BPrice.Text = "";
            OrderedQuan.Value = 0;
            TotalPrice.Text = "";
            Registeration.instance.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                books = new ArrayList();
                for (int i = 0; i < BookEntry.instance.books.Count; i++)
                {
                    books.Add(BookEntry.instance.books[i]);
                }
                for (int i = 0; i < books.Count; i+=3)
                {
                    if (comboBox1.Text == books[i].ToString())
                    {
                        AvQuan.Text = books[i+1].ToString();
                        BPrice.Text = books[i+2].ToString();
                        TotalPrice.Text = (float.Parse(OrderedQuan.Value.ToString()) * float.Parse(books[i+2].ToString())).ToString();
                        break;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void OrderedQuan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckOnString(AvQuan.Text))
                {
                    if ((int)OrderedQuan.Value > int.Parse(AvQuan.Text))
                    {
                        OrderedQuan.Value = int.Parse(AvQuan.Text);
                        MessageBox.Show("The available quantity of this book is " + AvQuan.Text);
                    }
                    if (BPrice.Text != "")
                    {
                        TotalPrice.Text = (float.Parse(OrderedQuan.Value.ToString()) * float.Parse(BPrice.Text.ToString())).ToString();
                    }
                }
                else
                {
                    if((int)OrderedQuan.Value != 0) {
                        MessageBox.Show("Choose a book from the list");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CompleteBuy_Click(object sender, EventArgs e)
        {
            try
            {
                books = new ArrayList();
                for (int i = 0; i < BookEntry.instance.books.Count; i++)
                {
                    books.Add(BookEntry.instance.books[i]);
                }
                if (CheckOnString(comboBox1.Text))
                {
                    int bID = GetBookID(comboBox1.Text);
                    if (bID != -1)
                    {
                        if ((int)OrderedQuan.Value == 0)
                        {
                            MessageBox.Show("The ordered quantity of the book should be 1 at least");
                        }
                        else
                        {
                            if (BuyVerify.Checked)
                            {
                                operations.Add((int)OrderedQuan.Value);
                                operations.Add(Registeration.instance.currentClient);
                                operations.Add(bID / 3);
                                books[bID + 1] = int.Parse(books[bID + 1].ToString()) - int.Parse(OrderedQuan.Value.ToString());
                                BookEntry.instance.GiveNewValue(books[bID + 1], bID + 1);
                                MessageBox.Show("Operation done");
                                this.Hide();
                                comboBox1.Text = "";
                                comboBox1.Focus();
                                AvQuan.Text = "";
                                BPrice.Text = "";
                                OrderedQuan.Value = 0;
                                TotalPrice.Text = "";
                                BuyVerify.Checked = false;
                                HomePage.instance.Show();
                            }
                            else
                            {
                                MessageBox.Show("Click on the checkbox to verify the operation");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose a book from the list");
                    }

                }
                else
                {
                    MessageBox.Show("Choose a book from the list");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            books = new ArrayList();
            for (int i = 0; i < BookEntry.instance.books.Count; i++)
            {
                books.Add(BookEntry.instance.books[i]);
            }
            comboBox1.Items.Clear();
            for(int i = 0; i < books.Count; i+=3)
            {
                comboBox1.Items.Add(books[i].ToString());
            }
        }
        int GetBookID(string name)
        {
            for(int i = 0; i < books.Count; i += 3)
            {
                if(name == books[i].ToString())
                {
                    return i;
                }
            }
            return -1;
        }
        bool CheckOnString(string str)
        {
            bool b = false;
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

        private void OrderedQuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CompleteBuy_Click(sender, e);
            }
        }
    }
}

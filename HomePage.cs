using System;
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
    public partial class HomePage : Form
    {
        public static HomePage instance;
        Registeration reg;
        BookEntry bookE;
        public HomePage()
        {
            InitializeComponent();
            instance = this;
            reg = new Registeration();
            bookE = new BookEntry();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BuyOperation_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registeration.instance.Show();
        }

        private void EnterOperation_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuyOperation.Focus();
            BookEntry.instance.Show();
        }

        private void BorrowOperation_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn.instance.Show();
        }
    }
}

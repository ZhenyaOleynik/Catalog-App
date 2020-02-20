using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Test
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct addproduct = new AddProduct();
            addproduct.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowProducts show = new ShowProducts();
            show.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            getEmail email = new getEmail();
            email.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeletePage delP = new DeletePage();
            delP.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeSp changePage = new ChangeSp();
            changePage.Show();

        }
    }
}

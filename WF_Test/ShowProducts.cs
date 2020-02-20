using MySql.Data.MySqlClient;
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
    public partial class ShowProducts : Form
    {
        public ShowProducts()
        {
            InitializeComponent();
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

        private void ShowBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ShowData_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=catalog");

            DB db = new DB();

            db.openConnection();

            MySqlDataAdapter oda = new MySqlDataAdapter("SELECT * FROM products", connection);

            DataTable dt = new DataTable();

            oda.Fill(dt);

            dataGridView1.DataSource = dt;

            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            getEmail getE = new getEmail();
            getE.Show();
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
            ChangeSp change = new ChangeSp();
            change.Show();
        }
    }
}

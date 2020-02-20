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
    public partial class DeletePage : Form
    {
        public DeletePage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=catalog");

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("DELETE FROM `products` WHERE `products`.`name` = @dP", db.getConnection());

            command.Parameters.Add("@dP", MySqlDbType.VarChar).Value = delBox.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Product was deleted");
            }
            else
            {
                MessageBox.Show("Product was not deleted");
            }

            db.closeConnection();

            delBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct add = new AddProduct();
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowProducts showproducts = new ShowProducts();
            showproducts.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            getEmail getE = new getEmail();
            getE.Show();
        }

        private void delButton_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeSp change = new ChangeSp();
            change.Show();
        }
    }
}

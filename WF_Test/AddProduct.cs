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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quantBox_TextChanged(object sender, EventArgs e)
        {
            if (quantBox.Text == "")
            {
                stockBox.Text = "";
                return;
            }

            if(quantBox.Text == "0")
            {
                stockBox.Text = "N";
                return;
            }
            else
            {
                stockBox.Text = "Y";
                return;
            }
        }

        private void quantBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] empty = { "\0" };

           
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back))
             {
                 return;
            }
            

            e.KeyChar = Convert.ToChar(empty[0]);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `products` (`name`, `quantity`, `inStock`, `price($)`) VALUES (@name, @quant, @isIn, @price);", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = destBox.Text;
            command.Parameters.Add("@quant", MySqlDbType.VarChar).Value = quantBox.Text;
            command.Parameters.Add("@isIn", MySqlDbType.VarChar).Value = stockBox.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = priceBox.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Product was added");
            }
            else
            {
                MessageBox.Show("Product was not added");
            }

            db.closeConnection();

            destBox.Text = "";
            quantBox.Text = "";
            stockBox.Text = "";
            priceBox.Text = "";

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
            this.Hide();
            DeletePage delP = new DeletePage();
            delP.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeSp change = new ChangeSp();
            change.Show();
        }
    }
}

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
    public partial class ChangeSp : Form
    {
        public ChangeSp()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // public string prodToChange = ChangeBox.Text;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE `products` SET `name` = @nN, `quantity` = @nQ, `inStock` = @nIS, `price($)` = @nP WHERE `products`.`name` = @PN", db.getConnection());

            command.Parameters.Add("@nN", MySqlDbType.VarChar).Value = newDestB.Text;
            command.Parameters.Add("@nQ", MySqlDbType.VarChar).Value = newQuantB.Text;
            command.Parameters.Add("@nIS", MySqlDbType.VarChar).Value = newStockB.Text;
            command.Parameters.Add("@nP", MySqlDbType.VarChar).Value = newPriceB.Text;
            command.Parameters.Add("@PN", MySqlDbType.VarChar).Value = ChangeBox.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Product was changed");
            }
            else
            {
                MessageBox.Show("Product was not changed");
            }

            db.closeConnection();

            newDestB.Text = "";
            newQuantB.Text = "";
            newStockB.Text = "";
            newPriceB.Text = "";
            ChangeBox.Text = "";
        }

        private void newStockB_TextChanged(object sender, EventArgs e)
        {

        }

        private void newQuantB_TextChanged(object sender, EventArgs e)
        {
            if (newQuantB.Text == "")
            {
                newStockB.Text = "";
                return;
            }

            if (newQuantB.Text == "0")
            {
                newStockB.Text = "N";
                return;
            }
            else
            {
                newStockB.Text = "Y";
                return;
            }
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
            this.Hide();
            DeletePage delP = new DeletePage();
            delP.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

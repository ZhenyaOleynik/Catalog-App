using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Test
{
    public partial class getEmail : Form
    {
        public string fileToSend;
        public getEmail()
        {
            InitializeComponent(); 
            
     
        }

        private void sumEmail_Click(object sender, EventArgs e)
        {

            


            if (File.Exists(fileP_Box.Text))
            {

              MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=catalog");

              DB db = new DB();

              db.openConnection();

              MySqlDataAdapter oda = new MySqlDataAdapter("SELECT * FROM products", connection);

              DataTable dt = new DataTable();

              oda.Fill(dt);

              db.closeConnection();

             int i = 0;
             StreamWriter sw = null;

            

                sw = new StreamWriter(fileP_Box.Text, false);



                for (i = 0; i < dt.Columns.Count - 1; i++)
                {

                    sw.Write(dt.Columns[i].ColumnName + " | ");

                }
                sw.Write(dt.Columns[i].ColumnName);
                sw.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    object[] array = row.ItemArray;

                    for (i = 0; i < array.Length - 1; i++)
                    {
                        sw.Write(array[i].ToString() + "    | ");
                    }
                    sw.Write(array[i].ToString());
                    sw.WriteLine();

                }

                sw.Close();

                fileToSend = fileP_Box.Text;

                MessageBox.Show("Data was saved");
            }

            else
            {
                MessageBox.Show("Invalid file path");
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fileP_Box.Text == "")
            {
                MessageBox.Show("You should previously fill and point path to a file");
                return;
            }
            // EMAIL ////////////////////
            MailAddress from = new MailAddress("mailsender37@gmail.com");
            
            // recipient
            MailAddress to = new MailAddress(emailBox.Text);

            // object
            MailMessage m = new MailMessage(from, to);

            // theme
            string theme = "Products list (in txt)";
            m.Subject = theme;
            
            //attachment
            m.Attachments.Add(new Attachment(fileToSend));

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            // login and password
            client.Credentials = new NetworkCredential("mailsender37@gmail.com", "sendmail64");
            client.EnableSsl = true;

            client.Send(m);

            emailBox.Text = "";

            /////////////////////////////////////////////
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Open notebook => Create an empty file => Save data(enter path)");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create a file => Send it(enter email)");
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

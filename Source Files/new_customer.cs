using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace es_all
{
    public partial class new_customer : Form
    {
        public string conString = "Server=localhost\\SQLEXPRESS;Database=escrm;Trusted_Connection=True";
        public SqlConnection con;
        public new_customer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)

        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fName = textBox5.Text;
            string lName = textBox1.Text;
            string email = textBox2.Text;
            string mobile = textBox3.Text;
            string company = comboBox2.Text;

            int selectedId = int.Parse(comboBox1.Text);

            SqlCommand update = new SqlCommand($"UPDATE customer SET firstName = '{fName}', lastName= '{email}',mobile='{mobile}',company='{company}' WHERE id = '{selectedId}'",con);
            update.ExecuteNonQuery();

            MessageBox.Show("Record update successully!");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void new_customer_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conString);
            con.Open();

            string loadCompanyQuery = "SELECT companyName FROM company";
            SqlCommand companyCommand = new SqlCommand(loadCompanyQuery, con);
            SqlDataReader companyDataReader = companyCommand.ExecuteReader();
            comboBox2.Items.Clear();

            while (companyDataReader.Read())
            {
                comboBox2.Items.Add(companyDataReader["companyName"].ToString());
            }
            companyDataReader.Close();


            SqlCommand loadId= new SqlCommand("SELECT id FROM customer", con);
            SqlDataReader idDataReader = loadId.ExecuteReader();

            while (idDataReader.Read())
            {
                comboBox1.Items.Add(idDataReader["id"]);
            }
            idDataReader.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load data when selected id is change in customer

            int selectedId = int.Parse(comboBox1.Text);
            SqlCommand loadCustomer = new SqlCommand($"SELECT * FROM customer WHERE id = {selectedId}",con);
            SqlDataReader selectedCustomer = loadCustomer.ExecuteReader();

            while (selectedCustomer.Read())
            {
                textBox5.Text = selectedCustomer[1].ToString();
                textBox1.Text = selectedCustomer[2].ToString();
                textBox2.Text = selectedCustomer[3].ToString();
                textBox3.Text = selectedCustomer[4].ToString();
                comboBox2.Text = selectedCustomer[5].ToString();
            }
            selectedCustomer.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string fName = textBox5.Text;
            string lName = textBox1.Text;
            string email = textBox2.Text;
            string mobile = textBox3.Text;
            string company = comboBox2.Text;

            SqlCommand saveCompany = new SqlCommand($"INSERT INTO customer(firstName,lastName,email,mobile,company) VALUES('{fName}','{lName}','{email}','{mobile}','{company}')", con);
            saveCompany.ExecuteNonQuery();
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


            MessageBox.Show("New customer added");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(comboBox1.Text);
            SqlCommand delete = new SqlCommand($"DELETE FROM customer WHERE id='{selectedId}'", con);

            DialogResult dialogResult = MessageBox.Show(
                "Are you sure want to delete?", "Delete", MessageBoxButtons.YesNo
                );
            if(dialogResult == DialogResult.Yes )
            {
                SqlDataReader reader = delete.ExecuteReader();
                reader.Close();

                MessageBox.Show("Record deleted!");

                this.Close();
            }
            else
            {

            }
        }
    }
}

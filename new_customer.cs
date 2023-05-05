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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace es_all
{
    public partial class new_company : Form
    {

        public string conString = "Server=localhost\\SQLEXPRESS;Database=escrm;Trusted_Connection=True";
        public SqlConnection con;
        public new_company()
        {
            InitializeComponent();
        }

        private void new_company_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conString);
            con.Open();

            string loadCategoryQuery = "SELECT category FROM categories";
            SqlCommand catCommand = new SqlCommand(loadCategoryQuery, con);
            SqlDataReader catDataReader = catCommand.ExecuteReader();
            comboBox2.Items.Clear();

            while (catDataReader.Read())
            {
                comboBox2.Items.Add(catDataReader["category"].ToString());
            }
            catDataReader.Close();

            //Select id
            SqlCommand loadId = new SqlCommand("SELECT id FROM company", con);
            SqlDataReader idDataReader = loadId.ExecuteReader();

            while (idDataReader.Read())
            {
                comboBox1.Items.Add(idDataReader["id"]);
            }
            idDataReader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string companyName = textBox5.Text;
            string address = textBox1.Text;
            string email = textBox2.Text;
            string telephone = textBox3.Text;
            string catogory = comboBox2.Text;

            SqlCommand saveCompany = new SqlCommand($"INSERT INTO company(companyName,address,email,telephone,category) VALUES('{companyName}','{address}','{email}','{telephone}','{catogory}')", con);
            saveCompany.ExecuteNonQuery();
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


            MessageBox.Show("New company added");


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load data when selected id is change in customer

            int selectedId = int.Parse(comboBox1.Text);
            SqlCommand loadCompany = new SqlCommand($"SELECT * FROM company WHERE id = {selectedId}", con);
            SqlDataReader selectedCompany = loadCompany.ExecuteReader();

            while (selectedCompany.Read())
            {
                textBox5.Text = selectedCompany[1].ToString();
                textBox1.Text = selectedCompany[2].ToString();
                textBox2.Text = selectedCompany[3].ToString();
                textBox3.Text = selectedCompany[4].ToString();
                comboBox2.Text = selectedCompany[5].ToString();
            }
            selectedCompany.Close();
        }
    }
}

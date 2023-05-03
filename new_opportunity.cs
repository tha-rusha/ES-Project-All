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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace es_all
{
    public partial class new_opportunity : Form
    {
        public string conString = "Server=localhost\\SQLEXPRESS;Database=escrm;Trusted_Connection=True";
        public SqlConnection con;
        public new_opportunity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String referenceNumber = textBox5.Text;
            String company = comboBox1.Text;
            String person = comboBox2.Text;
            String probability = textBox3.Text;
            String description = textBox4.Text;
            SqlCommand saveopportunity = new SqlCommand($"INSERT INTO opportunity(referanceNumber,company,person,probability,description)VALUES('{referenceNumber}','{company}','{person}','{probability}','{probability}')", con);
            saveopportunity.ExecuteNonQuery();
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();

            MessageBox.Show("New opportunity added");
        }

        private void new_opportunity_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conString);
            con.Open();
            string loadcompanyQuery = "SELECT companyName FROM company";
            SqlCommand companyCommand = new SqlCommand(loadcompanyQuery, con);
            SqlDataReader companyDataReader = companyCommand.ExecuteReader();
            comboBox1.Items.Clear();
            while (companyDataReader.Read())
            {
                comboBox1.Items.Add(companyDataReader["companyName"].ToString());
            }
            companyDataReader.Close();

            string loadcustomerQuery = "SELECT * FROM customer";
            SqlCommand customerCommand = new SqlCommand(loadcustomerQuery, con);
            SqlDataReader customerDataReader = customerCommand.ExecuteReader();
            comboBox2.Items.Clear();
            while (customerDataReader.Read())
            {
                comboBox2.Items.Add(customerDataReader["firstName"].ToString()+" "+customerDataReader["lastName"].ToString());
            }
            customerDataReader.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}

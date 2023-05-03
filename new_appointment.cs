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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace es_all
{
    public partial class new_appointment : Form
    {
        public string conString = "Server=localhost\\SQLEXPRESS;Database=escrm;Trusted_Connection=True";
        public SqlConnection con;
        public new_appointment()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void new_appointment_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conString);
            con.Open();
            string loadcustomerQuery = "SELECT firstName FROM customer";
            SqlCommand customorCommand = new SqlCommand(loadcustomerQuery, con);
            SqlDataReader customerDataReader = customorCommand.ExecuteReader();
            comboBox1.Items.Clear();
            while (customerDataReader.Read())
            {
                comboBox1.Items.Add(customerDataReader["firstName"].ToString());
            }
            customerDataReader.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String referenceNumber = textBox3.Text;
            String venue = textBox1.Text;
            DateTime dateTime = dateTimePicker1.Value.Date;
            String person = comboBox1.Text;
            String topic = textBox4.Text;
            SqlCommand saveAppointment = new SqlCommand($"INSERT INTO appointment(referanceNumber,venue,dateTime,person,topic)VALUES('{referenceNumber}','{venue}','{dateTime}','{person}','{topic}')", con);
            saveAppointment.ExecuteNonQuery();
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();

            MessageBox.Show("New Appointmet added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
        }
    }
}

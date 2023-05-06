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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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

            //Select id
            SqlCommand loadId = new SqlCommand("SELECT id FROM appointment", con);
            SqlDataReader idDataReader = loadId.ExecuteReader();

            while (idDataReader.Read())
            {
                comboBox3.Items.Add(idDataReader["id"]);
            }
            idDataReader.Close();

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

            //comment

            MessageBox.Show("New Appointmet added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox1.Clear();
            textBox4.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load data when selected id is change in customer

            int selectedId = int.Parse(comboBox3.Text);
            SqlCommand loadAppointment = new SqlCommand($"SELECT * FROM appointment WHERE id = {selectedId}", con);
            SqlDataReader selectedAppointment = loadAppointment.ExecuteReader();

            while (selectedAppointment.Read())
            {
                textBox3.Text = selectedAppointment[1].ToString();
                textBox1.Text = selectedAppointment[2].ToString();
                dateTimePicker1.Text = selectedAppointment[3].ToString();
                comboBox1.Text = selectedAppointment[4].ToString();
                textBox4.Text = selectedAppointment[5].ToString();  
            }
            selectedAppointment.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(comboBox3.Text);
            SqlCommand delete = new SqlCommand($"DELETE FROM appointment WHERE id='{selectedId}'", con);

            DialogResult dialogResult = MessageBox.Show(
                "Are you sure want to delete?", "Delete", MessageBoxButtons.YesNo
                );
            if (dialogResult == DialogResult.Yes)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string refNum = textBox3.Text;
            string venue = textBox1.Text;
            DateTime dateTime = dateTimePicker1.Value.Date;
            string person = comboBox1.Text;
            string topic = textBox4.Text;

            int selectedId = int.Parse(comboBox3.Text);

            SqlCommand update = new SqlCommand($"UPDATE appointment SET referanceNumber = '{refNum}', venue= '{venue}',dateTime='{dateTime}',person='{person}',topic='{topic}' WHERE id = '{selectedId}'", con);
            update.ExecuteNonQuery();

            MessageBox.Show("Record update successully!");
        }
    }
}

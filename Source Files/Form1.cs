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
    public partial class Form1 : Form


    {
        public string conString = "Server=localhost\\SQLEXPRESS;Database=escrm;Trusted_Connection=True";
        public SqlConnection con;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //dashboard dashboard = new dashboard();
            //dashboard.Show();
            
            con = new SqlConnection(conString);
            con.Open();

            string username = textBox1.Text;
            string password = textBox2.Text;

            string query = "SELECT * FROM users WHERE username ='" + username + "' AND password ='" + password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            
            string conState = con.State.ToString();
            string conMessage = "";

            if(conState == "Open")
            {
                conMessage = "Success";
            }
            else
            {
                conMessage = "Failed";
            }

            if (rdr.HasRows)
            {
                MessageBox.Show("Connection is "+conMessage+".\n Welcome "+username+"!");

               dashboard dashboard = new dashboard();
               dashboard.Show();
            }
            else
            {
                MessageBox.Show("Connection is " + conMessage + ".\n Login failed!");
            }


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register register = new register();
            register.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

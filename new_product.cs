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
    public partial class new_product : Form
    {
        public string conString = "Server=localhost\\SQLEXPRESS;Database=escrm;Trusted_Connection=True";
        public SqlConnection con;
        public new_product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productCode = textBox5.Text;
            string productName = textBox1.Text;
            string supplier = textBox2.Text;
            string catogory = textBox3.Text;

            SqlCommand saveProduct = new SqlCommand($"INSERT INTO product(productCode,productName,supplier,category) VALUES('{productCode}','{productName}','{supplier}','{catogory}')", con);
            saveProduct.ExecuteNonQuery();
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


            MessageBox.Show("New product added");
        }

        private void new_product_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conString);
            con.Open();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}

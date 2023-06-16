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

            //Select id
            SqlCommand loadId = new SqlCommand("SELECT id FROM product", con);
            SqlDataReader idDataReader = loadId.ExecuteReader();

            while (idDataReader.Read())
            {
                comboBox1.Items.Add(idDataReader["id"]);
            }
            idDataReader.Close();

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
            string code = textBox5.Text;
            string pName = textBox1.Text;
            string supplier = textBox2.Text;
            string cat = textBox3.Text;
           

            int selectedId = int.Parse(comboBox1.Text);

            SqlCommand update = new SqlCommand($"UPDATE product SET productCode = '{code}', productName= '{pName}',supplier='{supplier}',category='{cat}' WHERE id = '{selectedId}'", con);
            update.ExecuteNonQuery();

            MessageBox.Show("Record update successully!");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load data when selected id is change in product

            int selectedId = int.Parse(comboBox1.Text);
            SqlCommand loadProduct = new SqlCommand($"SELECT * FROM product WHERE id = {selectedId}", con);
            SqlDataReader selectedProduct = loadProduct.ExecuteReader();

            while (selectedProduct.Read())
            {
                textBox5.Text = selectedProduct[1].ToString();
                textBox1.Text = selectedProduct[2].ToString();
                textBox2.Text = selectedProduct[3].ToString();
                textBox3.Text = selectedProduct[4].ToString();
            }
            selectedProduct.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedId = int.Parse(comboBox1.Text);
            SqlCommand delete = new SqlCommand($"DELETE FROM product WHERE id='{selectedId}'", con);

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
    }
}

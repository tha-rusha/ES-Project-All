using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace es_all
{
    public partial class dashboard : Form
    {
        public string conString = "Server=localhost\\SQLEXPRESS;Database=escrm;Trusted_Connection=True";
        public SqlConnection con;

        public string customerQuery = "SELECT * FROM customer";
        public string catQuery = "SELECT * FROM categories";
        public string companyQuery = "SELECT * FROM company";
        public string appoQueary = "SELECT * FROM appointment";
        public string opportunityQueary = "SELECT * FROM opportunity";
        public string productQueary = "SELECT * FROM product";



        public dashboard()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            button1.BackColor = Color.Red;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conString);
            con.Open();

            //dashboard

            SqlCommand customerCountQ = new SqlCommand("SELECT * FROM customer", con);
            SqlDataReader customerRead = customerCountQ.ExecuteReader();

            int customerCount = 0;

            while (customerRead.Read())
            {
                customerCount++;
            }
            label13.Text = "";
            label13.Text = customerCount.ToString();

            customerRead.Close();

            SqlCommand companyCountQ = new SqlCommand("SELECT * FROM company", con);
            SqlDataReader companyRead = companyCountQ.ExecuteReader();

            int companyCount = 0;

            while (companyRead.Read())
            {
                companyCount++;
            }
            label14.Text = "";
            label14.Text = companyCount.ToString();

            companyRead.Close();

            SqlCommand appointmentCountQ = new SqlCommand("SELECT * FROM appointment", con);
            SqlDataReader appointmentRead = appointmentCountQ.ExecuteReader();

            int appointmentCount = 0;

            while (appointmentRead.Read())
            {
                appointmentCount++;
            }
            label15.Text = "";
            label15.Text = appointmentCount.ToString();

            appointmentRead.Close();

            SqlCommand opportunityCountQ = new SqlCommand("SELECT * FROM opportunity", con);
            SqlDataReader opportunityRead = opportunityCountQ.ExecuteReader();

            int opportunityCount = 0;

            while (opportunityRead.Read())
            {
                opportunityCount++;
            }
            label16.Text = "";
            label16.Text = opportunityCount.ToString();

            opportunityRead.Close();

            //This moth appointments
             string thisAppoQueary = "SELECT * FROM appointment";
            SqlCommand loadThisAppointment = new SqlCommand(thisAppoQueary, con);
            SqlDataAdapter thisAppointmentAdapter = new SqlDataAdapter(loadThisAppointment);
            DataSet thisAppointmentDataSet = new DataSet();
            thisAppointmentAdapter.Fill(thisAppointmentDataSet);

            dataGridView7.DataSource = thisAppointmentDataSet.Tables[0];
            //

            //End dashboad



            SqlCommand loadCustomers = new SqlCommand(customerQuery, con);
            SqlDataAdapter customerAdapter = new SqlDataAdapter(loadCustomers);
            DataSet customerDataSet= new DataSet();
            customerAdapter.Fill(customerDataSet);

            dataGridView1.DataSource= customerDataSet.Tables[0];

            SqlCommand loadCategories = new SqlCommand(catQuery, con);
            SqlDataAdapter catAdapter = new SqlDataAdapter(loadCategories);
            DataSet catDataSet= new DataSet();
            catAdapter.Fill(catDataSet);

            dataGridView2.DataSource= catDataSet.Tables[0];

            SqlCommand loadCompany = new SqlCommand(companyQuery, con);
            SqlDataAdapter companyAdapter = new SqlDataAdapter(loadCompany);
            DataSet companyDataSet= new DataSet();
            companyAdapter.Fill(companyDataSet);

            dataGridView3.DataSource = companyDataSet.Tables[0];

            SqlCommand loadAppointment = new SqlCommand(appoQueary, con);
            SqlDataAdapter appointmentAdapter = new SqlDataAdapter(loadAppointment);
            DataSet appointmentDataSet= new DataSet();
            appointmentAdapter.Fill(appointmentDataSet);

            dataGridView4.DataSource = appointmentDataSet.Tables[0];

            SqlCommand loadoppertunity = new SqlCommand(opportunityQueary, con);
            SqlDataAdapter opportunityAdapter = new SqlDataAdapter(loadoppertunity);
            DataSet oppertunityDataset = new DataSet();
            opportunityAdapter.Fill(oppertunityDataset);

            dataGridView5.DataSource = oppertunityDataset.Tables[0];

            SqlCommand loadproduct = new SqlCommand(productQueary, con);
            SqlDataAdapter productAdapter = new SqlDataAdapter(loadproduct);
            DataSet productDataset = new DataSet();
            productAdapter.Fill(productDataset);

            dataGridView6.DataSource = productDataset.Tables[0];

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            button1.BackColor = Color.OrangeRed;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            button1.BackColor = Color.White;
            button2.BackColor = Color.OrangeRed;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.OrangeRed;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.OrangeRed;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.OrangeRed;
            button6.BackColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 6;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.OrangeRed;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                button1.BackColor= Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
            }

            if(tabControl1.SelectedIndex == 1)
            {
                button1.BackColor = Color.OrangeRed;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
            }

            if(tabControl1.SelectedIndex == 2)
            {
                button1.BackColor = Color.White;
                button2.BackColor = Color.OrangeRed;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
            }

            if (tabControl1.SelectedIndex == 3)
            {
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.OrangeRed;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
            }

            if(tabControl1.SelectedIndex == 4)
            {
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.OrangeRed;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
            }

            if (tabControl1.SelectedIndex == 5)
            {
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.OrangeRed;
                button6.BackColor = Color.White;
            }

            if (tabControl1.SelectedIndex == 6)
            {
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.OrangeRed;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string newCategory = textBox1.Text;

            SqlCommand saveCategory = new SqlCommand($"INSERT INTO categories(category) VALUES('{newCategory}')",con);
            saveCategory.ExecuteNonQuery();
            textBox1.Clear();
            MessageBox.Show("New category added");

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            new_company new_Company = new new_company();
            new_Company.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new_customer new_customer = new new_customer();
            new_customer.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand loadCustomers = new SqlCommand(customerQuery, con);
            SqlDataAdapter customerAdapter = new SqlDataAdapter(loadCustomers);
            DataSet customerDataSet = new DataSet();
            customerAdapter.Fill(customerDataSet);

            dataGridView1.DataSource = customerDataSet.Tables[0];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand loadCompany = new SqlCommand(companyQuery, con);
            SqlDataAdapter companyAdapter = new SqlDataAdapter(loadCompany);
            DataSet companyDataSet = new DataSet();
            companyAdapter.Fill(companyDataSet);

            dataGridView3.DataSource = companyDataSet.Tables[0];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlCommand loadCategories = new SqlCommand(catQuery, con);
            SqlDataAdapter catAdapter = new SqlDataAdapter(loadCategories);
            DataSet catDataSet = new DataSet();
            catAdapter.Fill(catDataSet);

            dataGridView2.DataSource = catDataSet.Tables[0];


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            new_appointment new_appointment =new new_appointment();
            new_appointment.Show();
            
                            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlCommand loadAppointment = new SqlCommand(appoQueary, con);
            SqlDataAdapter appointmentAdapter = new SqlDataAdapter(loadAppointment);
            DataSet appointmentDataSet = new DataSet();
            appointmentAdapter.Fill(appointmentDataSet);

            dataGridView4.DataSource = appointmentDataSet.Tables[0];
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new_opportunity new_opportunity = new new_opportunity();
            new_opportunity.Show();
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlCommand loadoppertunity = new SqlCommand(opportunityQueary, con);
            SqlDataAdapter opportunityAdapter = new SqlDataAdapter(loadoppertunity);
            DataSet oppertunityDataset = new DataSet();
            opportunityAdapter.Fill(oppertunityDataset);

            dataGridView5.DataSource = oppertunityDataset.Tables[0];
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            new_product new_Product = new new_product();
            new_Product.Show();
          
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlCommand loadproduct = new SqlCommand(productQueary, con);
            SqlDataAdapter productAdapter = new SqlDataAdapter(loadproduct);
            DataSet productDataset = new DataSet();
            productAdapter.Fill(productDataset);

            dataGridView6.DataSource = productDataset.Tables[0];
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}

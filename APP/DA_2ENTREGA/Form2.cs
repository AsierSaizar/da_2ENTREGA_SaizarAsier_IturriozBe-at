using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DA_2ENTREGA
{
    public partial class Form2 : Form
    {
        MySqlConnection connection;

        public Form2()
        {
            InitializeComponent();

           
            

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string conexiodatuak = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Konexio arazoak");
            }
            try
            {
                string query = "SELECT * FROM da_2entrega.langilea";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(query, connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch
            {
                MessageBox.Show("irakurketa arazoak");
            }
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DA_2ENTREGA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Opción 1");
            comboBox1.Items.Add("Opción 2");
            comboBox1.Items.Add("Opción 3");
        }

        public MySqlConnection conn;
        string conexiodatuak = "server='localhost';port='3306';user id='root'; password = '1WMG2023'; database = 'da_2entrega'; SslMode ='none'";

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Erabiltzaiea_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaioaHasiButton_Click(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

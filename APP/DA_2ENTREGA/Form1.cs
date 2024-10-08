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
        }

        public MySqlConnection conn;
        string conexiodatuak = "server='localhost';port='3306';user id='root'; password = '1WMG2023'; database = 'ig_2entrega'; SslMode ='none'";

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                conn = new MySqlConnection(conexiodatuak);

            }
            catch
            {
                MessageBox.Show("Datu basean, konexio arazoak");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Erabiltzaiea_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaioaHasiButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(conexiodatuak);
                conn.Open();
            }
            catch
            {
                MessageBox.Show(ToString());
            }
            try
            {
                string erabiltzailea = ErabiltzaieaTextBox.Text;
                string pasahitza = PasahitzaTextBox.Text;

                if(Login(erabiltzailea, pasahitza))
                {
                    MessageBox.Show("Saioa ongi hasi da!!");
                }
                else
                {
                    MessageBox.Show("Erabultzailea edo pasahitzak okerrak dira");
                }
            }
            catch
            {
                MessageBox.Show(ToString());
            }

        }
        
        private bool Login(string erabiltzailea, string pasahitza)
        {
            string query = "SELECT COUNT(*) FROM erabiltzailea WHERE erabiltzailea = @erabiltzailea AND pasahitza = @pasahitza";

            try
            {
                using (MySqlConnection conn = new MySqlConnection()) ;
                {

                    // Ejecutamos la consulta y obtenemos los resultados usando un DataReader
                    using (MySqlDataReader reader = conn.ExecuteReader())
                    {
                        // Leemos los resultados
                        if (reader.Read())
                        {
                            // Verificamos si la primera columna (el COUNT(*)) tiene un valor mayor a 0
                            int userCount = reader.GetInt32(0);
                            return userCount > 0; // Si hay al menos una coincidencia, el login es exitoso
                        }
                    }

                }
            }
            catch
            {

            }
        }

    }
}

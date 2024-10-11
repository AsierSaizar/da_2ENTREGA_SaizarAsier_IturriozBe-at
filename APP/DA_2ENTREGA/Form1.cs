using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DA_2ENTREGA
{
    

    public partial class Form1 : Form
    {
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();

            string conexiodatuak = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
            connection = new MySqlConnection(conexiodatuak);

            try
            {
                connection.Open();

                string query = "SELECT erabiltzaileIzena FROM erabiltzailea;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string erabiltzaileIzena = reader.GetString("erabiltzaileIzena");
                    comboBox1.Items.Add(erabiltzaileIzena);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

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
            if (comboBox1.SelectedItem == null)
            {
                Console.WriteLine("Mesedez, aukeratu erabiltzaile bat.");
            }
            else
            {
                UserSession.ErabiltzaileIzena = comboBox1.SelectedItem.ToString();
                //string erabiltzaile = UserSession.ErabiltzaileIzena;
                //Console.WriteLine("Erabiltzaile aukeratua: " + erabiltzaile);
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
    public static class UserSession
    {
        public static string ErabiltzaileIzena { get; set; }
    }
}


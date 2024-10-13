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

                string query = "SELECT langilea_id, erabiltzaileIzena FROM erabiltzailea;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string erabiltzaileIzena = reader.GetString("erabiltzaileIzena");
                    int idErabiltzailea = reader.GetInt32("langilea_id");
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
        private void SaioaHasiButton_Click(object sender, EventArgs e)
        {
            {
                if (comboBox1.SelectedItem == null)
                {
                    Console.WriteLine("Mesedez, aukeratu erabiltzaile bat.");
                }
                else
                {
                    string selectedErabiltzaileIzena = comboBox1.SelectedItem.ToString();

                    string query = "SELECT langilea_id FROM erabiltzailea WHERE erabiltzaileIzena = @erabiltzaileIzena";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@erabiltzaileIzena", selectedErabiltzaileIzena);

                    try
                    {
                        connection.Open();

                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            int idErabiltzailea = reader.GetInt32("langilea_id");

                            UserSession.ErabiltzaileIzena = selectedErabiltzaileIzena;
                            UserSession.IdErabiltzailea = idErabiltzailea;

                            Form2 form2 = new Form2();
                            form2.Show();
                        }
                        else
                        {
                            Console.WriteLine("Erabiltzailea ez da datu-basean aurkitu.");
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
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

    public static class UserSession
    {
        public static string ErabiltzaileIzena { get; set; }
        public static int IdErabiltzailea { get; set; }
    }
}



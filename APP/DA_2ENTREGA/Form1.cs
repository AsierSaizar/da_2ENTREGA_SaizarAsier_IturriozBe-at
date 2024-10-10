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

            // Cadena de conexión
            string conexiodatuak = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
            connection = new MySqlConnection(conexiodatuak);

            try
            {
                // Abre la conexión
                connection.Open();

                // Consulta SQL
                string query = "SELECT erabiltzaileIzena FROM erabiltzailea"; // Ajusta el nombre de la columna

                // Ejecuta la consulta
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                // Lee los resultados y añádelos al ComboBox
                while (reader.Read())
                {
                    string erabiltzaileIzena = reader.GetString("erabiltzaileIzena");
                    comboBox1.Items.Add(erabiltzaileIzena);
                }

                // Cierra el lector de datos
                reader.Close();
            }
            catch (Exception ex)
            {
                // Muestra el mensaje de error en caso de que falle algo
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
            finally
            {
                // Asegura que la conexión se cierra después de su uso
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}


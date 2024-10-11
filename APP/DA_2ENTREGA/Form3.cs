using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_2ENTREGA
{
    public partial class Form3 : Form
    {
        private int idLangilea;
        public Form3(int idLangilea)
        {
            InitializeComponent();
            this.idLangilea = idLangilea;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string erabiltzaileIzenBerria = textBox1.Text;
            string erabiltzailePasahitzBerria = textBox2.Text;



            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
            string query = "INSERT INTO erabiltzailea (erabiltzaileIzena, erabiltzailePasahitza, langilea_id) VALUES (@izena, @pasahitza, @idLangilea)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrimos la conexión
                    connection.Open();

                    using(MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@izena", erabiltzaileIzenBerria);
                        command.Parameters.AddWithValue("@pasahitza", erabiltzailePasahitzBerria);
                        command.Parameters.AddWithValue("@idLangilea", idLangilea);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Erabiltzailea gehitu da.");
                        }
                        else
                        {
                            MessageBox.Show("Arazoa gertatu da erabiltzailea sortzean");
                        }
                    }




                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    MessageBox.Show("Error: " + ex.Message);


                }
            }
        }
    }
}

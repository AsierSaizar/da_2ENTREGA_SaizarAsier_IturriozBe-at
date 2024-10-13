using MySql.Data.MySqlClient;
using System;
using System.IO;
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

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string erabiltzaileIzenBerria = textBox1.Text.Trim();
            string erabiltzailePasahitzBerria = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(erabiltzaileIzenBerria) || string.IsNullOrEmpty(erabiltzailePasahitzBerria))
            {
                MessageBox.Show("Por favor, rellena todos los campos.");
                return;
            }

            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
            string query = "INSERT INTO erabiltzailea (erabiltzaileIzena, erabiltzailePasahitza, langilea_id) " +
                           "VALUES (@izena, @pasahitza, @idLangilea)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
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

                    RegistrarMovimiento("Erabiltzaile bihurtu", UserSession.IdErabiltzailea, idLangilea);
                }
                catch (Exception)
                {
                    MessageBox.Show("Iada erabiltzailea da langile hau");
                }
            }
        }

        private void RegistrarMovimiento(string accion, int idUsuario, int idLangilea)
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string carpetaRegistro = Path.Combine(rutaBase, @"..\..\..\AldaketenRegistroak");

            if (!Directory.Exists(carpetaRegistro))
            {
                Directory.CreateDirectory(carpetaRegistro);
            }

            string filePath = Path.Combine(carpetaRegistro, "AldaketenRegistroak.txt");
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string mensaje = idLangilea == 0
                ? $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin langile erabiltzaile sortu du id honekin: {idLangilea}' .\n"
                : $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin akzioa hau egin du '{accion}' id hau {idLangilea} daukan langileari.\n";

            try
            {
                System.IO.File.AppendAllText(filePath, mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar movimiento: " + ex.Message);
            }
        }
    }
}


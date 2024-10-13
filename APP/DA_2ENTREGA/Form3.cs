using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                    RegistrarMovimiento("Erabiltzaile bihurtu", UserSession.IdErabiltzailea, idLangilea);



                }
                catch (Exception)
                {
                    // Manejo de errores
                    MessageBox.Show("Iada erabiltzailea da langile hau ");


                }
            }

            
        }
        private void RegistrarMovimiento(string accion, int idUsuario, int idLangilea)
        {
            // Obtener la ruta base de la aplicación
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;

            // Construir la ruta relativa a la carpeta "AldaketenRegistroak"
            string carpetaRegistro = Path.Combine(rutaBase, @"..\..\..\AldaketenRegistroak");

            // Asegurarse de que la carpeta existe
            if (!Directory.Exists(carpetaRegistro))
            {
                Directory.CreateDirectory(carpetaRegistro);
            }

            // Definir el archivo donde se registrarán los movimientos
            string filePath = Path.Combine(carpetaRegistro, "AldaketenRegistroak.txt");

            // Obtener la fecha y hora actual
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (idLangilea == 0)
            {
                // Crear el mensaje que se guardará en el archivo
                string mensaje = $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin langile erabiltzaile sortu du id honekin: {idLangilea}' .\n";
                // Escribir en el archivo. Si el archivo no existe, lo creará.
                try
                {
                    System.IO.File.AppendAllText(filePath, mensaje);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar movimiento: " + ex.Message);
                }
            }
            else
            {
                // Crear el mensaje que se guardará en el archivo
                string mensaje = $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin akzioa hau egin du '{accion}' id hau  {idLangilea} daukan langileari.\n";
                // Escribir en el archivo. Si el archivo no existe, lo creará.
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
}

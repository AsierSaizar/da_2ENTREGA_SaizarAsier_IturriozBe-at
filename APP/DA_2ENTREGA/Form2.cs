using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DA_2ENTREGA
{
    public partial class Form2 : Form
    {
        MySqlConnection connection;
        private int idLangileaSeleccionado = -1;

        public Form2()
        {
            InitializeComponent();
            CargarDatos();
            IzenBuruaJarri();

            dataGridView2.SelectionChanged += new EventHandler(dataGridView2_SelectionChanged);

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void IzenBuruaJarri()
        {
            textBox5.Text = "Kaixo " + UserSession.ErabiltzaileIzena + "!";
        }

        private void CargarDatos()
        {
            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

            string query = "SELECT id, izena, abizena, kKorrontea, jaiotzeData FROM da_2entrega.langilea WHERE borratua IS NULL";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea: " + ex.Message);
                }
            }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView2.SelectedRows[0];

                idLangileaSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["id"].Value);

                if (filaSeleccionada.Cells["izena"] != null && filaSeleccionada.Cells["izena"].Value != DBNull.Value)
                {
                    textBox1.Text = filaSeleccionada.Cells["izena"].Value.ToString();
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.idLangileaSeleccionado > 0)
            {
                Form3 form3 = new Form3(this.idLangileaSeleccionado);
                form3.Show();
            }
            else
            {
                MessageBox.Show("Langile bat aukeratu jarraitu aurretik.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String izenBerria = textBox2.Text;
            String abizenBerria = textBox3.Text;
            String kKorronteBerria = textBox4.Text;
            DateTime jDataBerria = dateTimePicker1.Value;
            String jDataBerriaSt = jDataBerria.ToString("yyyy-MM-dd");

            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO langilea (izena, abizena, kKorrontea, jaiotzeData) VALUES (@Nombre, @Apellido, @kkorrontea, @FechaNacimiento)";

                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", izenBerria);
                        command.Parameters.AddWithValue("@Apellido", abizenBerria);
                        command.Parameters.AddWithValue("@kkorrontea", kKorronteBerria);
                        command.Parameters.AddWithValue("@FechaNacimiento", jDataBerriaSt);

                        command.ExecuteNonQuery();
                    }

                    RegistrarMovimiento("sortu", UserSession.IdErabiltzailea, 0, izenBerria);

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";

                    MessageBox.Show("Langilea ongi sortu da.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                    CargarDatos();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.idLangileaSeleccionado > 0)
            {
                DialogResult result = MessageBox.Show("Aukeratutako langilea ezabatu nahi duzu ziur?", "Berrespena", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

                    string query = "UPDATE langilea SET borratua = 1, deleted_by = @deletedBy, deleted_at = @deletedAt WHERE id = @idLangilea";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                int idUsuarioActual = UserSession.IdErabiltzailea;

                                command.Parameters.AddWithValue("@deletedBy", idUsuarioActual);
                                command.Parameters.AddWithValue("@deletedAt", DateTime.Now);
                                command.Parameters.AddWithValue("@idLangilea", this.idLangileaSeleccionado);

                                int filasAfectadas = command.ExecuteNonQuery();

                                if (filasAfectadas > 0)
                                {
                                    MessageBox.Show("Langilea ongi ezabatu da (ezabatze arina).");

                                    RegistrarMovimiento("ezabatu", idUsuarioActual, this.idLangileaSeleccionado, "izenaEzertako");
                                }
                                else
                                {
                                    MessageBox.Show("Langilea ez da aurkitu edo ez da ezabatu.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Errorea: " + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                            CargarDatos();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Langile bat aukeratu jarraitu aurretik.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void RegistrarMovimiento(string accion, int idUsuario, int idLangilea, String izenaCrear)
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;

            string carpetaRegistro = Path.Combine(rutaBase, @"..\..\..\AldaketenRegistroak");

            if (!Directory.Exists(carpetaRegistro))
            {
                Directory.CreateDirectory(carpetaRegistro);
            }

            string filePath = Path.Combine(carpetaRegistro, "AldaketenRegistroak.txt");

            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (idLangilea == 0)
            {
                string mensaje = $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin langile berri bat sortu du {izenaCrear} izenarekin'.\n";
                try
                {
                    System.IO.File.AppendAllText(filePath, mensaje);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea mugimendua erregistratzean: " + ex.Message);
                }
            }
            else
            {
                string mensaje = $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin akzioa hau egin du '{accion}' id hau {idLangilea} daukan langileari.\n";
                try
                {
                    System.IO.File.AppendAllText(filePath, mensaje);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errorea mugimendua erregistratzean: " + ex.Message);
                }
            }

        }

    }

}



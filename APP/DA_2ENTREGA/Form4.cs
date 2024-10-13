using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DA_2ENTREGA
{
    public partial class Form4 : Form
    {
        private int idLangileaSeleccionado = -1;

        public Form4()
        {
            InitializeComponent();
            IzenBuruaJarri();
            CargarDatos();
            dataGridView2.SelectionChanged += new EventHandler(dataGridView2_SelectionChanged);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView2.SelectedRows[0];
                int idLangileaSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["id"].Value);
                textBox1.Text = filaSeleccionada.Cells["izena"].Value.ToString();
                this.idLangileaSeleccionado = idLangileaSeleccionado;
            }
        }

        private void CargarDatos()
        {
            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
            string query = @"SELECT 
                                l1.id, 
                                l1.izena, 
                                l1.abizena, 
                                l1.kKorrontea, 
                                l1.jaiotzeData,  
                                l2.izena AS deleted_by,
                                l1.deleted_at
                             FROM 
                                da_2entrega.langilea l1
                             LEFT JOIN 
                                da_2entrega.langilea l2 ON l1.deleted_by = l2.id
                             WHERE 
                                l1.borratua = 1";

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
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void IzenBuruaJarri()
        {
            textBox5.Text = "Kaixo " + UserSession.ErabiltzaileIzena + "!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idLangileaSeleccionado == -1)
            {
                MessageBox.Show("Ez dago langilerik aukeratuta.");
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Seguru zaude borratu nahi duzula erregistro hau eta lotutako erregostroak ere?(Ezin izango da errekuperatu)",
                                                         "Ezabaketa konfirmatu.",
                                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
                string deleteQuery = "DELETE FROM langilea WHERE id = @idLangilea";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                        cmd.Parameters.AddWithValue("@idLangilea", idLangileaSeleccionado);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Langilea ongi ezabatua izan da.");
                            CargarDatos();
                            RegistrarMovimiento("Hard delete", UserSession.IdErabiltzailea, idLangileaSeleccionado);
                        }
                        else
                        {
                            MessageBox.Show("Langilea ezin izan da aurkitu edo ezin izan da ezabatu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Arazoa langilea ezabatzean: " + ex.Message);
                    }
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
                ? $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin hard delete egin dio {idLangilea} duen langileari' .\n"
                : $"{fechaHora} - Erabilztaileak: {idUsuario} id-arekin akzioa hau egin du '{accion}' id hau {idLangilea} daukan langileari.\n";

            try
            {
                System.IO.File.AppendAllText(filePath, mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea erregistroa aldatzean: " + ex.Message);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void Form4_Load(object sender, EventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}

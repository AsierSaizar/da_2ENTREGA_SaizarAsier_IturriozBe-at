using System;
using System.Data;
using System.Data.SqlClient;
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

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string conexiodatuak = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Konexio arazoak");

            }

            try
            {
                string query = "SELECT * FROM da_2entrega.langilea";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(query, connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch
            {
                MessageBox.Show("irakurketa arazoak");
            }
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void IzenBuruaJarri()
        {
            textBox5.Text = "Kaixo "+UserSession.ErabiltzaileIzena+"!";
        }

        private void CargarDatos()
        {
            // Tu cadena de conexión a MySQL
            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

            // La consulta SQL que quieres ejecutar
            string query = "SELECT * FROM da_2entrega.langilea";

            // Usamos MySqlConnection, MySqlCommand, y MySqlDataAdapter
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrimos la conexión
                    connection.Open();

                    // Usamos un MySqlDataAdapter para ejecutar la consulta y llenar un DataTable
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Llenamos el DataTable con los resultados
                    dataAdapter.Fill(dataTable);

                    // Asignamos el DataTable como la fuente de datos del DataGridView
                    dataGridView2.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            // Verificamos si hay filas seleccionadas
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Tomamos la primera fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView2.SelectedRows[0];

                // Obtenemos el valor de la columna "id_langilea" y lo guardamos en una variable
                int idLangileaSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["id"].Value);

                // Mostrar en un TextBox u otro control si lo deseas
                textBox1.Text = filaSeleccionada.Cells["izena"].Value.ToString();

                // Guardamos el valor en una variable de clase para usarlo al abrir el siguiente formulario
                this.idLangileaSeleccionado = idLangileaSeleccionado; // Variable de clase
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un langilea antes de abrir el Form3
            if (this.idLangileaSeleccionado > 0)
            {
                // Pasar el id_langilea seleccionado al Form3
                Form3 form3 = new Form3(this.idLangileaSeleccionado);
                form3.Show();
            }
            else
            {
                MessageBox.Show("Selecciona un langilea antes de continuar.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(textBox1);
        }

        private void label1_Click(object sender, EventArgs e)
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
            Console.WriteLine(izenBerria);

                // Tu cadena de conexión a MySQL
                string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";



                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        string query = "INSERT INTO langilea (izena, abizena, kKorrontea, jaiotzeData) VALUES (@Nombre, @Apellido, @kkorrontea, @FechaNacimiento)";

                        // Abrir la conexión
                        connection.Open();

                        // Crear el comando con la consulta y la conexión
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            // Asignar los valores a los parámetros
                            command.Parameters.AddWithValue("@Nombre", izenBerria);
                            command.Parameters.AddWithValue("@Apellido", abizenBerria);
                            command.Parameters.AddWithValue("@kkorrontea", kKorronteBerria);
                            command.Parameters.AddWithValue("@FechaNacimiento", jDataBerriaSt);

                            // Ejecutar la consulta
                            command.ExecuteNonQuery();
                        }
                        textBox2.Text="";
                        textBox3.Text="";
                        textBox4.Text="";

                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally 
                    { 
                        connection.Close();
                        CargarDatos();
                    }
                }


            }
    }
}


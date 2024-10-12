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
        private void CargarDatos()
        {
            // Tu cadena de conexión a MySQL
            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

            // La consulta SQL que quieres ejecutar
            string query = "SELECT \r\n    l1.id, \r\n    l1.izena, \r\n    l1.abizena, \r\n    l1.kKorrontea, \r\n    l1.jaiotzeData, \r\n    l1.borratua, \r\n    l2.izena AS deleted_by,\r\n    l1.deleted_at\r\nFROM \r\n    da_2entrega.langilea l1\r\nLEFT JOIN \r\n    da_2entrega.langilea l2 ON l1.deleted_by = l2.id  -- Hacemos el self-join con la misma tabla\r\nWHERE \r\n    l1.borratua = 1;";


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
        private void IzenBuruaJarri()
        {
            textBox5.Text = "Kaixo " + UserSession.ErabiltzaileIzena + "!";
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idLangileaSeleccionado == -1)
            {
                MessageBox.Show("No se ha seleccionado ningún langilea para borrar.");
                return;
            }

            // Confirmar eliminación
            DialogResult confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar permanentemente este langilea y todos los registros asociados?",
                                                         "Confirmar eliminación",
                                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Cadena de conexión a MySQL
                string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

                // Consulta SQL para eliminar el registro de langilea
                string deleteQuery = "DELETE FROM langilea WHERE id = @idLangilea";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Abrimos la conexión
                        connection.Open();

                        // Preparamos el comando SQL para la eliminación
                        MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                        cmd.Parameters.AddWithValue("@idLangilea", idLangileaSeleccionado);

                        // Ejecutamos la consulta
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("El langilea ha sido eliminado correctamente.");
                            // Recargar los datos para reflejar los cambios en el DataGridView
                            CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el langilea o no se pudo eliminar.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        MessageBox.Show("Error al eliminar el langilea: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

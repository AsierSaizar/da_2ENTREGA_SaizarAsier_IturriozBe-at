﻿using System;
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
            // Tu cadena de conexión a MySQL
            string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

            // La consulta SQL que quieres ejecutar
            string query = "SELECT id, izena, abizena, kKorrontea, jaiotzeData FROM da_2entrega.langilea WHERE borratua IS NULL";


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
                idLangileaSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["id"].Value);

                if (filaSeleccionada.Cells["izena"] != null && filaSeleccionada.Cells["izena"].Value != DBNull.Value)
                {
                    textBox1.Text = filaSeleccionada.Cells["izena"].Value.ToString();
                }
                else
                {
                    textBox1.Text = ""; // Si no hay valor, limpiamos el TextBox
                }
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

                    RegistrarMovimiento("crear", UserSession.IdErabiltzailea);

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";

                    MessageBox.Show("Langilea ongi sortu da.");

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.idLangileaSeleccionado > 0)
            {
                // Mostrar un cuadro de diálogo para confirmar si se desea borrar el langilea
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas borrar el langilea seleccionado?",
                                                      "Confirmación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Tu cadena de conexión a MySQL
                    string connectionString = "server=localhost;port=3306;user id=root;password=1WMG2023;database=da_2entrega;SslMode=none";

                    // Consulta SQL para realizar un soft delete (actualizar las columnas 'borratua', 'deleted_by' y 'deleted_at')
                    string query = "UPDATE langilea SET borratua = 1, deleted_by = @deletedBy, deleted_at = @deletedAt WHERE id = @idLangilea";

                    // Usamos MySqlConnection y MySqlCommand
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            // Abrimos la conexión
                            connection.Open();

                            // Creamos el comando con la consulta
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                // Suponiendo que 'idUsuarioActual' es el ID del usuario que está realizando la operación
                                int idUsuarioActual = UserSession.IdErabiltzailea; // Cambia este valor según tu lógica de aplicación

                                // Asignamos los parámetros para evitar inyección de SQL
                                command.Parameters.AddWithValue("@deletedBy", idUsuarioActual);
                                command.Parameters.AddWithValue("@deletedAt", DateTime.Now); // Fecha y hora actual
                                command.Parameters.AddWithValue("@idLangilea", this.idLangileaSeleccionado);

                                // Ejecutamos la consulta
                                int filasAfectadas = command.ExecuteNonQuery();

                                // Verificamos si la actualización fue exitosa
                                if (filasAfectadas > 0)
                                {
                                    MessageBox.Show("El langilea ha sido borrado correctamente (soft delete).");

                                    RegistrarMovimiento("borrar", idUsuarioActual, this.idLangileaSeleccionado);
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró el langilea o no se pudo borrar.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            // Cerrar la conexión y refrescar los datos en el DataGridView
                            connection.Close();
                            CargarDatos();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un langilea antes de continuar.");
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
        private void RegistrarMovimiento(string accion, int idUsuario, int idLangilea = -1)
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


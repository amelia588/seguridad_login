using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace login
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server = DESKTOP - NN738GS\\USUARIO; database=amelia;Integrated Security = True");
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string lastName = txtLastName.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string password = txtPassword.Text;

            // Cadena de conexión con la autenticación de Windows
            string connectionString = "server=DESKTOP-NN738GS\\USUARIO;database=amelia;Integrated Security=True";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    string consulta = "INSERT INTO usuario (userName, lastName, telefono, correo, password) VALUES (@UserName, @LastName, @Telefono, @Correo, @Password)";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@UserName", userName);
                        comando.Parameters.AddWithValue("@LastName", lastName);
                        comando.Parameters.AddWithValue("@Telefono", telefono);
                        comando.Parameters.AddWithValue("@Correo", correo);
                        comando.Parameters.AddWithValue("@Password", password);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Usuario guardado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message);
            }
        }
    }
}

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

    public partial class Form1 : Form
    {
        Form2 formularioForm2;
        Form3 formularioForm3;
        public Form1()
        {
            InitializeComponent();
            formularioForm2 = new Form2();
        }
        SqlConnection conexion = new SqlConnection("server = DESKTOP - NN738GS\\USUARIO; database=amelia;Integrated Security = True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formularioForm2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                // Consulta SQL parametrizada para evitar inyección SQL
                string consulta = "SELECT * FROM usuario WHERE userName = @userName AND password = @password";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                // Agregar parámetros a la consulta SQL
                comando.Parameters.AddWithValue("@userName", texUser.Text);
                comando.Parameters.AddWithValue("@password", texPass.Text);

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    // Si el usuario y la contraseña son correctos, mostrar el formulario Form3
                    formularioForm3.ShowDialog();
                }
                else
                {
                    // Si el usuario o la contraseña son incorrectos, mostrar un mensaje de error
                    MessageBox.Show("Usuario o contraseña incorrecto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión en el bloque finally para asegurar que se cierre correctamente
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

        }
    }
}

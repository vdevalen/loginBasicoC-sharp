using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection coneccion = new SqlConnection("server=SISTE200 ; database = SISTEMA ; INTEGRATED SECURITY = true"); 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            coneccion.Open(); //abierta la base de datos 
            SqlCommand comando = new SqlCommand("SELECT USUARIO, CONTRASENA FROM PERSONA WHERE USUARIO = @vusuario AND CONTRASENA = @vcontrasena", coneccion);
            comando.Parameters.AddWithValue("@vusuario", textUsuario.Text);
            comando.Parameters.AddWithValue("@vcontrasena", textContrasena.Text);

            SqlDataReader lector = comando.ExecuteReader(); //lector de sql y se guarda en lector 

            if (lector.Read())
            {
                coneccion.Close(); //cerrar consulta
                home pantalla = new home(); //darle paso a el gome si es correcta la consulta 
                pantalla.Show(); 
            }


        }
    }
}

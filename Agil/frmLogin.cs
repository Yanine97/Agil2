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

namespace Agil
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Global.v_conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT cod_usuario,loggin, contraseña FROM usuario WHERE loggin = @vusuario and contraseña = @vpass ", conexion);
            comando.Parameters.AddWithValue("@vusuario", txtUsuario.Text);
            comando.Parameters.AddWithValue("@vpass", txtPass.Text);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                Global.v_CodUsuarioPermiso = lector.GetInt32(0);
                conexion.Close();
                this.Hide();
                frmPrincipal f = new frmPrincipal();
                f.Closed += (s, args) => this.Close();
                f.Show();

            }
            else
            {
                MessageBox.Show( "Usuario No Valido", "Advertencia");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtUsuario.Focus();
        }
    }
}

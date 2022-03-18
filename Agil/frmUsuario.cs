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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            CargaGrilla(txtFiltroNombre.Text);
            txtCodigoUsuario.Enabled = false;
            btnConfirmar.Enabled = false;
            LlenarCombo();
            txtCodigoUsuario.Focus();
            txtLogin.Focus();

        }

        private void LlenarCombo()
        {

            cboEstado.ResetText();
            cboEstado.Items.Clear();
            cboEstado.Items.Add("INSERTADO");
            cboEstado.Items.Add("ACTIVO");
            cboEstado.Items.Add("INACTIVO");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigoUsuario.Text = "";
            txtLogin.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtFiltroNombre.Text = "";
            CargaGrilla(txtFiltroNombre.Text);
            btnConfirmar.Text = "Confirmar";
            txtCodigoUsuario.Enabled = true;
            txtLogin.Enabled = true;
            btnConfirmar.Enabled = false;
            txtCodigoUsuario.Enabled = false;
            btnNuevo.Enabled = true;
            LlenarCombo();
            txtLogin.Focus();
        }



        public void CargaGrilla(string vWhere)
            {

                string query = "";

                if (vWhere == "")
                {
                    query = @" select * from usuario order by 1 asc ";
                }
                else
                {
                    query = @" select * from usuario 
                where nombre like '%" + txtFiltroNombre.Text + "%' order by 1 asc ";
                }
                
            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvUsuario.DataSource = dt;
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }




        public void InsertarUsuario(string v_codigo_usuario, 
                                    string v_login, 
                                    string v_nombre, 
                                    string v_correo, 
                                    string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"insert into usuario 
            select " + v_codigo_usuario + ",'" + v_login + "','" + v_nombre + "', '" + v_correo + "','" +  v_estado + "',null ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Usuario Insertado correctamente ");
            btnLimpiar.PerformClick();
        }

        public void ModificarUsuario(string v_codigo_usuario,
                            string v_login,
                            string v_nombre,
                            string v_correo,
                            string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"update usuario 
     set loggin = '" + v_login + "', nombre = '" + v_nombre + "', correo = '" + v_correo + "',  estado = '" + v_estado + "' where cod_usuario = "+v_codigo_usuario+" ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Usuario Modificado correctamente ");
            btnLimpiar.PerformClick();
        }




        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvUsuario.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                txtCodigoUsuario.Text = Convert.ToString(filaSeleccionada.Cells[0].Value);
                txtLogin.Text = Convert.ToString(filaSeleccionada.Cells[1].Value);
                txtNombre.Text = Convert.ToString(filaSeleccionada.Cells[2].Value);
                txtCorreo.Text = Convert.ToString(filaSeleccionada.Cells[3].Value);
                cboEstado.Text = Convert.ToString(filaSeleccionada.Cells[4].Value);
                btnConfirmar.Text = "Modificar";
                txtCodigoUsuario.Enabled = false;
                txtLogin.Enabled = false;
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtNombre.Focus();

            }
        }




        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Global.v_conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT MAX(COD_USUARIO)+1 FROM USUARIO ", conexion);
          
            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                txtCodigoUsuario.Text = lector.GetValue(0).ToString();
                conexion.Close();
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtLogin.Focus();
                

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodigoUsuario.Text == "")
            {
                btnNuevo.PerformClick();
            }

            if (txtLogin.Text == "")
            {
                MessageBox.Show("Debe asignar un Login al Usuario","Advertencia");
                txtLogin.Focus();
                return;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe asignar un Nombre al Usuario", "Advertencia");
                txtNombre.Focus();
                return;
            }

            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Debe asignar un Correo al Usuario", "Advertencia");
                txtCorreo.Focus();
                return;
            }

            if (cboEstado.Text == "")
            {
                MessageBox.Show("Debe asignar un Estado al Usuario", "Advertencia");
                cboEstado.Focus();
                return;
            }






            if (btnConfirmar.Text == "Modificar")
            {
                ModificarUsuario(txtCodigoUsuario.Text, txtLogin.Text, txtNombre.Text, txtCorreo.Text, cboEstado.Text);

            }
            else if (btnConfirmar.Text == "Confirmar")
            {
                InsertarUsuario(txtCodigoUsuario.Text,txtLogin.Text,txtNombre.Text,txtCorreo.Text,cboEstado.Text);
            }
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            CargaGrilla(txtFiltroNombre.Text);
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            if (txtCodigoUsuario.Text == "" && txtNombre.Text == "") 
            {
                MessageBox.Show("Debe Seleccionar un Usuario de la Grilla", "Advertencia");
                txtNombre.Focus();
                return;
            }

            Global.v_CodUsuario = txtCodigoUsuario.Text;
            Global.v_NombreUsuario = txtNombre.Text;

            frmAsignarPermiso f = new frmAsignarPermiso();
            f.Show();
        }
    }
}

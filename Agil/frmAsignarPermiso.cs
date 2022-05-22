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
    public partial class frmAsignarPermiso : Form
    {
        public frmAsignarPermiso()
        {
            InitializeComponent();
        }

        private void frmAsignarPermiso_Load(object sender, EventArgs e)
        {
            txtCodUsuario.Text = Global.v_CodUsuario;
            txtNombreUsuario.Text = Global.v_NombreUsuario;

            txtCodUsuario.Enabled = false;
            txtNombreUsuario.Enabled = false;

            CargaGrillaAsignado();
            CargaGrillaDisponible();
        }

        public void CargaGrillaDisponible()
        {

            string query = "";
            query = @" select cod_rol, Descripcion from rol  order by 1 asc ";


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDisponible.DataSource = dt;
            dgvDisponible.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        public void CargaGrillaAsignado()
        {

            string query = "";
            query = @" select cod_rol as CodigoRol, Descripcion from v_usuario_rol where cod_usuario = " + txtCodUsuario.Text + "  order by 1 asc ";


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAsignado.DataSource = dt;
            dgvAsignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        private void dgvDisponible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvDisponible.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {

                SqlConnection connectionx = new SqlConnection();
                connectionx.ConnectionString = Global.v_conexion;
                connectionx.Open();

                string query = @"select * from rol_usuario where cod_usuario = " + Global.v_CodUsuario + " and cod_rol = " + Convert.ToString(filaSeleccionada.Cells[0].Value);

                try
                {

                    SqlCommand cmd = new SqlCommand(query, connectionx);
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        MessageBox.Show("El Usuario ya cuenta con los permisos");

                    }
                    else
                    {
                        SqlConnection connection2 = new SqlConnection();
                        connection2.ConnectionString = Global.v_conexion;
                        connection2.Open();

                        string query_insert = @"insert into rol_usuario
                                        select " + Global.v_CodUsuario + "," + Convert.ToString(filaSeleccionada.Cells[0].Value);
                        SqlCommand cmd2 = new SqlCommand(query_insert, connection2);
                        cmd2.ExecuteNonQuery();
                        connection2.Close();

                        CargaGrillaAsignado();
                        CargaGrillaDisponible();


                        MessageBox.Show("Rol Asignado");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("error de conexion " + ex);
                }


            }
        }

        private void dgvAsignado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvAsignado.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                SqlConnection connection2 = new SqlConnection();
                connection2.ConnectionString = Global.v_conexion;
                connection2.Open();

                string query_insert = @"delete from  Rol_usuario 
                                where cod_usuario = " + Global.v_CodUsuario + " and cod_rol = " + Convert.ToString(filaSeleccionada.Cells[0].Value);
                SqlCommand cmd2 = new SqlCommand(query_insert, connection2);
                cmd2.ExecuteNonQuery();
                connection2.Close();

                CargaGrillaAsignado();
                CargaGrillaDisponible();


                MessageBox.Show("Permiso Revocado");

            }
        }

        private void dgvDisponible_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class frmRolMenu : Form
    {
        public frmRolMenu()
        {
            InitializeComponent();
        }

        private void dgvDisponible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvDisponible.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {

                SqlConnection connectionx = new SqlConnection();
                connectionx.ConnectionString = Global.v_conexion;
                connectionx.Open();

                string query = @"select * from rol_detalle where cod_rol = " + Global.v_Rol + " and cod_menu = " + Convert.ToString(filaSeleccionada.Cells[0].Value);

                try
                {

                    SqlCommand cmd = new SqlCommand(query, connectionx);
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        MessageBox.Show("El Rol ya cuenta con los permisos");

                    }
                    else
                    {
                        SqlConnection connection2 = new SqlConnection();
                        connection2.ConnectionString = Global.v_conexion;
                        connection2.Open();

                        string query_insert = @"insert into rol_detalle 
                                        select " + Global.v_Rol + "," + Convert.ToString(filaSeleccionada.Cells[0].Value);
                        SqlCommand cmd2 = new SqlCommand(query_insert, connection2);
                        cmd2.ExecuteNonQuery();
                        connection2.Close();

                        CargaGrillaAsignado();
                        CargaGrillaDisponible();


                        MessageBox.Show("Permiso Asignado");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("error de conexion " + ex);
                }


            }
        }

        private void DgvAsignado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = DgvAsignado.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                SqlConnection connection2 = new SqlConnection();
                connection2.ConnectionString = Global.v_conexion;
                connection2.Open();

                string query_insert = @"delete from  Rol_Detalle 
                                where cod_rol = " + Global.v_Rol + " and cod_menu = " + Convert.ToString(filaSeleccionada.Cells[0].Value);
                SqlCommand cmd2 = new SqlCommand(query_insert, connection2);
                cmd2.ExecuteNonQuery();
                connection2.Close();

                CargaGrillaAsignado();
                CargaGrillaDisponible();


                MessageBox.Show("Permiso Revocado");

            }

        }


        public void CargaGrillaDisponible()
        {

            string query = "";
            query = @" select cod_menu as Codigo_Menu, Descripcion from menu_sistema  order by 1 asc ";


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
            query = @" select CODIGO_MENU,DESCRIPCION from v_rol_asignado where codigo_rol = " + txtCodRol.Text +"  order by 1 asc ";


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DgvAsignado.DataSource = dt;
            DgvAsignado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        private void frmRolMenu_Load(object sender, EventArgs e)
        {
           
            txtCodRol.Enabled = false;
            txtDescripcionRol.Enabled = false;
            txtCodRol.Text = Global.v_Rol;
            txtDescripcionRol.Text = Global.v_Descriocion_Rol;

            CargaGrillaAsignado();
            CargaGrillaDisponible();


        }
    }
}

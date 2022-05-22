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
    public partial class frmAsignarUsuario : Form
    {
        public frmAsignarUsuario()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtCodProyecto.Enabled = false;
            txtNombreProyecto.Enabled = false;
            txtCodProyecto.Text = Global.v_CodProyecto;
            txtNombreProyecto.Text = Global.v_NombreProyecto;

            CargaGrillaAsignado();
            CargaGrillaDisponible();
        }

        private void dgvDisponible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvDisponible.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {

                SqlConnection connectionx = new SqlConnection();
                connectionx.ConnectionString = Global.v_conexion;
                connectionx.Open();

                string query = @"select * from proyecto_usuario where cod_proyecto = " + Global.v_CodProyecto + " and cod_usuario = " + Convert.ToString(filaSeleccionada.Cells[0].Value);

                try
                {

                    SqlCommand cmd = new SqlCommand(query, connectionx);
                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        MessageBox.Show("El Usuario seleccionado ya esta Asignado al Proyecto");

                    }
                    else
                    {
                        SqlConnection connection2 = new SqlConnection();
                        connection2.ConnectionString = Global.v_conexion;
                        connection2.Open();

                        string query_insert = @"insert into proyecto_usuario 
                                        select " + Global.v_CodProyecto + "," + Convert.ToString(filaSeleccionada.Cells[0].Value);
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
            var filaSeleccionada = dgvAsignado.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                SqlConnection connection2 = new SqlConnection();
                connection2.ConnectionString = Global.v_conexion;
                connection2.Open();

                string query_insert = @"delete from  proyecto_usuario    
                                where cod_proyecto = " + Global.v_CodProyecto + " and cod_usuario = " + Convert.ToString(filaSeleccionada.Cells[0].Value);
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
            query = @" select COD_USUARIO,NOMBRE from USUARIO order by 1 asc ";


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
            query = @"select u.COD_USUARIO,u.NOMBRE 
from USUARIO u 
where COD_USUARIO in (select COD_USUARIO from PROYECTO_USUARIO where cod_proyecto =  " + txtCodProyecto.Text + " ) order by 1 asc ";


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

        private void dgvDisponible_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

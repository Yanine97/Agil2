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
    public partial class frmSprintUS : Form
    {
        public frmSprintUS()
        {
            InitializeComponent();
        }

        private void frmSprintUS_Load(object sender, EventArgs e)
        {
            txtCodProyecto.Text = Global.v_CodProyecto;
            txtDesProyecto.Text = Global.v_NombreProyecto;
            txtCodSprint.Text = Global.v_CodSprint;
            txtDesSprint.Text = Global.v_DescripcionSprint;
            CargaGrillaBacklog();
            CargaGrillaSprint();
        }


        public void CargaGrillaBacklog()
        {

            string query = "";
            query = @" select * from v_sprint_us where cod_proyecto = " + txtCodProyecto.Text + "   order by 1 asc ";


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBacklog.DataSource = dt;
            dgvBacklog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }


        public void CargaGrillaSprint()
        {

            string query = "";
            query = @" select * from v_sprint_us_2 where cod_proyecto = " + txtCodProyecto.Text + " AND COD_SPRINT = " + txtCodSprint.Text + "  order by 1 asc ";


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSprint.DataSource = dt;
            dgvSprint.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }


        public void CargaGrillaUS()
        {

            string query = "";
            query = @" select * from v_sprint_us_2 where cod_proyecto = " + txtCodProyecto.Text + "  order by 1 asc ";


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBacklog.DataSource = dt;
            dgvBacklog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        private void dgvBacklog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvBacklog.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {

                        SqlConnection connection2 = new SqlConnection();
                        connection2.ConnectionString = Global.v_conexion;
                        connection2.Open();

                        string query_insert = @"insert into SPRINT_US  
                                        select " + Global.v_CodSprint + "," + Convert.ToString(filaSeleccionada.Cells[0].Value);
                        SqlCommand cmd2 = new SqlCommand(query_insert, connection2);
                        cmd2.ExecuteNonQuery();
                        connection2.Close();

                        CargaGrillaBacklog();
                        CargaGrillaSprint();


                        MessageBox.Show("User Story asignado al Sprint...");

                    }


         }

        private void dgvBacklog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
        }
 

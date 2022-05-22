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
    public partial class frmKanban : Form
    {
        public frmKanban()
        {
            InitializeComponent();
        }

        private void frmKanban_Load(object sender, EventArgs e)
        {
            CargaGrillatodo();
            CargaGrilladoing();
            CargaGrilladone();
        }

        public void CargaGrillatodo()
        {

            string query = "";
            query = @" select * from v_sprint_kanban where estado = 'TO DO'
                       and cod_sprint = " + Global.v_CodSprint + " order by 1 asc ";

            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTodo.DataSource = dt;
            dgvTodo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        public void CargaGrilladoing()
        {

            string query = "";
            query = @" select * from v_sprint_kanban where estado = 'DOING'
                       and cod_sprint = "+Global.v_CodSprint+" order by 1 asc ";


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDoing.DataSource = dt;
            dgvDoing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        public void CargaGrilladone()
        {

            string query = "";
            query = @" select * from v_sprint_kanban where estado = 'DONE'
                       and cod_sprint = " + Global.v_CodSprint + " order by 1 asc ";

            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDone.DataSource = dt;
            dgvDone.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        private void dgvTodo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvTodo.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                SqlConnection connection2 = new SqlConnection();
                connection2.ConnectionString = Global.v_conexion;
                connection2.Open();

                string query_update= @"update user_story set estado = 'DOING'
                                where cod_us = " + Convert.ToString(filaSeleccionada.Cells[0].Value);
                SqlCommand cmd2 = new SqlCommand(query_update, connection2);
                cmd2.ExecuteNonQuery();
                connection2.Close();

                CargaGrillatodo();
                CargaGrilladoing();
                CargaGrilladone();

                MessageBox.Show("User Story a Doing Listo...");

            }
        }

        private void dgvDoing_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvDoing.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                SqlConnection connection2 = new SqlConnection();
                connection2.ConnectionString = Global.v_conexion;
                connection2.Open();

                string query_update = @"update user_story set estado = 'DONE'
                                where cod_us = " + Convert.ToString(filaSeleccionada.Cells[0].Value);
                SqlCommand cmd2 = new SqlCommand(query_update, connection2);
                cmd2.ExecuteNonQuery();
                connection2.Close();

                CargaGrillatodo();
                CargaGrilladoing();
                CargaGrilladone();

                MessageBox.Show("User Story a Done Listo...");

            }
        }
    }
}

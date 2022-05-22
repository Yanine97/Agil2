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

namespace Agil
{
    public partial class FrmKanbanProyecto : Form
    {
        public FrmKanbanProyecto()
        {
            InitializeComponent();
        }

        private void dgvProyectos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lblDescripcion.Text == "Proyectos")
            {
                var filaSeleccionada = dgvProyectos.CurrentRow;

                if (filaSeleccionada != null) //¿Existe una referencia?
                {
                    CargaGrilla("select * from sprint where cod_proyecto = " + Convert.ToString(filaSeleccionada.Cells[0].Value) + " order by 1 ");
                    lblDescripcion.Text = "Sprint";
                }
            }
            else
            {
                var filaSeleccionada = dgvProyectos.CurrentRow;
                Global.v_CodSprint = Convert.ToString(filaSeleccionada.Cells[0].Value);
                frmKanban f = new frmKanban();
                f.Show();
            }
        }

        public void CargaGrilla(string vQuery)
        {

            string query = "";

            if (vQuery == "")
            {
                query = @" select * from proyecto order by 1 asc ";
            }
            else
            {
                query = vQuery;
                //query = @" select * from v_sprint
                // where nombre_proyecto like '%" + cboFiltro.Text + "%' order by 1 asc ";
            }

            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvProyectos.DataSource = dt;
            dgvProyectos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }
        private void FrmKanbanProyecto_Load(object sender, EventArgs e)
        {
            CargaGrilla("select * from proyecto order by 1 asc");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            lblDescripcion.Text = "Proyectos";
            CargaGrilla("select * from proyecto order by 1 asc");
        }
    }
}

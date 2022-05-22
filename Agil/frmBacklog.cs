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
    public partial class frmBacklog : Form
    {
        public frmBacklog()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();            
            CargaGrilla();
            LlenarComboProyecto();
            //txtNombreProyecto.Focus();
        }

        public void CargaGrilla()
        {

            string query = "";
            query = @" select b.cod_backlog, b.fecha_inicio, b.cod_proyecto, p.nombre, b.estado from backlog b join proyecto p on p.cod_proyecto = b.cod_proyecto order by 1 asc ";


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

        private void LlenarCombo()
        {

            cboEstado.ResetText();
            cboEstado.Items.Clear();
            cboEstado.Items.Add("PENDIENTE");
            cboEstado.Items.Add("ANULADO");
            cboEstado.Items.Add("ACTIVO");
            cboEstado.Items.Add("FINALIZADO");
        }

        private void LlenarComboProyecto()
        {
            using (SqlConnection sqlConnection1 = new SqlConnection(Global.v_conexion))
            {
                sqlConnection1.Open();
                DataTable dataTable1 = new DataTable();
                using (SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select cod_proyecto, nombre from proyecto", sqlConnection1))
                {
                    sqlDataAdapter1.Fill(dataTable1);
                    cboProyecto.DataSource = dataTable1;
                    cboProyecto.DisplayMember = "nombre";
                    cboProyecto.ValueMember = "cod_proyecto"; //identificador
                    cboProyecto.SelectedIndex = -1; //opcional
                }
            }

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                btnNuevo.PerformClick();
            }


            if (dtpInicio.Text == "")
            {
                MessageBox.Show("Debe seleccionar una fecha de inicio", "Advertencia");
                dtpInicio.Focus();
                return;
            }

            if (cboProyecto.Text == "")
            {
                MessageBox.Show("Debe asignar un Proyecto al Backlog", "Advertencia");
                cboEstado.Focus();
                return;
            }
            if (cboEstado.Text == "")
            {
                MessageBox.Show("Debe asignar un Estado al Backlog", "Advertencia");
                cboEstado.Focus();
                return;
            }


            if (btnConfirmar.Text == "Modificar")
            {
                ModificarBacklog(txtCodigo.Text, cboEstado.Text);

            }
            else if (btnConfirmar.Text == "Confirmar")
            {
                InsertarBacklog(txtCodigo.Text, dtpInicio.Text,cboProyecto.SelectedValue.ToString() ,cboEstado.Text);
            }
        }


        public void InsertarBacklog(string v_codigo_backlog,
                 
                              string fechainicio,
                              string v_cod_proyecto,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"insert into backlog
            select " + v_codigo_backlog + ",convert(datetime, '" + fechainicio + "', 103),"+ v_cod_proyecto + " ,'" + v_estado + "' ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Backlog Insertado correctamente ");
            btnLimpiar.PerformClick();
        }

        public void ModificarBacklog(string v_codigo_backlog,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"update backlog
     set   estado = '" + v_estado + "' where cod_backlog = " + v_codigo_backlog + " ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Backlog Modificado correctamente ");
            btnLimpiar.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Global.v_conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT MAX(cod_backlog)+1 FROM backlog ", conexion);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                txtCodigo.Text = lector.GetValue(0).ToString();
                conexion.Close();
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                dtpInicio.Focus();
                LlenarComboProyecto();

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LlenarCombo();
            txtCodigo.Text = "";
            dtpInicio.Text = "";
            txtCodigo.Enabled = false;
            btnNuevo.Enabled = true;
            cboProyecto.Enabled = true;
            dtpInicio.Enabled = true;
            btnConfirmar.Text = "Confirmar";
            CargaGrilla();
            LlenarComboProyecto();
            btnNuevo.Focus();

        }

        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Backlog de la Grilla", "Advertencia");
                //txt.Focus();
                return;
            }

            Global.v_CodBacklog = txtCodigo.Text;
            Global.v_CodProyecto = cboProyecto.SelectedValue.ToString();
            Global.v_NombreProyecto = cboProyecto.Text;

            frmUS f = new frmUS();
            f.Show();

         
        }

        private void dgvProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvProyectos.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                txtCodigo.Text = Convert.ToString(filaSeleccionada.Cells[0].Value);
                dtpInicio.Text = Convert.ToString(filaSeleccionada.Cells[1].Value);
                //dtpFin.Text = Convert.ToString(filaSeleccionada.Cells[3].Value);
                cboProyecto.Text = Convert.ToString(filaSeleccionada.Cells[3].Value);
                cboEstado.Text = Convert.ToString(filaSeleccionada.Cells[4].Value);

                cboProyecto.Enabled = false;
                dtpInicio.Enabled = false;
                btnConfirmar.Text = "Modificar";
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                cboEstado.Focus();

            }
        }
    }
}

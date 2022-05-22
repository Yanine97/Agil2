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
    public partial class frmSprint : Form
    {
        public frmSprint()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();            
            CargaGrilla("");
            LlenarComboProyecto();
            LlenarComboFiltro();
            //txtNombreProyecto.Focus();
        }

        public void CargaGrilla(string vWhere)
        {

            string query = "";

            if (vWhere == "")
            {
                query = @" select * from v_sprint order by 1 asc ";
            }
            else
            {
                query = @" select * from v_sprint
                where nombre_proyecto like '%" + cboFiltro.Text + "%' order by 1 asc ";
            }

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

        private void LlenarCombo()
        {

            cboEstado.ResetText();
            cboEstado.Items.Clear();
            cboEstado.Items.Add("ANULADO");
            cboEstado.Items.Add("INICIADO");
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

        private void LlenarComboFiltro()
        {
            using (SqlConnection sqlConnection2 = new SqlConnection(Global.v_conexion))
            {
                sqlConnection2.Open();
                DataTable dataTable2 = new DataTable();
                using (SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select cod_proyecto, nombre from proyecto", sqlConnection2))
                {
                    sqlDataAdapter2.Fill(dataTable2);
                    cboFiltro.DataSource = dataTable2;
                    cboFiltro.DataSource = dataTable2;
                    cboFiltro.DisplayMember = "nombre";
                    cboFiltro.ValueMember = "cod_proyecto"; //identificador
                    cboFiltro.SelectedIndex = -1; //opcional

                }
            }

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                btnNuevo.PerformClick();
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe proporcionar una Descripcion para el Sprint", "Advertencia");
                txtDescripcion.Focus();
                return;
            }

            if (dtpInicio.Text == "")
            {
                MessageBox.Show("Debe seleccionar una fecha de inicio", "Advertencia");
                dtpInicio.Focus();
                return;
            }

            if (dtpFin.Text == "")
            {
                MessageBox.Show("Debe seleccionar una fecha de Fin", "Advertencia");
                dtpFin.Focus();
                return;
            }

            if (cboProyecto.Text == "")
            {
                MessageBox.Show("Debe asignar un Proyecto al Sprint", "Advertencia");
                cboEstado.Focus();
                return;
            }
            if (cboEstado.Text == "")
            {
                MessageBox.Show("Debe asignar un Estado al Sprint", "Advertencia");
                cboEstado.Focus();
                return;
            }


            if (btnConfirmar.Text == "Modificar")
            {
                ModificarSprint(txtCodigo.Text, cboEstado.Text);

            }
            else if (btnConfirmar.Text == "Confirmar")
            {
                InsertarSprint(txtCodigo.Text, cboProyecto.SelectedValue.ToString(), txtDescripcion.Text, dtpInicio.Text, dtpFin.Text,cboEstado.Text);
            }
        }


        public void InsertarSprint(string v_codigo,
                              string v_cod_proyecto,
                              string v_descripcion,
                              string fechainicio,
                              string fechaFin,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"insert into sprint
            select " + v_codigo +",  "+ v_cod_proyecto +", '"+ v_descripcion + "',convert(datetime, '" + fechainicio + "', 103)," + "convert(datetime, '" + fechaFin + "', 103)," + " '" + v_estado + "' ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Backlog Insertado correctamente ");
            btnLimpiar.PerformClick();
        }

        public void ModificarSprint(string v_codigo,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"update sprint
     set   estado = '" + v_estado + "' where cod_sprint = " + v_codigo + " ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Sprint Modificado Correctamente ");
            btnLimpiar.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Global.v_conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT MAX(cod_sprint)+1 FROM sprint ", conexion);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                txtCodigo.Text = lector.GetValue(0).ToString();
                conexion.Close();
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtDescripcion.Focus();
                LlenarComboProyecto();

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LlenarCombo();
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            dtpInicio.Text = "";
            dtpFin.Text = "";
            txtCodigo.Enabled = false;
            btnNuevo.Enabled = true;
            txtDescripcion.Enabled = true;
            cboProyecto.Enabled = true;
            dtpInicio.Enabled = true;
            dtpFin.Enabled = true;
            btnConfirmar.Text = "Confirmar";
            CargaGrilla("");
            LlenarComboProyecto();
            LlenarComboFiltro();
            btnNuevo.Focus();

        }

        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Sprint de la Grilla", "Advertencia");
                //txt.Focus();
                return;
            }

            Global.v_CodSprint = txtCodigo.Text;
            Global.v_DescripcionSprint = txtDescripcion.Text;
            Global.v_CodProyecto = cboProyecto.SelectedValue.ToString();
            Global.v_NombreProyecto = cboProyecto.Text;

            frmSprintUS f = new frmSprintUS();
            f.Show();

         
        }



        private void dgvSprint_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvSprint.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                txtCodigo.Text = Convert.ToString(filaSeleccionada.Cells[0].Value);
                txtDescripcion.Text = Convert.ToString(filaSeleccionada.Cells[1].Value);
                dtpInicio.Text = Convert.ToString(filaSeleccionada.Cells[4].Value);
                dtpFin.Text = Convert.ToString(filaSeleccionada.Cells[5].Value);
                cboProyecto.Text = Convert.ToString(filaSeleccionada.Cells[3].Value);
                cboEstado.Text = Convert.ToString(filaSeleccionada.Cells[6].Value);

                cboProyecto.Enabled = false;
                dtpInicio.Enabled = false;
                dtpFin.Enabled = false;
                btnConfirmar.Text = "Modificar";
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtDescripcion.Enabled = false;
                cboEstado.Focus();

            }
        }

        private void cboFiltro_TextChanged(object sender, EventArgs e)
        {
            CargaGrilla(cboFiltro.Text);
        }
    }
}
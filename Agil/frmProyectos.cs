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
    public partial class frmProyectos : Form
    {
        public frmProyectos()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();            
            CargaGrilla();
            txtNombreProyecto.Focus();
        }

        public void CargaGrilla()
        {

            string query = "";
            query = @" select * from proyecto order by 1 asc ";


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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProyecto.Text == "")
            {
                btnNuevo.PerformClick();
            }

            if (txtNombreProyecto.Text == "")
            {
                MessageBox.Show("Debe asignar una Descripcion", "Advertencia");
                txtNombreProyecto.Focus();
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
                MessageBox.Show("Debe seleccionar una fecha de finalización", "Advertencia");
                dtpFin.Focus();
                return;
            }

            if (cboEstado.Text == "")
            {
                MessageBox.Show("Debe asignar un Estado al Proyecto", "Advertencia");
                cboEstado.Focus();
                return;
            }


            if (btnConfirmar.Text == "Modificar")
            {
                ModificarProyecto(txtCodigoProyecto.Text, txtNombreProyecto.Text, dtpInicio.Text, dtpFin.Text, cboEstado.Text);

            }
            else if (btnConfirmar.Text == "Confirmar")
            {
                InsertarProyecto(txtCodigoProyecto.Text, txtNombreProyecto.Text, dtpInicio.Text, dtpFin.Text, cboEstado.Text);
            }
        }


        public void InsertarProyecto(string v_codigo_proyecto,
                              string v_descripcion,
                              string fechainicio,
                              string fechafin,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"insert into proyecto
            select " + v_codigo_proyecto + ",'" + v_descripcion + "',convert(datetime, '" + fechainicio + "', 103), convert(datetime,'" + fechafin + "', 103), '" + v_estado + "' ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Proyecto Insertado correctamente ");
            btnLimpiar.PerformClick();
        }

        public void ModificarProyecto(string v_codigo_proyecto,
                              string v_descripcion,
                              string fechainicio,
                              string fechafin,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"update proyecto
     set   estado = '" + v_estado + "' where cod_proyecto = " + v_codigo_proyecto + " ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Proyecto Modificado correctamente ");
            btnLimpiar.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Global.v_conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT MAX(COD_PROYECTO)+1 FROM PROYECTO ", conexion);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                txtCodigoProyecto.Text = lector.GetValue(0).ToString();
                conexion.Close();
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtNombreProyecto.Focus();


            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LlenarCombo();
            txtCodigoProyecto.Text = "";
            txtNombreProyecto.Text = "";
            dtpInicio.Text = "";
            dtpFin.Text = "";
            txtCodigoProyecto.Enabled = false;
            txtNombreProyecto.Enabled = true;
            btnNuevo.Enabled = true;
            btnConfirmar.Text = "Confirmar";
            CargaGrilla();
            txtNombreProyecto.Focus();
        }

        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            if (txtCodigoProyecto.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Proyecto de la Grilla", "Advertencia");
                txtNombreProyecto.Focus();
                return;
            }

            Global.v_CodProyecto = txtCodigoProyecto.Text;
            Global.v_NombreProyecto = txtNombreProyecto.Text;

            frmAsignarUsuario f = new frmAsignarUsuario();
            f.Show();

        }

        private void dgvProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvProyectos.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                txtCodigoProyecto.Text = Convert.ToString(filaSeleccionada.Cells[0].Value);
                txtNombreProyecto.Text = Convert.ToString(filaSeleccionada.Cells[1].Value);
                dtpInicio.Text = Convert.ToString(filaSeleccionada.Cells[2].Value);
                dtpFin.Text = Convert.ToString(filaSeleccionada.Cells[3].Value);
                cboEstado.Text = Convert.ToString(filaSeleccionada.Cells[4].Value);

                btnConfirmar.Text = "Modificar";
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
               // cboEstado.Focus();

            }
        }
    }
}

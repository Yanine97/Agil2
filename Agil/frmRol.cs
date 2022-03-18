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
    public partial class frmRol : Form
    {
        public frmRol()
        {
            InitializeComponent();
        }

        private void frmRol_Load(object sender, EventArgs e)
        {
            //CargaGrilla(txtDescripcion.Text);
            btnLimpiar.PerformClick();
            //txtCodigoRol.Enabled = false;
            //btnConfirmar.Enabled = false;
            //LlenarCombo();
            CargaGrilla();
            txtDescripcion.Focus();
        }

        public void CargaGrilla()
        {

            string query = "";
            query = @" select * from rol  order by 1 asc ";
            

            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRol.DataSource = dt;
            dgvRol.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }

        private void LlenarCombo()
        {

            cboEstado.ResetText();
            cboEstado.Items.Clear();
            cboEstado.Items.Add("ACTIVO");
            cboEstado.Items.Add("INACTIVO");
        }

        private void dgvRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvRol.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                txtCodigoRol.Text = Convert.ToString(filaSeleccionada.Cells[0].Value);
                txtDescripcion.Text = Convert.ToString(filaSeleccionada.Cells[1].Value);
                cboEstado.Text = Convert.ToString(filaSeleccionada.Cells[2].Value);
                btnConfirmar.Text = "Modificar";
                txtCodigoRol.Enabled = false;
                txtDescripcion.Enabled = false;
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                cboEstado.Focus();

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LlenarCombo();
            txtCodigoRol.Text = "";
            txtDescripcion.Text = "";
            txtCodigoRol.Enabled = false;
            txtDescripcion.Enabled = true;
            btnNuevo.Enabled = true;
            btnConfirmar.Text = "Confirmar";
            CargaGrilla();
            txtDescripcion.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Global.v_conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT MAX(COD_ROL)+1 FROM ROL ", conexion);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                txtCodigoRol.Text = lector.GetValue(0).ToString();
                conexion.Close();
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtDescripcion.Focus();


            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodigoRol.Text == "")
            {
                btnNuevo.PerformClick();
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe asignar una Descripcion", "Advertencia");
                txtDescripcion.Focus();
                return;
            }

            if (cboEstado.Text == "")
            {
                MessageBox.Show("Debe asignar un Estado al Rol", "Advertencia");
                cboEstado.Focus();
                return;
            }


            if (btnConfirmar.Text == "Modificar")
            {
                ModificarRol(txtCodigoRol.Text,txtDescripcion.Text,cboEstado.Text);

            }
            else if (btnConfirmar.Text == "Confirmar")
            {
                InsertarRol(txtCodigoRol.Text, txtDescripcion.Text, cboEstado.Text);
            }
        }


        public void InsertarRol(string v_codigo_rol,
                              string v_descripcion,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"insert into rol 
            select " + v_codigo_rol + ",'" + v_descripcion + "','" + v_estado + "' ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Rol Insertado correctamente ");
            btnLimpiar.PerformClick();
        }

        public void ModificarRol(string v_codigo_rol,
                              string v_descripcion,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"update rol 
     set   estado = '" + v_estado + "' where cod_rol = " + v_codigo_rol + " ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("Rol Modificado correctamente ");
            btnLimpiar.PerformClick();
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            if (txtCodigoRol.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un Rol de la Grilla", "Advertencia");
                txtDescripcion.Focus();
                return;
            }

            Global.v_Rol = txtCodigoRol.Text;
            Global.v_Descriocion_Rol = txtDescripcion.Text;

            frmRolMenu f = new frmRolMenu();
            f.Show();

        }
    }
}

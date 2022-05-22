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
    public partial class frmUS : Form
    {
        public frmUS()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();
            txtCodProyecto.Text = Global.v_CodProyecto;
            txtProyecto.Text = Global.v_NombreProyecto;
            txtCodBacklog.Text = Global.v_CodBacklog;

            txtCodProyecto.Enabled = false;
            txtProyecto.Enabled = false;
            txtCodBacklog.Enabled = false;

            CargaGrilla();
            txtNombre.Focus();
        }

        public void CargaGrilla()
        {

            string query = "";
            query = @"   select COD_US,u.NOMBRE,DESCRIPCION,U.COD_PROYECTO, p.NOMBRE as NOMBRE_PROYECTO, COD_BACKLOG, u.ESTADO from user_story u
  join proyecto p on p.cod_proyecto = u.cod_proyecto where p.cod_proyecto = " + Global.v_CodProyecto;


            SqlConnection connection2 = new SqlConnection(Global.v_conexion);
            connection2.Open();


            SqlCommand cmd = new SqlCommand(query, connection2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvUS.DataSource = dt;
            dgvUS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            connection2.Close();
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                btnNuevo.PerformClick();
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Nombre", "Advertencia");
                txtNombre.Focus();
                return;    
            }

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe agregar una breve descripcion", "Advertencia");
                txtDescripcion.Focus();
                return;
            }

            if (txtProyecto.Text == "")
            {
                MessageBox.Show("Debe seleccionar un un proyecto", "Advertencia");
                txtProyecto.Focus();
                return;
            }

            if (txtCodBacklog.Text == "")
            {
                MessageBox.Show("Debe seleccionar un backlog", "Advertencia");
                txtCodBacklog.Focus();
                return;
            }


            if (btnConfirmar.Text == "Modificar")
            {
                ModificarBacklog(txtCodigo.Text, txtDescripcion.Text);

            }
            else if (btnConfirmar.Text == "Confirmar")
            {
                InsertarBacklog(txtCodigo.Text, txtNombre.Text, txtDescripcion.Text, txtCodProyecto.Text, txtCodBacklog.Text, "TO DO");
            }
        }


        public void InsertarBacklog(string v_codigo,
                              string v_nombre,
                              string v_descripcion,
                              string v_cod_proyecto,
                              string v_cod_backlog,
                              string v_estado)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"insert into user_story
            select " + v_codigo + ",'"+ v_nombre + "' ,'" + v_descripcion + "', "+v_cod_proyecto + ", " + v_cod_backlog + ", '" + v_estado + "' ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("User Story Insertado correctamente ");
            btnLimpiar.PerformClick();
        }

        public void ModificarBacklog(string v_codigo,
                              string v_descripcion)
        {
            SqlConnection a = new SqlConnection();
            a.ConnectionString = Global.v_conexion;
            a.Open();
            string query2 = @"update user_story
     set   descripcion = '" + v_descripcion + "' where cod_us = " + v_codigo + " ";
            SqlCommand comando = new SqlCommand(query2, a);
            comando.ExecuteNonQuery();
            a.Close();
            MessageBox.Show("User Story Modificado correctamente ");
            btnLimpiar.PerformClick();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(Global.v_conexion);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SELECT MAX(cod_us)+1 FROM user_story ", conexion);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                txtCodigo.Text = lector.GetValue(0).ToString();
                conexion.Close();
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtNombre.Focus();

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
 
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtProyecto.Text = Global.v_NombreProyecto;
            txtCodBacklog.Text = Global.v_CodBacklog;

            txtCodigo.Enabled = false;
            btnNuevo.Enabled = true;
            txtProyecto.Enabled = false;
            txtCodBacklog.Enabled = false;
            btnConfirmar.Text = "Confirmar";
            CargaGrilla();
            btnNuevo.Focus();

        }


        private void dgvProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var filaSeleccionada = dgvUS.CurrentRow;

            if (filaSeleccionada != null) //¿Existe una referencia?
            {
                txtCodigo.Text = Convert.ToString(filaSeleccionada.Cells[0].Value);
                txtNombre.Text = Convert.ToString(filaSeleccionada.Cells[1].Value);
                txtDescripcion.Text = Convert.ToString(filaSeleccionada.Cells[2].Value);
                txtCodProyecto.Text = Convert.ToString(filaSeleccionada.Cells[3].Value);
                txtProyecto.Text = Convert.ToString(filaSeleccionada.Cells[4].Value);
                txtCodBacklog.Text = Convert.ToString(filaSeleccionada.Cells[5].Value);

                btnConfirmar.Text = "Modificar";
                btnConfirmar.Enabled = true;
                btnNuevo.Enabled = false;
                txtCodigo.Enabled = false;
                txtNombre.Enabled = false;
                txtProyecto.Enabled = false;
                txtCodBacklog.Enabled = false;
                txtDescripcion.Focus();

            }
        }
    }
}

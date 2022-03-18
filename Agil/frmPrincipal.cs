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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void usarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario f = new frmUsuario();
            f.Show();

        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRol f = new frmRol();
            f.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            mantenimientoUsuarioToolStripMenuItem.Enabled = false;
            proyectosToolStripMenuItem.Enabled = false;
            moduloDeDesarrolloToolStripMenuItem.Enabled = false;


            SqlConnection connectionx = new SqlConnection();
            connectionx.ConnectionString = Global.v_conexion;
            connectionx.Open();

            string query = @"select * from v_permisos where cod_usuario = " + Global.v_CodUsuarioPermiso;

            try
            {

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = Global.v_conexion;
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Cod_Menu"].ToString() == "1")
                    {
                        mantenimientoUsuarioToolStripMenuItem.Enabled = true;
                    }

                    if (dr["Cod_Menu"].ToString() == "2")
                    {
                        proyectosToolStripMenuItem.Enabled = true;

                    }

                    if (dr["Cod_Menu"].ToString() == "3")
                    {
                        moduloDeDesarrolloToolStripMenuItem.Enabled = true;
                    }

                }
                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error de conexion " + ex);
            }

        }

    }
}
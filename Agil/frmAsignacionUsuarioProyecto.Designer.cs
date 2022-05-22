
namespace Agil
{
    partial class frmAsignarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAsignado = new System.Windows.Forms.DataGridView();
            this.dgvDisponible = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreProyecto = new System.Windows.Forms.TextBox();
            this.txtCodProyecto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponible)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Realice doble clic en cualquier grilla para modificar los cambios";
            // 
            // dgvAsignado
            // 
            this.dgvAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignado.Location = new System.Drawing.Point(333, 124);
            this.dgvAsignado.Name = "dgvAsignado";
            this.dgvAsignado.Size = new System.Drawing.Size(303, 245);
            this.dgvAsignado.TabIndex = 16;
            this.dgvAsignado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAsignado_CellClick);
            // 
            // dgvDisponible
            // 
            this.dgvDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisponible.Location = new System.Drawing.Point(12, 124);
            this.dgvDisponible.Name = "dgvDisponible";
            this.dgvDisponible.Size = new System.Drawing.Size(300, 247);
            this.dgvDisponible.TabIndex = 15;
            this.dgvDisponible.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisponible_CellClick);
            this.dgvDisponible.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisponible_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Usuarios miembros del Proyecto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Usuarios Disponibles";
            // 
            // txtNombreProyecto
            // 
            this.txtNombreProyecto.Location = new System.Drawing.Point(235, 52);
            this.txtNombreProyecto.Name = "txtNombreProyecto";
            this.txtNombreProyecto.Size = new System.Drawing.Size(289, 20);
            this.txtNombreProyecto.TabIndex = 12;
            // 
            // txtCodProyecto
            // 
            this.txtCodProyecto.Location = new System.Drawing.Point(129, 52);
            this.txtCodProyecto.Name = "txtCodProyecto";
            this.txtCodProyecto.Size = new System.Drawing.Size(100, 20);
            this.txtCodProyecto.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Proyecto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(232, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Nombre del Proyecto";
            // 
            // frmAsignarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 425);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAsignado);
            this.Controls.Add(this.dgvDisponible);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreProyecto);
            this.Controls.Add(this.txtCodProyecto);
            this.Name = "frmAsignarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de usuarios a Proyecto";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAsignado;
        private System.Windows.Forms.DataGridView dgvDisponible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreProyecto;
        private System.Windows.Forms.TextBox txtCodProyecto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
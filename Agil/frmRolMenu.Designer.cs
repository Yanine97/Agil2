
namespace Agil
{
    partial class frmRolMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodRol = new System.Windows.Forms.TextBox();
            this.txtDescripcionRol = new System.Windows.Forms.TextBox();
            this.dgvDisponible = new System.Windows.Forms.DataGridView();
            this.DgvAsignado = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAsignado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rol :";
            // 
            // txtCodRol
            // 
            this.txtCodRol.Location = new System.Drawing.Point(154, 23);
            this.txtCodRol.Name = "txtCodRol";
            this.txtCodRol.Size = new System.Drawing.Size(100, 20);
            this.txtCodRol.TabIndex = 1;
            // 
            // txtDescripcionRol
            // 
            this.txtDescripcionRol.Location = new System.Drawing.Point(260, 23);
            this.txtDescripcionRol.Name = "txtDescripcionRol";
            this.txtDescripcionRol.Size = new System.Drawing.Size(307, 20);
            this.txtDescripcionRol.TabIndex = 2;
            // 
            // dgvDisponible
            // 
            this.dgvDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisponible.Location = new System.Drawing.Point(12, 85);
            this.dgvDisponible.Name = "dgvDisponible";
            this.dgvDisponible.Size = new System.Drawing.Size(345, 170);
            this.dgvDisponible.TabIndex = 3;
            this.dgvDisponible.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisponible_CellClick);
            // 
            // DgvAsignado
            // 
            this.DgvAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAsignado.Location = new System.Drawing.Point(371, 85);
            this.DgvAsignado.Name = "DgvAsignado";
            this.DgvAsignado.Size = new System.Drawing.Size(349, 170);
            this.DgvAsignado.TabIndex = 4;
            this.DgvAsignado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAsignado_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Modulos Disponibles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Modulos Asignados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Realice doble clic en cualquier grilla para modificar los permisos";
            // 
            // frmRolMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 279);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DgvAsignado);
            this.Controls.Add(this.dgvDisponible);
            this.Controls.Add(this.txtDescripcionRol);
            this.Controls.Add(this.txtCodRol);
            this.Controls.Add(this.label1);
            this.Name = "frmRolMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rol Menu";
            this.Load += new System.EventHandler(this.frmRolMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAsignado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodRol;
        private System.Windows.Forms.TextBox txtDescripcionRol;
        private System.Windows.Forms.DataGridView dgvDisponible;
        private System.Windows.Forms.DataGridView DgvAsignado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
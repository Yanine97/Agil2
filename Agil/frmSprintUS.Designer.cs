
namespace Agil
{
    partial class frmSprintUS
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
            this.dgvBacklog = new System.Windows.Forms.DataGridView();
            this.dgvSprint = new System.Windows.Forms.DataGridView();
            this.Sprint = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodProyecto = new System.Windows.Forms.TextBox();
            this.txtDesSprint = new System.Windows.Forms.TextBox();
            this.txtDesProyecto = new System.Windows.Forms.TextBox();
            this.txtCodSprint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBacklog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSprint)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBacklog
            // 
            this.dgvBacklog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBacklog.Location = new System.Drawing.Point(7, 130);
            this.dgvBacklog.Name = "dgvBacklog";
            this.dgvBacklog.Size = new System.Drawing.Size(333, 260);
            this.dgvBacklog.TabIndex = 0;
            this.dgvBacklog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBacklog_CellClick);
            this.dgvBacklog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBacklog_CellContentClick);
            // 
            // dgvSprint
            // 
            this.dgvSprint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSprint.Location = new System.Drawing.Point(349, 130);
            this.dgvSprint.Name = "dgvSprint";
            this.dgvSprint.Size = new System.Drawing.Size(333, 260);
            this.dgvSprint.TabIndex = 1;
            // 
            // Sprint
            // 
            this.Sprint.AutoSize = true;
            this.Sprint.Location = new System.Drawing.Point(125, 45);
            this.Sprint.Name = "Sprint";
            this.Sprint.Size = new System.Drawing.Size(40, 13);
            this.Sprint.TabIndex = 2;
            this.Sprint.Text = "Sprint :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Proyecto : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User Stories - Backlog";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "User Stories - Sprint";
            // 
            // txtCodProyecto
            // 
            this.txtCodProyecto.Enabled = false;
            this.txtCodProyecto.Location = new System.Drawing.Point(186, 6);
            this.txtCodProyecto.Name = "txtCodProyecto";
            this.txtCodProyecto.Size = new System.Drawing.Size(72, 20);
            this.txtCodProyecto.TabIndex = 6;
            // 
            // txtDesSprint
            // 
            this.txtDesSprint.Enabled = false;
            this.txtDesSprint.Location = new System.Drawing.Point(264, 42);
            this.txtDesSprint.Name = "txtDesSprint";
            this.txtDesSprint.Size = new System.Drawing.Size(293, 20);
            this.txtDesSprint.TabIndex = 8;
            // 
            // txtDesProyecto
            // 
            this.txtDesProyecto.Enabled = false;
            this.txtDesProyecto.Location = new System.Drawing.Point(264, 6);
            this.txtDesProyecto.Name = "txtDesProyecto";
            this.txtDesProyecto.Size = new System.Drawing.Size(293, 20);
            this.txtDesProyecto.TabIndex = 9;
            // 
            // txtCodSprint
            // 
            this.txtCodSprint.Enabled = false;
            this.txtCodSprint.Location = new System.Drawing.Point(186, 42);
            this.txtCodSprint.Name = "txtCodSprint";
            this.txtCodSprint.Size = new System.Drawing.Size(72, 20);
            this.txtCodSprint.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Realice doble clic en cualquier grilla para mover los User Stories";
            // 
            // frmSprintUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodSprint);
            this.Controls.Add(this.txtDesProyecto);
            this.Controls.Add(this.txtDesSprint);
            this.Controls.Add(this.txtCodProyecto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Sprint);
            this.Controls.Add(this.dgvSprint);
            this.Controls.Add(this.dgvBacklog);
            this.Name = "frmSprintUS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprint - User Stories";
            this.Load += new System.EventHandler(this.frmSprintUS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBacklog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSprint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBacklog;
        private System.Windows.Forms.DataGridView dgvSprint;
        private System.Windows.Forms.Label Sprint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodProyecto;
        private System.Windows.Forms.TextBox txtDesSprint;
        private System.Windows.Forms.TextBox txtDesProyecto;
        private System.Windows.Forms.TextBox txtCodSprint;
        private System.Windows.Forms.Label label1;
    }
}
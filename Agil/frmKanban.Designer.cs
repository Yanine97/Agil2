
namespace Agil
{
    partial class frmKanban
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
            this.dgvTodo = new System.Windows.Forms.DataGridView();
            this.dgvDoing = new System.Windows.Forms.DataGridView();
            this.dgvDone = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDone)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTodo
            // 
            this.dgvTodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodo.Location = new System.Drawing.Point(13, 25);
            this.dgvTodo.Name = "dgvTodo";
            this.dgvTodo.Size = new System.Drawing.Size(400, 413);
            this.dgvTodo.TabIndex = 0;
            this.dgvTodo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTodo_CellContentDoubleClick);
            // 
            // dgvDoing
            // 
            this.dgvDoing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoing.Location = new System.Drawing.Point(419, 25);
            this.dgvDoing.Name = "dgvDoing";
            this.dgvDoing.Size = new System.Drawing.Size(400, 413);
            this.dgvDoing.TabIndex = 1;
            this.dgvDoing.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoing_CellContentDoubleClick);
            // 
            // dgvDone
            // 
            this.dgvDone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDone.Location = new System.Drawing.Point(825, 25);
            this.dgvDone.Name = "dgvDone";
            this.dgvDone.Size = new System.Drawing.Size(400, 413);
            this.dgvDone.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To Do.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(822, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Done.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Doing.";
            // 
            // frmKanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDone);
            this.Controls.Add(this.dgvDoing);
            this.Controls.Add(this.dgvTodo);
            this.Name = "frmKanban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablero Kanban";
            this.Load += new System.EventHandler(this.frmKanban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTodo;
        private System.Windows.Forms.DataGridView dgvDoing;
        private System.Windows.Forms.DataGridView dgvDone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
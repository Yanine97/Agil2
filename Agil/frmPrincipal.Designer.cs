namespace Agil
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduloDeDesarrolloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backlogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backlogsProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userStoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userStoriesBackklogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sprintProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoUsuarioToolStripMenuItem,
            this.proyectosToolStripMenuItem,
            this.moduloDeDesarrolloToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoUsuarioToolStripMenuItem
            // 
            this.mantenimientoUsuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usarioToolStripMenuItem,
            this.rolesToolStripMenuItem});
            this.mantenimientoUsuarioToolStripMenuItem.Name = "mantenimientoUsuarioToolStripMenuItem";
            this.mantenimientoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.mantenimientoUsuarioToolStripMenuItem.Text = "Modulo Seguridad";
            // 
            // usarioToolStripMenuItem
            // 
            this.usarioToolStripMenuItem.Name = "usarioToolStripMenuItem";
            this.usarioToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.usarioToolStripMenuItem.Text = "Usuario";
            this.usarioToolStripMenuItem.Click += new System.EventHandler(this.usarioToolStripMenuItem_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // proyectosToolStripMenuItem
            // 
            this.proyectosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectosToolStripMenuItem1,
            this.usuarioProyectoToolStripMenuItem});
            this.proyectosToolStripMenuItem.Name = "proyectosToolStripMenuItem";
            this.proyectosToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.proyectosToolStripMenuItem.Text = "Modulo de Proyectos";
            // 
            // proyectosToolStripMenuItem1
            // 
            this.proyectosToolStripMenuItem1.Name = "proyectosToolStripMenuItem1";
            this.proyectosToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.proyectosToolStripMenuItem1.Text = "Proyectos";
            // 
            // usuarioProyectoToolStripMenuItem
            // 
            this.usuarioProyectoToolStripMenuItem.Name = "usuarioProyectoToolStripMenuItem";
            this.usuarioProyectoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.usuarioProyectoToolStripMenuItem.Text = "Usuario/Proyecto";
            // 
            // moduloDeDesarrolloToolStripMenuItem
            // 
            this.moduloDeDesarrolloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backlogsToolStripMenuItem,
            this.backlogsProyectoToolStripMenuItem,
            this.userStoriesToolStripMenuItem,
            this.userStoriesBackklogToolStripMenuItem,
            this.sprintToolStripMenuItem,
            this.sprintProyectoToolStripMenuItem,
            this.toolStripTextBox1});
            this.moduloDeDesarrolloToolStripMenuItem.Name = "moduloDeDesarrolloToolStripMenuItem";
            this.moduloDeDesarrolloToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.moduloDeDesarrolloToolStripMenuItem.Text = "Modulo de Desarrollo";
            // 
            // backlogsToolStripMenuItem
            // 
            this.backlogsToolStripMenuItem.Name = "backlogsToolStripMenuItem";
            this.backlogsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.backlogsToolStripMenuItem.Text = "Backlogs";
            // 
            // backlogsProyectoToolStripMenuItem
            // 
            this.backlogsProyectoToolStripMenuItem.Name = "backlogsProyectoToolStripMenuItem";
            this.backlogsProyectoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.backlogsProyectoToolStripMenuItem.Text = "Backlog/Proyecto";
            // 
            // userStoriesToolStripMenuItem
            // 
            this.userStoriesToolStripMenuItem.Name = "userStoriesToolStripMenuItem";
            this.userStoriesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.userStoriesToolStripMenuItem.Text = "User Stories";
            // 
            // userStoriesBackklogToolStripMenuItem
            // 
            this.userStoriesBackklogToolStripMenuItem.Name = "userStoriesBackklogToolStripMenuItem";
            this.userStoriesBackklogToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.userStoriesBackklogToolStripMenuItem.Text = "User Stories/Backlog";
            // 
            // sprintToolStripMenuItem
            // 
            this.sprintToolStripMenuItem.Name = "sprintToolStripMenuItem";
            this.sprintToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sprintToolStripMenuItem.Text = "Sprint";
            // 
            // sprintProyectoToolStripMenuItem
            // 
            this.sprintProyectoToolStripMenuItem.Name = "sprintProyectoToolStripMenuItem";
            this.sprintProyectoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sprintProyectoToolStripMenuItem.Text = "Sprint/Proyecto";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Tablero Kanban";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 371);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal - Sistema Agil";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyectosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyectosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuarioProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduloDeDesarrolloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backlogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backlogsProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userStoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userStoriesBackklogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sprintProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}
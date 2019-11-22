namespace TcpGuardClient
{
    partial class ServerManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerManageForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lvPortals = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddPortal = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePortals = new System.Windows.Forms.ToolStripButton();
            this.pnlMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lvPortals);
            this.pnlMain.Controls.Add(this.toolStrip1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(520, 343);
            this.pnlMain.TabIndex = 0;
            // 
            // lvPortals
            // 
            this.lvPortals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPortals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPortals.FullRowSelect = true;
            this.lvPortals.Location = new System.Drawing.Point(0, 25);
            this.lvPortals.Name = "lvPortals";
            this.lvPortals.Size = new System.Drawing.Size(520, 318);
            this.lvPortals.TabIndex = 3;
            this.lvPortals.UseCompatibleStateImageBehavior = false;
            this.lvPortals.View = System.Windows.Forms.View.Details;
            this.lvPortals.SelectedIndexChanged += new System.EventHandler(this.lvPortals_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Remote Host";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Remote Port";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Local Port";
            this.columnHeader3.Width = 120;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddPortal,
            this.btnDeletePortals});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(520, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddPortal
            // 
            this.btnAddPortal.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPortal.Image")));
            this.btnAddPortal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPortal.Name = "btnAddPortal";
            this.btnAddPortal.Size = new System.Drawing.Size(52, 22);
            this.btnAddPortal.Text = "Add";
            this.btnAddPortal.Click += new System.EventHandler(this.btnAddPortal_Click);
            // 
            // btnDeletePortals
            // 
            this.btnDeletePortals.Enabled = false;
            this.btnDeletePortals.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePortals.Image")));
            this.btnDeletePortals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePortals.Name = "btnDeletePortals";
            this.btnDeletePortals.Size = new System.Drawing.Size(65, 22);
            this.btnDeletePortals.Text = "Delete";
            this.btnDeletePortals.Click += new System.EventHandler(this.btnDeletePortals_Click);
            // 
            // ServerManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 343);
            this.Controls.Add(this.pnlMain);
            this.Name = "ServerManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Manage";
            this.Load += new System.EventHandler(this.ServerManageForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListView lvPortals;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddPortal;
        private System.Windows.Forms.ToolStripButton btnDeletePortals;
    }
}
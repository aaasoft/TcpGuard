namespace TcpGuardClient
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpPortals = new System.Windows.Forms.TabPage();
            this.lvPortals = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddPortal = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePortals = new System.Windows.Forms.ToolStripButton();
            this.tpServers = new System.Windows.Forms.TabPage();
            this.lvServers = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddServer = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteServer = new System.Windows.Forms.ToolStripButton();
            this.tcMain.SuspendLayout();
            this.tpPortals.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tpServers.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpPortals);
            this.tcMain.Controls.Add(this.tpServers);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(695, 442);
            this.tcMain.TabIndex = 0;
            // 
            // tpPortals
            // 
            this.tpPortals.Controls.Add(this.lvPortals);
            this.tpPortals.Controls.Add(this.toolStrip1);
            this.tpPortals.Location = new System.Drawing.Point(4, 22);
            this.tpPortals.Name = "tpPortals";
            this.tpPortals.Padding = new System.Windows.Forms.Padding(3);
            this.tpPortals.Size = new System.Drawing.Size(687, 416);
            this.tpPortals.TabIndex = 0;
            this.tpPortals.Text = "Portals";
            this.tpPortals.UseVisualStyleBackColor = true;
            // 
            // lvPortals
            // 
            this.lvPortals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvPortals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPortals.FullRowSelect = true;
            this.lvPortals.Location = new System.Drawing.Point(3, 28);
            this.lvPortals.Name = "lvPortals";
            this.lvPortals.Size = new System.Drawing.Size(681, 385);
            this.lvPortals.TabIndex = 1;
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
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(681, 25);
            this.toolStrip1.TabIndex = 0;
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
            // tpServers
            // 
            this.tpServers.Controls.Add(this.lvServers);
            this.tpServers.Controls.Add(this.toolStrip2);
            this.tpServers.Location = new System.Drawing.Point(4, 22);
            this.tpServers.Name = "tpServers";
            this.tpServers.Padding = new System.Windows.Forms.Padding(3);
            this.tpServers.Size = new System.Drawing.Size(687, 416);
            this.tpServers.TabIndex = 1;
            this.tpServers.Text = "Servers";
            this.tpServers.UseVisualStyleBackColor = true;
            // 
            // lvServers
            // 
            this.lvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServers.FullRowSelect = true;
            this.lvServers.Location = new System.Drawing.Point(3, 28);
            this.lvServers.Name = "lvServers";
            this.lvServers.Size = new System.Drawing.Size(681, 385);
            this.lvServers.TabIndex = 3;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            this.lvServers.SelectedIndexChanged += new System.EventHandler(this.lvServers_SelectedIndexChanged);
            this.lvServers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvServers_MouseDoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Host";
            this.columnHeader4.Width = 240;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Manage Port";
            this.columnHeader5.Width = 120;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddServer,
            this.btnDeleteServer});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(681, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAddServer
            // 
            this.btnAddServer.Image = ((System.Drawing.Image)(resources.GetObject("btnAddServer.Image")));
            this.btnAddServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(52, 22);
            this.btnAddServer.Text = "Add";
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // btnDeleteServer
            // 
            this.btnDeleteServer.Enabled = false;
            this.btnDeleteServer.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteServer.Image")));
            this.btnDeleteServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteServer.Name = "btnDeleteServer";
            this.btnDeleteServer.Size = new System.Drawing.Size(65, 22);
            this.btnDeleteServer.Text = "Delete";
            this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 442);
            this.Controls.Add(this.tcMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TcpGuard Client";
            this.tcMain.ResumeLayout(false);
            this.tpPortals.ResumeLayout(false);
            this.tpPortals.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tpServers.ResumeLayout(false);
            this.tpServers.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpPortals;
        private System.Windows.Forms.ListView lvPortals;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddPortal;
        private System.Windows.Forms.TabPage tpServers;
        private System.Windows.Forms.ToolStripButton btnDeletePortals;
        private System.Windows.Forms.ListView lvServers;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddServer;
        private System.Windows.Forms.ToolStripButton btnDeleteServer;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}


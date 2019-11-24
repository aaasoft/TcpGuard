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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gpServers = new System.Windows.Forms.GroupBox();
            this.lvServers = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsServers = new System.Windows.Forms.ToolStrip();
            this.btnAddServer = new System.Windows.Forms.ToolStripButton();
            this.btnEditServer = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteServer = new System.Windows.Forms.ToolStripButton();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.gbPortals = new System.Windows.Forms.GroupBox();
            this.lvPortals = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsPortals = new System.Windows.Forms.ToolStrip();
            this.btnAddPortal = new System.Windows.Forms.ToolStripButton();
            this.btnEditPortal = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePortals = new System.Windows.Forms.ToolStripButton();
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gpServers.SuspendLayout();
            this.tsServers.SuspendLayout();
            this.gbPortals.SuspendLayout();
            this.tsPortals.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gpServers);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gbPortals);
            this.scMain.Size = new System.Drawing.Size(784, 561);
            this.scMain.SplitterDistance = 261;
            this.scMain.TabIndex = 1;
            // 
            // gpServers
            // 
            this.gpServers.Controls.Add(this.lvServers);
            this.gpServers.Controls.Add(this.tsServers);
            this.gpServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpServers.Location = new System.Drawing.Point(0, 0);
            this.gpServers.Name = "gpServers";
            this.gpServers.Size = new System.Drawing.Size(261, 561);
            this.gpServers.TabIndex = 2;
            this.gpServers.TabStop = false;
            this.gpServers.Text = "Servers";
            // 
            // lvServers
            // 
            this.lvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lvServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServers.FullRowSelect = true;
            this.lvServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvServers.HideSelection = false;
            this.lvServers.Location = new System.Drawing.Point(3, 42);
            this.lvServers.Name = "lvServers";
            this.lvServers.Size = new System.Drawing.Size(255, 516);
            this.lvServers.TabIndex = 5;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            this.lvServers.SelectedIndexChanged += new System.EventHandler(this.lvServers_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Host";
            this.columnHeader4.Width = 240;
            // 
            // tsServers
            // 
            this.tsServers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddServer,
            this.btnEditServer,
            this.btnDeleteServer,
            this.btnTest});
            this.tsServers.Location = new System.Drawing.Point(3, 17);
            this.tsServers.Name = "tsServers";
            this.tsServers.Size = new System.Drawing.Size(255, 25);
            this.tsServers.TabIndex = 4;
            this.tsServers.Text = "toolStrip2";
            // 
            // btnAddServer
            // 
            this.btnAddServer.Image = global::TcpGuardClient.Properties.Resources.add_16p;
            this.btnAddServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(52, 22);
            this.btnAddServer.Text = "Add";
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // btnEditServer
            // 
            this.btnEditServer.Enabled = false;
            this.btnEditServer.Image = global::TcpGuardClient.Properties.Resources.adjustment_16px;
            this.btnEditServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditServer.Name = "btnEditServer";
            this.btnEditServer.Size = new System.Drawing.Size(50, 22);
            this.btnEditServer.Text = "Edit";
            this.btnEditServer.Click += new System.EventHandler(this.btnEditServer_Click);
            // 
            // btnDeleteServer
            // 
            this.btnDeleteServer.Enabled = false;
            this.btnDeleteServer.Image = global::TcpGuardClient.Properties.Resources.remove_16px;
            this.btnDeleteServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteServer.Name = "btnDeleteServer";
            this.btnDeleteServer.Size = new System.Drawing.Size(65, 22);
            this.btnDeleteServer.Text = "Delete";
            this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Image = global::TcpGuardClient.Properties.Resources.sound_waves_16px;
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(52, 22);
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // gbPortals
            // 
            this.gbPortals.Controls.Add(this.lvPortals);
            this.gbPortals.Controls.Add(this.tsPortals);
            this.gbPortals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPortals.Location = new System.Drawing.Point(0, 0);
            this.gbPortals.Name = "gbPortals";
            this.gbPortals.Size = new System.Drawing.Size(519, 561);
            this.gbPortals.TabIndex = 3;
            this.gbPortals.TabStop = false;
            this.gbPortals.Text = "Portals";
            this.gbPortals.Visible = false;
            // 
            // lvPortals
            // 
            this.lvPortals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5});
            this.lvPortals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPortals.FullRowSelect = true;
            this.lvPortals.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPortals.HideSelection = false;
            this.lvPortals.Location = new System.Drawing.Point(3, 42);
            this.lvPortals.Name = "lvPortals";
            this.lvPortals.Size = new System.Drawing.Size(513, 516);
            this.lvPortals.TabIndex = 3;
            this.lvPortals.UseCompatibleStateImageBehavior = false;
            this.lvPortals.View = System.Windows.Forms.View.Details;
            this.lvPortals.SelectedIndexChanged += new System.EventHandler(this.lvPortals_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Remote Host";
            this.columnHeader1.Width = 200;
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
            // columnHeader5
            // 
            this.columnHeader5.Text = "Runing";
            // 
            // tsPortals
            // 
            this.tsPortals.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddPortal,
            this.btnEditPortal,
            this.btnDeletePortals});
            this.tsPortals.Location = new System.Drawing.Point(3, 17);
            this.tsPortals.Name = "tsPortals";
            this.tsPortals.Size = new System.Drawing.Size(513, 25);
            this.tsPortals.TabIndex = 2;
            this.tsPortals.Text = "toolStrip1";
            // 
            // btnAddPortal
            // 
            this.btnAddPortal.Image = global::TcpGuardClient.Properties.Resources.add_16p;
            this.btnAddPortal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPortal.Name = "btnAddPortal";
            this.btnAddPortal.Size = new System.Drawing.Size(52, 22);
            this.btnAddPortal.Text = "Add";
            this.btnAddPortal.Click += new System.EventHandler(this.btnAddPortal_Click);
            // 
            // btnEditPortal
            // 
            this.btnEditPortal.Enabled = false;
            this.btnEditPortal.Image = global::TcpGuardClient.Properties.Resources.adjustment_16px;
            this.btnEditPortal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditPortal.Name = "btnEditPortal";
            this.btnEditPortal.Size = new System.Drawing.Size(50, 22);
            this.btnEditPortal.Text = "Edit";
            this.btnEditPortal.Click += new System.EventHandler(this.btnEditPortal_Click);
            // 
            // btnDeletePortals
            // 
            this.btnDeletePortals.Enabled = false;
            this.btnDeletePortals.Image = global::TcpGuardClient.Properties.Resources.remove_16px;
            this.btnDeletePortals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePortals.Name = "btnDeletePortals";
            this.btnDeletePortals.Size = new System.Drawing.Size(65, 22);
            this.btnDeletePortals.Text = "Delete";
            this.btnDeletePortals.Click += new System.EventHandler(this.btnDeletePortals_Click);
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.cmsMain;
            this.niMain.Icon = ((System.Drawing.Icon)(resources.GetObject("niMain.Icon")));
            this.niMain.Text = "TcpGuard Client";
            this.niMain.Visible = true;
            this.niMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niMain_MouseClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(97, 26);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(96, 22);
            this.miExit.Text = "E&xit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.scMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TcpGuard Client";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gpServers.ResumeLayout(false);
            this.gpServers.PerformLayout();
            this.tsServers.ResumeLayout(false);
            this.tsServers.PerformLayout();
            this.gbPortals.ResumeLayout(false);
            this.gbPortals.PerformLayout();
            this.tsPortals.ResumeLayout(false);
            this.tsPortals.PerformLayout();
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gpServers;
        private System.Windows.Forms.ListView lvServers;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip tsServers;
        private System.Windows.Forms.ToolStripButton btnAddServer;
        private System.Windows.Forms.ToolStripButton btnDeleteServer;
        private System.Windows.Forms.GroupBox gbPortals;
        private System.Windows.Forms.ListView lvPortals;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip tsPortals;
        private System.Windows.Forms.ToolStripButton btnAddPortal;
        private System.Windows.Forms.ToolStripButton btnDeletePortals;
        private System.Windows.Forms.ToolStripButton btnTest;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripButton btnEditServer;
        private System.Windows.Forms.ToolStripButton btnEditPortal;
        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem miExit;
    }
}


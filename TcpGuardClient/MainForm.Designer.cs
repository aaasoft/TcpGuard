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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvServers = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddServer = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteServer = new System.Windows.Forms.ToolStripButton();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvPortals = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddPortal = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePortals = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.scMain.Panel1.Controls.Add(this.groupBox1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.groupBox2);
            this.scMain.Size = new System.Drawing.Size(784, 561);
            this.scMain.SplitterDistance = 261;
            this.scMain.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvServers);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 561);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servers";
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
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddServer,
            this.btnDeleteServer,
            this.btnTest});
            this.toolStrip2.Location = new System.Drawing.Point(3, 17);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(255, 25);
            this.toolStrip2.TabIndex = 4;
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
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(52, 22);
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvPortals);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 561);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Portals";
            // 
            // lvPortals
            // 
            this.lvPortals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
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
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(513, 25);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.scMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TcpGuard Client";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvServers;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddServer;
        private System.Windows.Forms.ToolStripButton btnDeleteServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvPortals;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddPortal;
        private System.Windows.Forms.ToolStripButton btnDeletePortals;
        private System.Windows.Forms.ToolStripButton btnTest;
    }
}


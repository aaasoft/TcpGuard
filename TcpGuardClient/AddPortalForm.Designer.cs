namespace TcpGuardClient
{
    partial class AddPortalForm
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
            this.txtRemoteHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRemotePort = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudLocalPort = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemotePort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remote Host:";
            // 
            // txtRemoteHost
            // 
            this.txtRemoteHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteHost.Location = new System.Drawing.Point(101, 12);
            this.txtRemoteHost.Name = "txtRemoteHost";
            this.txtRemoteHost.Size = new System.Drawing.Size(174, 21);
            this.txtRemoteHost.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Remote Port:";
            // 
            // nudRemotePort
            // 
            this.nudRemotePort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRemotePort.Location = new System.Drawing.Point(101, 39);
            this.nudRemotePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudRemotePort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRemotePort.Name = "nudRemotePort";
            this.nudRemotePort.Size = new System.Drawing.Size(174, 21);
            this.nudRemotePort.TabIndex = 2;
            this.nudRemotePort.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(200, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Local Port:";
            // 
            // nudLocalPort
            // 
            this.nudLocalPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudLocalPort.Location = new System.Drawing.Point(101, 66);
            this.nudLocalPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudLocalPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLocalPort.Name = "nudLocalPort";
            this.nudLocalPort.Size = new System.Drawing.Size(174, 21);
            this.nudLocalPort.TabIndex = 2;
            this.nudLocalPort.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // AddPortalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 133);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudLocalPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudRemotePort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemoteHost);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddPortalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Portal";
            ((System.ComponentModel.ISupportInitialize)(this.nudRemotePort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLocalPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemoteHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRemotePort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudLocalPort;
    }
}
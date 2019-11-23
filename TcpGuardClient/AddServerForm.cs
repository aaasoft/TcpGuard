using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpGuardClient
{
    public partial class AddServerForm : Form
    {
        public Model.ServerModel Model { get; set; }

        public AddServerForm()
        {
            InitializeComponent();
        }

        private void AddServerForm_Load(object sender, EventArgs e)
        {
            if (Model != null)
            {
                txtHost.Text = Model.Host;
                nudPort.Value = Model.Port;
                txtPassword.Text = Model.Password;
                cbEnableCompress.Checked = Model.EnableCompress;
                cbEnableEncrypt.Checked = Model.EnableEncrypt;
                this.Text = "Edit Server";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Model == null)
                Model = new Model.ServerModel();

            Model.Host = txtHost.Text.Trim();
            Model.Port = Convert.ToInt32(nudPort.Value);
            Model.Password = txtPassword.Text.Trim();
            Model.EnableCompress = cbEnableCompress.Checked;
            Model.EnableEncrypt = cbEnableEncrypt.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

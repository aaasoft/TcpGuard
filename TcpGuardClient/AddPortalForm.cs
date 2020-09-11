using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpGuardClient.Model;

namespace TcpGuardClient
{
    public partial class AddPortalForm : Form
    {
        public PortalModel Model { get; set; }

        public AddPortalForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Model == null)
                Model = new PortalModel();
            Model.RemoteHost = txtRemoteHost.Text.Trim();
            Model.RemotePort = Convert.ToInt32(nudRemotePort.Value);
            Model.LocalIpAddress = txtLocalIpAddress.Text.Trim();
            Model.LocalPort = Convert.ToInt32(nudLocalPort.Value);
            Model.SendInterval = Convert.ToInt32(nudSendInterval.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddPortalForm_Load(object sender, EventArgs e)
        {
            if (Model != null)
            {
                txtRemoteHost.Text = Model.RemoteHost;
                nudRemotePort.Value = Model.RemotePort;
                txtLocalIpAddress.Text = Model.LocalIpAddress;
                nudLocalPort.Value = Model.LocalPort;
                nudSendInterval.Value = Model.SendInterval;
                this.Text = "Edit Portal";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

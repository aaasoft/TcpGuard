using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpGuard.Core.Protocol.V1.Model;

namespace TcpGuardClient
{
    public partial class AddPortalForm : Form
    {
        public PortalModel Model { get; private set; }

        public AddPortalForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Model = new PortalModel()
            {
                RemoteHost = txtRemoteHost.Text.Trim(),
                RemotePort = Convert.ToInt32(nudRemotePort.Value),
                Port = Convert.ToInt32(nudLocalPort.Value)
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

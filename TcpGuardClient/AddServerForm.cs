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
        public Model.ServerModel Model { get; private set; }

        public AddServerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Model = new Model.ServerModel()
            {
                Host = txtHost.Text.Trim(),
                Port = Convert.ToInt32(nudPort.Value),
                Password = txtPassword.Text.Trim(),
                EnableCompress = cbEnableCompress.Checked,
                EnableEncrypt = cbEnableEncrypt.Checked
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

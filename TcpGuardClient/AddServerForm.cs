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
                txtUrl.Text = Model.Url;
                txtPassword.Text = Model.Password;
                this.Text = "Edit Server";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Model == null)
                Model = new Model.ServerModel();

            Model.Url = txtUrl.Text.Trim();
            Model.Password = txtPassword.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

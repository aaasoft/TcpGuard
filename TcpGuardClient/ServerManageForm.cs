using Quick.Protocol.Tcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpGuard.Core.Protocol.V1.Commands;
using TcpGuard.Core.Protocol.V1.Model;
using TcpGuardClient.Model;

namespace TcpGuardClient
{
    public partial class ServerManageForm : Form
    {
        public ServerModel Model { get; set; }
        private QpTcpClient client;
        private Label label;

        public ServerManageForm()
        {
            InitializeComponent();
        }

        private void addPortalToListView(PortalModel model)
        {
            var lvi = new ListViewItem(model.RemoteHost);
            lvi.SubItems.Add(model.RemotePort.ToString());
            lvi.SubItems.Add(model.Port.ToString());
            lvi.Tag = model;
            lvPortals.Items.Add(lvi);
        }

        private async void ServerManageForm_Load(object sender, EventArgs e)
        {
            this.Text += $"[{Model.Host}:{Model.Port}]";
            client = new QpTcpClient(new QpTcpClientOptions()
            {
                Host = Model.Host,
                Port = Model.Port,
                EnableCompress = false,
                EnableEncrypt = false,
                Password = Model.Password
            });
            pnlMain.Visible = false;
            label = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Connecting..."
            };
            this.Controls.Add(label);

            try
            {
                await client.ConnectAsync();
                label.Visible = false;
                pnlMain.Visible = true;
            }
            catch (Exception ex)
            {
                label.Text = "Connected failed.Reason:" + ex.Message;
            }
            await refreshPortalList();
        }

        private async Task refreshPortalList()
        {
            try
            {
                label.Visible = true;
                pnlMain.Visible = false;
                label.Text = "Querying Portal list...";
                var rep = await client.SendCommand(new QueryPortalCommand());
                if (rep.Code != 0)
                    throw new ApplicationException(rep.Message);
                foreach (var portal in rep.Data)
                    addPortalToListView(portal);

                label.Visible = false;
                pnlMain.Visible = true;
            }
            catch (Exception ex)
            {
                label.Text = "Refresh portal list failed.Reason:" + ex.Message;
            }
        }

        private void lvPortals_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeletePortals.Enabled = lvPortals.SelectedItems.Count > 0;
        }

        private async void btnAddPortal_Click(object sender, EventArgs e)
        {
            var form = new AddPortalForm();
            var ret = form.ShowDialog();
            if (ret != DialogResult.OK)
                return;
            try
            {
                var rep = await client.SendCommand(AddPortalCommand.Create(form.Model));
                await refreshPortalList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add portal failed.Reason:" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeletePortals_Click(object sender, EventArgs e)
        {
            if (lvPortals.SelectedItems.Count <= 0)
                return;
            var lvi = lvPortals.SelectedItems[0];
            var model = (PortalModel)lvi.Tag;
            try
            {
                var rep = await client.SendCommand(DeletePortalCommand.Create(model));
                await refreshPortalList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete portal failed.Reason:" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

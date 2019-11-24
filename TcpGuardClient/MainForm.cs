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
using TcpGuard.Core;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardClient
{
    public partial class MainForm : Form
    {
        public Model.Config Config { get; private set; }
        private Model.ServerModel currentServer = null;
        private Label label = null;
        public MainForm()
        {
            InitializeComponent();
            label = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            this.Controls.Add(label);
            Config = Model.Config.Load();

            foreach (var server in Config.ServerList)
            {
                addServerToListView(server);
                server.Init();
            }
        }

        private void refreshServerListView()
        {
            lvServers.Items.Clear();
            foreach (var server in Config.ServerList)
            {
                addServerToListView(server);
            }
        }

        private void refreshPortalListView()
        {
            lvPortals.Items.Clear();
            foreach (var portal in currentServer.PortalList)
                addPortalToListView(portal);
        }

        private void showLoading(string text)
        {
            scMain.Visible = false;
            label.Text = text;
            label.Visible = true;
        }

        private void closeLoading()
        {
            label.Visible = false;
            scMain.Visible = true;
        }

        private void addPortalToListView(Model.PortalModel model)
        {
            var lvi = new ListViewItem(model.RemoteHost);
            lvi.SubItems.Add(model.RemotePort.ToString());
            lvi.SubItems.Add(model.Port.ToString());
            lvi.SubItems.Add(model.IsRuning.ToString());
            lvi.Tag = model;
            lvPortals.Items.Add(lvi);
        }

        private void addServerToListView(Model.ServerModel model)
        {
            var lvi = new ListViewItem(model.Host);
            lvi.SubItems.Add(model.Port.ToString());
            lvi.Tag = model;
            lvServers.Items.Add(lvi);
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            var form = new AddServerForm();
            var ret = form.ShowDialog();
            if (ret != DialogResult.OK)
                return;
            Config.ServerList.Add(form.Model);
            addServerToListView(form.Model);
            Config.Save();
        }

        private void btnEditServer_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedItems.Count <= 0)
                return;
            var lvi = lvServers.SelectedItems[0];
            var model = (Model.ServerModel)lvi.Tag;

            var form = new AddServerForm();
            form.Model = model;
            var ret = form.ShowDialog();
            if (ret != DialogResult.OK)
                return;
            model.Uninit();
            model.Init();
            refreshServerListView();
            Config.Save();
        }

        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedItems.Count <= 0)
                return;
            var lvi = lvServers.SelectedItems[0];
            var model = (Model.ServerModel)lvi.Tag;
            var ret = MessageBox.Show($"Are you really want to delete server[{model.Host}:{model.Port}]?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.Cancel)
                return;

            model.Uninit();

            lvServers.Items.Remove(lvi);
            Config.ServerList.Remove(model);
            Config.Save();
        }

        private void lvServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbPortals.Visible = btnEditServer.Enabled = btnTest.Enabled = btnDeleteServer.Enabled = lvServers.SelectedItems.Count > 0;
            if (lvServers.SelectedItems.Count <= 0)
                return;
            var lvi = lvServers.SelectedItems[0];
            currentServer = (Model.ServerModel)lvi.Tag;
            refreshPortalListView();
        }

        private void btnAddPortal_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new AddPortalForm();
                var ret = form.ShowDialog();
                if (ret != DialogResult.OK)
                    return;
                currentServer.AddPortal(form.Model);
                addPortalToListView(form.Model);
                Config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add portal error,reason:" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditPortal_Click(object sender, EventArgs e)
        {
            if (lvPortals.SelectedItems.Count <= 0)
                return;
            var lvi = lvPortals.SelectedItems[0];
            var model = (Model.PortalModel)lvi.Tag;

            var form = new AddPortalForm();
            form.Model = model;
            var ret = form.ShowDialog();
            if (ret != DialogResult.OK)
                return;
            currentServer.RemovePortal(model);
            currentServer.AddPortal(model);
            Config.Save();
            refreshPortalListView();
        }

        private void btnDeletePortals_Click(object sender, EventArgs e)
        {
            if (lvPortals.SelectedItems.Count <= 0)
                return;
            var lvi = lvPortals.SelectedItems[0];
            var model = (Model.PortalModel)lvi.Tag;
            var ret = MessageBox.Show($"Are you really want to delete Portal[{model.RemoteHost}:{model.RemotePort}]?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.Cancel)
                return;

            lvPortals.Items.Remove(lvi);
            currentServer.RemovePortal(model);
            Config.Save();
        }

        private void lvPortals_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditPortal.Enabled = btnDeletePortals.Enabled = lvPortals.SelectedItems.Count > 0;
        }

        private void lvServers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvServers.SelectedItems.Count <= 0)
                return;
            var lvi = lvServers.SelectedItems[0];
            var model = (Model.ServerModel)lvi.Tag;

            btnTest.PerformClick();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedItems.Count <= 0)
                return;
            var lvi = lvServers.SelectedItems[0];
            var model = (Model.ServerModel)lvi.Tag;

            showLoading($"Testing server[{model.Host}:{model.Port}]...");
            QpTcpClient client = new QpTcpClient(new QpTcpClientOptions()
            {
                Host = model.Host,
                Port = model.Port,
                Password = model.Password,
                EnableCompress = false,
                EnableEncrypt = false,
                InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
            });
            try
            {
                await client.ConnectAsync();
                var rep = await client.SendCommand(new GetVersionCommand());
                if (rep.Code != 0)
                    throw new ApplicationException("Get server verion error,reason:" + rep.Message);
                var serverVersion = rep.Data;
                var clientVersion = this.GetType().Assembly.GetName().Version;
                if (clientVersion != serverVersion)
                    throw new ApplicationException($"Client[{clientVersion}] and server[{serverVersion}] version not match.");
                client.Close();
                MessageBox.Show("Test success.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test failed.Reason:" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            closeLoading();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void niMain_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.Activate();
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

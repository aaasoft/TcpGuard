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
using TcpGuard.Core.Protocol.V1.Model;

namespace TcpGuardClient
{
    public partial class MainForm : Form
    {
        public Model.Config Config { get; private set; }
        private Dictionary<PortalModel, PortalGun> portalGunDict = new Dictionary<PortalModel, PortalGun>();
        
        public MainForm()
        {
            InitializeComponent();
            Config = Model.Config.Load();

            foreach (var portal in Config.PortalList)
                addPortalToListView(portal);
            foreach (var server in Config.ServerList)
                addServerToListView(server);
        }

        private void addPortalToListView(PortalModel model)
        {
            var lvi = new ListViewItem(model.RemoteHost);
            lvi.SubItems.Add(model.RemotePort.ToString());
            lvi.SubItems.Add(model.Port.ToString());
            lvi.Tag = model;
            lvPortals.Items.Add(lvi);

            var portalGun = new PortalGun(model);
            portalGun.Start();
            portalGunDict[model] = portalGun;
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

        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            if (lvServers.SelectedItems.Count <= 0)
                return;
            var lvi = lvServers.SelectedItems[0];
            var model = (Model.ServerModel)lvi.Tag;
            var ret = MessageBox.Show($"Are you really want to delete server[{model.Host}:{model.Port}]?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.Cancel)
                return;

            lvServers.Items.Remove(lvi);
            Config.ServerList.Remove(model);
            Config.Save();
        }

        private void lvServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteServer.Enabled = lvServers.SelectedItems.Count > 0;
        }

        private void btnAddPortal_Click(object sender, EventArgs e)
        {
            var form = new AddPortalForm();
            var ret = form.ShowDialog();
            if (ret != DialogResult.OK)
                return;
            Config.PortalList.Add(form.Model);
            addPortalToListView(form.Model);
            Config.Save();
        }

        private void btnDeletePortals_Click(object sender, EventArgs e)
        {
            if (lvPortals.SelectedItems.Count <= 0)
                return;
            var lvi = lvPortals.SelectedItems[0];
            var model = (PortalModel)lvi.Tag;
            var ret = MessageBox.Show($"Are you really want to delete Portal[{model.RemoteHost}:{model.RemotePort}]?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.Cancel)
                return;

            lvPortals.Items.Remove(lvi);
            Config.PortalList.Remove(model);
            Config.Save();

            var portalGun = portalGunDict[model];
            portalGun.Stop();
            portalGunDict.Remove(model);
        }

        private void lvPortals_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeletePortals.Enabled = lvPortals.SelectedItems.Count > 0;
        }

        private void lvServers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvServers.SelectedItems.Count <= 0)
                return;
            var lvi = lvServers.SelectedItems[0];
            var model = (Model.ServerModel)lvi.Tag;

            var form = new ServerManageForm();
            form.Model = model;
            form.Show();
        }
    }
}

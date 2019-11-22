using Quick.Protocol.Commands;
using Quick.Protocol.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TcpGuard.Core;
using TcpGuard.Core.Protocol.V1.Commands;
using TcpGuard.Core.Protocol.V1.Model;

namespace TcpGuardServer
{
    public class QpManager
    {
        private QpTcpServer server;
        private CommandExecuterManager commandExecuterManager;
        public Config Config { get; private set; }
        public Dictionary<PortalModel, PortalGun> portalGunDict = new Dictionary<PortalModel, PortalGun>();

        public void AddPortal(PortalModel portalModel)
        {
            if (Config.PortalList.Any(t => t.Port == portalModel.Port))
                throw new ApplicationException($"Port [{portalModel}] is used.");
            Config.PortalList.Add(portalModel);
            Config.Save();
            var portalGun = new PortalGun(portalModel);
            portalGun.Start();
            portalGunDict[portalModel] = portalGun;
        }

        public void DeletePortal(PortalModel portalModel)
        {
            if (!Config.PortalList.Any(t => t.Port == portalModel.Port))
                throw new ApplicationException($"Portal use port [{portalModel}] not found.");

            portalModel = Config.PortalList.FirstOrDefault(t => t.Port == portalModel.Port);
            Config.PortalList.Remove(portalModel);
            Config.Save();
            var portalGun = portalGunDict[portalModel];
            portalGunDict.Remove(portalModel);
            portalGun.Stop();
        }

        public PortalModel[] QueryPortal() => Config.PortalList.ToArray();

        public QpManager(int port, string password)
        {
            server = new QpTcpServer(new QpTcpServerOptions()
            {
                Address = IPAddress.Any,
                Port = port,
                Password = password,
                InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
            });
            Config = Config.Load();
            commandExecuterManager = new CommandExecuterManager();
            commandExecuterManager.Add<AddPortalCommand>(new CommandExecuters.AddPortal(this));
            commandExecuterManager.Add<DeletePortalCommand>(new CommandExecuters.DeletePortal(this));
            commandExecuterManager.Add<QueryPortalCommand>(new CommandExecuters.QueryPortal(this));
        }

        public void Start()
        {
            server.ChannelConnected += Server_ChannelConnected;
            server.Start();

            foreach (var portalModel in Config.PortalList)
            {
                var portalGun = new PortalGun(portalModel);
                portalGunDict[portalModel] = portalGun;
                portalGun.Start();
            }
        }

        private void Server_ChannelConnected(object sender, Quick.Protocol.Core.QpServerChannel e)
        {
            e.CommandExecuter = commandExecuterManager;
        }

        public void Stop()
        {
            foreach (var portalGun in portalGunDict.Values)
                portalGun.Stop();
            portalGunDict.Clear();
            server.Stop();
        }
    }
}

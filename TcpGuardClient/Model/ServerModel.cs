using System;
using System.Collections.Generic;
using System.Text;

namespace TcpGuardClient.Model
{
    public class ServerModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }

        public List<PortalModel> PortalList { get; set; } = new List<PortalModel>();

        private Dictionary<PortalModel, PortalGun> portalGunDict = new Dictionary<PortalModel, PortalGun>();

        public void AddPortal(PortalModel portalModel)
        {
            var portalGun = new PortalGun(this, portalModel);
            portalGun.Start();
            portalGunDict[portalModel] = portalGun;
            PortalList.Add(portalModel);
        }

        public void RemovePortal(PortalModel portalModel)
        {
            if (!portalGunDict.ContainsKey(portalModel))
                return;
            var portalGun = portalGunDict[portalModel];
            portalGun.Stop();
            portalGunDict.Remove(portalModel);
            PortalList.Remove(portalModel);
        }

        public void Init()
        {
            foreach (var portalModel in PortalList)
            {
                var portalGun = new PortalGun(this, portalModel);
                portalGun.Start();
                portalGunDict[portalModel] = portalGun;
            }
        }
    }
}

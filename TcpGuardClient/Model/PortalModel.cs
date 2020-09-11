using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TcpGuardClient.Model
{
    public class PortalModel
    {
        /// <summary>
        /// Portal listen IP Address
        /// </summary>
        public string LocalIpAddress { get; set; } = "127.0.0.1";
        /// <summary>
        /// Portal listen port
        /// </summary>
        public int LocalPort { get; set; }

        /// <summary>
        /// Remote host
        /// </summary>
        public string RemoteHost { get; set; }
        /// <summary>
        /// Remote port
        /// </summary>
        public int RemotePort { get; set; }
        /// <summary>
        /// Package send interval
        /// </summary>
        public int SendInterval { get; set; }

        [JsonIgnore]
        public bool IsRuning { get; set; }

        public override bool Equals(object obj)
        {
            var b = (PortalModel)obj;
            if (b == null)
                return false;
            return LocalIpAddress == b.LocalIpAddress && LocalPort == b.LocalPort;
        }

        public override int GetHashCode()
        {
            return (LocalIpAddress + LocalPort).GetHashCode();
        }
    }
}

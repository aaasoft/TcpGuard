using System;
using System.Collections.Generic;
using System.Text;

namespace TcpGuardClient.Model
{
    public class PortalModel
    {
        /// <summary>
        /// Portal listen port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Remote host
        /// </summary>
        public string RemoteHost { get; set; }
        /// <summary>
        /// Remote port
        /// </summary>
        public int RemotePort { get; set; }

        public override bool Equals(object obj)
        {
            var b = (PortalModel)obj;
            if (b == null)
                return false;
            return Port == b.Port;
        }

        public override int GetHashCode()
        {
            return Port.GetHashCode();
        }
    }
}

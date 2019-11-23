﻿using ProtoBuf;
using Quick.Protocol.Packages;
using System;
using System.Collections.Generic;
using System.Text;

namespace TcpGuard.Core.Protocol.V1.Pkgs
{
    [ProtoContract]
    public class TcpPackage : AbstractPackage
    {
        public override byte PackageType => 11;

        [ProtoMember(1)]
        public byte[] Buffer { get; set; }
    }
}

﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TcpGuard.Core.Protocol.V1.Model;

namespace TcpGuardClient.Model
{
    public class Config
    {

        private static string configFilePath = typeof(Config).FullName + ".json";

        public List<PortalModel> PortalList { get; set; } = new List<PortalModel>();
        public List<ServerModel> ServerList { get; set; } = new List<ServerModel>();

        public void Save()
        {
            File.WriteAllText(configFilePath, JsonConvert.SerializeObject(this));
        }

        public static Config Load()
        {
            if (!File.Exists(configFilePath))
                return new Config();
            var content = File.ReadAllText(configFilePath);
            return JsonConvert.DeserializeObject<Config>(content);
        }
    }
}

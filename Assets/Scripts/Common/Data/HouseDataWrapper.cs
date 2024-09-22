using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UI.Screens.MainScreen;

namespace Common.Data
{
    [Serializable]
    public class HouseDataWrapper
    {
        public int Id { get; set; }
        public float Score { get; set; }
        public Features Features { get; set; }

        [JsonProperty("Investors")]
        public List<Investors> Investors { get; set; }
    }
}
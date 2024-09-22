using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.Data
{
    [Serializable]
    public class Projects
    {
        [JsonProperty("Projects")]
        public List<HouseDataWrapper> HouseDataWrapper { get; set; }
    }
}
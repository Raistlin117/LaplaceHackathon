using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.Data
{
    [Serializable]
    public class Features
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonProperty("BuildingType")]
        public string BuildingType { get; set; }

        [JsonProperty("Photos")]
        public List<int> Photos { get; set; }

        public float Area { get; set; }
        public int Rooms { get; set; }
        public int Floor { get; set; }
        public int MaxFloor { get; set; }

        [JsonProperty("CeilingHeight")]
        public float CeilingHeight { get; set; }

        public int Price { get; set; }
        public int Invested { get; set; }
    }
}
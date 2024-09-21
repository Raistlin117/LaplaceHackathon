using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Screens.MainScreen
{
    [Serializable]
    public class HouseData
    {
        public Sprite HouseImage;
        public string DeveloperText;
        public string HouseInfo;
        public int InvestedLeftAmount;
        public int RoomsCount;
        public int Floor;
        public int HouseFloorness;
        public int HouseOverallPrice;
        public int Id;
        public string BuildingType;
        public int Area;
        public float CellingHight;
        public Investors[] Investors;
    }
}
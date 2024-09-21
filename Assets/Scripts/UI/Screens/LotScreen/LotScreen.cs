using System.Collections.Generic;
using UnityEngine;

namespace Common.Screens
{
    public class LotScreen : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _investorPictures;
        [SerializeField] private List<string> _investorNames;

        public struct HouseParams
        {
            public string propertyClass;
            public string parking;
            public string houseType;
            public int complexArea;
            public int numberOfBuildings;
        }

        public void Setup(LotScreenData lotScreenData)
        {
            _investorPictures = lotScreenData.InvestorPictures;
            _investorNames = lotScreenData.InvestorNames;
            
        }
    }
}
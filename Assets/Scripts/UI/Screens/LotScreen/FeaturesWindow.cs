using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Screens
{
    public class FeaturesWindow : MonoBehaviour
    {
        [SerializeField] private string _propertyClass;
        [SerializeField] private string _parking;
        [SerializeField] private string _houseType;
        [SerializeField] private int _complexArea;
        [SerializeField] private int _numberOfBuildings;
        
        private GameObject[] _children;
        
        public struct HouseParams // TODO
        {
            public string propertyClass;
            public string parking;
            public string houseType;
            public int complexArea;
            public int numberOfBuildings;
        }
        
        public void Setup(HouseParams houseParams)
        {
            _propertyClass = houseParams.propertyClass;
            _parking = houseParams.parking;
            _houseType = houseParams.houseType;
            _complexArea = houseParams.complexArea;
            _numberOfBuildings = houseParams.numberOfBuildings;
            
            FeatureUnitsSetter();
        }
        
        
        
        private void FeatureUnitsSetter()
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = _propertyClass;
            }
        }
    }
}
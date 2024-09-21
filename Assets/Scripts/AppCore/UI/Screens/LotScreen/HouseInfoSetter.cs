using System.Globalization;
using TMPro;
using UI.Screens.MainScreen;
using UnityEngine;

namespace AppCore.UI.Screens.LotScreen
{
    public class HouseInfoSetter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _developerName;
        [SerializeField] private TextMeshProUGUI _buildingType;
        [SerializeField] private TextMeshProUGUI _rooms;
        [SerializeField] private TextMeshProUGUI _area;
        [SerializeField] private TextMeshProUGUI _floor;
        [SerializeField] private TextMeshProUGUI _cellingHight;

        public void Setup(HouseData houseWindowData)
        {
            _developerName.text = houseWindowData.DeveloperText;
            _buildingType.text = houseWindowData.BuildingType;
            _rooms.text = houseWindowData.RoomsCount.ToString();
            _area.text = houseWindowData.Area.ToString();
            _floor.text = houseWindowData.Floor.ToString();
            _cellingHight.text = houseWindowData.CellingHight.ToString("F1");
        }
    }
}
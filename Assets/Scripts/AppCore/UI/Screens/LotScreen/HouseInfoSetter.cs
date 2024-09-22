using Common.Data;
using TMPro;
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

        public void Setup(Projects houseWindowData, int id)
        {
            var features = houseWindowData.HouseDataWrapper[id].Features;
            _developerName.text = features.Title;
            _buildingType.text = $"Building Type: {features.BuildingType}";
            _rooms.text = $"Room(s): {features.Rooms}";
            _area.text = $"Area: {features.Area} sq. m";
            _floor.text = $"{features.Floor} floor of {features.MaxFloor}";
            _cellingHight.text = $"Ceiling Height: {features.CeilingHeight:F1} m";
        }
    }
}
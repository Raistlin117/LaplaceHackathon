using AppSignals;
using deVoid.Utils;
using TMPro;
using UI.Screens.MainScreen;
using UnityEngine;
using UnityEngine.UI;

namespace AppCore.UI.Screens.MainScreen
{
    public class HouseWindow : MonoBehaviour
    {
        [SerializeField] private Image _houseImage;
        [SerializeField] private TextMeshProUGUI _developerText;
        [SerializeField] private TextMeshProUGUI _roomInfo;
        [SerializeField] private TextMeshProUGUI _floorInfo;
        [SerializeField] private TextMeshProUGUI _investedLeftAmountText;
        [SerializeField] private Slider _slider;

        private int _id;

        public void Setup(HouseData houseWindowData)
        {
            _id = houseWindowData.Id;
            _houseImage.sprite = houseWindowData.HouseImage;
            _developerText.text = houseWindowData.DeveloperText;
            _roomInfo.text = $"{houseWindowData.RoomsCount} rooms";
            _floorInfo.text = $"{houseWindowData.Floor} floor of {houseWindowData.HouseFloorness}";
            _investedLeftAmountText.text = houseWindowData.InvestedLeftAmount.ToString();
            _slider.value = (float) houseWindowData.InvestedLeftAmount / houseWindowData.HouseOverallPrice;
        }

        public void OnClick()
        {
            Signals.Get<OpenScreenSignal>().Dispatch(ScreenType.Lot, _id);
        }
    }
}
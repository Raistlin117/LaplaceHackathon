using AppSignals;
using Common.Data;
using Configs;
using deVoid.Utils;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI _investedPercent;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Slider _slider;

        private int _id;

        public void Setup(Projects houseData, PhotoConfigs photoConfigs, int id)
        {
            _id = houseData.HouseDataWrapper[id].Id;
            var features = houseData.HouseDataWrapper[id].Features;
            _houseImage.sprite = photoConfigs.PhotoList[id];
            _developerText.text = features.Title;
            _roomInfo.text = $"{features.Rooms} rooms";
            _floorInfo.text = $"{features.Floor} floor of {features.MaxFloor}";
            _investedLeftAmountText.text = $"~${(features.Price - features.Invested)}";
            _slider.value = (float) features.Invested / features.Price;
            var percent = (float)features.Invested / features.Price;
            _investedPercent.text = $"{(int)(percent * 100)}%";
            _score.text = houseData.HouseDataWrapper[id].Score.ToString("F1");
        }

        public void OnClick()
        {
            Signals.Get<OpenScreenSignal>().Dispatch(ScreenType.Lot, _id);
        }
    }
}
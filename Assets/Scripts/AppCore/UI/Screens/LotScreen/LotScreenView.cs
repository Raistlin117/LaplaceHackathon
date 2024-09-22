using AppSaveAndLoad;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace AppCore.UI.Screens.LotScreen
{
    public class LotScreenView : MonoBehaviour
    {
        [SerializeField] private HouseInfoSetter _houseInfoSetter;
        [SerializeField] private InvestorsListSetter _investorsListSetter;
        [SerializeField] private Image _photo;
        [SerializeField] private TextMeshProUGUI _percent;

        private SaveAndLoad _saveAndLoad;
        private PhotoConfigs _photoConfigs;

        [Inject]
        public void Construct(SaveAndLoad saveAndLoad, PhotoConfigs photoConfigs)
        {
            _saveAndLoad = saveAndLoad;
            _photoConfigs = photoConfigs;
        }

        private int _id;
        public void Setup(int id)
        {
            _id = id;

            var houseData = _saveAndLoad.LoadHouseData();
            _houseInfoSetter.Setup(houseData, _id);
            _investorsListSetter.Setup(houseData, _id);
            _photo.sprite = _photoConfigs.PhotoList[houseData.HouseDataWrapper[id].Features.Photos[0]];
            _percent.text =
                $"{(houseData.HouseDataWrapper[id].Features.Invested / houseData.HouseDataWrapper[id].Features.Price) * 100}%";
        }
    }
}
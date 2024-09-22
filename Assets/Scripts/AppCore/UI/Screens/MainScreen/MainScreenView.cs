using AppCore.UI.Screens.MainScreen;
using AppSaveAndLoad;
using Configs;
using UnityEngine;
using VContainer;

namespace UI.Screens.MainScreen
{
    public class MainScreenView : MonoBehaviour
    {
        [SerializeField] private HouseWindow[] _houseWindows;

        private SaveAndLoad _saveAndLoad;
        private PhotoConfigs _photoConfigs;

        [Inject]
        public void Construct(SaveAndLoad saveAndLoad, PhotoConfigs photoConfigs)
        {
            _saveAndLoad = saveAndLoad;
            _photoConfigs = photoConfigs;

            SetHouseScrollData();
        }

        private void SetHouseScrollData()
        {
            var houseData = _saveAndLoad.LoadHouseData();

            for (var i = 0; i < _houseWindows.Length; i++)
            {
                var window = _houseWindows[i];
                window.Setup(houseData, _photoConfigs, i);
            }
        }
    }
}
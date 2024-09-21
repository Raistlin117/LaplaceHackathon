using AppSaveAndLoad;
using UnityEngine;
using VContainer;

namespace UI.Screens.MainScreen
{
    public class MainScreenView : MonoBehaviour
    {
        private SaveAndLoad _saveAndLoad;

        [Inject]
        public void Construct(SaveAndLoad saveAndLoad)
        {
            _saveAndLoad = saveAndLoad;

            SetHouseScrollData();
        }

        private void SetHouseScrollData()
        {
            // var houseData = _saveAndLoad.LoadHouseData();
        }
    }
}
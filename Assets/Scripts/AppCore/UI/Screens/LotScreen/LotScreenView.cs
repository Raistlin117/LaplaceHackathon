using AppSaveAndLoad;
using UnityEngine;
using VContainer;

namespace AppCore.UI.Screens.LotScreen
{
    public class LotScreenView : MonoBehaviour
    {
        [SerializeField] private HouseInfoSetter _houseInfoSetter;
        [SerializeField] private InvestorsListSetter _investorsListSetter;

        private SaveAndLoad _saveAndLoad;

        [Inject]
        public void Construct(SaveAndLoad saveAndLoad)
        {
            _saveAndLoad = saveAndLoad;
        }

        private int _id;
        public void SetId(int id)
        {
            _id = id;

            var houseData = _saveAndLoad.LoadHouseData();
            _houseInfoSetter.Setup(houseData);
            _investorsListSetter.Setup(houseData.Investors, houseData);
        }
    }
}
using UI.Screens.MainScreen;
using UnityEngine;
using UnityEngine.UI;

namespace AppCore.UI.Screens.LotScreen
{
    public class InvestorsListSetter : MonoBehaviour
    {
        [SerializeField] private InvestorItem[] _investorItem;
        [SerializeField] private Slider _slider;

        public void Setup(Investors[] investorsData, HouseData houseData)
        {
            for (var i = 0; i < _investorItem.Length; i++)
            {
                if (investorsData.Length == i)
                {
                    _investorItem[i].gameObject.SetActive(false);
                    continue;
                }
                _investorItem[i].gameObject.SetActive(true);
                _investorItem[i].Setup(investorsData[i].amount);
            }

            _slider.value = (float) houseData.InvestedLeftAmount / houseData.HouseOverallPrice;
        }
    }
}
using Common.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AppCore.UI.Screens.LotScreen
{
    public class InvestorsListSetter : MonoBehaviour
    {
        [SerializeField] private InvestorItem[] _investorItem;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _potencial;

        public void Setup(Projects houseData, int id)
        {
            for (var i = 0; i < _investorItem.Length; i++)
            {
                _investorItem[i].Setup(houseData.HouseDataWrapper[id].Investors[i].Amount);
            }

            var features = houseData.HouseDataWrapper[id].Features;
            _slider.value = (float) features.Invested / features.Price;

            _potencial.text = $"up to ${features.Price - features.Invested}";
        }
    }
}
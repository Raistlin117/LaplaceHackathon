using TMPro;
using UnityEngine;

namespace AppCore.UI.Screens.LotScreen
{
    internal class InvestorItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyCount;

        public void Setup(int count)
        {
            _moneyCount.text = $"+${count}";
        }
    }
}
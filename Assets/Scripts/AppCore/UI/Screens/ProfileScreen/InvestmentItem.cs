using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.ProfileScreen
{
    public class InvestmentItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _developerName;
        [SerializeField] private TextMeshProUGUI _moneyCount;

        public void Setup(Sprite sprite, string developerName, int moneyCount)
        {
            _image.sprite = sprite;
            _developerName.text = developerName;
            _moneyCount.text = _moneyCount.ToString();
        }
    }
}
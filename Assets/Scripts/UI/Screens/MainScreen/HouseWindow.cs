using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.MainScreen
{
    public class HouseWindow : MonoBehaviour
    {
        [SerializeField] private Image _houseImage;
        [SerializeField] private TextMeshProUGUI _developerText;
        [SerializeField] private TextMeshProUGUI _houseInfo;
        [SerializeField] private TextMeshProUGUI _investedAmountText;
        [SerializeField] private Sprite _slider;

        private int _id;

        public void Setup(HouseWindowData houseWindowData)
        {
            _houseImage.sprite = houseWindowData.HouseImage;
            _developerText.text = houseWindowData.DeveloperText;
            _houseInfo.text = houseWindowData.HouseInfo;
            _investedAmountText.text = houseWindowData.InvestedAmountText;
        }
    }
}
using AppSaveAndLoad;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.IntroScreen
{
    public class IntroSlider : MonoBehaviour
    {
        [SerializeField] private Slider priceSlider;
        [SerializeField] private TextMeshProUGUI priceText;

        private SaveAndLoad _saveAndLoad;
        private UsersDataStruct _usersDataStruct;
        private int _preferredPrice;

        public void Setup(SaveAndLoad saveAndLoad)
        {
            _saveAndLoad = saveAndLoad;
        }

        void Start()
        {
            priceText.text = priceSlider.value.ToString();

            priceSlider.onValueChanged.AddListener(UpdatePriceText);
        }

        void UpdatePriceText(float value)
        {
            float priceValue = Mathf.Lerp(5000, 30000, value);
            priceValue = Mathf.Round(priceValue / 500f) * 500f;

            priceText.text = priceValue.ToString("F0");
            _preferredPrice = (int) priceValue;
        }

        public void OnConfirmClicked()
        {
            _usersDataStruct = _saveAndLoad.LoadUserData();

            _usersDataStruct.PreferredPrice = _preferredPrice;

            _saveAndLoad.SaveUserData(_usersDataStruct);
        }
    }
}
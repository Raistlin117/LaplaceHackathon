using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AppCore.UI.Screens.MainScreen
{
    public class BottomBar : MonoBehaviour
    {
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _unselectedColor;
        [SerializeField] private TextMeshProUGUI _invest;
        [SerializeField] private TextMeshProUGUI _profile;
        [SerializeField] private Image _profileIcon;
        [SerializeField] private Image _investIcon;
        [SerializeField] private GameObject _mainScreen;
        [SerializeField] private GameObject _profileScreen;
        [SerializeField] private GameObject _lotScreen;

        public void OnInvestClick()
        {
            _invest.color = _selectedColor;
            _profile.color = _unselectedColor;
            _profileIcon.color = _unselectedColor;
            _investIcon.color = _selectedColor;
            _mainScreen.SetActive(true);
            _profileScreen.SetActive(false);
            _lotScreen.SetActive(false);
        }

        public void OnProfileClick()
        {
            _invest.color = _unselectedColor;
            _profile.color = _selectedColor;
            _profileIcon.color = _selectedColor;
            _investIcon.color = _unselectedColor;
            _mainScreen.SetActive(false);
            _profileScreen.SetActive(true);
            _lotScreen.SetActive(false);
        }
    }
}
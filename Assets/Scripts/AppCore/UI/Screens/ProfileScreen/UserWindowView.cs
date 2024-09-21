using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.ProfileScreen
{
    public class UserWindowView : MonoBehaviour
    {
        [SerializeField] private Image _userImage;
        [SerializeField] private TextMeshProUGUI _userName;
        [SerializeField] private TextMeshProUGUI _userInfo;

        public void Setup(Sprite userSprite, string userName, string userInfo)
        {
            _userImage.sprite = userSprite;
            _userName.text = userName;
            _userInfo.text = userInfo;
        }
    }
}
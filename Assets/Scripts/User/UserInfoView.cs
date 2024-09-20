using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace User
{
    public class UserInfoView : MonoBehaviour
    {
        [SerializeField] private Image _userImage;
        [SerializeField] private TextMeshProUGUI _userName;

        public void Setup(Sprite sprite, string userName)
        {
            _userImage.sprite = sprite;
            _userName.text = userName;
        }
    }
}
using Configs;
using UnityEngine;
using VContainer;

namespace Common.Screens
{
    public class IntroScreen : MonoBehaviour
    {
        private UserData _userData;

        [Inject]
        public void Construct(UserData userData)
        {
            _userData = userData;

            Debug.Log(_userData.GetUserById(0).Name);
            Debug.Log(_userData.GetUserById(1).Name);
        }
    }
}
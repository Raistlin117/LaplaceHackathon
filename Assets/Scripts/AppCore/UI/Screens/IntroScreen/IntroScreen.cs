using AppSaveAndLoad;
using Configs;
using UI.Screens.IntroScreen;
using UnityEngine;
using VContainer;

namespace Common.Screens
{
    public class IntroScreen : MonoBehaviour
    {
        [SerializeField] private IntroSlider _introSlider;

        private UserDataConfigs _userDataConfigs;
        private SaveAndLoad _saveAndLoad;

        [Inject]
        public void Construct(UserDataConfigs userDataConfigs, SaveAndLoad saveAndLoad)
        {
            _userDataConfigs = userDataConfigs;
            _saveAndLoad = saveAndLoad;

            _introSlider.Setup(saveAndLoad);
        }
    }
}
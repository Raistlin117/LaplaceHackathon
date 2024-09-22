using System;
using AppCore.UI.Screens.LotScreen;
using AppSignals;
using deVoid.Utils;
using UI.Screens.MainScreen;
using UI.Screens.ProfileScreen;
using UnityEngine;

namespace AppCore.UI.Screens
{
    public class ScreensController : MonoBehaviour
    {
        [SerializeField] private MainScreenView _mainScreenView;
        [SerializeField] private ProfileScreenView _profileScreenView;
        [SerializeField] private LotScreenView _lotScreen;

        private void Awake()
        {
            Signals.Get<OpenScreenSignal>().AddListener(OnOpenScreen);
        }

        private void OnOpenScreen(ScreenType screenType, int id)
        {
            OpenScreen(screenType, id);
        }

        public void OpenScreen(ScreenType screenType, int id)
        {
            switch (screenType)
            {
                case ScreenType.Main:
                    _mainScreenView.gameObject.SetActive(true);
                    _profileScreenView.gameObject.SetActive(false);
                    _lotScreen.gameObject.SetActive(false);
                    break;
                case ScreenType.Profile:
                    _mainScreenView.gameObject.SetActive(false);
                    _profileScreenView.gameObject.SetActive(true);
                    _lotScreen.gameObject.SetActive(false);
                    break;
                case ScreenType.Lot:
                    _mainScreenView.gameObject.SetActive(false);
                    _profileScreenView.gameObject.SetActive(false);
                    _lotScreen.gameObject.SetActive(true);
                    _lotScreen.Setup(id);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(screenType), screenType, null);
            }
        }
    }
}
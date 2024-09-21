using AppSaveAndLoad;
using UnityEngine;
using VContainer;

namespace UI.Screens.ProfileScreen
{
    public class ProfileScreen : MonoBehaviour
    {
        private SaveAndLoad _saveAndLoad;

        [Inject]
        public void Construct(SaveAndLoad saveAndLoad)
        {
            _saveAndLoad = saveAndLoad;
        }
    }
}
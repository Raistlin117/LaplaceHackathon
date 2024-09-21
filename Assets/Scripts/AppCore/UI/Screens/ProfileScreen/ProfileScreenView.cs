using AppSaveAndLoad;
using Configs;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI.Screens.ProfileScreen
{
    public class ProfileScreenView : MonoBehaviour
    {
        [SerializeField] private UserWindowView _userWindowView;
        [SerializeField] private TextMeshProUGUI _investedCount;
        [SerializeField] private TextMeshProUGUI _readyForInvestment;
        [SerializeField] private UserInvestmentsList _userInvestmentsList;

        private SaveAndLoad _saveAndLoad;

        [Inject]
        public void Construct(SaveAndLoad saveAndLoad)
        {
            _saveAndLoad = saveAndLoad;
        }

        public void Setup(int investedCount, int readyForInvest, Sprite userSprite, string userName, string userInfo)
        {
            UsersDataStruct userData = _saveAndLoad.LoadUserData();

            _userWindowView.Setup(userSprite, userName, userInfo);
            _investedCount.text = investedCount.ToString();
            _readyForInvestment.text = readyForInvest.ToString();

            SetupMyInvestmentData();
        }

        private void SetupMyInvestmentData()
        {
            MyInvestmentsData[] myInvestmentsDatas = new MyInvestmentsData[2];

            _userInvestmentsList.Setup(myInvestmentsDatas);
        }
    }
}
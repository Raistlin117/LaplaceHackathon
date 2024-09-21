using UnityEngine;

namespace UI.Screens.ProfileScreen
{
    public class UserInvestmentsList : MonoBehaviour
    {
        [SerializeField] private InvestmentItem[] _investmentItems;

        public void Setup(MyInvestmentsData[] myInvestmentsData)
        {
            for (int i = 0; i < _investmentItems.Length; i++)
            {
                if (myInvestmentsData.Length == i)
                {
                    _investmentItems[i].gameObject.SetActive(false);
                    continue;
                }

                _investmentItems[i].gameObject.SetActive(true);
                var investmentItem = _investmentItems[i];
                var sprite = myInvestmentsData[i].BuildingSprite;
                var userName = myInvestmentsData[i].Name;
                var investedCount = myInvestmentsData[i].InvestedCount;

                investmentItem.Setup(sprite, userName, investedCount);
            }
        }
    }
}
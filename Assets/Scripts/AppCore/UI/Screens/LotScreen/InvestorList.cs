using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Screens
{
    public partial class InvestorList : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _investorPictures;
        [SerializeField] private List<string> _investorNames;
        
        
        
        
        
        public void Setup(LotScreenData lotScreenData)
        {
            _investorPictures = lotScreenData.InvestorPictures;
            _investorNames = lotScreenData.InvestorNames;
            
            InvestorListSetter();
        }
    
    private void InvestorListSetter()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = _investorPictures[i];
            gameObject.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = _investorNames[i];
        }
    }
}
}
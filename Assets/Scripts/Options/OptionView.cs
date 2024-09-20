using AppSignals;
using deVoid.Utils;
using UnityEngine;

namespace Common
{
    public class OptionView : MonoBehaviour
    {
        [SerializeField] private OptionType _optionType;
        [SerializeField] private GameObject _labelImage;

        private void Start()
        {
            Signals.Get<OptionSelectedSignal>().AddListener(OnSelected);
        }

        private void OnDestroy()
        {
            Signals.Get<OptionSelectedSignal>().RemoveListener(OnSelected);
        }

        public void Selected()
        {
            Signals.Get<OptionSelectedSignal>().Dispatch(_optionType);

            _labelImage.SetActive(true);
        }

        private void OnSelected(OptionType optionType)
        {
            _labelImage.SetActive(optionType == _optionType);
        }
    }
}
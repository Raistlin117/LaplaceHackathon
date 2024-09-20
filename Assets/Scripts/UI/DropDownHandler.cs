using System.Linq;
using UnityEngine;

namespace Common
{
    public class DropDownHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _optionsWindow;
        [SerializeField] private OptionView[] _options;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PhotoConfigs", menuName = "Configs/PhotoConfigs", order = 1)]
    public class PhotoConfigs : ScriptableObject
    {
        [SerializeField] private List<Sprite> _photoList;

        public List<Sprite> PhotoList => _photoList;
    }
}
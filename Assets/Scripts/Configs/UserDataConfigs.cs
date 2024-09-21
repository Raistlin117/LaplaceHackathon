using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "UserData", menuName = "Configs/UserData", order = 0)]
    public class UserDataConfigs : ScriptableObject
    {
        [SerializeField] private List<UsersDataStruct> _usersList;

        public UsersDataStruct GetUserById(int userId)
        {
            return _usersList.FirstOrDefault(x => x.Id == userId);
        }
    }
}
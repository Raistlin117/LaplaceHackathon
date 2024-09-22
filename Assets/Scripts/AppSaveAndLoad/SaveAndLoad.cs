using System.IO;
using AppSignals;
using Common;
using Common.Data;
using Configs;
using deVoid.Utils;
using Newtonsoft.Json;
using UnityEngine;

namespace AppSaveAndLoad
{
    public class SaveAndLoad
    {
        public void SaveUserData(UsersDataStruct usersDataStruct)
        {
            string json = JsonConvert.SerializeObject(usersDataStruct, Formatting.Indented);

            SaveJsonToFile(json, Constants.UserDataFileName);

            Signals.Get<UserDataUpdatedSignal>().Dispatch();
        }

        public Projects LoadHouseData()
        {
            string json = ReadJsonFromFile(Constants.HouseDataFileName);

            Projects projects = JsonConvert.DeserializeObject<Projects>(json);

            return projects;
        }

        public UsersDataStruct LoadUserData()
        {
            string json = ReadJsonFromFile(Constants.UserDataFileName);

            if (string.IsNullOrEmpty(json))
            {
                UsersDataStruct newUserData = new UsersDataStruct();

                newUserData.Name = "User";
                newUserData.Id = 0;
                newUserData.Age = 24;

                SaveUserData(newUserData);

                json = ReadJsonFromFile(Constants.AppDataFileName);
            }

            UsersDataStruct userData = JsonConvert.DeserializeObject<UsersDataStruct>(json);

            return userData;
        }


        private void SaveJsonToFile(string json, string jsonFileName)
        {
            if (string.IsNullOrEmpty(json))
            {
                Debug.LogError("Json is null or empty !");
                return;
            }

            string path = Path.Combine(Application.dataPath, "JsonData", jsonFileName + ".json");

            if (!File.Exists(path)) File.Create(path);

            try
            {
                File.WriteAllText(path, json);
                Debug.Log("JSON файл успешно сохранен в " + path);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Ошибка при сохранении JSON файла: " + e.Message);
            }
        }
        private string ReadJsonFromFile(string jsonFileName)
        {
            string path = Path.Combine(Application.dataPath, "JsonData", jsonFileName + ".json");

            if (File.Exists(path))
            {
                try
                {
                    return File.ReadAllText(path);
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Ошибка при чтении JSON файла: " + e.Message);
                    return null;
                }
            }

            Debug.LogError("Файл не найден: " + path);
            return null;
        }
    }
}
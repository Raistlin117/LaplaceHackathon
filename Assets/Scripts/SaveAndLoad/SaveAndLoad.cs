using System.IO;
using AppSignals;
using Common;
using Common.Data;
using deVoid.Utils;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveAndLoad
{
    public class SaveAndLoad
    {
        public void SaveAppData(AppData appData)
        {
            string json = JsonConvert.SerializeObject(appData, Formatting.Indented);

            SaveJsonToFile(json, Constants.AppDataFileName);

            Signals.Get<AppDataUpdatedSignal>().Dispatch();
        }

        public AppData LoadAppData()
        {
            string json = ReadJsonFromFile(Constants.AppDataFileName);

            if (string.IsNullOrEmpty(json))
            {
                AppData newAppData = new AppData();

                SaveAppData(newAppData);

                json = ReadJsonFromFile(Constants.AppDataFileName);
            }

            AppData appData = JsonConvert.DeserializeObject<AppData>(json);

            return appData;
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
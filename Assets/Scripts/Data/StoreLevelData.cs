using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

namespace Data
{
    public class StoreLevelData : MonoBehaviour
    {
        public LevelData levelData;

        public LevelData levelDataDefault;

        private void Awake()
        {
            Deseralize();
        }

        public void SaveData()
        {
            //DO no update Level Count
            var jsonString = JsonConvert.SerializeObject(levelData);
            //Debug.Log(jsonString);
            PlayerPrefs.SetString("Save Data", jsonString);
        }

        private void Deseralize()
        {
            var jsonString = PlayerPrefs.GetString("Save Data");

            if (jsonString == "")
            {
                var JsonString = JsonConvert.SerializeObject(levelDataDefault);
                PlayerPrefs.SetString("Save Data", JsonString);
                var newData = JsonConvert.DeserializeObject<LevelData>(JsonString);
                levelData = null;
                levelData = newData;
                Debug.Log("List Cleared And Set Default");
                return;
            }

            var data = JsonConvert.DeserializeObject<LevelData>(jsonString);
            Debug.Log(jsonString);
            levelData = null;
            levelData = data;

            ResetLevel();
        }

        private void ResetLevel()
        {
            levelData.level = 1;
        }
    }
}
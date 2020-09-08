using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime;
namespace CS
{
    public static class SaveData
    {
        public static void newSave()
        {
            List<Level> list = LevelSelector.instance.levels;
            PlayerPrefs.SetString("SS_cCount", objectToString(LevelSelector.instance.CompleteCount));
            PlayerPrefs.SetString("SS_pCount", objectToString(LevelSelector.instance.PerfectCount));
            for (int i = 0; i < list.Count; i++)
            {
                PlayerPrefs.SetString(list[i].name, objectToString(list[i]));
            }
            PlayerPrefs.SetInt("SS_LVersionCode", 4995);
            PlayerPrefs.SetInt("SS_saveData", 1);
            PlayerPrefs.Save();
        }

        public static void saveLevel(Level level)
        {
            PlayerPrefs.SetString(level.name, objectToString(level));
            PlayerPrefs.SetString("SS_cCount", objectToString(LevelSelector.instance.CompleteCount));
            PlayerPrefs.SetString("SS_pCount", objectToString(LevelSelector.instance.PerfectCount));
        }

        public static void load(List<Level> list)
        {
            LevelSelector.instance.CompleteCount = (int)stringToObject(PlayerPrefs.GetString("SS_cCount"));
            LevelSelector.instance.PerfectCount = (int)stringToObject(PlayerPrefs.GetString("SS_pCount"));
            for (int i = 0; i < list.Count; i++)
            {
                if (PlayerPrefs.HasKey(list[i].name))
                {
                    list[i] = (Level)stringToObject(PlayerPrefs.GetString(list[i].name));
                }
                else
                {
                    PlayerPrefs.SetString(list[i].name, objectToString(list[i]));
                }
            }
            LevelSelector.instance.CurrentPage = PlayerPrefs.GetInt("SS_pageNumber", 0);
            SaveData.saveLevel(list[0]);
        }
        
        public static void savePage(int page)
        {
            PlayerPrefs.SetInt("SS_pageNumber", page);
        }

        public static void saveTransitions(bool enabled)
        {
            int enabledInt = enabled == true ? 1 : 0;
            PlayerPrefs.SetInt("SS_TransitionsEnabled", enabledInt);
        }

        private static string objectToString(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return System.Convert.ToBase64String(ms.ToArray());
            }
        }

        private static object stringToObject(string base64String)
        {
            byte[] bytes = System.Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return new BinaryFormatter().Deserialize(ms);
            }
        }
    }
}
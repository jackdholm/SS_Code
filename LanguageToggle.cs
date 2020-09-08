using UnityEngine;
using UnityEngine.UI;

namespace CS
{
    public class LanguageToggle : MonoBehaviour
    {
        public delegate void ChangeLanguage();
        public static event ChangeLanguage Event_LanguageChanged;
        public Toggle[] Toggles;

        void Start()
        {
            int currentLanguage = (int)Language.CurrentLanguage;
            Toggles[currentLanguage].isOn = true;
        }

        public void Switch(int t)
        {
            if (Toggles[t].isOn)
            {
                Language.CurrentLanguage = (LanguageCode)t;
                Debug.Log("New language: " + (LanguageCode)t + " " + t);
                PlayerPrefs.SetInt("SS_Language", t);
                Debug.Log("language set to " + PlayerPrefs.GetInt("SS_Language", 3));
                PlayerPrefs.Save();
                Event_LanguageChanged();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class LanguageSelect : MonoBehaviour
    {
        private TMPro.TMP_Text targetText;
        public int TextIndex;
        public bool AutoChange = false;

        private void Start()
        {
            targetText = GetComponent<TMPro.TMP_Text>();
            select();
        }
        private void OnEnable()
        {
            //Debug.Log("CurrentLanguage: " + Language.CurrentLanguage);
            if (AutoChange)
            {
                LanguageToggle.Event_LanguageChanged += select;
            }
        }
        private void OnDisable()
        {
            if (AutoChange)
            {
                LanguageToggle.Event_LanguageChanged -= select;
            }
        }

        private void select()
        {
            if (targetText == null)
                targetText = GetComponent<TMPro.TMP_Text>();
            targetText.text = Language.GetString(TextIndex);
        }
    }
}
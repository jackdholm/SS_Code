using UnityEngine;

namespace CS
{
    public class CompletionStats : MonoBehaviour
    {
        public TMPro.TMP_Text PercentComplete;
        public TMPro.TMP_Text PercentPerfect;

        void Start()
        {
            PercentComplete.text = Language.GetString(11) + LevelSelector.instance.PercentComplete().ToString("0.00") + "%";
            PercentPerfect.text = Language.GetString(12) + LevelSelector.instance.percentPerfect().ToString("0.00") + "%";
        }
        private void OnEnable()
        {
            LanguageToggle.Event_LanguageChanged += updateText;
        }
        private void OnDisable()
        {
            LanguageToggle.Event_LanguageChanged -= updateText;
        }
        public void updateText()
        {
            PercentComplete.text = Language.GetString(11) + LevelSelector.instance.PercentComplete().ToString("0.00") + "%";
            PercentPerfect.text = Language.GetString(12) + LevelSelector.instance.percentPerfect().ToString("0.00") + "%";
        }
    }
}
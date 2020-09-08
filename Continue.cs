using UnityEngine;

namespace CS
{
    public class Continue : MonoBehaviour
    {
        public TMPro.TMP_Text ButtonText;
        public ScreenLoader Loader;
        // If it's a new game
        private bool loadTutorial;
        
        void Start()
        {
            if (LevelSelector.instance.HighestUnlockedLevel >= 0)
            {
                loadTutorial = false;
                ButtonText.text = Language.ContinueString();
            }
            else
            {
                loadTutorial = true;
                ButtonText.text = Language.StartString();
            }
        }
        private void OnEnable()
        {
            LanguageToggle.Event_LanguageChanged += Restart;
        }
        private void OnDisable()
        {
            LanguageToggle.Event_LanguageChanged -= Restart;
        }
        public void load()
        {
            if (loadTutorial)
            {
                Loader.load(LoadingMode.TUTORIAL);
            }
            else
            {
                Loader.load(LoadingMode.CONTINUE);
            }
        }

        public void ReplayTutorial()
        {
            Loader.load(LoadingMode.TUTORIAL);
        }
        public void setLoadTutorial()
        {
            loadTutorial = false;
            ButtonText.text = Language.ContinueString();
        }
        private void Restart()
        {
            if (LevelSelector.instance.HighestUnlockedLevel >= 0)
            {
                loadTutorial = false;
                ButtonText.text = Language.ContinueString();
            }
            else
            {
                loadTutorial = true;
                ButtonText.text = Language.StartString();
            }
        }
    }
}
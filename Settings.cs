using UnityEngine;
using UnityEngine.SceneManagement;

namespace CS
{
    public class Settings : MonoBehaviour
    {
        public Transform ResetScreen;
        public Transform LanguageScreen;
        public UnityEngine.UI.Toggle TransitionToggle;
        Vector3 offScreenPosition;
        Vector3 onScreenPosition;

        private void Awake()
        {
            offScreenPosition = new Vector3(Screen.width * 3, 0, 0);
            onScreenPosition = Vector3.zero;
            ResetScreen.localPosition = offScreenPosition;
            LanguageScreen.localPosition = offScreenPosition;
        }
        private void Start()
        {
            bool transitions = PlayerPrefs.GetInt("SS_TransitionsEnabled", 1) == 1 ? true : false;
            Transition.instance.Enabled = transitions;
            TransitionToggle.isOn = transitions;
        }
        public void showResetScreen()
        {
            ResetScreen.localPosition = onScreenPosition;
        }
        public void hideResetScreen()
        {
            ResetScreen.localPosition = offScreenPosition;
        }
        public void resetData()
        {
            int temp = LevelSelector.instance.LevelVersionCode;
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("SS_LVersionCode", temp);
            SceneManager.LoadScene("PreLoader");
        }
        public void ToggleTransitions()
        {
            bool transitions = TransitionToggle.isOn;
            Transition.instance.Enabled = transitions;
            SaveData.saveTransitions(transitions);
        }
        public void ShowLanguageScreen()
        {
            LanguageScreen.localPosition = onScreenPosition;
        }
        public void HideLanguageScreen()
        {
            LanguageScreen.localPosition = offScreenPosition;
        }
    }
}
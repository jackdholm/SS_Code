using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ReviewPrompt : MonoBehaviour
    {
        public GameObject Panel;
        private void Awake()
        {
            if (LevelSelector.instance.ReviewPrompt == 1)
            {
                Panel.SetActive(true);
            }
        }

        public void Review()
        {
            PlayerPrefs.SetInt("SS_ReviewPrompt", 2);
            Panel.SetActive(false);
            Application.OpenURL("market://details?id=com.JackHolm.Synchro_Slide");
        }
        public void HidePrompt()
        {
            Panel.SetActive(false);
        }
        public void DisablePrompt()
        {
            PlayerPrefs.SetInt("SS_ReviewPrompt", 2);
            Panel.SetActive(false);
        }
    }
}
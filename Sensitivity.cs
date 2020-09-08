using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CS
{
    public class Sensitivity : MonoBehaviour
    {
        const float DEFAULT_VALUE = 80;
        public static float value = 80;
        public Slider slider;

        private void Start()
        {
            value = PlayerPrefs.GetFloat("SS_Sensitivity", DEFAULT_VALUE);
            slider.value = value;
        }

        public void changeValue()
        {
            value = slider.value;
            PlayerPrefs.SetFloat("SS_Sensitivity", value);
        }

        public void resetValue()
        {
            value = DEFAULT_VALUE;
            slider.value = value;
            PlayerPrefs.SetFloat("SS_Sensitivity", value);
        }
    }
}
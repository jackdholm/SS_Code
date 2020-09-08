using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class LevelNumberText : MonoBehaviour
    {
        private TMPro.TMP_Text text;

        private void Start()
        {
            text = GetComponent<TMPro.TMP_Text>();
            text.text = Language.LevelNumberString(LevelSelector.instance.CurrentLevel + 1);
        }
    }
}
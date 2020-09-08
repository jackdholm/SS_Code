using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ResetLevel : MonoBehaviour
    {
        public delegate void resetLevel();
        public static event resetLevel Event_ResetLevel;

        public void resetButtonClick()
        {
            Event_ResetLevel();
        }

        public void ResetTutorial()
        {
            Event_ResetLevel();
        }
    }
}
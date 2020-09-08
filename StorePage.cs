using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class StorePage : MonoBehaviour
    {
        public void Open()
        {
            Application.OpenURL("market://details?id=com.JackHolm.Synchro_Slide");
        }
    }
}
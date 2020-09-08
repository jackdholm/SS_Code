using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ScreenLoaderStart : MonoBehaviour
    {
        private void Start()
        {
            ScreenLoader.instance.showMenu();
        }
    }
}
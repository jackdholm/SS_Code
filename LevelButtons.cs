using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    /// <summary>
    /// Handles loading the menu and levels from within
    /// levels. Also checks for escape/back button presses.
    /// </summary>
    public class LevelButtons : MonoBehaviour
    {
        private ScreenLoader _loader;
        private bool clicked = false;

        private void Awake()
        {
            _loader = ScreenLoader.instance;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LevelSelect();
            }
        }

        public void NextLevel()
        {
            if (!clicked)
            {
                clicked = true;
                LevelSelector.instance.loadNext();
            }
        }

        public void LevelSelect()
        {
            if (!clicked)
            {
                Input.ResetInputAxes();
                clicked = true;
                if (_loader != null)
                    _loader.load(LoadingMode.LEVEL_SELECT);
                else
                    LevelSelector.instance.loadLevelSelect();
            }
        }

        public void MainMenu()
        {
            if (!clicked)
            {
                Input.ResetInputAxes();
                clicked = true;
                if (_loader != null)
                    _loader.load(LoadingMode.MAIN_MENU);
                else
                    LevelSelector.instance.loadMenu();
            }
        }
    }
}
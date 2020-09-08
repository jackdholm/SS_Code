using UnityEngine;

namespace CS
{
    public class Button : MonoBehaviour
    {
        private ScreenLoader loader;

        private void Awake()
        {
            loader = ScreenLoader.instance;
        }
        bool clicked = false;
        public void nextLevel()
        {
            if(!clicked)
            {
                clicked = true;
                LevelSelector.instance.loadNext();
            }
        }

        public void mainMenu()
        {
            if (!clicked)
            {
                Input.ResetInputAxes();
                clicked = true;
                if (loader != null)
                    loader.load(LoadingMode.MAIN_MENU);
                else
                    LevelSelector.instance.loadMenu();
            }
        }
        
        public void loadLevel(int level)
        {
            LevelSelector.instance.loadLevel(level);
        }
        public void levelSelect()
        {
            if (!clicked)
            {
                Input.ResetInputAxes();
                clicked = true;
                if (loader != null)
                    loader.load(LoadingMode.LEVEL_SELECT);
                else
                    LevelSelector.instance.loadLevelSelect();
            }
        }
    }
}

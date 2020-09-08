using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public enum LoadingMode { MAIN_MENU, LEVEL_SELECT, CONTINUE, TUTORIAL };
    // Manages the main menu, level select, and settings UIs
    public class ScreenLoader : MonoBehaviour
    {
        public static ScreenLoader instance;
        public LevelSelectScreen LevelSelect;
        public ScrollSnapRect ScrollRect;
        public List<ButtonLock> LevelButtons;
        public Transform mainCanvas;
        public Transform lsCanvas;
        public Transform settingsCanvas;
        public Settings settings;
        public CompletionStats Stats;
        public Continue ContinueButton;
        Vector3 offScreenPosition;
        Vector3 onScreenPosition;
        private bool levelSelectShown;
        private bool settingsShown;
        private Canvas _canvas;
        private LevelSelector _ls;
        private ClickSound _clickSound;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                Destroy(ScrollRect);
                return;
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
            _ls = LevelSelector.instance;
            offScreenPosition = new Vector3(Screen.width*2, 0, 0);
            onScreenPosition = Vector3.zero;
            settingsCanvas.position = offScreenPosition;
            if (LevelSelect != null)
                LevelSelect.Open();
            _clickSound = GetComponent<ClickSound>();
            _canvas = GetComponent<Canvas>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (levelSelectShown)
                {
                    closeLevelSelect();
                    _clickSound.Play(0.9f);
                }
                else if (settingsShown)
                {
                    settings.hideResetScreen();
                    closeSettings();
                    _clickSound.Play(0.9f);
                }
                else
                {
                    Application.Quit();
                }
            }
        }
        public void openLevelSelect()
        {
            levelSelectShown = true;
            mainCanvas.localPosition = offScreenPosition;
            lsCanvas.localPosition = onScreenPosition;
        }
        public void closeLevelSelect()
        {
            levelSelectShown = false;
            mainCanvas.localPosition = onScreenPosition;
            lsCanvas.localPosition = offScreenPosition;
        }
        public void openSettings()
        {
            settingsShown = true;
            mainCanvas.localPosition = offScreenPosition;
            settingsCanvas.localPosition = onScreenPosition;
        }
        public void closeSettings()
        {
            settingsShown = false;
            mainCanvas.localPosition = onScreenPosition;
            settingsCanvas.localPosition = offScreenPosition;
        }
        public void loadLevel(int level)
        {
            if (Transition.instance.Enabled)
            {
                StartCoroutine(loadWithTransition(level, Transition.instance.SlideTime));
            }
            else
            {
                loadLevelNoTransition(level);
            }
        }
        private void loadLevelNoTransition(int level)
        {
            hideMenu();
            _ls.loadLevel(level);
            _canvas.enabled = false;
            this.enabled = false;
        }
        public void loadContinue(bool loadTutorial)
        {
            hideMenu();
            if (loadTutorial)
                _ls.loadTutorial();
            else
                _ls.loadHighest();
            _canvas.enabled = false;
            this.enabled = false;
        }
        public void loadMenu(bool levelSelectActive)
        { 
            if (levelSelectActive)
            {
                _ls.loadLevelSelect();
                levelSelectShown = true;
            }
            else
            {
                _ls.loadMenu();
                levelSelectShown = false;
            }
            _canvas.enabled = true;
            this.enabled = true;
        }
        public void load(LoadingMode mode)
        {
            if (Transition.instance.Enabled)
            {
                StartCoroutine(loadWithTransition(mode, Transition.instance.SlideTime));
            }
            else
            {
                switch (mode)
                {
                    case LoadingMode.MAIN_MENU:
                        loadMenu(false);
                        break;
                    case LoadingMode.LEVEL_SELECT:
                        loadMenu(true);
                        break;
                    case LoadingMode.CONTINUE:
                        loadContinue(false);
                        break;
                    case LoadingMode.TUTORIAL:
                        loadContinue(true);
                        break;
                }
            }
        }
        public void showMenu()
        {
            if (levelSelectShown)
                openLevelSelect();
            else
                closeLevelSelect();
        }
        private void hideMenu()
        {
            mainCanvas.localPosition = offScreenPosition;
            lsCanvas.localPosition = offScreenPosition;
            levelSelectShown = false;
        }
        public void destroy()
        {
            Destroy(this.gameObject);
        }

        IEnumerator loadWithTransition(int level, float t)
        {
            Transition.instance.TStart(TransitionMode.SLIDE);
            yield return new WaitForSeconds(t);
            loadLevelNoTransition(level);
        }

        IEnumerator loadWithTransition(LoadingMode mode, float t)
        {
            Transition.instance.TStart(TransitionMode.SLIDE);
            yield return new WaitForSeconds(t);

            switch (mode)
            {
                case LoadingMode.MAIN_MENU:
                    loadMenu(false);
                    break;
                case LoadingMode.LEVEL_SELECT:
                    loadMenu(true);
                    break;
                case LoadingMode.CONTINUE:
                    loadContinue(false);
                    break;
                case LoadingMode.TUTORIAL:
                    loadContinue(true);
                    break;
            }
        }
    }
}
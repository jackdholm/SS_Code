using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CS
{
    public class LevelSelectScreen : MonoBehaviour
    {
        public GameObject LevelSelectPage;
        public GameObject LevelSelectButton;
        public GameObject PageSelectGroup;
        public GameObject PageSelectImage;
        public int LevelsPerPage;
        public ScreenLoader Loader;

        private GameObject currentPage;

        public void Open()
        {
            List<ButtonLock> buttonList = Loader.LevelButtons;
            for (int i = 0; i < LevelSelector.instance.levels.Count; i++)
            {
                if (i % LevelsPerPage == 0)
                {
                    currentPage = Instantiate(LevelSelectPage, transform);
                    Instantiate(PageSelectImage, PageSelectGroup.transform);
                }
                GameObject button = Instantiate(LevelSelectButton, currentPage.transform);

                ButtonLock bLock = button.GetComponent<ButtonLock>();
                bLock.setLevelNumber((i + 1).ToString());
                UnityEngine.UI.Button b = button.GetComponent<UnityEngine.UI.Button>();

                int x = i; // Using i directly for add onClick event causes it to use the final value of i after loop ends
                b.onClick.AddListener(delegate { Loader.loadLevel(x); });
                
                // Add move record if it exists
                if (LevelSelector.instance.levels[i].moveRecord > 0)
                {
                    bLock.setMoves(LevelSelector.instance.levels[i].moveRecord.ToString());
                }
                else
                {
                    bLock.setMoves("");
                }
                // Add perfect star/border if perfect score
                if (LevelSelector.instance.levels[i].perfect)
                {
                    bLock.setPerfect();
                }
                // Lock/unlock level
                if (LevelSelector.instance.levels[i].unlocked)
                {
                    bLock.unlockLevel();
                    LevelSelector.instance.HighestUnlockedLevel = i;
                }
                else
                {
                    bLock.lockLevel();
                }
                buttonList.Add(bLock);
            }
        }
    }
}

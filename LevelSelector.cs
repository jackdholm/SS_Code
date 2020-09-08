using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CS
{
    /// <summary>
    /// Class for managing/loading levels and completion data
    /// </summary>
    public class LevelSelector : MonoBehaviour
    {
        public static LevelSelector instance;
        public List<Level> levels;
        public int CurrentLevel;
        public bool LevelSelectLoad = false;
        public int HighestUnlockedLevel = -1;
        public int CompleteCount;
        public int PerfectCount;
        public bool LoadData = false;
        public int CurrentPage = 0;
        public int ReviewPrompt;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                LoadData = false;
                return;
            }
            else
            {
                instance = this;
            }

            DontDestroyOnLoad(this);

            if (LoadData)
            {
                if (PlayerPrefs.GetInt("SS_saveData", 0) == 0)
                {
                    SaveData.newSave();
                }
                else
                {
                    SaveData.load(levels);
                }
                LoadData = false;
            }
            Debug.Log("Language " + (LanguageCode)PlayerPrefs.GetInt("SS_Language", 0));
            Language.CurrentLanguage = (LanguageCode)PlayerPrefs.GetInt("SS_Language", 0);
            ReviewPrompt = PlayerPrefs.GetInt("SS_ReviewPrompt", 0);
        }

        private void OnApplicationQuit()
        {
            SaveData.savePage(CurrentPage);
        }
        /// <summary>
        /// Sets the current level as complete
        /// and saves the data for that level.
        /// Also Indicates if currently on the last
        /// level.
        /// </summary>
        /// <returns>
        /// true if the current level is last
        /// </returns>
        public bool completedLevelIsLast()
        {
            if (LevelSelector.instance.ReviewPrompt == 0)
            {
                Debug.Log("Prompt");
                PlayerPrefs.SetInt("SS_ReviewPrompt", 1);
            }
            if (CurrentLevel < levels.Count-1)
            {
                if (!levels[CurrentLevel + 1].unlocked)
                {
                    unlock(CurrentLevel + 1);
                    SaveData.saveLevel(levels[CurrentLevel + 1]);
                    if (ScreenLoader.instance != null)
                        ScreenLoader.instance.LevelButtons[CurrentLevel + 1].unlockLevel();
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Loads the level specified and sets it as the current level.
        /// </summary>
        /// <param name="level">The index of the lvel to load</param>
        public void loadLevel(int level)
        {
            CurrentLevel = level;
            SceneManager.LoadScene(levels[level].name);
        }

        /// <summary>
        /// Loads the level after the current level
        /// </summary>
        public void loadNext()
        {
            if (CurrentLevel < levels.Count)
            {
                CurrentLevel++;
                CurrentPage = CurrentLevel / 20;
                SceneManager.LoadScene(levels[CurrentLevel].name);
            }
        }

        /// <summary>
        /// Loads the menu without the level select screen open.
        /// </summary>
        public void loadMenu()
        {
            LevelSelectLoad = false;
            SceneManager.LoadScene("Menu");
        }
        
        /// <summary>
        /// Loads the menu with the level select screen open.
        /// </summary>
        public void loadLevelSelect()
        {
            LevelSelectLoad = true;
            SceneManager.LoadScene("Menu");
        }

        public void loadHighest()
        {
            loadLevel(HighestUnlockedLevel);
        }
        
        public void loadTutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }

        /// <summary>
        /// Unlocks the specified level
        /// </summary>
        /// <param name="level">The index of the level</param>
        public void unlock(int level)
        {
            if (!levels[level].unlocked)
            {
                levels[level].unlocked = true;
                HighestUnlockedLevel++;
            }
        }
        
        /// <summary>
        /// Sets the current level as perfect and updates the corresponding
        /// button on the level select screen.
        /// </summary>
        public void perfectScore()
        {
            if (!levels[CurrentLevel].perfect)
            {
                PerfectCount++;
                GooglePlayGames.PlayGamesPlatform.Instance.ReportScore(PerfectCount, "CgkIxLu1_aAXEAIQEg", report);
                if (PerfectCount % 15 == 0)
                {
                    int achievementIdIndex = PerfectCount / 15 - 1;
                    GooglePlayGames.PlayGamesPlatform.Instance.ReportProgress(Achievements.PERFECT_ACHIEVEMENT_ID[achievementIdIndex], 100.0, report);
                }
                levels[CurrentLevel].perfect = true;
                if (ScreenLoader.instance != null)
                    ScreenLoader.instance.LevelButtons[CurrentLevel].setPerfect();
            }
        }

        public void setComplete()
        {
            if (levels[CurrentLevel].moveRecord < 0)
            {
                CompleteCount++;
                GooglePlayGames.PlayGamesPlatform.Instance.ReportScore(CompleteCount, "CgkIxLu1_aAXEAIQEQ", report);
                if (CompleteCount % 5 == 0)
                {
                    LevelVersionCode += 3;
                    PlayerPrefs.SetInt("SS_LVersionCode", LevelVersionCode);
                    PlayerPrefs.Save();
                    int achievementIdIndex = CompleteCount / 5 - 1;
                    GooglePlayGames.PlayGamesPlatform.Instance.ReportProgress(Achievements.COMPLETE_ACHIEVEMENT_ID[achievementIdIndex], 100.0, report);
                }
            }
        }

        public float PercentComplete()
        {
            return CompleteCount / (float)levels.Count * 100f;
        }

        public float percentPerfect()
        {
            return PerfectCount / (float)levels.Count * 100f;
        }
        
        /// <summary>
        /// Returns a reference to the current Level object
        /// </summary>
        /// <returns>Reference to the current Level object</returns>
        public Level current()
        {
            return levels[CurrentLevel];
        }

        public void destroy()
        {
            Destroy(this.gameObject);
        }

        /// <summary>
        /// Updates the current level's button with a new move record
        /// as well as the completion stats.
        /// </summary>
        /// <param name="moveCount">String representing the move count</param>
        public void updateButton(string moveCount)
        {
            ScreenLoader sLoader = ScreenLoader.instance;
            if (sLoader != null)
            {
                sLoader.LevelButtons[CurrentLevel].setMoves(moveCount);
                sLoader.Stats.updateText();
            }
        }
        // callback for achievement functions
        private void report(bool success)
        {

        }
    }
}
using UnityEngine;

namespace CS
{
    public class Achievements : MonoBehaviour
    {
        public static const string[] COMPLETE_ACHIEVEMENT_ID =
        {
            "CgkIxLu1_aAXEAIQAQ",
            "CgkIxLu1_aAXEAIQAg",
            "CgkIxLu1_aAXEAIQAw",
            "CgkIxLu1_aAXEAIQBA",
            "CgkIxLu1_aAXEAIQBQ",
            "CgkIxLu1_aAXEAIQBg",
            "CgkIxLu1_aAXEAIQBw",
            "CgkIxLu1_aAXEAIQCA",
            "CgkIxLu1_aAXEAIQCQ",
            "CgkIxLu1_aAXEAIQCg",
            "CgkIxLu1_aAXEAIQCw",
            "CgkIxLu1_aAXEAIQDA"
        };
        public static const string[] PERFECT_ACHIEVEMENT_ID =
        {
            "CgkIxLu1_aAXEAIQDQ",
            "CgkIxLu1_aAXEAIQDg",
            "CgkIxLu1_aAXEAIQDw",
            "CgkIxLu1_aAXEAIQEA"
        };
        public void SignIn()
        {
            if (GooglePlayGames.PlayGamesPlatform.Instance.localUser.authenticated)
            {
                Show();
            }
            else
            {
                PlayerPrefs.SetInt("SS_AutoSignIn", 1);
                GooglePlayGames.PlayGamesPlatform.Instance.localUser.Authenticate((bool success) =>
                {
                    if (success)
                    {
                        UpdateAchievements();
                        Show();
                    }
                });
            }
        }

        public static void UpdateAchievements()
        {
            GooglePlayGames.PlayGamesPlatform.Instance.LoadAchievements(achievements =>
            {
                int completeAchievements = LevelSelector.instance.CompleteCount / 5;
                int perfectAchievements = LevelSelector.instance.PerfectCount / 15;
                for (int i = 0; i < completeAchievements; i++)
                    GooglePlayGames.PlayGamesPlatform.Instance.ReportProgress(Achievements.COMPLETE_ACHIEVEMENT_ID[i], 100.0, report);
                for (int i = 0; i < perfectAchievements; i++)
                    GooglePlayGames.PlayGamesPlatform.Instance.ReportProgress(Achievements.PERFECT_ACHIEVEMENT_ID[i], 100.0, report);
                GooglePlayGames.PlayGamesPlatform.Instance.ReportScore(LevelSelector.instance.CompleteCount, "CgkIxLu1_aAXEAIQEQ", report);
                GooglePlayGames.PlayGamesPlatform.Instance.ReportScore(LevelSelector.instance.PerfectCount, "CgkIxLu1_aAXEAIQEg", report);
            });
        }
        private static void report(bool success)
        {

        }
        private void Show()
        {
            GooglePlayGames.PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
    }
}
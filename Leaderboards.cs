using UnityEngine;

namespace CS
{
    public class Leaderboards : MonoBehaviour
    {
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
                        Achievements.UpdateAchievements();
                        Show();
                    }
                });
            }
        }

        private void Show()
        {
            GooglePlayGames.PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
    }
}
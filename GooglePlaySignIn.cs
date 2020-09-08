using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

namespace CS
{
    public class GooglePlaySignIn : MonoBehaviour
    {
        private void Start()
        {
            if (PlayGamesPlatform.Instance == null)
            {
                PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
                PlayGamesPlatform.InitializeInstance(config);
                PlayGamesPlatform.DebugLogEnabled = false;
                // Activate the Google Play Games platform
                PlayGamesPlatform.Activate();
            }
            if (PlayerPrefs.GetInt("SS_AutoSignIn", 0) == 1)
            {
                GooglePlayGames.PlayGamesPlatform.Instance.localUser.Authenticate((bool success) =>
                {
                    if (success)
                        Achievements.UpdateAchievements();
                });
            }
        }
    }
}
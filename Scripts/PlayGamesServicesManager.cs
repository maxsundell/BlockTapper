using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class PlayGamesServicesManager : MonoBehaviour
{

    private void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);

            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();

            Social.localUser.Authenticate((bool success) => { });            

        }

    }

    public void UnlockAchievement(string achievementID)
    {

        Social.ReportProgress(achievementID, 100f, (bool success) => { } );

    }

    public void IncrementAchievement(string achievementID, int stepsToIncrement)
    {

        PlayGamesPlatform.Instance.IncrementAchievement(achievementID, stepsToIncrement, (bool success) => { } );

    }

    public void PostingToLeaderboard(long scoreToReport, string leaderboardID)
    {

        Social.ReportScore(scoreToReport, leaderboardID, (bool success) => { } );

    }

    public void ShowLeaderboardUI()
    {

        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI0qzfiowYEAIQDQ");

    }

    public void ShowAchievementUI()
    {

        Social.ShowAchievementsUI();

    }

}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{

    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject gameOverUI;

    public Button retryButton;
    public Button achievementsButton;
    public Button scoreBoardButton;

    public static bool gameOver;

    public BannerView bannerAd;

    public void ShowBannerAd()
    {

        string bannerID = "ca-app-pub-2192478680249555/7212611318";

        bannerAd = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)
        .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
        .Build();

        bannerAd.LoadAd(request);

    }

    private void Start()
    {

        gameOver = false;

        BlockTouchController.score = 0;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

            ShowBannerAd();

        }

    }

    public void PlayButton()
    {

        bannerAd.Destroy();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void PauseButton()
    {

        ShowBannerAd();
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;        

    }

    public void ResumeButton()
    {

        bannerAd.Destroy();
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;

    }

    public void RetryButton()
    {

        bannerAd.Destroy();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void ScoreBoardButton()
    {

        FindObjectOfType<PlayGamesServicesManager>().ShowLeaderboardUI();

    }

    public void AchievementsButton()
    {

        FindObjectOfType<PlayGamesServicesManager>().ShowAchievementUI();

    }

    IEnumerator DisableButtonTemp(Button button)
    {

        Button buttonInstance = button.GetComponent<Button>();

        buttonInstance.interactable = false;
        yield return new WaitForSeconds(2);
        buttonInstance.interactable = true;

    }

    public void OnGameOver()
    {

        if (gameOver == false)
        {

            ShowBannerAd();

            StartCoroutine(DisableButtonTemp(retryButton));
            StartCoroutine(DisableButtonTemp(achievementsButton));
            StartCoroutine(DisableButtonTemp(scoreBoardButton));

            gameUI.SetActive(false);
            pauseUI.SetActive(false);
            gameOverUI.SetActive(true);

            FindObjectOfType<PlayGamesServicesManager>().IncrementAchievement("CgkI0qzfiowYEAIQCg", BlockTouchController.score);
            FindObjectOfType<PlayGamesServicesManager>().IncrementAchievement("CgkI0qzfiowYEAIQEQ", BlockTouchController.score);
            FindObjectOfType<PlayGamesServicesManager>().IncrementAchievement("CgkI0qzfiowYEAIQFA", BlockTouchController.score);
            FindObjectOfType<PlayGamesServicesManager>().IncrementAchievement("CgkI0qzfiowYEAIQFQ", BlockTouchController.score / 10);

            gameOver = true;           

        }

    }

}

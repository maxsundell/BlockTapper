using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{

    public static int highScore;
    int score;

    public Text highScoreText;

    private void Start()
    {

        highScore = PlayerPrefs.GetInt("High Score");

        score = BlockTouchController.score;

        if (score > highScore)
        {

            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);

            FindObjectOfType<PlayGamesServicesManager>().PostingToLeaderboard(score, "CgkI0qzfiowYEAIQDQ");

        }

        highScoreText.text = "<size=150>HIGH SCORE</size>\n<b>" + highScore.ToString() + "</b>";

    }

}

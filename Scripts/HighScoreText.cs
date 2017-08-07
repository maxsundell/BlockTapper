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

        score = BlockController.score;

        if (score > highScore)
        {

            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);

        }

        highScoreText.text = highScore.ToString();

    }

}

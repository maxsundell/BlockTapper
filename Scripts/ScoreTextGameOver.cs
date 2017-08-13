using UnityEngine;
using UnityEngine.UI;

public class ScoreTextGameOver : MonoBehaviour
{

    public Text scoreText;

    private void Update()
    {

        scoreText.text = "<size=150>SCORE</size>\n<b>" + BlockTouchController.score.ToString() + "</b>";

    }

}

using UnityEngine;
using UnityEngine.UI;

public class ScoreTextGame : MonoBehaviour
{

    public Text scoreText;

    private void Update()
    {

        scoreText.text = "<size=100>SCORE</size>\n<b>" + BlockTouchController.score.ToString() + "</b>";

    }

}

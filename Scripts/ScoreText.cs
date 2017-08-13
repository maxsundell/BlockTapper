using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	
	public Text scoreText;

    private void Start()
    {

        scoreText.text = "<size=150>SCORE</size>\n<b>" + BlockTouchController.score.ToString() + "</b>";

    }

}

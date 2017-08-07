using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public Text scoreText;

    
    private void Update()
    {

        scoreText.text = BlockController.score.ToString();

    }

}

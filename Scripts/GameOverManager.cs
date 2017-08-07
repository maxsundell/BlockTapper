using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{

    bool gameOver = false;
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;

    float delayForTouch = 3.2f;
    float touchAvailable;

    private void Update()
    {

        if (gameOver && Input.touchCount > 0 && Time.timeSinceLevelLoad > touchAvailable)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            BlockController.isGameRunning = true;                        

        }

    }

    public void OnGameOver()
    {
        if (gameOver == false)
        {
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);

            touchAvailable = Time.timeSinceLevelLoad + delayForTouch;

            gameOver = true;
        }
        
    }
	
}

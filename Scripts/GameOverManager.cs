using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Advertisements;

public class GameOverManager : MonoBehaviour
{

    bool gameOver = false;
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;

    float delayForTouch = 3.2f;
    float touchAvailable;

    public static float playerSessionNumber = 1f;

    bool playerSessionCounted = false;

    private void Update()
    {

        if (gameOver && Input.touchCount > 0 && Time.timeSinceLevelLoad > touchAvailable)
        {      

            if ((playerSessionNumber / 4) % 1 == 0)
            {

                FindObjectOfType<AdManager>().ShowAdd();

                playerSessionNumber = 1;

            }

            if(!Advertisement.isShowing)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                BlockController.isGameRunning = true;

            }                

        }

    }

    public void PlayerSessionCounter()
    {

        playerSessionNumber++;
        playerSessionCounted = true;

    }

    public void OnGameOver()
    {
        if (gameOver == false)
        {

            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);

            touchAvailable = Time.timeSinceLevelLoad + delayForTouch;

            gameOver = true;

            if (playerSessionCounted == false)
            {

                PlayerSessionCounter();

            }                     
            
        }
        
    }
	
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{

    public GameObject mainMenuCanvas;

    private void Update()
    {

        if (Input.touchCount > 0)
        {

            mainMenuCanvas.SetActive(false);

            SceneManager.LoadScene(1);

        }

    }

}

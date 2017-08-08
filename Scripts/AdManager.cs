using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

    public void ShowAdd()
    {

        if (Advertisement.IsReady())
        {

            Advertisement.Show();

        }

    }

}
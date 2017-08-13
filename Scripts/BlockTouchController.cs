using UnityEngine;

public class BlockTouchController : MonoBehaviour
{

    public GameObject impactEffectSmall;
    public GameObject impactEffectBig;

    public static int score = 0;

    private void Update()
    {

        if (Input.touchCount > 0 && Input.touchCount < 3 && Time.timeScale != 0 && !GameManager.gameOver)
        {

            for (int i = 0; i < Input.touchCount; i++)
            {

                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {

                    CheckTouch(Input.GetTouch(i).position);

                }

            }

        }

    }

    private void CheckTouch(Vector3 touchPoint)
    {     

        Vector3 worldPointV3 = Camera.main.ScreenToWorldPoint(touchPoint);
        Vector2 worldPointV2 = new Vector2(worldPointV3.x, worldPointV3.y);

        Collider2D hit = Physics2D.OverlapPoint(worldPointV2);

        if (hit == gameObject.GetComponent<Collider2D>() && hit.tag == "Block")
        {

            PlayImpactEffect(transform.localScale.x);
            score++;

            if (score >= 50)
            {

                FindObjectOfType<PlayGamesServicesManager>().UnlockAchievement("CgkI0qzfiowYEAIQCQ");

            }

            if (score >= 75)
            {

                FindObjectOfType<PlayGamesServicesManager>().UnlockAchievement("CgkI0qzfiowYEAIQDg");

            }
            
            if (score >= 100)
            {

                FindObjectOfType<PlayGamesServicesManager>().UnlockAchievement("CgkI0qzfiowYEAIQDw");

            }

            if (score >= 150)
            {

                FindObjectOfType<PlayGamesServicesManager>().UnlockAchievement("CgkI0qzfiowYEAIQEg");

            }

            if (score >= 200)
            {

                FindObjectOfType<PlayGamesServicesManager>().UnlockAchievement("CgkI0qzfiowYEAIQEw");

            }

            if (score >= 250)
            {

                FindObjectOfType<PlayGamesServicesManager>().UnlockAchievement("CgkI0qzfiowYEAIQFg");
                
            }

            if (score >= 300)
            {

                FindObjectOfType<PlayGamesServicesManager>().UnlockAchievement("CgkI0qzfiowYEAIQFw");

            }

        }
        
    }

    public void PlayImpactEffect(float scale)
    {

        if (Time.timeScale != 0 && !GameManager.gameOver)
        {        

            Destroy(gameObject);


            if (scale <= 1.4)
            {

                GameObject effectInstance = Instantiate(impactEffectSmall, transform.position, transform.rotation);
                effectInstance.transform.parent = FindObjectOfType<BlockSpawner>().transform;
                Destroy(effectInstance, 3f);

            }
        
            else if(scale > 1.4)
            {

                GameObject effectInstance = Instantiate(impactEffectBig, transform.position, transform.rotation);
                effectInstance.transform.parent = FindObjectOfType<BlockSpawner>().transform;
                Destroy(effectInstance, 3f);

            }

        }

    }

}

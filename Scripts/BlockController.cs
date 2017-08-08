using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour
{

    public GameObject impactEffect;

    public Vector2 fallSpeedMinMax;
    float fallSpeed;

    float screenLowerBorder;

    public static int score;

    public static bool isGameRunning = true;

    private void Start()
    {

        fallSpeedMinMax = new Vector2(fallSpeedMinMax.x, fallSpeedMinMax.y) * Random.Range(0.5f, 1.5f);

        screenLowerBorder = -Camera.main.orthographicSize;
        fallSpeed = Mathf.Lerp(fallSpeedMinMax.x, fallSpeedMinMax.y, DifficultyManager.getDifficultyPercent());

    }

    private void Update()
    {

        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < screenLowerBorder - transform.localScale.x)
        {

            Destroy(gameObject);
            FindObjectOfType<GameOverManager>().OnGameOver();

            isGameRunning = false;

        }

        if (Input.touchCount > 0 && Input.touchCount < 3 && isGameRunning)
        {

            for (int i = 0; i < Input.touchCount; i++)
            {

                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(i).position);
                }         

            }

        }

    }

    private void checkTouch(Vector3 touchPoint)
    {

        Vector3 worldPointV3 = Camera.main.ScreenToWorldPoint(touchPoint);

        Vector2 worldPointV2 = new Vector2(worldPointV3.x, worldPointV3.y);

        Collider2D hit = Physics2D.OverlapPoint(worldPointV2);

        if (hit == gameObject.GetComponent<Collider2D>() && hit.tag == "Block")
        {

            GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectInstance, 5f);

            Destroy(gameObject);
            score++;
            
        }

    }

}

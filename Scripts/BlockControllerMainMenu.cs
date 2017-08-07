using UnityEngine;
using System.Collections;

public class BlockControllerMainMenu : MonoBehaviour
{

    public Vector2 fallSpeedMinMax;
    float fallSpeed;

    float screenLowerBorder;

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

        }

    }

}

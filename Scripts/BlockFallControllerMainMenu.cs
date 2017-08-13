using UnityEngine;

public class BlockFallControllerMainMenu : MonoBehaviour
{

    public Vector2 fallSpeedMinMax;
    float fallSpeed;

    private void Start()
    {

        fallSpeedMinMax = new Vector2(fallSpeedMinMax.x, fallSpeedMinMax.y) * Random.Range(.75f, 1.35f);
        fallSpeed = Mathf.Lerp(fallSpeedMinMax.x, fallSpeedMinMax.y, DifficultyManager.getDifficultyPercent());

    }

    private void Update()
    {

        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - transform.localScale.x)
        {

            Destroy(gameObject);

        }

    }

}

using UnityEngine;

public class BlockSpawnerMainMenu : MonoBehaviour
{

    public GameObject blockPrefab;

    public Vector2 spawnDelayMinMax;

    public Vector2 spawnScaleMinMax;
    public float spawnRotationMinMax;

    float nextSpawnTime;
    Vector2 screenBorder;

    private void Start()
    {

        screenBorder = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        
    }


    private void Update()
    {

        if (Time.timeSinceLevelLoad > nextSpawnTime && Time.timeScale != 0)
        {

            float spawnDelay = Mathf.Lerp(spawnDelayMinMax.y, spawnDelayMinMax.x, DifficultyManager.getDifficultyPercent());

            nextSpawnTime = Time.timeSinceLevelLoad + spawnDelay;

            float spawnRot = Random.Range(-spawnRotationMinMax, spawnRotationMinMax);
            float spawnScale = Random.Range(spawnScaleMinMax.x, spawnScaleMinMax.y);
            Vector2 spawnPos = new Vector2(Random.Range(screenBorder.x - spawnScale, -screenBorder.x + spawnScale), screenBorder.y + spawnScale);

            GameObject blockInstance = Instantiate(blockPrefab, spawnPos, Quaternion.Euler(Vector3.forward * spawnRot));
            blockInstance.transform.localScale = Vector3.one * spawnScale;

            blockInstance.transform.parent = transform;

        }
        
    }

}

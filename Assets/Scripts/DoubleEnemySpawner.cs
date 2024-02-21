using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyGO1;
    [SerializeField] private GameObject enemyGO2;
    
    private float maxSpawnRateInSeconds = 5f;

    void Start()
    {
        ScheduleEnemySpawner();
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        int randomEnemyIndex = Random.Range(0, 2); // Randomly choose between enemyGO1 and enemyGO2

        GameObject enemy;

        if (randomEnemyIndex == 0)
            enemy = Instantiate(enemyGO1);
        else
            enemy = Instantiate(enemyGO2);

        enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1f)
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        else
            spawnInSeconds = 1f;

        Invoke("SpawnEnemy", spawnInSeconds);
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
   
    public void ScheduleEnemySpawner()
    {
        maxSpawnRateInSeconds = 5f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}

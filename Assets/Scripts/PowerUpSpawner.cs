using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float spawnInterval = 28; 

    private float timer;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnPowerUp();

            // Reset the timer to the spawn interval
            timer = spawnInterval;
        }
    }

    private void SpawnPowerUp()
    {
        // Instantiate a new power-up object at the spawner's position
        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
    }
}

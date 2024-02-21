using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGO : MonoBehaviour
{
    [SerializeField] private GameObject EnemyGO;
    
    float maxSpawnRateInSeconds =5f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is used to spawn an enemy
    void SpawnEnemy()
    {

         // Calculate the minimum and maximum positions based on the camera's viewport.
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));

         // Instantiate an enemy game object and assign it to the "anEnemy" variable.
        GameObject anEnemy = (GameObject)Instantiate (EnemyGO);

        // Set the position of the enemy to a random position within the calculated range on the top of the screen.
        anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        // Schedule the next enemy spawn.
        ScheduleNextEnemySpawn();
    }
   
   // This method is used to schedule the next enemy spawn.
    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;

        if(maxSpawnRateInSeconds > 1f)
        {  
             // Generate a random spawn time between 1 second and the maximum spawn rate.
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;
        Invoke("SpawnEnemy", spawnInSeconds);// Invoke the "SpawnEnemy" method after the calculated spawn time.
    }

    // This method is used to increase the spawn rate of enemies
    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if(maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
   
   public void ScheduleEnemySpawner()
   {
      maxSpawnRateInSeconds =5f;
      Invoke ("SpawnEnemy", maxSpawnRateInSeconds);    

      InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
   }

   // This method is used to unschedule the enemy spawner.
    public void UnscheduleEnemySpawner()
    {
        // Cancel the invocation of "SpawnEnemy".
        CancelInvoke("SpawnEnemy");

         // Cancel the repeating invocation of "IncreaseSpawnRate"
        CancelInvoke("IncreaseSpawnRate");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreTextUIGO;

    [SerializeField] private GameObject ExplosionGO;
   
    float speed;

    // Start is called before the first frame update
    void Start()
    {
       speed = 2f;    
       
       // Find the game object with the "ScoreTextTag" tag and assign it to scoreTextUIGO.
       scoreTextUIGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        // Move the enemy downwards based on the specified speed and frame rate.
        position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
        
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));

        // Check if the enemy is outside the camera's viewport.
        if(transform.position.y < min.y)
        {
            // Destroy the enemy game object.
            Destroy(gameObject);
        }
    }

     // This method is called when the enemy collides with another collider.
    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag") )
        {
             // Trigger the explosion effect.
            PlayExplosion();
           
            // Increase the score by 100 using the Score property of the GameScore component attached to scoreTextUIGO.
            scoreTextUIGO.GetComponent<GameScore>().Score += 100;

            // Destroy the enemy game object.
            Destroy(gameObject);
        }
    }
     
     // This method is used to play the explosion effect.
     void PlayExplosion()
    {
         // Instantiate the ExplosionGO game object and assign it to the "explosion" variable.
        GameObject explosion = (GameObject)Instantiate (ExplosionGO);

        // Set the position of the explosion at the enemy's position.
        explosion.transform.position = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed; // The speed at which the bullet moves

    // Start is called before the first frame update
    void Start()
    {
        speed = 8f; // Set the initial speed of the bullet
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        // Move the bullet upwards based on its speed and the time elapsed since the last frame
        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        transform.position = position; // Update the position of the bullet
 
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));


        // Check if the bullet has gone beyond the top of the screen and destroy it
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the bullet has collided with an object tagged as "EnemyShipTag" and destroy it
        if(col.tag == "EnemyShipTag")
        {
            Destroy(gameObject);
        }
    }
}

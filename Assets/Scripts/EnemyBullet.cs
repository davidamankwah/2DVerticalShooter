using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    void Awake()
    {
        speed =5f;
        isReady = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // This method is used to set the direction of the bullet.
    public void SetDirection(Vector2 direction)
    {
        // Normalize the direction vector to have a magnitude of 1.
        _direction = direction.normalized;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            Vector2 position = transform.position;

            // Move the bullet in the specified direction with a specific speed.
            position += _direction * speed * Time.deltaTime;

            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

            // Check if the bullet is outside the camera's viewport
            if((transform.position.x < min.x) || (transform.position.x > max.x ) ||
             (transform.position.y < min.y) || (transform.position.y > max.y) )
             {
                // Destroy the bullet game object.
                Destroy(gameObject);
             }
        }
    }

     // This method is called when the bullet collides with another collider.
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "PlayerShipTag")
        {
             // Destroy the bullet game object if it collides with an object with the "PlayerShipTag".
            Destroy(gameObject);
        }
    }
}

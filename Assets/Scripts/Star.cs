using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed = 0; // The speed at which the star moves

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        // Move the star upwards based on its speed and the time elapsed since the last frame
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position; // Update the position of the star

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Check if the star has gone beyond the bottom of the screen
        if (transform.position.y < min.y)
        {
            // Reset the position of the star to a random position within the viewport's x-axis bounds
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}

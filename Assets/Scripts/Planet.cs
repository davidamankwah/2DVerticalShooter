using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float speed; // The speed at which the planet moves
    public bool isMoving; // Flag indicating whether the planet is currently moving
   
   //The minimum and maximum position of the planet
    Vector2 min;
    Vector2 max;

    void Awake()
    {
        isMoving =false; // Initially, the planet is not moving

        // Calculate the minimum and maximum positions of the planet based on the camera's viewport
        min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
        max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));

        // Adjust the maximum and minimum positions to account for the planet's size
        max.y = max.y + GetComponent<SpriteRenderer> ().sprite.bounds.extents.y;
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
           return; // If the planet is already moving, exit the method

        Vector2 position =  transform.position;

        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        if(transform.position.y < min.y)
        {
            isMoving =false; // If the planet reaches the minimum position, stop moving
        }   
    }

    public void ResetPosition()
    {
        // Set the planet's position to a random value within the minimum and maximum positions
        transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
    }
}

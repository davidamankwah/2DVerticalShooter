using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField] private GameObject StarGO; // Prefab for the star object
    [SerializeField] private int MaxStars = 40; // Maximum number of stars to generate

    // Array of star colors
    Color[] starColors = {
        new Color (0.5f, 0.5f, 1f), 
        new Color (0, 1f, 1f), 
        new Color (1f, 1f, 0), 
        new Color (1f, 0, 0), 
    };
    // Start is called before the first frame update
    void Start()
    {
        // Get the minimum and maximum positions of the viewport
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

        // Generate stars
        for(int i =0; i < MaxStars; ++i)
        {
            // Instantiate a star object
            GameObject star = (GameObject)Instantiate(StarGO);

            // Set the color of the star randomly from the starColors array
            star.GetComponent<SpriteRenderer>().color = starColors[1 % starColors.Length];

            // Set the position of the star to a random position within the viewport
            star.transform.position = new Vector2(Random.Range(min.x,max.x), Random.Range(min.y, max.y));

            // Set the speed of the star to a random negative value
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

             // Set the star object as a child of the StarGenerator object
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

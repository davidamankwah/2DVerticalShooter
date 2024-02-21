using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] private GameObject[] Planets; // Array of planet objects

    Queue<GameObject> availablePlanets = new Queue<GameObject>(); // Queue to store available planets

    // Start is called before the first frame update
    void Start()
    {
     // Enqueue the planets in the order they appear in the array
      availablePlanets.Enqueue (Planets [0]);   
      availablePlanets.Enqueue (Planets [1]);    
      availablePlanets.Enqueue (Planets [2]);   

       // Start invoking the MovePlanetDown method repeatedly with a delay of 20 seconds
      InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePlanetDown()
    {
        EnqueuePlanets(); // Check and enqueue any planets that have reached the bottom

        if(availablePlanets.Count == 0)
            return; // If there are no available planets, exit the method

        GameObject aPlanet =  availablePlanets.Dequeue (); // Dequeue a planet from the available planets queue

        aPlanet.GetComponent<Planet> ().isMoving = true; // Set the isMoving flag of the planet to true, triggering its movement
    }

    void EnqueuePlanets()
    {
        foreach(GameObject aPlanet in Planets)
        {
            // Check if a planet has reached the bottom and is not already moving
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving) )
            {
                aPlanet.GetComponent<Planet>().ResetPosition(); // Reset the position of the planet

                availablePlanets.Enqueue(aPlanet); // Enqueue the planet to make it available for movement again
            }
        }
    }
}

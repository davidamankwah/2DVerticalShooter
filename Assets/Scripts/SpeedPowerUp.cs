using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedIncreaseAmount = 4f;
    //public float speedIncreaseAmount = 4f;
    public float duration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {
    if (collision.CompareTag("PlayerShipTag"))
    {
        // Get the PlayerControl component from the player game object
        PlayerControl player = collision.GetComponent<PlayerControl>();

        if (player != null)
        {
            // Call a method in the PlayerControl script to increase the player's speed
            player.IncreaseSpeed(speedIncreaseAmount);

            // Activate the speed power-up on the player
            player.ActivateSpeedPowerUp(speedIncreaseAmount, duration);


            // Destroy the power-up game object
            Destroy(gameObject);
        }
    }
}

}

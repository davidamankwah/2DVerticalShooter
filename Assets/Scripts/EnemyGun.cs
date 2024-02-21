using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private GameObject EnemyBulletG0;

    // Start is called before the first frame update
    void Start()
    {
         // Invoke the "FireEnemyBullet" method after a delay of 1 second.
        Invoke ("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is used to fire an enemy bullet.
    void FireEnemyBullet()
    {
         // Find the game object with the tag "PlayerGo" and assign it to the "playerShip" variable.
        GameObject playerShip = GameObject.Find ("PlayerGo");

        if(playerShip != null)
        {
          // Instantiate an enemy bullet game object and assign it to the "bullet" variable.
          GameObject bullet = (GameObject)Instantiate(EnemyBulletG0);

         // Set the position of the bullet to match the position of the enemy gun.
          bullet.transform.position = transform.position;

          // Calculate the direction from the enemy gun to the player ship.  
          Vector2 direction = playerShip.transform.position - bullet.transform.position;

          // Set the direction of the bullet using the "SetDirection" method of the "EnemyBullet" script
          bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}

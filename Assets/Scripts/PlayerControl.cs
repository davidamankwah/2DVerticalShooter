using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class PlayerControl : MonoBehaviour
{
   [SerializeField] private GameObject GameManagerGO; // Reference to the GameManager game object
   [SerializeField] private GameObject PlayerBulletGO; // Prefab for the player bullet
   [SerializeField] private GameObject bulletPosition1; // Position for bullet instantiation
   [SerializeField] private GameObject bulletPosition2; // Position for bullet instantiation
   [SerializeField] private GameObject ExplosionGO; // Prefab for the explosion effect
   [SerializeField] private AudioSource lasers; // Audio source for the laser sound effect
   [SerializeField] private AudioSource explode; // Audio source for the explosion sound effect
   [SerializeField] private Text LivesUIText; // UI text displaying the player's remaining lives


   const int MaxLives = 3; // Maximum number of lives for the player
   int lives; // Current number of lives for the player

   [SerializeField] private float speed = 4; // Speed of the player's movement
   float originalSpeed; // Original speed of the player

   public void Init()
   {
        lives = MaxLives;

        LivesUIText.text = lives.ToString();

        transform.position = new Vector2(0, 0);

        gameObject.SetActive (true);

   }

    // Start is called before the first frame update
    void Start()
    {
     originalSpeed = speed;   
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("space"))
        {
           lasers.Play();

            // Instantiate player bullets at the specified bullet positions
            GameObject bullet1 = (GameObject)Instantiate (PlayerBulletGO);
            bullet1.transform.position = bulletPosition1.transform.position;

            GameObject bullet2 = (GameObject)Instantiate (PlayerBulletGO);
            bullet2.transform.position = bulletPosition2.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);   

    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            explode.Play();
            
            lives--;
            LivesUIText.text = lives.ToString();

            if(lives == 0)
            {
              GameManagerGO.GetComponent<GameMangers>().SetGameManagerState(GameMangers.GameManagerState.GameOver);
              
              gameObject.SetActive(false);
            }
            
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate (ExplosionGO);

        explosion.transform.position = transform.position;
    }

    public void IncreaseSpeed(float amount)
  {
    // Increase the player's speed by the specified amount
    speed += amount;
  }

  public void ActivateSpeedPowerUp(float amount, float duration)
    {
        // Increase the player's speed by the specified amount
        speed += amount;

        // Start a coroutine to revert the speed back to its original value after the duration
        StartCoroutine(RevertSpeed(duration));
    }

    private IEnumerator RevertSpeed(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Revert the speed back to its original value
        speed = originalSpeed;
    }

}


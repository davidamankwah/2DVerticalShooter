using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMangers : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject playerShip;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject GameOverGO;
    [SerializeField] private GameObject scoreTextUIGO;

    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening; // Set the initial game manager state to Opening.
    }

   // Update the game manager state based on the current value of GMState.
   void UpdateGameManagerState()
   {
    switch(GMState)
    {
        case GameManagerState.Opening:
        // Disable the game over UI.
        GameOverGO.SetActive(false);
        // Show the play button UI.
        playButton.SetActive(true);
        break;

         case GameManagerState.GamePlay:
         // Reset the score to 0
         scoreTextUIGO.GetComponent<GameScore>().Score = 0;
         // Hide the play button UI.
         playButton.SetActive(false);
        // Initialize the player ship.
         playerShip.GetComponent<PlayerControl>().Init();
         // Schedule enemy spawning.
         enemySpawner.GetComponent<EnemySpawnerGO>().ScheduleEnemySpawner();
         enemySpawner.GetComponent<DoubleEnemySpawner>().ScheduleEnemySpawner();

        break;

        case GameManagerState.GameOver:
        // Unschedule enemy spawning.
        enemySpawner.GetComponent<EnemySpawnerGO>().UnscheduleEnemySpawner();
        enemySpawner.GetComponent<DoubleEnemySpawner>().UnscheduleEnemySpawner();
        // Show the game over.
        GameOverGO.SetActive(true);
        // Change to the Opening state after a delay of 8 seconds
        Invoke("ChangeToOpeningState", 8f);
        break;
    }
   }

   // Set the game manager state to the specified state and update the game manager state accordingly.
   public void SetGameManagerState(GameManagerState state)
   {
    GMState = state;
    UpdateGameManagerState();
   }
   
   // Start the game play by setting the game manager state to GamePlay and updating the game manager state.
   public void StartGamePlay()
   {
    GMState = GameManagerState.GamePlay;
    UpdateGameManagerState();
   }
   
   // Change the game manager state to Opening.
   public void ChangeToOpeningState()
   {
     SetGameManagerState (GameManagerState.Opening);
   }

   
}

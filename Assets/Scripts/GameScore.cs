using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;

    int score;
   
    // Property to get or set the score
    public int Score
    {
        get
        {
            return this.score;
        }
        set 
        {
            // Update the score and call the method to update the score text UI
            this.score = value;
            UpdateScoreTextUI();
           // Check if the score reaches 5500
           if (score >= 5500)
            {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
            }
           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Get the Text component attached to this game object
        scoreTextUI = GetComponent<Text> ();
    }

    // Update the score text UI with the current score
    void UpdateScoreTextUI()
    {
        // Format the score as a string with leading zeros and update the text UI
        string scoreStr = string.Format ("{0:0000000}", score);
        scoreTextUI.text =scoreStr;
    }
}

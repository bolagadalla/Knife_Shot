using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public int playerScore = 0;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI playerHighscore;
    public bool isAlive = true;
    public GameObject gameOverPanel;
    public GameObject revivePoint;
    //[SerializeField] AudioSource deadSoundEFX;

    private static GameSession instance;
    /// <summary>
    /// Singleton so you can call it from other scripts
    /// </summary>
    public static GameSession Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameSession>();
            }
            return GameSession.instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        playerScoreText.text = playerScore.ToString();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

        }
    }

    /// <summary>
    /// Adds score
    /// </summary>
    /// <param name="scoreTobeAdded">This will be when we have a powerup to 2x the score</param>
    public void AddToScore(int scoreTobeAdded)
    {
        playerScore += scoreTobeAdded;
        playerScoreText.text = playerScore.ToString();
    }

    public void IsPlayerAlive(Rigidbody2D player)
    {
        if(SceneManager.GetActiveScene().buildIndex == 0) { return; } // it will not activate then next code if the scene index is 0
        isAlive = false;
        //deadSoundEFX.Play(); // Play lost sound effect    
        
        // { Creat a Panel for the following} \\
        gameOverPanel.SetActive(true); // This will show the game over panel containing all the buttons after death
    }

    /// <summary>
    /// This will be for the button to send them back to the main menu and reset the score
    /// </summary>
    public void ResetGameSession()
    {
        // Send the player to the 0 indexed scene
        SceneManager.LoadScene(0);
        // Destroying this game object will destroy the singleton which will reset the score
        Destroy(gameObject);
    }
}

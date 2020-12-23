using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    /// <summary>
    /// This is Singleton
    /// </summary>
    void Awake()
    {
        //Finds how many game sessions are there in the scene
        int highscoreCount = FindObjectsOfType<Highscore>().Length;

        // If there is more then one gamesession then destroy this gameobject
        if (highscoreCount > 1)
        {
            Destroy(gameObject);
        }
        // Else it would not be destroied
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        highscoreText.text = "Highscore: \n" + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSession.Instance.playerScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", GameSession.Instance.playerScore);
            highscoreText.text = GameSession.Instance.playerScore.ToString();
        }
    }
}

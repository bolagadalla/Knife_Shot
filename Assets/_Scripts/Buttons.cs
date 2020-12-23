using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    /// <summary>
    /// Reloads the current scene
    /// </summary>
    public void Replay()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Loads the very first scene with index 0, this should be the main menu scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads any scene with the index
    /// </summary>
    /// <param name="sceneIndex"> The Scene Index </param>
    public void PlayGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

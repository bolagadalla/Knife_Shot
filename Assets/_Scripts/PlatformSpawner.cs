using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public int spawnAmount = 20;
    public GameObject[] platformsToSpawn;
    public GameObject platformWillBeSpwaned;
    public GameObject basePlatform;
    public List<GameObject> platformList = new List<GameObject>();
    public GameObject player;

    private static PlatformSpawner instance;
    /// <summary>
    /// Singleton so you can call it from other scripts
    /// </summary>
    public static PlatformSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlatformSpawner>();
            }
            return PlatformSpawner.instance;
        }
    }

    void Start()
    {
        SpawnInitalPlatform();
        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnPlatformToList();
        }
    }

    /// <summary>
    /// Spawns the inital platforms for player
    /// </summary>
    public void SpawnInitalPlatform()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int randomIndex = Random.Range(0, platformsToSpawn.Length);
            basePlatform = Instantiate(platformsToSpawn[randomIndex], basePlatform.transform.GetChild(0).position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Spawns platforms and then addes it to the list
    /// </summary>
    public void SpawnPlatformToList()
    {
        // Spawns platform and then addes it to a list and then sets them deactivate
        int randomIndex = Random.Range(0, platformsToSpawn.Length); // get random index
        var spawnedPlatform = Instantiate(platformsToSpawn[randomIndex], transform.position, Quaternion.identity); // Instanciate
        platformList.Add(spawnedPlatform); // Add the instanctiated GameObject to the list
        spawnedPlatform.SetActive(false); // set it to deactive
    }

    /// <summary>
    /// Spawns a random platform from the list
    /// </summary>
    public void SpawnPlatform ()
    {
        int randomIndex = Random.Range(0, platformList.Count); // creates a random number
        platformWillBeSpwaned = platformList[randomIndex]; // assigning the random game object in the list to the platform that will be spawned //This is bad because it will even pick the activated once\\
        platformWillBeSpwaned.SetActive(true); // Set that platform active
        platformWillBeSpwaned.transform.position = basePlatform.transform.GetChild(0).position; // Set the postion of that platform to the baseplatform position
        basePlatform = platformWillBeSpwaned; // now the game object BasePlatform will be the that platform that was spawned. Making the platform that was spawned to become the new baseplatform
        platformList.Remove(basePlatform); // Removes the gameobject from the list and then we will add it back when it touches a boundry or when its below the player position
    }

    void OnTriggerExit2D(Collider2D other) // Fix this part, it doesnt want to add the platform to the list
    {
        if (other.gameObject.CompareTag("MainBody"))
        {
            Debug.Log("Platform touched the destroyer");
            other.gameObject.SetActive(false);
            platformList.Add(other.gameObject);
        }
    }
    // We can add the destroyer here and instead of destroying the gameobject we can return it back to the list
    // This way it will all be in one code and we dont have to call this code from other codes and increase the Cached size
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        int randomIndex = Random.Range(0, 10);
        int randomScale;
        if (randomIndex % 2 == 0)
        {
            randomScale = -1;
        }
        else
        {
            randomScale = 1;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            PlatformSpawner.Instance.SpawnPlatform();
            PlatformSpawner.Instance.platformWillBeSpwaned.transform.localScale = new Vector3(randomScale, 1, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Launcher : MonoBehaviour
{
    // Variables

    Vector2 playerLaunchSpeed = new Vector2(0f, 20f); // Launch speed
    int currentScore = 1; // This will change when we add powerups, ex, 2XScore

    // Cached Component
    Rigidbody2D playerRigi;
    public ParticleSystem deathPFX;
    GameSession gameSession;


    // Start is called before the first frame update
    void Start()
    {
        playerRigi = this.gameObject.GetComponent<Rigidbody2D>();
        gameSession = GameSession.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region PC CONTROLS

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        // Controls for the unity editor, standalone, and webplayer only
        if (Input.GetMouseButtonDown(0))
        {
            var playerVelocity = GetComponent<Rigidbody2D>();

            // Uses the velocity of the gameobject to move the object forward every time the mouse button is clicked
            playerVelocity.velocity = playerLaunchSpeed;
        }
#endif
        #endregion

        #region MOBILE CONTROL
        if (Input.touchCount > 0)
        {
            var playerVelocity = GetComponent<Rigidbody2D>();

            // Uses the velocity of the gameobject to move the object forward every time the mouse button is clicked
            playerVelocity.velocity = playerLaunchSpeed;
        }
        #endregion
    }

    /// <summary>
    /// Once the player touching the launching spot it will stop
    /// </summary>
    /// <param name="other"> The other gameObject that collided with this gameObject. </param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LaunchSpot"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Stops player movement
            gameSession.AddToScore(currentScore); // Increases score
            gameSession.revivePoint = other.gameObject; // Sets the revive point to the launchspot that we just collided with so we can transform the player there.
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            gameSession.IsPlayerAlive(playerRigi);
            if (gameSession.isAlive == false)
            {
                var deathPartical = Instantiate(deathPFX, transform.position, Quaternion.identity); // Play partical effect here first
                Destroy(deathPartical, 1f);
                gameObject.SetActive(false);
            }
        }
    }

}

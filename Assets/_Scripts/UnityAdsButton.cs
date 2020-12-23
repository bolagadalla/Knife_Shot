using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class UnityAdsButton : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerOriganlPosition;
    GameSession gameSession;

    void Start()
    {
        playerOriganlPosition = player.transform.position;
        gameSession = GameSession.Instance;
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.

                // Change the player position to the next platform
                RevivingThePlayer();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    private void RevivingThePlayer()
    {
        if (gameSession.revivePoint != null)
        {
            Vector3 offset = new Vector3(0, -0.65f, 0);
            player.transform.position = gameSession.revivePoint.transform.position + offset;
            gameSession.gameOverPanel.gameObject.SetActive(false);
            gameSession.playerScore -= 1;
            player.SetActive(true);
        }
        else
        {
            player.transform.position = playerOriganlPosition;
            gameSession.gameOverPanel.gameObject.SetActive(false);
            player.SetActive(true);
        }
    }
}
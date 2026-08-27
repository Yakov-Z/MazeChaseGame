using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to the events
        PlayerController.OnPlayerCaught += GameOver;
        PlayerController.OnExitReached += Victory;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        PlayerController.OnPlayerCaught -= GameOver;
        PlayerController.OnExitReached -= Victory;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Over! Event triggered.");
    }

    private void Victory()
    {
        Time.timeScale = 0f;
        Debug.Log("Victory! Event triggered.");
    }
}
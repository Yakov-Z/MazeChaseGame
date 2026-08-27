using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject gameOverPanel;
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
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    private void Victory()
    {
        Time.timeScale = 0f;
        if (victoryPanel != null) victoryPanel.SetActive(true);
    }

    public void RestartGame()
    {
        // Reset game time back to normal before reloading
        Time.timeScale = 1f;
        
        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {    
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
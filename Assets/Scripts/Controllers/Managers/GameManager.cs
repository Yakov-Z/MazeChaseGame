using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject gameOverPanel;
    [Header("Managers")]
    [SerializeField] private TimerController timerController;
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private TextMeshProUGUI victoryTimeText;
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
        if(timerController != null) timerController.StopTimer();
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    private void Victory()
    {
        Time.timeScale = 0f;
        if (timerController != null) 
        {
            timerController.StopTimer();
            
            // Get the final time and send it to the leaderboard to be saved
            if (leaderboardManager != null)
            {               
                float finalTime = timerController.GetFinalTime();
                if (victoryTimeText != null)
                    victoryTimeText.text = "Your Time: " + finalTime.ToString("F2") + "s";
                leaderboardManager.CheckAndSaveNewTime(finalTime);
            }
        }
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
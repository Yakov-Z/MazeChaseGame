using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject leaderboardPanel;
    // Loads the main game scene when the Play button is clicked
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    // Quits the application
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void accessLeaderboard()
    {
        leaderboardPanel.SetActive(true);
    }
    public void exitLeaderboard()
    {
        leaderboardPanel.SetActive(false);
    }
}
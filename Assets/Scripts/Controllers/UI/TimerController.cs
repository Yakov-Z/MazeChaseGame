using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI timerText;

    private float currentTime = 0f;
    private bool isTimerRunning = false;

    private void Start()
    {
        // Start the timer when the game begins
        isTimerRunning = true;
    }

    private void Update()
    {
        // Only increase time if the timer is actively running
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;
            
            // Format the time to a string with exactly 2 decimal places (e.g., 12.34)
            timerText.text = currentTime.ToString("F2");
        }
    }

    // this function is called from the GameManager when the player wins or dies
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // this function is called to get the final time for the leaderboard
    public float GetFinalTime()
    {
        return currentTime;
    }
}
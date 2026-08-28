using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private TextMeshProUGUI scoresText;

    // This is called automatically when the panel is activated (turned on)
    private void OnEnable()
    {
        UpdateLeaderboardDisplay();
    }

    public void UpdateLeaderboardDisplay()
    {
        if (leaderboardManager == null || scoresText == null) return;

        // Fetch the scores from the disk
        List<float> topScores = leaderboardManager.GetTopScores();
        
        // If there are no scores yet, show a default message
        if (topScores.Count == 0)
        {
            scoresText.text = "No scores yet!";
            return;
        }

        // Build the text block string line by line
        string displayText = "";
        for (int i = 0; i < topScores.Count; i++)
        {
            displayText += (i + 1) + ". " + topScores[i].ToString("F2") + "s\n";
        }

        // Update the UI
        scoresText.text = displayText;
    }
}
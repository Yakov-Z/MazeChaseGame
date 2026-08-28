using UnityEngine;
using System.Collections.Generic;
using System.Linq; // Required for sorting the list

public class LeaderboardManager : MonoBehaviour
{
    // A simple wrapper class so we can serialize the list to JSON
    [System.Serializable]
    private class HighScoreData
    {
        public List<float> topTimes = new List<float>();
    }

    private const string LEADERBOARD_KEY = "MazeLeaderboard";
    private const int MAX_SCORES = 5;

    public void CheckAndSaveNewTime(float timeInSeconds)
    {
        // 1. Load the existing scores from the disk
        HighScoreData data = LoadScores();

        // 2. Add the new time to the list
        data.topTimes.Add(timeInSeconds);

        // 3. Sort ascending (lowest time is the best) and take only the top 5
        data.topTimes = data.topTimes.OrderBy(t => t).Take(MAX_SCORES).ToList();

        // 4. Save the updated list back to the disk
        SaveScores(data);
    }

    private HighScoreData LoadScores()
    {
        // Check if a saved file/key already exists
        if (PlayerPrefs.HasKey(LEADERBOARD_KEY))
        {
            // Read the JSON string and convert it back to a HighScoreData object
            string json = PlayerPrefs.GetString(LEADERBOARD_KEY);
            return JsonUtility.FromJson<HighScoreData>(json);
        }
        
        // Return a fresh object if this is the first time playing
        return new HighScoreData(); 
    }

    private void SaveScores(HighScoreData data)
    {
        // Convert the object to a JSON string
        string json = JsonUtility.ToJson(data);
        
        // Save to PlayerPrefs
        PlayerPrefs.SetString(LEADERBOARD_KEY, json);
        
        // Force Unity to write it to the physical disk immediately
        PlayerPrefs.Save(); 
    }
    public List<float> GetTopScores()
    {
        HighScoreData data = LoadScores();
        return data.topTimes;
    }
}
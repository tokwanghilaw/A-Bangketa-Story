using UnityEngine;
using TMPro;  // For TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI text element
    private int score = 0;

    private void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        // Increase the score by the specified points
        score += points;
        // Update the score text
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score; // Return the current score for other scripts to access
    }

    private void UpdateScoreText()
    {
        // Update the UI text to display the current score
        scoreText.text = "Score: " + score.ToString();
    }
}

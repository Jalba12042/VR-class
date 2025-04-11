using UnityEngine;
using TMPro; // Import TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro scoreText; // Reference to the 3D TextMeshPro object
    private int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}

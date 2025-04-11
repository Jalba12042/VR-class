using UnityEngine;

public class BallScoreTracker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Score")) // Check if it collides with "Score" object
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(1); // Increase score
            }
        }
    }
}

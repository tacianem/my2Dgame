using UnityEngine;

public class ScoreKeeper : MonoBehaviour { // Keeps track of the score in between levels

    public static ScoreKeeper Instance { get; private set; }
    public int score = 0;
    public int previousScore = 0; // Keeps track of the score from previous levels

    private void Awake() {
        if (Instance == null) {
            Instance = this;  // Set the singleton instance
            DontDestroyOnLoad(gameObject);  // Preserve this object across scenes
        } else {
            Destroy(gameObject);  // Destroy duplicate instances
        }
    }

    public void AddScore(int amount) {
        score += amount;
    }

    public void UpdateScore(int newScore) {
        score = newScore;
    }

    public int GetScore() {
        return score;
    }

    public void ResetScore() {
        score = 0;
    }

    public void ResetScores() {
        score = 0;
        previousScore = 0;
    }

    public void SetPreviousScore() { 
       previousScore = score;
    // Debug.Log(previousScore);
    }

    public int GetPreviousScore() {
       return previousScore;
    }

}
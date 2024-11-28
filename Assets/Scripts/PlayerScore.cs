using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour {
    
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    void Start() {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount) {
        score += amount;
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void ResetScore() {
        score = 0;
    }

}

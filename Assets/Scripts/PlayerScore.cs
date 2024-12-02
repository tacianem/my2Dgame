using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour {
    public TextMeshProUGUI scoreText;  // Reference to the UI Text for score display

    void Start() {
        if (scoreText != null) {
            scoreText.text = "Score: " + ScoreKeeper.Instance.GetScore();
        }
    }

    public void AddScore(int amount){
        ScoreKeeper.Instance.AddScore(amount);
        UpdateScoreUI();
    }

    private void UpdateScoreUI() {
        scoreText.text = "Score: " + ScoreKeeper.Instance.GetScore();
    }

}

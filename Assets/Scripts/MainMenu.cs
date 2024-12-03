using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI maxScoreText;

    void Start() {
        int maxScore = GameManager.Instance.maxScore;
        if (maxScore != 0) {
            maxScoreText.text = "Max Score: " + maxScore;
            maxScoreText.gameObject.SetActive(true);
        }
    }

    // Called when we click the "Play" button
    public void OnPlayButton () {
        SceneManager.LoadScene("Level1");
    }

    // Called when we click the "Quit" button
    public void OnQuitButton () {
        Application.Quit();
    }

}
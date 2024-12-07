using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI maxScoreText;
    public Button playButton;
    public Button quitButton;

    void Start() {
        int maxScore = GameManager.Instance.maxScore;
        if (maxScore != 0) {
            maxScoreText.text = "Max Score: " + maxScore;
            maxScoreText.gameObject.SetActive(true);
        }

    playButton.onClick.AddListener(OnPlayButton);
    quitButton.onClick.AddListener(OnQuitButton);

    }

    // Called when we click the "Play" button
    public void OnPlayButton () {
        SceneManager.LoadScene(1);
    }

    // Called when we click the "Quit" button
    public void OnQuitButton () {
        Application.Quit();
    }

    void OnDisable() {
        playButton.onClick.RemoveListener(OnPlayButton);
        quitButton.onClick.RemoveListener(OnQuitButton);
    }

}
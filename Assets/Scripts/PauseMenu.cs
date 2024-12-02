using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour {

    public void OnContinueButton () { // SAVED STATE!!
        GameManager.Instance.LoadState();
    }

    public void OnRestartButton () {
        string lastScene = GameManager.Instance.GetLastScene();
        if (lastScene == "Level1")
            OnNewGameButton();
        else {
            ScoreKeeper.Instance.UpdateScore(ScoreKeeper.Instance.GetPreviousScore());
            SceneManager.LoadScene(lastScene); // Restarts current game level
        }
    }

    public void OnNewGameButton () {
        SceneManager.LoadScene("Level1"); // First game scene
        ScoreKeeper.Instance.ResetScore();
    }

    public void OnQuitButton () {
        Application.Quit();
    }

}
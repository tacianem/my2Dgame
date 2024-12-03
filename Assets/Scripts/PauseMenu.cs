using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour {

    public void OnContinueButton () { // SAVED STATE!!
        GameManager.Instance.SetMaxScore(ScoreKeeper.Instance.GetScore());
        GameManager.Instance.LoadStateFromMenu();
    }

    public void OnRestartButton () {
        string lastScene = GameManager.Instance.GetLastScene();
        if (lastScene == "Level1")
            OnNewGameButton();
        else {
            GameManager.Instance.SetMaxScore(ScoreKeeper.Instance.GetScore());
            ScoreKeeper.Instance.UpdateScore(ScoreKeeper.Instance.GetPreviousScore());
            GameManager.Instance.RestartDestroyed();
            SceneManager.LoadScene(lastScene); // Restarts current game level
        }
    }

    public void OnNewGameButton () {
        GameManager.Instance.SetMaxScore(ScoreKeeper.Instance.GetScore());
        ScoreKeeper.Instance.ResetScores();
        GameManager.Instance.RestartDestroyed();
        SceneManager.LoadScene("Level1"); // First game scene
    }

    public void OnQuitButton () {
        SceneManager.LoadScene("MainMenu");
    }

}
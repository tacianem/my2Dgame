using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour {

    public void OnContinueButton () { // SAVED STATE!!
        GameManager.Instance.LoadState(); // SceneManager.LoadScene("Level1"); --default
    }

    public void OnRestartButton () {
        SceneManager.LoadScene(GameManager.Instance.GetLastScene()); // Restarts current game level
    }

    public void OnNewGameButton () {
        SceneManager.LoadScene("Level1"); // First game scene
    }

    public void OnQuitButton () {
        Application.Quit();
    }

}
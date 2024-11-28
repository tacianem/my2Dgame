using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Called when we click the "Play" button
    public void OnPlayButton () {
        SceneManager.LoadScene("Level1");
    }

    // Called when we click the "Quit" button
    public void OnQuitButton () {
        Application.Quit();
    }

}
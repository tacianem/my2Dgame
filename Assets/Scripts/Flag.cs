using UnityEngine;
using UnityEngine.SceneManagement; 

public class Flag : MonoBehaviour {

    public bool finalLevel = false;
    public string nextLevel;

    private void OnTriggerEnter2D (Collider2D collision) {

        if(collision.CompareTag("Player")) {
            // If this is the final level, go to menu
            if (finalLevel) {
                collision.GetComponent<PlayerScore>().ResetScore();
                SceneManager.LoadScene("MainMenu");
            }
            // Otherwise load up next level
            else {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }

}
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Flag : MonoBehaviour {

    public bool finalLevel = false;
    public string nextLevel;

    private void OnTriggerEnter2D (Collider2D collision) {

        if(collision.CompareTag("Player")) {
            GameManager.Instance.SetMaxScore(ScoreKeeper.Instance.GetScore());
            
            // If this is the final level, go to menu
            if (finalLevel) {
                ScoreKeeper.Instance.ResetScores();
                SceneManager.LoadScene("MainMenu");
            }
            // Otherwise load up next level
            else {
                ScoreKeeper.Instance.SetPreviousScore();
                SceneManager.LoadScene(nextLevel);
            }
        }
    }

}

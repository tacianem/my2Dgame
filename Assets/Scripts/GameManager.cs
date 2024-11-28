using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class GameState {
    public Vector3 playerPosition = Vector3.zero;
    // public int playerHealth;
    public int score = 0;
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance; // Singleton instance
    private string lastScene = ""; // Stores last scene name

    private GameState currentState = new GameState();
    private GameObject player;


    private void Awake() {
        if (Instance == null) { // Ensure there's only one GameManager
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object across scenes
        }
        else {
            Destroy(gameObject); // Destroys duplicates
        }
    }

    private void Start() {
        player = GameObject.FindWithTag("Player"); // Sets the player instance
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) { // Checks if the Escape key is pressed
            // If in gameplay, return to menu
            if (SceneManager.GetActiveScene().name != "PauseMenu") {
                lastScene = SceneManager.GetActiveScene().name; // Stores current scene
                SceneManager.LoadScene("PauseMenu"); // Loads pause menu
            }
            else if (!string.IsNullOrEmpty(lastScene)) { // If in menu, goes back to where it stopped
                // SceneManager.LoadState();
                SceneManager.LoadScene(lastScene); 
            }
        }
    }

    public void LoadState() {
        //player.transform.position = currentState.playerPosition;
        //player.score = currentState.score;
        SceneManager.LoadScene(lastScene); 
    }

    public void SaveState (Vector3 position, /*int health,*/ int score) {
        currentState = new GameState {
            playerPosition = position,
            // playerHealth = health,
            score = score
        };
    }

    public string GetLastScene() {
        return lastScene;
    }

}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[System.Serializable]
public class GameState {
    public Vector3 playerPosition = Vector3.zero;
    public bool isFlippedOnX = false;
    // public int playerHealth;
    public int score = 0;
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance; // Singleton instance
    
    private string lastScene = ""; // Stores last scene name
    private GameState currentState = new GameState();
    private GameObject player;
    private HashSet<string> destroyedObjs = new HashSet<string>();

    public int maxScore = 0;

    private void Awake() {
        if (Instance == null) { // Ensure there's only one GameManager
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object across scenes
        }
        else {
            Destroy(gameObject); // Destroys duplicates
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) { // Checks if the Escape key is pressed
            // If in gameplay, return to menu
            if (SceneManager.GetActiveScene().name != "PauseMenu") {
                lastScene = SceneManager.GetActiveScene().name; // Stores last scene
                player = GameObject.FindWithTag("Player"); // Sets the player instance
                SaveState(player.transform.position, player.GetComponent<SpriteRenderer>().flipX, ScoreKeeper.Instance.GetScore());
                SceneManager.LoadScene("PauseMenu"); // Loads pause menu
            }
            else if (!string.IsNullOrEmpty(lastScene)) { // If in menu, goes back to where it stopped
                StartCoroutine(LoadState());
            }
        }
    }

    public void SetMaxScore(int score) {
        if(score > maxScore)
            maxScore = score;
    }

    public void LoadStateFromMenu() {
        StartCoroutine(LoadState());
    }

    private IEnumerator LoadState() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(lastScene);
        while (!asyncLoad.isDone) {
            yield return null; // Wait until the scene is loaded
        }

        player = GameObject.FindWithTag("Player"); // Sets the player instance
        player.transform.position = currentState.playerPosition;
        player.GetComponent<SpriteRenderer>().flipX = currentState.isFlippedOnX;
        ScoreKeeper.Instance.UpdateScore(currentState.score);
        DestroyObjects();
    }

    public void SaveState (Vector3 position, bool flipX, int score) {
        currentState.playerPosition = position;
        currentState.isFlippedOnX = flipX;
        currentState.score = score;
    }

    public string GetLastScene() {
        return lastScene;
    }

    public void RestartDestroyed () {
        destroyedObjs = new HashSet<string>();
        // Debug.Log("It's now empty!!");
    }

    public void RegisterDestroyedObject(string objName) {
        destroyedObjs.Add(objName);
        // Debug.Log(objName);
    }

    private void DestroyObjects () {
        // Loop through all the previously destroyed objects to redestroy them and recreate the scene
        foreach (string obj in destroyedObjs) {
            // Find the object in the current scene
            GameObject gameObj = GameObject.Find(obj);
            
            if (gameObj != null) {
                Destroy(gameObj); // Destroys the object
                // Debug.Log("Destroyed " + obj);
            }
        }
    }

}
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;

// public class GameManager : MonoBehaviour {

//     public static GameManager Instance; // Singleton instance
//     private string lastScene = ""; // Stores last scene name
//     public TextMeshProUGUI playButtonText;

//     private void Awake() {
//         if (Instance == null) { // Ensure there's only one GameManager
//             Instance = this;
//             DontDestroyOnLoad(gameObject); // Keeps this object across scenes
//         }
//         else {
//             Destroy(gameObject); // Destroys duplicates
//             SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to sceneLoaded event
//         }
//     }

//     private void OnDestroy() {
//         if (Instance == this) {
//             SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to avoid memory leaks
//         }
//     }

//     private void Update() {
//         if (Input.GetKeyDown(KeyCode.Escape)) { // Checks if the Escape key is pressed
//             // If in gameplay, return to menu
//             if (SceneManager.GetActiveScene().name != "Menu") {
//                 lastScene = SceneManager.GetActiveScene().name; // Stores current scene
//                 SceneManager.LoadScene("Menu"); // Loads menu
//             }
//             else if (!string.IsNullOrEmpty(lastScene)) { // If in menu, goes back to last scene
//                 SceneManager.LoadScene(lastScene);
//             }
//         }
//     }

//     private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
//         // Check if the menu scene is loaded
//         if (scene.name == "Menu") {
//             UpdateMenuUI(); // Call OnMenuLoaded to update the button text
//         }
//     }

//     private void UpdateMenuUI() { // Change play button text dynamically
//         if (playButtonText != null && !string.IsNullOrEmpty(lastScene)) {
//             playButtonText.text = "Restart";
//         }
//         else {
//             playButtonText.text = "Play";
//         }
//     }

// }
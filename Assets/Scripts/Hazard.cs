using UnityEngine;

public class Hazard : MonoBehaviour {

    private void OnTriggerEnter2D (Collider2D collision) {
        if(collision.CompareTag("Player")) {
            // Triggers the game over state on the player class
            collision.GetComponent<PlayerController>().GameOver();
        }
    }

}

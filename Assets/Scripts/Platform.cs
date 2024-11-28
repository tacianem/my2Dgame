using UnityEngine;

public class Platform : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // Sets the player as a child of the platform
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // Unparents the player when it leaves the platform
            collision.transform.SetParent(null);
        }
    }
    
}
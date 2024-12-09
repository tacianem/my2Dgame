using UnityEngine;

public class Platform : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        foreach (ContactPoint2D contact in collision.contacts) {
            Debug.Log("" + contact.normal);

            if (collision.gameObject.CompareTag("Player") && contact.normal.y == -1) {
                // collision.gameObject.GetComponent<PlayerController>().UpdatePosOnPlatform(gameObject, transform.position);

                // Sets the player as a child of the platform
                collision.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // collision.gameObject.GetComponent<PlayerController>().LeavePlatform();

            // Unparents the player when it leaves the platform
            collision.transform.SetParent(null);
        }
    }
    
}
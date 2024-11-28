using UnityEngine;

public class Trampoline : MonoBehaviour {

    public Sprite normalSprite;
    public Sprite compressedSprite;
    public float bounceForce = 30f;  // Upward force applied to the player

    private SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {

            // Checks the contact point to make sure the collision is on the top surface
            foreach (ContactPoint2D contact in collision.contacts) {

                // Debug.Log("" + collision.contacts.Length);
                // Debug.Log("" + contact.normal);

                // Checks if the contact point is coming from above
                if (contact.normal.y == -1) { // Ensures the contact is from the top
                    sr.sprite = compressedSprite;
                    collision.gameObject.GetComponent<PlayerJump>().JumpTrampoline(bounceForce);

                    // Resets the trampoline sprite after a short delay
                    Invoke("ResetSprite", 0.1f);

                    break;  // Exits loop after applying force
                }
                
            }
        }
    }

    private void ResetSprite() {
        // Resets the trampoline sprite to the normal state
        sr.sprite = normalSprite;
    }


    // public void ChangeSprite(string path) {
    //     Sprite newSprite = Resources.Load<Sprite>(path);
        
    //     if (newSprite != null) {
    //         // Set the sprite on the SpriteRenderer
    //         sr.sprite = newSprite;
    //     }
    // }

}

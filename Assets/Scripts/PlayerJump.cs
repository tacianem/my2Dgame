using UnityEngine;

public class PlayerJump : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float jumpForce = 11f;

    private bool isGrounded;
    private bool isJumping;
    private bool trampolineJump = false;

    void FixedUpdate () {
        if (isJumping) {
            isJumping = false;
            if(trampolineJump && rb.linearVelocity.y >= 0) {
                trampolineJump = false;
                rb.AddForce(Vector2.up * (jumpForce)/8, ForceMode2D.Impulse);
            }
            else {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
            isJumping = true;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if(Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.8f) { // Both vector upright returns a perfect 1, but we're accounting for some minor differences
            isGrounded = true;
            trampolineJump = false;
        }
    }

    public void JumpTrampoline(float bounceForce) { // Applies an upward force to the player
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
        isGrounded = false;
        trampolineJump = true;
    }

}

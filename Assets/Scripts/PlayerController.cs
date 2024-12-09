using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour { //Responsible for player movement and Game Over
    
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float moveSpeed;

    // private bool onPlatform = false;
    // private GameObject platform;
    // private Vector3 previousPlatformPos;

    void FixedUpdate () { // Runs a fixed 60 times per second (used for physics)
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 0 or 1 depending if it's left stopped or right
        rb.linearVelocity = new Vector2(moveInput * moveSpeed,rb.linearVelocity.y);

        if(rb.linearVelocity.x > 0) { // Moving to the right
            sr.flipX = true; // Flips the sprite to look to the right
        }
        else if(rb.linearVelocity.x < 0) {
            sr.flipX = false; // Uses default sprite
        }

        // if(onPlatform) {
        //     Vector3 platformMovement = platform.transform.position - previousPlatformPos;
        //     Vector3 playerPos = transform.position;
        //     playerPos.x += platformMovement.x;
        //     transform.position = playerPos;
        //     previousPlatformPos = playerPos;
        // }
    }

    void Update() { // Called every single frame (once per frame)
        if(transform.position.y <= -5) { //Dies when much too down on the Y axis
            GameOver();
        }
    }

    // public void UpdatePosOnPlatform(GameObject gameObject, Vector3 pos) {
    //     onPlatform = true;
    //     platform = gameObject;
    //     previousPlatformPos = pos;
    // }

    // public void LeavePlatform() {
    //     onPlatform = false;
    // }

    public void GameOver () { // Reloads current scene
        gameObject.GetComponent<PlayerCollectibles>().LoseKey();
        GameManager.Instance.RestartDestroyed();
        GameManager.Instance.SetMaxScore(ScoreKeeper.Instance.GetScore());
        ScoreKeeper.Instance.UpdateScore(ScoreKeeper.Instance.GetPreviousScore());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

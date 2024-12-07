using UnityEngine;

public class Coin : MonoBehaviour {
    
    private void OnTriggerEnter2D (Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<PlayerScore>().AddScore(1); // Adds to the score of the player
            GameManager.Instance.AddDestroyedObject(gameObject.name);
            Destroy(gameObject);
        }
    }

}

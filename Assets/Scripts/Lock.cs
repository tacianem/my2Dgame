using UnityEngine;

public class Lock : MonoBehaviour {

    private void OnCollisionEnter2D (Collision2D collision) {

        if(collision.gameObject.CompareTag("Player")) { 
            PlayerCollectibles playerCollectible = collision.gameObject.GetComponent<PlayerCollectibles>();
            
            if (PlayerCollectibles.hasKey) {
                playerCollectible.UseKeyOnLock();
                Destroy(gameObject);
            }
        }

    }

}

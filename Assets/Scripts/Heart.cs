using UnityEngine;

public class Heart : MonoBehaviour {

    private void OnTriggerEnter2D (Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<PlayerCollectibles>().GetHeart();
            GameManager.Instance.AddDestroyedObject(gameObject.name);
            Destroy(gameObject);
        }
    }

}

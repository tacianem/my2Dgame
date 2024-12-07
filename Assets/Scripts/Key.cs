using UnityEngine;

public class Key : MonoBehaviour {

    private void OnTriggerEnter2D (Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<PlayerCollectibles>().GetKey();
            GameManager.Instance.AddDestroyedObject(gameObject.name);
            Destroy(gameObject);
        }
    }

}

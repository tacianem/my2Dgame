using UnityEngine;
using System.Collections;

public class SwitchSprite : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;
    public float interval = 0.2f;

    private SpriteRenderer sr;
    private bool isSprite1 = true; // Tracks which sprite is currently displayed

    void Start() {
        sr = GetComponent<SpriteRenderer>();

        if (sr == null || sprite1 == null || sprite2 == null) {
            Debug.LogError("SpriteRenderer or sprites not assigned!");
            return;
        }

        StartCoroutine(AlternateSprites());
    }

    private IEnumerator AlternateSprites() {
        while (true) {
            sr.sprite = isSprite1 ? sprite1 : sprite2;
            isSprite1 = !isSprite1;

            // Waits for the specified interval before switching again
            yield return new WaitForSeconds(interval);
        }
    }

}

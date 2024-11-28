// using UnityEngine;

// public class SwitchSprite : MonoBehaviour {

//     public Sprite normalSprite;
//     public Sprite flippedSprite;
//     public float spriteInterval = 0f;

//     private SpriteRenderer sr;
//     private bool isNormalSprite = true; // Tracks which sprite is currently displayed

//     void Start() {
//         sr = GetComponent<SpriteRenderer>();

//         if (sr == null || normalSprite == null || flippedSprite == null) {
//             Debug.LogError("SpriteRenderer or sprites not assigned!");
//             return;
//         }

//         // Starts alternating sprites at a regular interval
//         InvokeRepeating("AlternateSprites", 0f, spriteInterval);
//     }

//     private void  AlternateSprites() {
//         sr.sprite = isNormalSprite ? normalSprite : flippedSprite;
//         isNormalSprite = !isNormalSprite;
//     }

// }

using UnityEngine;

public class FloatSprite : MonoBehaviour {
    
    public float moveSpeed = 2f;
    public float moveDistance = 0.2f;  // Distance the object floats up and down

    private Vector3 startPos;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        // Calculates new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        
        // Apply new position
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

}

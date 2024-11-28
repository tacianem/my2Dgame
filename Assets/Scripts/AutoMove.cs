using UnityEngine;

public class AutoMovement : MonoBehaviour {

    public float moveSpeed = 1.2f;
    public Vector3 moveOffset;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start() {
        startPos = transform.position;
        endPos = startPos;
    }

    void Update() {
        // Moves towards the target position
        transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime); // Turns per frame into per second

        // Are we at the target position?
        if(transform.position == endPos) {
            // If endPos equals to startPos, invert
            if(endPos == startPos) {
                endPos = startPos + moveOffset;
            }
            else {
                endPos = startPos;
            }
        }
    }

}
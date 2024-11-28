using UnityEngine;

public class PlayerCollectibles : MonoBehaviour {
    
    public static bool hasKey = false;

    public void GetKey () {
        hasKey = true;
    }

    public void UseKeyOnLock () {
        hasKey = false;
        gameObject.GetComponent<DisplayMessage>().ShowMessage("Key used!");
    }

    public void GetHeart () {
        gameObject.GetComponent<PlayerScore>().AddScore(50);
    }

}

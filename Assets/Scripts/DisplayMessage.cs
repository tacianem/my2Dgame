using UnityEngine;
using TMPro;

public class DisplayMessage : MonoBehaviour {

    public TextMeshProUGUI messageText;

    public void ShowMessage(string message) {
        // Debug.Log(message);

        messageText.text = message;
        messageText.gameObject.SetActive(true);

        Invoke("HideMessage", 1f);
    }

    void HideMessage() {
        messageText.gameObject.SetActive(false);
    }

}
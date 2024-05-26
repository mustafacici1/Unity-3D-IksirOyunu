using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    public Text startMessageText;

    void Start()
    {
        // Mesajı başlangıçta göster ve 5 saniye sonra gizle
        startMessageText.gameObject.SetActive(true);
        Invoke("HideMessage", 5f);
    }

    void HideMessage()
    {
        startMessageText.gameObject.SetActive(false);
    }
}

using UnityEngine;

public class Tarif : MonoBehaviour
{
    public GameObject tarifCanvas;
    public GameObject player;
    public GameObject scrollOpen;
    public float interactionDistance = 2.0f;

    private bool isCanvasVisible = false;

    void Start()
    {
        // Canvas'ı başlangıçta gizle
        tarifCanvas.SetActive(false);
    }

    void Update()
    {
        // Oyuncu ve Scroll_Open nesnesi arasındaki mesafeyi hesapla
        float distance = Vector3.Distance(player.transform.position, scrollOpen.transform.position);

        // Eğer oyuncu yeterince yakınsa ve "k" tuşuna basarsa
        if (distance <= interactionDistance && Input.GetMouseButtonDown(0))
        {
            // Canvas'ın görünürlüğünü değiştir
            isCanvasVisible = !isCanvasVisible;
            tarifCanvas.SetActive(true);
        }
        if (distance > interactionDistance)
        {
            tarifCanvas.SetActive(false);
        }

        if (distance <= interactionDistance && !isCanvasVisible)
        {
            if(Input.GetMouseButtonDown(0))
            {
                tarifCanvas.SetActive(false);
            }
        }
    }
}

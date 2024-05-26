using UnityEngine;

public class RenkIzleyici : MonoBehaviour
{
    Renderer rend;
    public GameObject shield;
    public GameObject gorevCanvas;
    public GameObject panelText;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Nesnenin materyalini kontrol et
        if (rend.material.name.Contains("blue"))
        {
            // Shield nesnesine temas ediyorsa
            if (Vector3.Distance(transform.position, shield.transform.position) < 1.0f)
            {
                // Nesneyi yok et
                Destroy(gameObject);
                // PanelText nesnesini gizle
                panelText.SetActive(false);
            }
        }
    }
}

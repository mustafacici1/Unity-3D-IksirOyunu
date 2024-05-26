using UnityEngine;
using UnityEngine.UI;

public class ShieldColorChecker : MonoBehaviour
{
    public Image taskImage; // Görev panelindeki Image bileşeni
    public GameObject textLegacy; // Text(legacy)(1) bileşeni

    private void OnCollisionEnter(Collision collision)
    {
        // Eğer çarpışan nesne Bottle_03 (4) ise
        if (collision.gameObject.name == "Bottle_03 (4)")
        {
            Renderer bottleRenderer = collision.gameObject.GetComponent<Renderer>();

            if (bottleRenderer != null)
            {
                Color bottleColor = bottleRenderer.material.color;

                // Belirli bir alana düşen cismin rengi mavi ise (0, 0, 255)
                if (bottleColor.r == 0f && bottleColor.g == 0f && bottleColor.b == 1f)
                {
                    // Task Image görünür yapma
                    taskImage.enabled = true;

                    // Text(legacy)(1) gizleme
                    textLegacy.SetActive(false);

                    // Bottle cismi yok etme
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}

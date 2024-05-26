using UnityEngine;

public class Renk_Degisim : MonoBehaviour
{
    private Renderer bottleRenderer; // Bottle_03 nesnesinin Renderer bileşeni

    private void Start()
    {
        // Bottle_03 nesnesinin Renderer bileşenini al
        bottleRenderer = GetComponent<Renderer>();

        if (bottleRenderer == null)
        {
            Debug.LogError("Bottle_03 nesnesinde Renderer bileşeni bulunamadı.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kazan"))
        {
            // Kazan nesnesinin Renderer bileşenini al
            Renderer cauldronRenderer = other.GetComponent<Renderer>();

            if (cauldronRenderer != null)
            {
                // Kazanın materyallerini al
                Material[] cauldronMaterials = cauldronRenderer.materials;

                // Kazanın indeks 2 materyalini al
                if (cauldronMaterials.Length > 2)
                {
                    Material cauldronMaterial = cauldronMaterials[2];

                    // Bottle_03'ün materyalinin rengini, kazanın indeks 2 materyalinin rengine ayarla
                    bottleRenderer.material.color = cauldronMaterial.color;
                    Debug.Log($"Bottle_03'ün rengi değiştirildi: {cauldronMaterial.color}");
                }
                else
                {
                    Debug.LogWarning("Kazan nesnesinde yeterli materyal bulunmuyor.");
                }
            }
            else
            {
                Debug.LogError("Kazan nesnesinde Renderer bileşeni bulunamadı.");
            }
        }
    }
}

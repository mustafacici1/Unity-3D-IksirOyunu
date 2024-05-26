using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public Material defaultMaterial; // Cauldron'un varsayılan materyali
    public Renderer cauldronRenderer; // Cauldron'un renderer bileşeni

    private void OnTriggerEnter(Collider other)
    {
        // Collider'ı kontrol ederek içine atılan nesneyi belirle
        GameObject otherObject = other.gameObject;

        // Eğer içine atılan nesnenin bir Renderer bileşeni varsa
        if (otherObject.GetComponent<Renderer>() != null)
        {
            // Cauldron'un rengini içine atılan nesnenin rengi ile değiştir
            cauldronRenderer.material = otherObject.GetComponent<Renderer>().material;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Eğer içinden bir şey çıktıysa, varsayılan materyale geri dön
        cauldronRenderer.material = defaultMaterial;
    }
}

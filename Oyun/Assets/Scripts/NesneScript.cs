using UnityEngine;

public class NesneScript : MonoBehaviour
{
    private Vector3 initialPosition; // Nesnenin başlangıç konumu
    private Quaternion initialRotation; // Nesnenin başlangıç rotasyonu

    private void Start()
    {
        // Başlangıç konumunu ve rotasyonunu kaydet
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void ResetObject()
    {
        // Nesnenin konumunu ve rotasyonunu başlangıç değerlerine sıfırla
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        // Nesnenin hızını ve dönüş hızını sıfırla
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
    
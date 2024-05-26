using UnityEngine;
using UnityEngine.UI;

public class ShieldKontrol : MonoBehaviour
{
    public GameObject zindan1;
    public Canvas gorevCanvas;
    public GameObject taskImage;
    public GameObject textLegacy;
    public GameObject cauldronFull; // Cauldron_Full nesnesini ekled ik


    private void Start()
    {
        // UI bileşenlerine doğru şekilde erişim sağlayın
        taskImage = gorevCanvas.transform.Find("Panel/Image").gameObject;
        textLegacy = gorevCanvas.transform.Find("Panel/Text (Legacy)(1)").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        Renderer rend = other.GetComponent<Renderer>();

        if (rend != null)
        {
            // Nesnenin rengini al
            Color renk = rend.material.color;

            // Belirli bir RGB renge göre kontrol et
            if (IsColorSimilar(renk, new Color(191f / 255f, 218f / 255f, 128f / 255f)))
            {
                zindan1.SetActive(false);
                taskImage.SetActive(true);
                textLegacy.SetActive(false);
                Destroy(other.gameObject);
           

                
            }
        }
    }

    // Verilen iki renk arasında benzerlik kontrolü yapar
    bool IsColorSimilar(Color color1, Color color2)
    {
        // Renklerin her bir bileşenini mutlak değeri ile karşılaştırır
        // 0.01 eşik değeriyle yeterince benzer olup olmadığını kontrol eder
        return Mathf.Abs(color1.r - color2.r) <= 0.01f &&
               Mathf.Abs(color1.g - color2.g) <= 0.01f &&
               Mathf.Abs(color1.b - color2.b) <= 0.01f;
    }
}

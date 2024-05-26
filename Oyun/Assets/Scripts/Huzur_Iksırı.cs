using UnityEngine;
using UnityEngine.UI;

public class Huzur_Iksırı : MonoBehaviour
{
    public GameObject zindan2;
    public GameObject zindan3;
    public GameObject kılıt1;
    public GameObject kılıt2;
    public Canvas gorevCanvas;
    public GameObject taskImage;
    public GameObject textLegacy;


    private void Start()
    {
        // UI bileşenlerine doğru şekilde erişim sağlayın
        taskImage = gorevCanvas.transform.Find("Panel/Image(1)").gameObject;
        textLegacy = gorevCanvas.transform.Find("Panel/Text (Legacy)(2)").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        Renderer rend = other.GetComponent<Renderer>();

        if (rend != null)
        {
            // Nesnenin rengini al
            Color renk = rend.material.color;

            // Belirli bir RGB renge göre kontrol et
            if (IsColorSimilar(renk, new Color(191f / 255f, 191f / 255f, 191f / 255f)))
            {
                zindan3.SetActive(false);
                kılıt1.SetActive(false);
                kılıt2.SetActive(false);
                zindan2.SetActive(false);
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

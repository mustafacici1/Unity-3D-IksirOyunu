using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KazanScript : MonoBehaviour
{
    private Renderer cauldronRenderer; // Kazanın renderer bileşeni
    private List<Color> liquidColors = new List<Color>(); // Kazanın içindeki sıvıların renkleri

    // Sıvının materyalinin indexi
    public int liquidMaterialIndex = 2; // "potion" materyali sıvıyı temsil ediyor

    private void Start()
    {
        // Kazanın renderer bileşenini al
        cauldronRenderer = GetComponent<Renderer>();
        if (cauldronRenderer == null)
        {
            Debug.LogError("Renderer component not found on the game object!");
            return;
        }

        // Başlangıçta içinde bir sıvı yoksa varsayılan bir renk atayın
        ResetCauldron();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("canPickUp") && liquidMaterialIndex >= 0)
        {
            // Eğer nesne Renk_Degisim scriptine sahipse
            Renk_Degisim renkDegisimScript = other.GetComponent<Renk_Degisim>();
            NesneScript nesneScript = other.GetComponent<NesneScript>();

            if (renkDegisimScript != null)
            {
                // Nesnenin rengini kazandaki sıvının rengiyle değiştir
                Renderer otherRenderer = other.GetComponent<Renderer>();
                if (otherRenderer != null)
                {
                    otherRenderer.material.color = CalculateAverageColor();
                }

                // Kazanın içindeki sıvı renklerini sıfırla 3 saniye sonra
                StartCoroutine(ResetCauldronAfterDelay(3f));

                // Nesneyi başlangıç konumuna geri gönder
                if (nesneScript != null)
                {
                    nesneScript.ResetObject();
                }
            }
            else
            {
                // Kazana atılan nesnenin rengini al
                Color newColor = other.GetComponent<Renderer>().material.color;

                // Kazanın içindeki sıvı renklerini güncelleyin
                liquidColors.Add(newColor);

                // Materyal rengini güncelleyin
                ApplyLiquidColor();

                // Nesneyi başlangıç konumuna geri gönder
                if (nesneScript != null)
                {
                    nesneScript.ResetObject();
                }
            }
        }
        else
        {
            Debug.LogWarning("Cannot change color because liquid material index is not set correctly or tag is incorrect.");
        }
    }

    // Kazanın içindeki sıvının rengini güncelleyen fonksiyon
    private void ApplyLiquidColor()
    {
        // Kazandaki tüm renklerin ortalamasını alın
        Color mixedColor = CalculateAverageColor();

        // Kazanın sıvı materyalinin rengini ayarla
        Material[] materials = cauldronRenderer.materials;
        if (liquidMaterialIndex < materials.Length)
        {
            materials[liquidMaterialIndex].color = mixedColor;
            cauldronRenderer.materials = materials;
        }
    }

    // Tüm sıvı renklerinin ortalamasını hesaplayan fonksiyon
    private Color CalculateAverageColor()
    {
        if (liquidColors.Count == 0)
        {
            return Color.white; // Eğer sıvı yoksa varsayılan bir renk dönün
        }

        float totalR = 0f;
        float totalG = 0f;
        float totalB = 0f;

        // Tüm renkleri toplayın
        foreach (Color color in liquidColors)
        {
            totalR += color.r;
            totalG += color.g;
            totalB += color.b;
        }

        // Ortalama renk değerlerini hesaplayın
        float avgR = totalR / liquidColors.Count;
        float avgG = totalG / liquidColors.Count;
        float avgB = totalB / liquidColors.Count;

        return new Color(avgR, avgG, avgB);
    }

    // Kazanın içindeki sıvıyı sıfırlayan fonksiyon
    private void ResetCauldron()
    {
        liquidColors.Clear();
        liquidColors.Add(Color.white);
        ApplyLiquidColor();
    }

    // Belirli bir süre sonra kazanın içindeki sıvıyı sıfırlayan coroutine
    private IEnumerator ResetCauldronAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetCauldron();
    }
}

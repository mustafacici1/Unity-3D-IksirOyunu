using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tab : MonoBehaviour
{
    public GameObject canvas;

    private void Start()
    {
        // Canvas'ı başlangıçta gizle
        canvas.SetActive(false);
    }

    void Update()
    {
        // Tab tuşuna basıldığında ve canvas aktif değilse canvas'ı görünür yap
        if (Input.GetKeyDown(KeyCode.Tab) && !canvas.activeSelf)
        {
            canvas.SetActive(true);
        }
        // Tab tuşu bırakıldığında ve canvas aktif ise canvas'ı gizle
        else if (Input.GetKeyUp(KeyCode.Tab) && canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
    }
}

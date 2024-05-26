using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missions : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { 
            SceneManager.LoadSceneAsync(2);
        }
    }
}

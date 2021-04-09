using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string scene;
    public GameObject loadingScreen;

    public void OnButtonPress()
    {
        if (!string.IsNullOrEmpty(scene))
        {
            if (loadingScreen != null)
            {
                loadingScreen.SetActive(true);
            }
            
            SceneManager.LoadScene(scene);
        }
        else
        {
            Application.Quit();
        }
    }
}

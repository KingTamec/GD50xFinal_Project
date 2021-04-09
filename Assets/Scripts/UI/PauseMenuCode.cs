using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuCode : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Time.timeScale = 1;
            transform.gameObject.SetActive(false);
        }
        
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}

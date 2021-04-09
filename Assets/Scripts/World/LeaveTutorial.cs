using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaveTutorial : MonoBehaviour
{   public GameObject player;
    public Image flashEffect;

    private float alpha = 0f;
    void Update()
    {
        if (player.transform.position.y <= 600)
        {
            if (alpha < 1f)
            {
                alpha += Time.deltaTime;
            }
            if (alpha >= 1f)
            {
                alpha = 1f;
            }
            flashEffect.color = new Color (1,1,1,alpha);
        }

        if (player.transform.position.y <= 300)
        {
            SceneManager.LoadScene("Game");
        }
    }
}

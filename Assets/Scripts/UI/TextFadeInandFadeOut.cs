using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInandFadeOut : MonoBehaviour
{
    public float startFadeInTime;
    public float fadeInDuration;
    public float readDuration;
    public float fadeOutDuration;

    private float time;
    private float alpha;
    private bool fadedIn;


    void Start()
    {
        time = 0f;
        alpha = 0f;
        fadedIn = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > startFadeInTime && !fadedIn)
        {
            if (alpha < 1f)
            {
                alpha += Time.deltaTime/fadeInDuration;
            }
            
            if (alpha > 1f)
            {
                alpha = 1f;
                fadedIn = true;
            }
    
            gameObject.GetComponent<Text>().color = new Color(1,1,1,alpha);
        }

        if (time > (startFadeInTime + fadeInDuration + readDuration))
        {
            alpha -= Time.deltaTime/fadeOutDuration;
            if (alpha <= 0)
            {
                Destroy(gameObject);
            }
            gameObject.GetComponent<Text>().color = new Color(1,1,1,alpha);
        }

    }
}

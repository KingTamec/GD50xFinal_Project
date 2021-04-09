using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public int activationTime;
    public ProgressBar progressBar;
    public GameObject playerHUD;
    public AudioClip[] activationSounds;
    [HideInInspector] public bool active = false;

    private AudioSource audioSource;
    private bool inZone = false;
    private float zoneTime;
    private ProgressBar activeBar;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!active)
        {

            if (inZone == true)
            {
                zoneTime += Time.deltaTime;
                activeBar.SetValue(zoneTime);
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = activationSounds[0];
                    audioSource.PlayOneShot(audioSource.clip);
                }
            }
            else
            {
                zoneTime = 0.0f;
                audioSource.Stop();
            }

            if (zoneTime >= activationTime)
            {   
                audioSource.Stop();
                audioSource.clip = activationSounds[1];
                audioSource.PlayOneShot(audioSource.clip);
                zoneTime = 0.0f;
                inZone = false;
                Destroy(activeBar.gameObject);
                transform.GetChild(0).gameObject.SetActive(true);
                active = true;
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Player" && !active)
        {
            activeBar = Instantiate(progressBar, playerHUD.transform);
            activeBar.SetMaxValue(activationTime);
            inZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" && !active)
        {
            inZone = false;
            if (activeBar != null)
            {
                Destroy(activeBar.gameObject);
            }
            zoneTime = 0.0f;
        }
    }
}

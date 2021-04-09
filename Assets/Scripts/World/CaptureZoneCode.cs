using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureZoneCode : MonoBehaviour
{
    public int captureTime = 6;
    public List<GameObject> spawners = new List<GameObject>();
    public List<GameObject> nextSpawners = new List<GameObject>();
    public List<GameObject> instantSpawns = new List<GameObject>();
    public ProgressBar progressBar;
    public GameObject playerHUD;
    public GameObject wall;
    public GameObject allRemainingIcos;
    public AudioClip[] activationSounds;
    
    private AudioSource audioSource;
    private float zoneTime = 0.0f;
    private bool inZone = false;
    private bool cleared = false;
    private bool shrinkedSpawner = false;
    private float scaleValue = 1f;
    private float shrinkSpeed = 2f;

    private ProgressBar activeBar;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Player" && !cleared)
        {
            activeBar = Instantiate(progressBar, playerHUD.transform);
            activeBar.SetMaxValue(captureTime);
            inZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player" && !cleared)
        {
            inZone = false;
            Destroy(activeBar.gameObject);
            zoneTime = 0.0f;
        }
    }

    void Update()
    {
        if (!cleared)
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

            if (zoneTime >= captureTime)
            {
                foreach (var spawner in spawners)
                {
                    spawner.GetComponent<IcoSpawner>().StopAllCoroutines();
                    Destroy(spawner, 2f);
                }

                audioSource.Stop();
                audioSource.clip = activationSounds[1];
                audioSource.PlayOneShot(audioSource.clip);

                zoneTime = 0.0f;
                inZone = false;
                Destroy(activeBar.gameObject);
                Destroy(transform.GetChild(0).gameObject);

                if (nextSpawners != null)
                {
                    foreach (var spawner in nextSpawners)
                    spawner.SetActive(true);
                }
                cleared = true;
                Destroy(wall);

                if (instantSpawns != null)
                {
                    foreach (var spawn in instantSpawns)
                    spawn.SetActive(true);
                }

                if (allRemainingIcos != null)
                {
                    for (int i = 0; i < 8; i ++)
                    {
                        Transform holder = allRemainingIcos.transform.GetChild(i);
                        foreach (Transform child in holder)
                            child.GetComponent<Target>().Die();
                    }
                }
            }
        }
        else if (!shrinkedSpawner)
        {
            if (scaleValue > 0f)
            {
                scaleValue -= shrinkSpeed * Time.deltaTime;
                Vector3 scale = new Vector3(scaleValue, scaleValue, scaleValue);
                foreach (var spawner in spawners)
                {
                    spawner.transform.localScale = scale;
                }
            }
            else 
            {
                foreach (var spawner in spawners)
                {
                    spawner.transform.localScale = new Vector3(0, 0, 0);
                }
                shrinkedSpawner = true;
            }
        }
    }
}

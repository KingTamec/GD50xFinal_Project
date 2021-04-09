using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterFinalRoom : MonoBehaviour
{
    public GameObject icoBoss;
    public List<GameObject> spawners = new List<GameObject>();
    public AudioClip bossMusic;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource music = other.GetComponent<Player>().gameMusic;
            music.clip = bossMusic;
            music.Play();
            icoBoss.SetActive(true);
            
            foreach (var spawner in spawners)
            spawner.SetActive(true);
            
            Destroy(transform.GetComponent<BoxCollider>());
        }
    }
}

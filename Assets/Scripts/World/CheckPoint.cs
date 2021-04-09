using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();
    public List<GameObject> instantSpawns = new List<GameObject>();
    public GameObject allRemainingIcos;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (spawners != null)
            {
                foreach (var spawner in spawners)
                spawner.SetActive(true);
            }
            
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

            Destroy(gameObject);
        }   
    }
}

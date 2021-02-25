using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleCode : MonoBehaviour
{
    public GameObject player;

    public GameObject destroyable;

    public float maxCaptureDistance = 1f;
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(player.transform.position, transform.position) < maxCaptureDistance)
        {
            Destroy(destroyable);
        }
    }
}

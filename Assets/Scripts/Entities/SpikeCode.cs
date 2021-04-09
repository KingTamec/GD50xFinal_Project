using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCode : MonoBehaviour
{
    public float spikeSpeed = 5f;
    
    private Vector3 target;
    private Vector3 normalizedDirection;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        normalizedDirection = (target - transform.position).normalized;

        transform.LookAt(target);
        transform.RotateAround(transform.position, transform.right, 90);        
    }

    void Update()
    {
        transform.position += normalizedDirection * spikeSpeed*Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) > 100)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

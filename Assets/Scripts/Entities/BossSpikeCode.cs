using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpikeCode : MonoBehaviour
{

    public float bossSpikeSpeed;
    
    void Start()
    {  
       transform.position += transform.forward * 100 * Time.deltaTime;         
    }

    void Update()
    {
        transform.position += transform.forward * bossSpikeSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

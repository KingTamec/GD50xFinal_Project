using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroIcoCode : MonoBehaviour
{
    public float MicroIcoSpeed;
    public float LRTeleDist;
    public float minTeleFreq;
    public float maxTeleFreq;

    public float sinPeriod;
    public float sinAmplitude;

    private GameObject player;
    private Vector3 targetPos;
    private Vector3 dir;
    private Vector3 normalToDir;

    // Position of the gameobject
    private float x;
    private float y;
    private float z;

    // private int signLR = -1;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        //StartCoroutine(LeftRightTeleporting());
    }

    void Update()
    {
        transform.Rotate(0, 0.5f, 0, Space.World);
        targetPos = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, 
        targetPos, MicroIcoSpeed*Time.deltaTime);

        dir = targetPos - transform.position;

        normalToDir = new Vector3(dir.z, dir.y, -dir.x);
        
        transform.position = transform.position + normalToDir*Mathf.Sin(Time.time*sinPeriod)*Time.deltaTime*sinAmplitude;

    }

    /* Commented out due to buggy behaviour
    IEnumerator LeftRightTeleporting()
    {
        while (true)
        {
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
        
            if (signLR == -1)
            {
                signLR += 2;
            }
            else
            {
                signLR -= 2;
            }
            transform.position = new Vector3(x +(signLR)*LRTeleDist, y, z);                
    
            yield return new WaitForSeconds(Random.Range(minTeleFreq,maxTeleFreq));
        }
    }*/
}

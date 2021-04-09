using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcoCode : MonoBehaviour
{
    public float icoSpeed;
    public float agroRange;
    public float maxMovDistX;
    public float maxMovDistY;
    public float maxMovDistZ;
    public float newTargetDelay;

    private float startX;
    private float startY;
    private float startZ;
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 targetPos;
    private float newTargetTime = 0f;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
    }

    void Update()
    {
        transform.Rotate(0, 0.5f, 0, Space.World);

        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        float distToPlayer = Vector3.Distance(transform.position, playerPos);

        if (player && distToPlayer <= agroRange)
        {   
            transform.position = Vector3.MoveTowards(transform.position, 
            playerPos, icoSpeed*Time.deltaTime);
        }
        else
        {
            if (Time.time > newTargetTime)
            {
                targetPos = new Vector3(Random.Range(startX-maxMovDistX, startX+maxMovDistX), 
                    Random.Range(startY, startY+maxMovDistY), Random.Range(startZ-maxMovDistZ, startZ+maxMovDistZ));

                newTargetTime = Time.time + Random.Range(0.1f, newTargetDelay);
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, icoSpeed/2*Time.deltaTime); 
        }
    }
}

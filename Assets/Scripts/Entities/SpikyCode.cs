using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyCode : MonoBehaviour
{
    public GameObject spike;
    public float agroRange;
    public float spikySpeed;
    public float spikyFireRateMin;
    public float spikyFireRateMax;

    float x;
    float y;
    float z;

    private GameObject player;

    private float NewTargetTime = 0f;

    private Vector3 targetPos;
    private bool shooting = false;
    [HideInInspector] public bool alive = true;

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (alive)
        {
            transform.Rotate(0.5f, 0.5f, 0.5f, Space.World);

            if (Time.time > NewTargetTime)
            {
                targetPos = new Vector3(Random.Range(x-2f, x+2f), Random.Range(y, y+5), Random.Range(z-2f, z+2f));

                NewTargetTime = Time.time + Random.Range(0.1f, 1.5f);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, spikySpeed*Time.deltaTime);

            // Code to shoot towards player
            float distToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distToPlayer <= agroRange && shooting == false)
            {
                StartCoroutine(SpawnSpikes());
                shooting = true;
            }
            else if (distToPlayer > agroRange && shooting == true)
            {
                StopAllCoroutines();
                shooting = false;
            }
        }
    }

    IEnumerator SpawnSpikes()
    {
        while (true)
        {
            //Vector3 relativePos = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.FromToRotation(transform.position, player.transform.position);
            Instantiate(spike, new Vector3(transform.position.x, transform.position.y, transform.position.z), rotation);
            yield return new WaitForSeconds(Random.Range(spikyFireRateMin, spikyFireRateMax));
        }
    }
}

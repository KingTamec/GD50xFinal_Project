using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCircularMotion : MonoBehaviour
{
    public float speed;
    public float radius;
    private float timeCounter;

    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        float x = transform.position.x + Mathf.Sin(timeCounter) * radius;

        float y = transform.position.y; 

        float z = transform.position.z + Mathf.Cos(timeCounter) * radius;

        transform.position = new Vector3 (x, y, z);
    }
}

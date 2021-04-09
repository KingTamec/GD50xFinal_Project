using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRotation : MonoBehaviour
{
    private int x;
    private int z;
    
    void Start()
    {
        x = 0;
        z = 0;
        StartCoroutine(RandomXZRotation());
    }
    void Update()
    {
        transform.Rotate(x, 0, z, Space.World);
    }
    IEnumerator RandomXZRotation()
    {
        while (true)
        {
            x = Random.Range(-1, 1);
            if (x == 0)
            {
                x = 1;
            }
            z = Random.Range(-1, 1);
            if (z == 0)
            {
                z = -1;
            }
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }
}

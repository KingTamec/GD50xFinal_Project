using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcoSpawner : MonoBehaviour
{
    public GameObject icoPrefab;
    public GameObject icoParent;
    public float spawnRateMin = 2f;
    public float spawnRateMax = 5f;
    public int icoMax;

    private bool firstSpawn = true;

    void Start()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        
        StartCoroutine(SpawnIcos());
    }

    private IEnumerator SpawnIcos()
    {
        while (true) 
        {
            if (icoParent.transform.childCount < icoMax)
            {
                if (!firstSpawn)
                {
                    yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
                }
                float x = transform.position.x;
                float y = transform.position.y;
                float z = transform.position.z;
                CreateChildPrefab(icoPrefab, icoParent, x, y, z);
                firstSpawn = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void CreateChildPrefab(GameObject prefab, GameObject parent, float x, float y, float z) 
    {
            var myPrefab = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
            myPrefab.transform.parent = parent.transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcoSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject IcoPrefab;
    public GameObject IcoParent;

    public int SpawnRateMin = 2;
    public int SpawnRateMax = 5;
    
    public int IcoMax;
    private int x;
    private int y; 
    private int z;

    void Start()
    {
        x = (int) Mathf.Round(transform.position.x);
        y = (int) Mathf.Round(transform.position.y);
        z = (int) Mathf.Round(transform.position.z);
        
        StartCoroutine(SpawnIcos());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnIcos()
    {
        while (true) 
        {
            if (GameObject.FindGameObjectsWithTag("Ico").Length < IcoMax)
            {
                CreateChildPrefab(IcoPrefab, IcoParent, Random.Range(x-2, x+2), Random.Range(y, y+2), Random.Range(z-2, z+2));
            }

            yield return new WaitForSeconds(Random.Range(SpawnRateMin, SpawnRateMax));
        }
    }

    void CreateChildPrefab(GameObject prefab, GameObject parent, int x, int y, int z) 
    {
            var myPrefab = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
            myPrefab.transform.parent = parent.transform;
    }

}

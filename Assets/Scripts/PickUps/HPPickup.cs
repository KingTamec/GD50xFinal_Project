using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPickup : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0.7f, 0, Space.World);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player>().playerHealth > 50)
            {
                other.gameObject.GetComponent<Player>().playerHealth = 100;
            }
            else
            {
                other.gameObject.GetComponent<Player>().playerHealth += 50;
            }
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorFloor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}

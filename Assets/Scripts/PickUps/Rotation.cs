using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationspeed;
    void Update()
    {
        transform.Rotate(0f, rotationspeed, 0f, Space.World);
    }
}

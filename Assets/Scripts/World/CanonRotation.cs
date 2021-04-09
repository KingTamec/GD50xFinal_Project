using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotation : MonoBehaviour
{
    public GameObject IcoBoss;

    private Vector3 target;
    void Update()
    {
        if (IcoBoss != null)
        {
            target = IcoBoss.transform.position;
            transform.LookAt(target);     
        }
    }
}

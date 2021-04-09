using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchOpener : MonoBehaviour
{
    public GameObject[] Icos;
    Animator openHatch;
    void Start()
    {
        openHatch = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Icos = GameObject.FindGameObjectsWithTag("Ico");

        if (Icos.Length == 0)
        {
            openHatch.SetBool("HatchOpen", true);
        }
    }
}

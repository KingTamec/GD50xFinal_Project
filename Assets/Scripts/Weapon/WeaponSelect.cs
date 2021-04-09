using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    int currentWeapon = 0;

    public bool automaticPickedUp = false;

    void Start()
    {
        ActivateWeapon();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1)
        {
            currentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && automaticPickedUp)
        {
            currentWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            currentWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            currentWeapon = 3;
        }

        if (previousWeapon != currentWeapon)
        {
            ActivateWeapon();
        }
    }

    void ActivateWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}

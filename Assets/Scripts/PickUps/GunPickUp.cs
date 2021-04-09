using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickUp : MonoBehaviour
{
    public GameObject weaponHolder;
    public Text autoPickupText;
    public GameObject playerHUD;

    void Update()
    {
        transform.Rotate(0, 0.3f, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            weaponHolder.GetComponent<WeaponSelect>().automaticPickedUp = true;
            Text text = Instantiate(autoPickupText, playerHUD.transform);
            Destroy(gameObject);
        }
    }
}
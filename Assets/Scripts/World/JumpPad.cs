using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    /*public GameObject player;
    public float Thrust;
    private Rigidbody playerRigidbody;
    private bool playerOnPad = false;

    private CharacterController characterController;

    void start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        //characterController = player.GetComponent<CharacterController>();
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Player")
        {
            playerOnPad = true;
            Debug.Log(playerOnPad);
        }
    }

    //    void OnTriggerEnter(Collider other)
    //    {
    //        if (other == player)
    //        {
    //            playerOnPad = true;
    //            Debug.Log(playerOnPad);
    //        }
    //    }
    
    //    void OnControllerColliderHit(CharacterController characterController)
    //    {
    //
    //    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerOnPad = false;
            Debug.Log(playerOnPad);
            //other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * Thrust);
        }
    }

    void update()
    {
        if (playerOnPad == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerRigidbody.AddForce(player.transform.up * Thrust);
            }
        }
    }
    */
}

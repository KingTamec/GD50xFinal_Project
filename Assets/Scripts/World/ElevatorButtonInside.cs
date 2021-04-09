using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorButtonInside : MonoBehaviour
{
    public GameObject player;
    public Text usageText;
    public GameObject playerHUD;
    public Camera fpsCam;

    private bool door1Slides;
    private bool elevatorUp = false;
    private float useableDistance = 2f;
    private Text text;
    private Animator Elevator;
    private Animator RightDoor2;
    private Animator LeftDoor2;
    

    void Start()
    {
        Elevator = transform.GetComponentInParent<Animator>();

        RightDoor2 = transform.GetChild(0).GetComponent<Animator>();
        LeftDoor2 = transform.GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {
        door1Slides = GameObject.Find("ElevatorButton").GetComponent<ElevatorButton>().door1Slides;
        // Code to show "Press [E] to use" and enable Button to call Elevator via raycast
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, useableDistance))
        {
            if (hit.transform.tag == "Button2")
            {
                if (!text)
                {
                    text = Instantiate(usageText, playerHUD.transform);
                }
                if (Input.GetButtonDown("Use") && !door1Slides && !elevatorUp)
                {
                    Elevator.SetTrigger("ElevatorUp");
                    elevatorUp = true;

                    StartCoroutine(ExecuteAfterTime(10));
                }
            }
            else
            {
                if (text)
                {
                    Destroy(text.gameObject);
                }
            }
            
        }
    }
    IEnumerator ExecuteAfterTime(int time)
    {
        yield return new WaitForSeconds(time);
        RightDoor2.SetTrigger("OpenRightDoor2");
        LeftDoor2.SetTrigger("OpenLeftDoor2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorButton : MonoBehaviour
{  
    public GameObject player;
    public Text usageText;
    public GameObject playerHUD;
    public Camera fpsCam;
    
    [HideInInspector] public bool door1Slides = false;
    private float useableDistance = 2f;
    private Text text;
    private Animator rightDoor;
    private Animator leftDoor;

    void Start()
    {
        rightDoor = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        leftDoor = transform.GetChild(0).GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, useableDistance))
        {
            if (hit.transform.tag == "Button")
            {
                if (!text)
                {
                    text = Instantiate(usageText, playerHUD.transform);
                }
                if (Input.GetButtonDown("Use") && !door1Slides)
                {
                    // Elevator
                    rightDoor.SetTrigger("OpenRightDoor");
                    leftDoor.SetTrigger("OpenLeftDoor");
                    door1Slides = true;

                    StartCoroutine(ExecuteAfterTime(15));
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
        door1Slides = false;
    }
}

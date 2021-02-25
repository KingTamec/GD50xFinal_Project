using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcoCode : MonoBehaviour
{
    public GameObject player;

    public float IcoSpeed;

    //public Image hitEffect;

    private GameObject target;
    private Vector3 targetPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.5f, 0, Space.World);

        target = GameObject.FindGameObjectWithTag("Player");

        targetPos = target.transform.position;

        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
            targetPos, IcoSpeed*Time.deltaTime);
        }
    }


//    void OnControllerColliderHit(ControllerColliderHit hit)
//    {
//        if (hit.gameObject.tag == "Ico")
//        {
//            hitEffect.color = new Color (1,0,0,1/4);
//
//            Invoke("stopHitEffect", 0.2f);
//
//            Destroy(gameObject);
//        }
//    }
//
//    void stopHitEffect()
//    {
//        hitEffect.color = new Color (1,0,0,0);
//    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject player;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(transform.position.x, transform.position.y - 50, transform.position.z);
    }
    void Update()
    {
        transform.Rotate(0, 2f, 0, Space.World);

        transform.position = Vector3.MoveTowards(transform.position, target, 4*Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Victory");
        }
    }
}

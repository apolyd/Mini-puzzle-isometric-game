using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerControl>().readyToSit)
        {
            Debug.Log("prospathisa");
            //other.gameObject.transform.rotation = transform.rotation;
           // other.GetComponent<PlayerControl>().setRotationToItem();
            other.gameObject.transform.position = transform.position;
            other.GetComponent<PlayerControl>().agent.velocity = Vector3.zero;
            other.GetComponent<PlayerControl>().agent.isStopped = true;
            other.GetComponent<PlayerControl>().anim.SetBool("isSitting", value: true);
            if(other.transform.rotation == transform.rotation)
            {
                Debug.Log("gamw ton papakaliati");
            }
        }
    }
}

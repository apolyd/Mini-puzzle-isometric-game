using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationKey : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) //too many arguments for the player to stop to interact
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerControl>().readyToExamine == true && other.GetComponent<PlayerControl>().leaveExamineAreaFlag == false && gameObject.transform.parent.tag == other.GetComponent<PlayerControl>().InteractableToGo)
        {
            Debug.Log("fghdfghdfs");
            other.GetComponent<PlayerControl>().agent.velocity = Vector3.zero;
            other.GetComponent<PlayerControl>().agent.ResetPath();
            GameObject.FindWithTag("Player").GetComponent<PlayerControl>().anim.SetTrigger("isPickingKey");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerControl>().leaveExamineAreaFlag == true) //the player leaves to examine something else
            {
                other.GetComponent<PlayerControl>().readyToExamine = true;
            }
            else if (other.GetComponent<PlayerControl>().leaveExamineAreaFlag == false && gameObject.transform.parent.tag == other.GetComponent<PlayerControl>().InteractableToGo) //this second argument might be a problem
            {
                other.GetComponent<PlayerControl>().readyToExamine = false; //the player just leaves
            }
            //other.GetComponent<PlayerControl>().readyToExamine = false;
            other.GetComponent<PlayerControl>().leaveExamineAreaFlag = false;
        }
    }

}

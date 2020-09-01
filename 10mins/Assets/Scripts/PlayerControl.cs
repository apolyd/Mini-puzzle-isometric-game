using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Animator anim;
    public GameObject CouchPositionToSit, ArmchairPositionToSit, CardboardBoxPosition, MonitorPosition, test; //where the player needs to go to sit
    public bool readyToSit, readyToExamine, leaveExamineAreaFlag, blockEve, hasKey; //condition for the player to sit, examine etc (leaveExamineAreaFlag is to leave the examine area to go to another one)
    public string InteractableToGo;
    public int furnitoreToSit;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        readyToSit = false;
        leaveExamineAreaFlag = false;
        blockEve = false;
        furnitoreToSit = 0;
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (blockEve == true)
        {
            return;
        }

        

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() || GameObject.FindGameObjectWithTag("PauseHandler").GetComponent<PauseGame>().GetPauseStatus() == true)    //<----------------------**** i added this again to block from clicking when UI is open
            {
                return;
            }

            //agent.velocity = Vector3.zero;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("Couch")) //the player has selected the couch to go and sit
                {
                    if (readyToSit == true) //new code here to start moving to a position when sitting
                    {
                        agent.isStopped = false;
                        anim.SetBool("isSitting", false); //last change here
                    }
                    agent.destination = CouchPositionToSit.transform.position;
                    readyToSit = true;
                    furnitoreToSit = 1;
                    Debug.Log("lets go");
                    CouchPositionToSit.SetActive(true);
                }
                else if (hit.collider.CompareTag("Armchair")) //the player has selected the armchair to go and sit
                {
                    if (readyToSit == true) //new code here to start moving to a position when sitting
                    {
                        agent.isStopped = false;
                        anim.SetBool("isSitting", false);
                    }
                    agent.destination = ArmchairPositionToSit.transform.position;
                    readyToSit = true;
                    furnitoreToSit = 2;
                    ArmchairPositionToSit.SetActive(true);
                }
                else if (hit.collider.CompareTag("TestItem") || hit.collider.CompareTag("Painting") || hit.collider.CompareTag("GreenBook") || hit.collider.CompareTag("RedBook") || hit.collider.CompareTag("Lamp") || hit.collider.CompareTag("CardboardBox") || hit.collider.CompareTag("Monitor") || hit.collider.CompareTag("Key") || hit.collider.CompareTag("Door") || hit.collider.CompareTag("PenAndPaper") || hit.collider.CompareTag("Speaker")) //is picking up or examining an item
                {
                    InteractableToGo = hit.collider.tag;
                    if (readyToSit == true) //new code here to start moving to a position when sitting
                    {
                        agent.isStopped = false;
                        anim.SetBool("isSitting", false);
                    }

                    if (readyToExamine == true)
                    {
                        leaveExamineAreaFlag = true;
                    }
                    readyToExamine = true;
                    agent.destination = hit.transform.position;

                    if(hit.collider.tag == "CardboardBox")
                    {
                        agent.destination = CardboardBoxPosition.transform.position;
                    }

                    if (hit.collider.tag == "Monitor")
                    {
                        agent.destination = MonitorPosition.transform.position;
                    }

                    if (hit.collider.tag == "Key")
                    {
                        agent.destination = GameObject.FindWithTag("KeyPosition").transform.position;
                    }
                }
                else //player has selected a place to go
                {
                    InteractableToGo = " ";
                    if (readyToSit == true) //if the player sits start moving again
                    {
                        readyToSit = false;
                        agent.isStopped = false;
                        anim.SetBool("isSitting", false);
                    }

                    if (readyToExamine == true) //if the player has started to interact with something stop it and start moving
                    {
                        readyToExamine = false;
                    }

                    if (EventSystem.current.IsPointerOverGameObject())    //<----------------------this is the line that caused the problem
                    {
                        return;
                    }
                    else
                    {
                        agent.destination = hit.point;
                    }
                    //agent.destination = hit.point;

                }

            }

        }


        //if (agent.remainingDistance <= 0.1) //when closing down to destination        <----------------------problematic with line 73 where I check if i click UI
        //{
        //agent.velocity = Vector3.zero;
        //anim.SetBool("isRunning", false);

        //}

        if (agent.velocity == Vector3.zero) //when the player is idle his velocity is 0
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

    }

    void FixedUpdate()
    {
        //transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        if (agent.velocity != Vector3.zero) //make the player rotate to his velocity
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }

    }

    public void setExamineVariable(bool status)
    {
        readyToExamine = status;
    }

    public void blockEveControl()
    {
        agent.isStopped = true; // more block for UI
        blockEve = true;
        Vector3 direction = GameObject.FindWithTag("Lamp").transform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    public void releaseEveControl()
    {
        agent.isStopped = false; // more block for UI
        blockEve = false;
        Vector3 direction = GameObject.FindWithTag("Lamp").transform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        anim.SetBool("isRunning", false);
    }

    public void blockEveControlforBoxes()
    {
        agent.isStopped = false; // more block for UI
        blockEve = true;
        Vector3 direction = GameObject.FindWithTag("CardboardBox").transform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    public void releaseEveControlforBoxes()
    {
        agent.isStopped = false; // more block for UI
        blockEve = false;
        Vector3 direction = GameObject.FindWithTag("CardboardBox").transform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        anim.SetBool("isRunning", false);
    }

    public void blockEveControlforKey()
    {
        agent.isStopped = false; // more block for UI
        blockEve = true;
        Vector3 direction = GameObject.FindWithTag("Key").transform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    public void releaseEveControlforKey()
    {
        agent.isStopped = false; // more block for UI
        blockEve = false;
        Vector3 direction = GameObject.FindWithTag("Key").transform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        anim.SetBool("isRunning", false);
        Destroy(GameObject.FindWithTag("Key"));
        Destroy(GameObject.FindWithTag("KeyPosition"));
        hasKey = true;
    }

    public void setRotation()
    {
        if(furnitoreToSit == 1)
        {
            transform.position = CouchPositionToSit.transform.position;
            transform.rotation = CouchPositionToSit.transform.rotation;
            CouchPositionToSit.SetActive(false);
        }
        else if( furnitoreToSit == 2)
        {
            transform.position = ArmchairPositionToSit.transform.position;
            transform.rotation = ArmchairPositionToSit.transform.rotation;
            ArmchairPositionToSit.SetActive(false);
        }

    }
}

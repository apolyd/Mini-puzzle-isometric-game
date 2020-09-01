using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other) //too many arguments for the player to stop to interact
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerControl>().hasKey == true && other.GetComponent<PlayerControl>().InteractableToGo == "Door")
            {
                GetComponent<Animator>().SetTrigger("openDoor");
            }

        }
    }

    public void EndScreen()
    {
        GameObject.FindGameObjectWithTag("PauseHandler").GetComponent<PauseGame>().SetOverStatus(true);
    }
}

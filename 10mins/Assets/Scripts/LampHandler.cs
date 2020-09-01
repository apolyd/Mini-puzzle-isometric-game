using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampHandler : MonoBehaviour
{
    public GameObject Lamp;
    public Animator anim;

    public void HandleLamp(bool status)
    {
        Lamp.GetComponent<Light>().enabled = status;
        anim.SetTrigger("pushButton");
    }

}

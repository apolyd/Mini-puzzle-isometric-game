using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncerHandler : MonoBehaviour
{
    public bool BlueBookFound;
    public GameObject BlueBookText;
    public float timeToPass;
    // Start is called before the first frame update
    void Start()
    {
        BlueBookFound = false;
        timeToPass = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(BlueBookFound == true)
        {
            BlueBookText.SetActive(true);
            timeToPass -= Time.deltaTime;
            if(timeToPass <= 0)
            {
                timeToPass = 5f;
                BlueBookFound = false;
                BlueBookText.SetActive(false);
            }
        }
    }
}

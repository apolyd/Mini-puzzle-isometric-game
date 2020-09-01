using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setrotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // transform.rotation = aftoo.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FixRotation"))
        {
            transform.rotation = other.transform.rotation;
        }
    }
}

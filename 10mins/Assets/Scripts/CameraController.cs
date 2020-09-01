using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTransform;
    public Quaternion newRotation;
    public float rotationAmount, movementTime;
   

    
    // Start is called before the first frame update
    void Start()
    {
        newRotation = transform.rotation;
 
    }

    // Update is called once per frame
    void Update()
    {
        if(followTransform != null)
        {
            transform.position = followTransform.position;
        }
        else
        {
            Debug.Log("mistakes were made.");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);

    }
}

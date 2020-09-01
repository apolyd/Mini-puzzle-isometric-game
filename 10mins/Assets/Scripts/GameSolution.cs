using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSolution : MonoBehaviour
{
    public GameObject CodeOne, CodeTwo, CodeThree, Plate, createdPlate;
    public Animator anim;
    public Vector3 desiredPosition;
    private bool LockOne, LockTwo, LockThree, flag;
    // Start is called before the first frame update
    void Start()
    {
        desiredPosition.x = -3.7f;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        LockOne = CodeOne.GetComponent<PasswordHandler>().Lock;  //make sure all the lock are open and then give the key to the player
        LockTwo = CodeTwo.GetComponent<PasswordHandler>().Lock;
        LockThree = CodeThree.GetComponent<PasswordHandler>().Lock;
        Debug.Log("ta lock einai " + LockOne + LockTwo + LockThree + " kai to anim einai " + anim.GetCurrentAnimatorStateInfo(0).IsName("StandToSit"));
        if (LockOne == LockTwo == LockThree == true && anim.GetCurrentAnimatorStateInfo(0).IsName("StandToSit"))
        {
            Debug.Log("gg wp");
            //currentPosition = transform.localPosition; //maybe this is not needed
            if(flag == true)
            createdPlate = Instantiate(Plate, new Vector3(-4.752f, 0.946f, -1.443f), Plate.transform.rotation);

            Vector3 newPosition = createdPlate.transform.localPosition;
            newPosition.x = Mathf.Lerp(newPosition.x, desiredPosition.x, Time.deltaTime * 2);
            createdPlate.transform.localPosition = newPosition;
            flag = false;
            
        }
    }

    public void updatePositionPlate(GameObject plate)
    {
        Vector3 newPosition = plate.transform.localPosition;
        newPosition.x = Mathf.Lerp(newPosition.x, desiredPosition.x, Time.deltaTime * 2);
        plate.transform.localPosition = newPosition;
        flag = false;
    }
}

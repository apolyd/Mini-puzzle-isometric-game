using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordHandler : MonoBehaviour
{
    public GameObject ImageColor;
    public Text numberToShow;
    public int number, correctNumber;
    public Color32[] colors;
    public bool Lock;
    // Start is called before the first frame update
    void Start()
    {
        number = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(colors[0]);
        numberToShow.text = number.ToString();
        ImageColor.GetComponent<Image>().color = colors[number - 1];
        if(number == correctNumber)
        {
            Lock = true;
        }
        else
        {
            Lock = false;
        }
    }

    public void upButtonPush()
    {
        Debug.Log(number);
        number++;
        if (number == 10)
        {
            number = 1;
        }
    }

    public void downButtonPush()
    {
        Debug.Log(number);
        number--;
        if (number == 0)
        {
            number = 9;
        }
    }
}

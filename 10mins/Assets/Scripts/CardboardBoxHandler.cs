using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardboardBoxHandler : MonoBehaviour
{
    public GameObject CardboardPanel, SearchButton;
    public Text TextToChange;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SearchCardboardBoxes()
    {
        anim.SetTrigger("isSearchingItems");
        CardboardPanel.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().blockEve = true;
        Vector3 direction = GameObject.FindWithTag("CardboardBox").transform.position - GameObject.FindWithTag("Player").transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        GameObject.FindWithTag("Player").transform.rotation = rotation;
        ChangeText();
        GameObject.FindWithTag("Announcements").GetComponent<AnnouncerHandler>().BlueBookFound = true;
    }

    public void ChangeText()
    {
        TextToChange.text = "You have search the cardboard boxes. You found a blue book. There is nothing left anymore here.";
        SearchButton.SetActive(false);
    }
}

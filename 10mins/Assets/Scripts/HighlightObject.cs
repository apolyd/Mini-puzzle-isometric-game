using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightObject : MonoBehaviour
{
    public GameObject LabelPosition;
    //public Texture2D CouchCursor, ChairCursor;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Outline>().enabled = false;
    }

    private void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject() || GameObject.FindGameObjectWithTag("PauseHandler").GetComponent<PauseGame>().GetPauseStatus() == true)    //<----------------------this is the line that caused the problem
        {
            return;
        }
        LabelPosition.GetComponent<LabelPopUp>().nameLabel.SetActive(true);
        GetComponent<Outline>().enabled = true;
        if (gameObject.CompareTag("Couch"))
        {
           // Cursor.SetCursor(CouchCursor, hotSpot, cursorMode);
        }
        else if (gameObject.CompareTag("Armchair"))
        {
           // Cursor.SetCursor(ChairCursor, hotSpot, cursorMode);
        }
    }

    private void OnMouseExit()
    {
        LabelPosition.GetComponent<LabelPopUp>().nameLabel.SetActive(false);
        GetComponent<Outline>().enabled = false;
        //Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour {

    private bool clickable = false;
    public string objectName;
    private Text infoText;
    private RectTransform infoTextPos;
    private float screenWidth;
    private float screenHeight;

    private void OnMouseOver()
    {
        if(infoText == null)
        {
            infoText = GameObject.Find("InfoText").GetComponent<Text>();
            infoTextPos = GameObject.Find("InfoText").GetComponent<RectTransform>();
            screenWidth = Camera.main.pixelWidth / 2;
            screenHeight = Camera.main.pixelHeight / 2;
        }
        infoText.text = getMouseOverText();
        float posX = Input.mousePosition.x - screenWidth + 5;
        float posY = Input.mousePosition.y - screenHeight - 30;
        infoTextPos.anchoredPosition = new Vector2(posX, posY);
    }

    private void OnMouseExit()
    {
        infoText.text = "";
    }

    private void OnMouseDown()
    {
        if(clickable)
        {
            Interact();
        }
        else
        {
            MoveToInteractable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Player")
        {
            clickable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name=="Player")
        {
            clickable = false;
        }
    }

    private void MoveToInteractable()
    {
        Debug.Log("Add code to move to "+objectName+".");
    }

    protected abstract void Interact();
    protected abstract string getMouseOverText();
}

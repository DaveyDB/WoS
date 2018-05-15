using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Ore : Interactable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Interact()
    {
        Debug.Log("You try to mine some "+objectName+".");
    }

    protected override string getMouseOverText()
    {
        return "<color=white>Mine </color><color=yellow>" + objectName + "</color>";
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinPartWorldObject : InteractableMono
{
    public string Name;
    public string PartType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        GameManager.Instance.PlayerOne.StartCarryingItem(Name);
    }

    public override string GetText()
    {
        return "Press E to pickup: " + name;
    }

    public override bool IsCurrentlyInteractable()
    {
        return !GameManager.Instance.PlayerOne.CarryingPart;
    }

    void OnTriggerEnter(Collider other)
    {
        //Disabled as we're no longer doing third person.
        //HoverTextManager.Instance.DisplayText("Press E to pickup: " + name);
    }

    void OnTriggerExit(Collider other)
    {
        //Disabled as we're no longer doing third person.
        //HoverTextManager.Instance.ClearText();
    }
}
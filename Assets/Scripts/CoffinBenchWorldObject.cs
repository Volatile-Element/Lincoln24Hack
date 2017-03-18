using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinBenchWorldObject : InteractableMono
{
    public string Top;
    public string Bottom;
    public string LeftSide;
    public string RightSide;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        //TODO: Add to coffin.
        GameManager.Instance.PlayerOne.StopCarryingItem();
    }

    public override string GetText()
    {
        return "Add " + GameManager.Instance.PlayerOne.CarryingPartName + " to coffin.";
    }

    public override bool IsCurrentlyInteractable()
    {
        return GameManager.Instance.PlayerOne.CarryingPart;
    }
}
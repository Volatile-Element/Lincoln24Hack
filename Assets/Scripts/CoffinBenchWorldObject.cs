using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinBenchWorldObject : InteractableMono
{
    public CoffinBuildTemplate BuildingCoffin;

    private void Awake()
    {
        BuildingCoffin = FindObjectOfType<CoffinBuildTemplate>();
    }

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
        var instanCoffinPart = CoffinManager.Instance.InstantiateCoffinPart(GameManager.Instance.PlayerOne.CarryingPartObject.Resource, BuildingCoffin.transform.position, Quaternion.identity, BuildingCoffin.transform);
        GameManager.Instance.PlayerOne.StopCarryingItem();
    }

    public override string GetText()
    {
        return "Add " + GameManager.Instance.PlayerOne.CarryingPartObject.Name + " to coffin.";
    }

    public override bool IsCurrentlyInteractable()
    {
        return GameManager.Instance.PlayerOne.CarryingPart;
    }
}
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
        var parts = new GameObject("Parts");
        parts.transform.parent = BuildingCoffin.transform;

        OrderManager.Instance.OrderCompleted.AddListener(CompleteOrder);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        var carriedItem = GameManager.Instance.PlayerOne.CarryingPartObject;

        Vector3 positionToSpawn = BuildingCoffin.transform.FindChild(carriedItem.PartType.ToString()).position;

        var instanCoffinPart = CoffinManager.Instance.InstantiateCoffinPart(carriedItem.Resource, positionToSpawn, Quaternion.identity, BuildingCoffin.transform.FindChild("Parts"));
        OrderManager.Instance.CurrentOrder.AddPlacedItem(carriedItem);
        GameManager.Instance.PlayerOne.StopCarryingItem();
    }

    public override string GetText()
    {
        return "Press (E) to add " + GameManager.Instance.PlayerOne.CarryingPartObject.Name + " to coffin.";
    }

    public override bool IsCurrentlyInteractable()
    {
        return GameManager.Instance.PlayerOne.CarryingPart;
    }

    public void CompleteOrder()
    {
        var newCoffin = Instantiate(BuildingCoffin.gameObject, BuildingCoffin.gameObject.transform.position, BuildingCoffin.transform.rotation) as GameObject;

        //TODO: Kill new coffin.
        Destroy(newCoffin); //Eventually this will be time based.

        //We destroy the placed parts and readd the child object.
        Destroy(BuildingCoffin.transform.FindChild("Parts").gameObject);
        var parts = new GameObject("Parts");
        parts.transform.parent = BuildingCoffin.transform;
    }
}
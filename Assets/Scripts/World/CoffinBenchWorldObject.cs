﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinBenchWorldObject : InteractableMono
{
    public CoffinBuildTemplate BuildingCoffin;

    private void Awake()
    {
        BuildingCoffin = FindObjectOfType<CoffinBuildTemplate>();
        var parts = new GameObject("Parts");
        parts.transform.parent = BuildingCoffin.transform;

        GameManager.Instance.OnDayChange.AddListener(ResetTemplate);
    }

    // Use this for initialization
    void Start()
    {
        OrderManager.Instance.OrderCompleted.AddListener(CompleteOrder);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        var carriedItem = GameManager.Instance.PlayerOne.CarryingPartObject;

        Vector3 positionToSpawn = BuildingCoffin.transform.Find(carriedItem.PartType.ToString()).position;

        var instanCoffinPart = CoffinManager.Instance.InstantiateCoffinPart(carriedItem.Resource, positionToSpawn, Quaternion.identity, BuildingCoffin.transform.Find("Parts"));
        OrderManager.Instance.CurrentOrder.AddPlacedItem(carriedItem);
        GameManager.Instance.PlayerOne.StopCarryingItem();
        GetComponent<PieceBuiltSound>().PlayRandomSound();
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

        newCoffin.AddComponent<DestroyIn>();
        newCoffin.AddComponent<MoveInDirection>().Direction = new Vector3(0, 0, 1);

        FindObjectOfType<Shutter>().PlayAnimation();

        //We destroy the placed parts and readd the child object.
        ResetTemplate();
    }

    public void ResetTemplate()
    {
        Destroy(BuildingCoffin.transform.Find("Parts").gameObject);
        var parts = new GameObject("Parts");
        parts.transform.parent = BuildingCoffin.transform;
    }
}
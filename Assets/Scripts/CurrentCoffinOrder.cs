using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CurrentCoffinOrder
{
    public CoffinOrder Order;

    public CoffinObject PlacedLid;
    public CoffinObject PlacedBase;
    public CoffinObject PlacedTop;
    public CoffinObject PlacedBottom;
    public CoffinObject PlacedLeftSide;
    public CoffinObject PlacedRightSide;
    public CoffinObject PlacedLeftHandle;
    public CoffinObject PlacedRightHandle;

    public UnityEvent OnOrderComplete = new UnityEvent();

    private List<CoffinParts> AddedParts = new List<CoffinParts>(); // In case we need to track adds for some reason. Also 05:27.

    public void AddPlacedItem(CoffinObject placedItem)
    {
        AddedParts.Add(placedItem.PartType);

        switch (placedItem.PartType)
        {
            case CoffinParts.Lid:
                PlacedLid = placedItem;
                break;
            case CoffinParts.Base:
                PlacedBase = placedItem;
                break;
            case CoffinParts.Top:
                PlacedTop = placedItem;
                break;
            case CoffinParts.Bottom:
                PlacedBottom = placedItem;
                break;
            case CoffinParts.LeftSide:
                PlacedLeftSide = placedItem;
                break;
            case CoffinParts.RightSide:
                PlacedRightSide = placedItem;
                break;
            case CoffinParts.HandleLeft:
                PlacedLeftHandle = placedItem;
                break;
            case CoffinParts.HandleRight:
                PlacedRightHandle = placedItem;
                break;
            default:
                break;
        }
        
        if (AddedParts.Distinct().Count() >= 8)
        {
            OnOrderComplete.Invoke();
        }
    }
}
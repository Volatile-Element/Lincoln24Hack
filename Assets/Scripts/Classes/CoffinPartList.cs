using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoffinPartList
{
    public List<CoffinObject> Lids;
    public List<CoffinObject> Bases;
    public List<CoffinObject> Tops;
    public List<CoffinObject> Bottoms;
    public List<CoffinObject> LeftSides;
    public List<CoffinObject> RightSides;
    public List<CoffinObject> HandlesLeft;
    public List<CoffinObject> HandlesRight;

    public void SetTypes()
    {
        for (int i = 0; i < Lids.Count; i++)
        {
            Lids[i].PartType = CoffinParts.Lid;
        }

        for (int i = 0; i < Bases.Count; i++)
        {
            Bases[i].PartType = CoffinParts.Base;
        }

        for (int i = 0; i < Tops.Count; i++)
        {
            Tops[i].PartType = CoffinParts.Top;
        }

        for (int i = 0; i < Bottoms.Count; i++)
        {
            Bottoms[i].PartType = CoffinParts.Bottom;
        }

        for (int i = 0; i < LeftSides.Count; i++)
        {
            LeftSides[i].PartType = CoffinParts.LeftSide;
        }

        for (int i = 0; i < RightSides.Count; i++)
        {
            RightSides[i].PartType = CoffinParts.RightSide;
        }

        for (int i = 0; i < HandlesLeft.Count; i++)
        {
            HandlesLeft[i].PartType = CoffinParts.HandleLeft;
        }

        for (int i = 0; i < HandlesRight.Count; i++)
        {
            HandlesRight[i].PartType = CoffinParts.HandleRight;
        }
    }
}
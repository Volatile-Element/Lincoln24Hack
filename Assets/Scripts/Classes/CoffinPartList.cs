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
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoffinOrder
{
    public string TopName;
    public string BottomName;
    public string LeftSideName;
    public string RightSideName;

    public CoffinOrder()
    {
            
    }

    public CoffinOrder(CoffinObject top, CoffinObject bottom, CoffinObject left, CoffinObject right)
    {
        TopName = top.Name;
        BottomName = bottom.Name;
        LeftSideName = left.Name;
        RightSideName = right.Name;
    }
}
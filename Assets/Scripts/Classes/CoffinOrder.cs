using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoffinOrder
{
    public string LidName;
    public string BaseName;
    public string TopName;
    public string BottomName;
    public string LeftSideName;
    public string RightSideName;
    public string HandleLeft;
    public string HandleRight;

    public CoffinOrder()
    {
            
    }

    public CoffinOrder(CoffinObject lid, CoffinObject basepart, CoffinObject top, CoffinObject bottom, CoffinObject left, CoffinObject right, CoffinObject handleLeft, CoffinObject handleRight)
    {
        LidName = lid.Name;
        BaseName = basepart.Name;
        TopName = top.Name;
        BottomName = bottom.Name;
        LeftSideName = left.Name;
        RightSideName = right.Name;
        HandleLeft = handleLeft.Name;
        HandleRight = handleRight.Name;
    }
}
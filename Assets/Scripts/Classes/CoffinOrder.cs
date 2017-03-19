using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoffinOrder
{
    public CoffinObject LidName;
    public CoffinObject BaseName;
    public CoffinObject TopName;
    public CoffinObject BottomName;
    public CoffinObject LeftSideName;
    public CoffinObject RightSideName;
    public CoffinObject HandleLeft;
    public CoffinObject HandleRight;

    public CoffinOrder()
    {
            
    }

    public CoffinOrder(CoffinObject lid, CoffinObject basepart, CoffinObject top, CoffinObject bottom, CoffinObject left, CoffinObject right, CoffinObject handleLeft, CoffinObject handleRight)
    {
        LidName = lid;
        BaseName = basepart;
        TopName = top;
        BottomName = bottom;
        LeftSideName = left;
        RightSideName = right;
        HandleLeft = handleLeft;
        HandleRight = handleRight;
    }
}
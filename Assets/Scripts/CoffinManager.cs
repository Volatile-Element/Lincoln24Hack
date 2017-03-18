using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CoffinManager : Singleton<CoffinManager>
{
    public CoffinPartList CoffinParts;

    public CoffinManager()
    {

    }

    void Awake()
    {
        //Load Coffin Parts
        var json = Resources.Load<TextAsset>("coffins").text;
        CoffinParts = JsonUtility.FromJson<CoffinPartList>(json);
    }
}
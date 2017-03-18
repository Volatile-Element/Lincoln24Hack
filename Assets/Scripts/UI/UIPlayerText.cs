using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerText : MonoBehaviour
{
    Canvas ParentCanvas;
    Text txtPlayer;

    void Awake()
    {
        //Set values
        ParentCanvas = gameObject.GetComponent<Canvas>();
        txtPlayer = ParentCanvas.transform.FindChild("txtPlayer").GetComponent<Text>();

        //Subscribe to events.
        HoverTextManager.Instance.OnTextChange.AddListener(UpdateUI);
    }

    public void UpdateUI(string text)
    {
        txtPlayer.enabled = !string.IsNullOrEmpty(text);
        
        txtPlayer.text = text;
    }
}
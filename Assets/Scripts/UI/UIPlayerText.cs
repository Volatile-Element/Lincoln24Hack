using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerText : MonoBehaviour
{
    Canvas ParentCanvas;
    Text txtPlayer;
    Text txtCarrying;

    void Awake()
    {
        //Set values
        ParentCanvas = gameObject.GetComponent<Canvas>();
        txtPlayer = ParentCanvas.transform.FindChild("txtPlayer").GetComponent<Text>();
        txtCarrying = ParentCanvas.transform.FindChild("txtCarrying").GetComponent<Text>();

        //Subscribe to events.
        HoverTextManager.Instance.OnTextChange.AddListener(UpdateHoverText);
        GameManager.Instance.PlayerOne.OnCarryingChange.AddListener(UpdateCarryingText);
    }

    public void UpdateHoverText(string text)
    {
        txtPlayer.enabled = !string.IsNullOrEmpty(text);
        
        txtPlayer.text = text;
    }

    public void UpdateCarryingText(string text)
    {
        txtCarrying.enabled = !string.IsNullOrEmpty(text);

        txtCarrying.text = "Currently Carrying: " + text;
    }
}
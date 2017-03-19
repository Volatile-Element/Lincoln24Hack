using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDayChanger : MonoBehaviour
{
    Canvas ParentCanvas;
    Text txtPopuptext;
    Image imgBlackout;

    void Awake()
    {
        //Set values
        ParentCanvas = gameObject.GetComponent<Canvas>();
        txtPopuptext = ParentCanvas.transform.FindChild("txtPopupText").GetComponent<Text>();
        imgBlackout = ParentCanvas.transform.FindChild("imgBlackout").GetComponent<Image>();

        //Subscribe to events.
        GameManager.Instance.OnStateChange.AddListener(UpdateOnStateChange);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateOnStateChange()
    {
        switch (GameManager.Instance.State)
        {
            case GameManager.GameState.ChangingDay:
                ShowChanger();
                break;
            case GameManager.GameState.PlayMode:
                HideChanger();
                break;
            default:
                break;
        }
    }

    public void ShowChanger()
    {
        txtPopuptext.text = "Day " + GameManager.Instance.CurrentDay;
        ParentCanvas.enabled = true;
    }

    public void HideChanger()
    {
        ParentCanvas.enabled = false;
    }
}

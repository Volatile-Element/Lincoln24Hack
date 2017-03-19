using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    Canvas ParentCanvas;
    Text txtTime;
    Text txtDay;

    void Awake()
    {
        //Set values
        ParentCanvas = gameObject.GetComponent<Canvas>();
        txtTime = ParentCanvas.transform.FindChild("txtTime").GetComponent<Text>();
        txtDay = ParentCanvas.transform.FindChild("txtDay").GetComponent<Text>();

        //Subscribe to events.
        GameManager.Instance.OnTimeChange.AddListener(OnTimeChange);
        GameManager.Instance.OnDayChange.AddListener(OnDayChange);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTimeChange()
    {
        txtTime.text = GameManager.Instance.CurrentTime.ToString("HH:mm");
    }

    public void OnDayChange()
    {
        txtDay.text = "Day " + GameManager.Instance.CurrentDay;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICash : MonoBehaviour
{
    Canvas ParentCanvas;
    Text txtCash;

    void Awake()
    {
        //Set values
        ParentCanvas = gameObject.GetComponent<Canvas>();
        txtCash = ParentCanvas.transform.Find("txtCash").GetComponent<Text>();

        //Subscribe to events.
        CashManager.Instance.OnCashChanged.AddListener(UpdateCash);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateCash()
    {
        txtCash.text = "£" + CashManager.Instance.CurrentCash;
    }
}
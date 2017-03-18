using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrders : MonoBehaviour
{
    Canvas ParentCanvas;
    Text txtOrders;

    void Awake()
    {
        //Set values
        ParentCanvas = gameObject.GetComponent<Canvas>();
        txtOrders = ParentCanvas.transform.FindChild("txtOrders").GetComponent<Text>();

        //Subscribe to events.
        OrderManager.Instance.OrderAdded.AddListener(UpdateUI);
    }

	public void UpdateUI()
    {
        var output = "";

        int counter = 0;
        foreach (var order in OrderManager.Instance.Orders)
        {
            counter++;
            output += "Order #" + counter;
            output += Environment.NewLine + "Top: " + order.TopName;
            output += Environment.NewLine + "Bottom: " + order.BottomName;
            output += Environment.NewLine + "Left: " + order.LeftSideName;
            output += Environment.NewLine + "Right: " + order.RightSideName;
        }

        txtOrders.text = output;
    }
}
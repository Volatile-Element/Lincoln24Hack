using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrders : MonoBehaviour
{
    Canvas ParentCanvas;
    Text txtOrders;
    Text txtOrderText;

    void Awake()
    {
        //Set values
        ParentCanvas = gameObject.GetComponent<Canvas>();
        txtOrders = ParentCanvas.transform.FindChild("Image/txtOrders").GetComponent<Text>();
        txtOrderText = ParentCanvas.transform.FindChild("Image/txtOrderText").GetComponent<Text>();

        //Subscribe to events.
        OrderManager.Instance.OrderAdded.AddListener(UpdateOrders);
        OrderManager.Instance.OnNewCurrentOrderAdded.AddListener(UpdateCurrentOrder);
    }

    public void UpdateOrders()
    {
        txtOrders.text = "Other Orders: " + OrderManager.Instance.Orders.Count;
    }

	public void UpdateCurrentOrder()
    {
        if (OrderManager.Instance.CurrentOrder == null)
        {
            txtOrderText.text = "No Current Order";
            return;
        }

        var order = OrderManager.Instance.CurrentOrder.Order;

        var output = "";
        output += "Lid: " + order.LidName.Name;
        output += Environment.NewLine + "Base: " + order.BaseName.Name;
        output += Environment.NewLine + "Top: " + order.TopName.Name;
        output += Environment.NewLine + "Bottom: " + order.BottomName.Name;
        output += Environment.NewLine + "Left Side: " + order.LeftSideName.Name;
        output += Environment.NewLine + "Right Side: " + order.RightSideName.Name;
        output += Environment.NewLine + "Left Handle: " + order.HandleLeft.Name;
        output += Environment.NewLine + "Right Handle: " + order.HandleRight.Name;

        txtOrderText.text = output;
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OrderManager : Singleton<OrderManager>
{
    public List<CoffinOrder> Orders = new List<CoffinOrder>();

    public bool MakingOrders;

    public UnityEvent OrderAdded;

    public void StartMakingOrders()
    {
        MakingOrders = true;
        
        StartCoroutine(MakeOrders());
    }

    public void StopMakingOrders()
    {
        MakingOrders = false;

        StopCoroutine(MakeOrders());
    }

    public void MakeOrder()
    {
        var CoffinParts = CoffinManager.Instance.CoffinParts;
        var top = CoffinParts.Tops.Skip(Random.Range(0, CoffinParts.Tops.Count())).FirstOrDefault();
        var bottom = CoffinParts.Bottoms.Skip(Random.Range(0, CoffinParts.Bottoms.Count())).FirstOrDefault();
        var left = CoffinParts.LeftSides.Skip(Random.Range(0, CoffinParts.LeftSides.Count())).FirstOrDefault();
        var right = CoffinParts.RightSides.Skip(Random.Range(0, CoffinParts.RightSides.Count())).FirstOrDefault();

        AddOrder(new CoffinOrder(top, bottom, left, right));
    }

    public void AddOrder(CoffinOrder coffinOrder)
    {
        Orders.Add(coffinOrder);
        OrderAdded.Invoke();
    }

    IEnumerator MakeOrders()
    {
        while (MakingOrders)
        {
            MakeOrder();
            yield return new WaitForSeconds(Random.Range(5, 20));
        }
    }
}
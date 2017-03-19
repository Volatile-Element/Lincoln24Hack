using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OrderManager : Singleton<OrderManager>
{
    public CurrentCoffinOrder CurrentOrder;

    public List<CoffinOrder> Orders = new List<CoffinOrder>();

    public bool MakingOrders;

    public UnityEvent OrderAdded;
    public UnityEvent OnNewCurrentOrderAdded;

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
        var lids = GetRandomCoffinPart(CoffinParts.Lids);
        var bases = GetRandomCoffinPart(CoffinParts.Bases);
        var tops = GetRandomCoffinPart(CoffinParts.Tops);
        var bottoms = GetRandomCoffinPart(CoffinParts.Bottoms);
        var leftSides = GetRandomCoffinPart(CoffinParts.LeftSides);
        var rightSides = GetRandomCoffinPart(CoffinParts.RightSides);
        var leftHandles = GetRandomCoffinPart(CoffinParts.HandlesLeft);
        var rightHandles = GetRandomCoffinPart(CoffinParts.HandlesRight);

        AddOrder(new CoffinOrder(lids, bases, tops, bottoms, leftSides, rightSides, leftHandles, rightHandles));
    }

    public void AddOrder(CoffinOrder coffinOrder)
    {
        Orders.Add(coffinOrder);
        OrderAdded.Invoke();

        if (CurrentOrder == null)
        {
            SetNewCurrentOrder();
        }
    }

    public void CompleteCurrentOrder()
    {
        if (CurrentOrder.PlacedLid.Name != CurrentOrder.Order.LidName.Name)
        {
            Debug.Log("Order was incorrect");
        }
        else
        {
            Debug.Log("Order was correct");
        }

        SetNewCurrentOrder();
    }

    public void SetNewCurrentOrder()
    {
        CurrentOrder = null;

        if (Orders.Count > 0)
        {
            CurrentOrder = new CurrentCoffinOrder()
            {
                Order = Orders[0]
            };
            CurrentOrder.OnOrderComplete.AddListener(CompleteCurrentOrder);
        }

        OnNewCurrentOrderAdded.Invoke();
    }

    private CoffinObject GetRandomCoffinPart(IEnumerable<CoffinObject> objects)
    {
        return objects.Skip(Random.Range(0, objects.Count())).FirstOrDefault();
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
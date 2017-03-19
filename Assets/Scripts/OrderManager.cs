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
    public UnityEvent OrderCompleted;
    public UnityEvent OrderCompletedSuccessfully;
    public IntUnityEvent OrderCompletedUnsuccessfully = new IntUnityEvent();
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
        var pickedIndex = Random.Range(0, CoffinParts.Lids.Count);
        var shuffleChance = GameManager.Instance.DifficultyModifier * 5;

        var lids = GetRandomCoffinPart(CoffinParts.Lids, pickedIndex, shuffleChance);
        var bases = GetRandomCoffinPart(CoffinParts.Bases, pickedIndex, shuffleChance);
        var tops = GetRandomCoffinPart(CoffinParts.Tops, pickedIndex, shuffleChance);
        var bottoms = GetRandomCoffinPart(CoffinParts.Bottoms, pickedIndex, shuffleChance);
        var leftSides = GetRandomCoffinPart(CoffinParts.LeftSides, pickedIndex, shuffleChance);
        var rightSides = GetRandomCoffinPart(CoffinParts.RightSides, pickedIndex, shuffleChance);
        var leftHandles = GetRandomCoffinPart(CoffinParts.HandlesLeft, pickedIndex, shuffleChance);
        var rightHandles = GetRandomCoffinPart(CoffinParts.HandlesRight, pickedIndex, shuffleChance);

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
        var amountWrong = 0;
        amountWrong += CurrentOrder.PlacedLid.Name == CurrentOrder.Order.LidName.Name ? 0 : 1;
        amountWrong += CurrentOrder.PlacedBase.Name == CurrentOrder.Order.BaseName.Name ? 0 : 1;
        amountWrong += CurrentOrder.PlacedTop.Name == CurrentOrder.Order.TopName.Name ? 0 : 1;
        amountWrong += CurrentOrder.PlacedBottom.Name == CurrentOrder.Order.BottomName.Name ? 0 : 1;
        amountWrong += CurrentOrder.PlacedLeftSide.Name == CurrentOrder.Order.LeftSideName.Name ? 0 : 1;
        amountWrong += CurrentOrder.PlacedRightSide.Name == CurrentOrder.Order.RightSideName.Name ? 0 : 1;
        amountWrong += CurrentOrder.PlacedLeftHandle.Name == CurrentOrder.Order.HandleLeft.Name ? 0 : 1;
        amountWrong += CurrentOrder.PlacedRightHandle.Name == CurrentOrder.Order.HandleRight.Name ? 0 : 1;

        if (amountWrong > 0)
        {
            OrderCompletedUnsuccessfully.Invoke(amountWrong);
            Debug.Log("Order was incorrect");
        }
        else
        {
            OrderCompletedSuccessfully.Invoke();
            Debug.Log("Order was correct");
        }

        OrderCompleted.Invoke();

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
            Orders.RemoveAt(0);
            CurrentOrder.OnOrderComplete.AddListener(CompleteCurrentOrder);
        }

        OnNewCurrentOrderAdded.Invoke();
    }

    private CoffinObject GetRandomCoffinPart(IEnumerable<CoffinObject> objects, int pickedIndex, int chanceToShuffle)
    {
        if (Random.Range(0, 100) < chanceToShuffle)
        {
            return objects.Skip(Random.Range(0, objects.Count())).FirstOrDefault();
        }
        else
        {
            return objects.Skip(pickedIndex).FirstOrDefault();
        }
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
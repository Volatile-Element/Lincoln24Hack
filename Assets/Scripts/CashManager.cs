using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CashManager : Singleton<CashManager>
{
    public int CurrentCash = 1000;
    public int RentDay = 500;
    public int ChargeForACoffin = 100;

    public UnityEvent OnCashChanged;

    private void Awake()
    {
        GameManager.Instance.OnDayChange.AddListener(OnDayChange);
        OrderManager.Instance.OrderCompletedSuccessfully.AddListener(OnSuccesfullOrder);
        OrderManager.Instance.OrderCompletedUnsuccessfully.AddListener(OnUnsuccessfullOrder);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDayChange()
    {
        ChangeCash(-RentDay);
    }

    public void OnSuccesfullOrder()
    {
        ChangeCash(ChargeForACoffin);
    }

    public void OnUnsuccessfullOrder(int amountWrong)
    {
        if (GameManager.Instance.DifficultyModifier > 1)
        {
            ChangeCash(amountWrong * (GameManager.Instance.DifficultyModifier * 10));
        }
    }

    public void ChangeCash(int amount)
    {
        CurrentCash += amount;

        OnCashChanged.Invoke();

        if (CurrentCash <= 0)
        {
            //TODO: Game Over
        }
    }
}
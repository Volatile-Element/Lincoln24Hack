using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : Singleton<GameManager>
{
    public Player PlayerOne;

    public int CurrentDay = 0;

    public System.DateTime CurrentTime;

    public UnityEvent OnStateChange;
    public UnityEvent OnDayChange;
    public UnityEvent OnTimeChange;

    public int DifficultyModifier;

    public GameState State;

    public enum GameState { ChangingDay, PlayMode };

    private void Awake()
    {
        PlayerOne = FindObjectOfType<Player>();
    }

    // Use this for initialization
    void Start()
    {
        IncrementDay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(GameState state)
    {
        State = state;
        OnStateChange.Invoke();
    }

    public void IncrementDay()
    {
        CurrentDay++;
        StopCoroutine(TickingClock());
        CurrentTime = new System.DateTime(2017, 3, 19, 9, 0, 0);

        DifficultyModifier = CurrentDay;

        ChangeState(GameState.ChangingDay);
        OnDayChange.Invoke();
        OrderManager.Instance.StopMakingOrders();
        PlayerOne.GetComponent<FirstPersonController>().enabled = false;
        PlayerOne.Paused = true;

        StartCoroutine(SlightDelayBetweenDaysForEffect());
    }

    public void ContinueWithDay()
    {
        ChangeState(GameState.PlayMode);
        OrderManager.Instance.StartMakingOrders();
        PlayerOne.GetComponent<FirstPersonController>().enabled = true;
        PlayerOne.Paused = false;
        StartCoroutine(TickingClock());
    }

    IEnumerator SlightDelayBetweenDaysForEffect()
    {
        yield return new WaitForSeconds(3);
        ContinueWithDay();
    }

    IEnumerator TickingClock()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            CurrentTime = CurrentTime.AddMinutes(1);
            OnTimeChange.Invoke();

            if (CurrentTime.Hour >= 17)
            {
                IncrementDay();
                break;
            }
        }
    }
}
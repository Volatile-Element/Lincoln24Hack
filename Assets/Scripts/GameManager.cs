using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : Singleton<GameManager>
{
    public Player PlayerOne;

    public int CurrentDay = 0;

    public UnityEvent OnStateChange;

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

        ChangeState(GameState.ChangingDay);
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
    }

    IEnumerator SlightDelayBetweenDaysForEffect()
    {
        yield return new WaitForSeconds(3);
        ContinueWithDay();
    }
}
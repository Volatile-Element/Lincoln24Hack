using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player PlayerOne;

    private void Awake()
    {
        PlayerOne = FindObjectOfType<Player>();
    }

    // Use this for initialization
    void Start ()
    {
        //We'll do some stuff here.

        //Then the gameplay will start:
        OrderManager.Instance.StartMakingOrders();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
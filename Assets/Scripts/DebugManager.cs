using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.B))
        {
            BuildCurrentCoffin();
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
        {
            RoseBud();
        }
    }

    public void BuildCurrentCoffin()
    {

    }

    public void RoseBud()
    {
        CashManager.Instance.ChangeCash(1000);
    }
}
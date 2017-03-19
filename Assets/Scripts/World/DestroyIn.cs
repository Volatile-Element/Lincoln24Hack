using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIn : MonoBehaviour
{
    public float TTD = 5;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(WaitForDestroy());
	}
	
    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(TTD);
        Destroy(gameObject);
    }
}
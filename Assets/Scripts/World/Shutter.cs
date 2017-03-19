using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    Animator Anim;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayAnimation()
    {
        Anim.Play("Shutter");
    }
}
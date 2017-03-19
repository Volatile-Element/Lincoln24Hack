using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieceBuiltSound : MonoBehaviour
{
    public AudioClip[] Sounds;
    public AudioSource AudioSource;

    // Use this for initialization
    void Start()
    {
        Sounds = Resources.LoadAll<AudioClip>("Sounds/Building");
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PlayRandomSound()
    {
        AudioSource.clip = Sounds.Skip(Random.Range(0, Sounds.Length)).FirstOrDefault();
        AudioSource.Play();
    }
}
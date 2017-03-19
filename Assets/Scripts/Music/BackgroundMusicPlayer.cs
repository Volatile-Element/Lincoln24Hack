using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    public AudioClip[] BackgroundMusics;
    public AudioSource AudioSource;

	// Use this for initialization
	void Start () {
        BackgroundMusics = Resources.LoadAll<AudioClip>("Sounds/Background Music");
        AudioSource = GetComponent<AudioSource>();

        AudioSource.clip = BackgroundMusics.Skip(Random.Range(0, BackgroundMusics.Length)).FirstOrDefault();
        AudioSource.Play();

        StartCoroutine(ChangeSongIn(AudioSource.clip.length));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ChangeSongIn(float songLength)
    {
        yield return new WaitForSeconds(songLength);
        AudioSource.clip = BackgroundMusics.Skip(Random.Range(0, BackgroundMusics.Length)).FirstOrDefault();
        AudioSource.Play();

        StartCoroutine(ChangeSongIn(AudioSource.clip.length));
    }
}
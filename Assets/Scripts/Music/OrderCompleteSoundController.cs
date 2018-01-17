using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCompleteSoundController : MonoBehaviour
{
    public AudioSource Shutter;
    public AudioSource Car;
    public AudioSource Response;

    public AudioClip Success;
    public AudioClip Failure;

    private void Awake()
    {
        Shutter = transform.Find("Shutter").GetComponent<AudioSource>();
        Car = transform.Find("Car").GetComponent<AudioSource>();
        Response = transform.Find("Response").GetComponent<AudioSource>();

        Success = Resources.Load<AudioClip>("Sounds/Orders/Success");
        Failure = Resources.Load<AudioClip>("Sounds/Orders/Failure");
    }

    // Use this for initialization
    void Start () {
        OrderManager.Instance.OrderCompletedSuccessfully.AddListener(PlaySuccessSounds);
        OrderManager.Instance.OrderCompletedUnsuccessfully.AddListener(PlayFailureSounds);
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void PlaySuccessSounds()
    {
        Response.clip = Success;

        StartCoroutine(PlaySoundsQueue());
    }

    public void PlayFailureSounds(int amount)
    {
        Response.clip = Failure;

        StartCoroutine(PlaySoundsQueue());
    }

    IEnumerator PlaySoundsQueue()
    {
        Shutter.Play();
        yield return new WaitForSeconds(Shutter.clip.length);

        Car.Play();
        Response.Play();
    }
}
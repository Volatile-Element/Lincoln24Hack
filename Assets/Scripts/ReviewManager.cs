using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReviewManager : Singleton<ReviewManager>
{
    public ReviewList Reviews;

    public StringUnityEvent OnReviewMade = new StringUnityEvent();

    void Awake()
    {
        //Load Coffin Parts
        var json = Resources.Load<TextAsset>("reviews").text;
        Reviews = JsonUtility.FromJson<ReviewList>(json);
    }

    // Use this for initialization
    void Start () {
        OrderManager.Instance.OrderCompletedSuccessfully.AddListener(OrderCompletedSuccess);
        OrderManager.Instance.OrderCompletedUnsuccessfully.AddListener(OrderCompletedUnsuccessfully);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OrderCompletedSuccess()
    {
        var randomGood = Reviews.Good.Skip(Random.Range(0, Reviews.Good.Count)).FirstOrDefault();

        OnReviewMade.Invoke(randomGood);
    }

    public void OrderCompletedUnsuccessfully(int amount)
    {
        var randomBad = Reviews.Bad.Skip(Random.Range(0, Reviews.Bad.Count)).FirstOrDefault();

        OnReviewMade.Invoke(randomBad);
    }
}
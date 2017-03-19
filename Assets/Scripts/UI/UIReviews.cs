using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReviews : MonoBehaviour
{
    Canvas ParentCanvas;
    Image imgTwitterPanel;
    Text txtReview;

    private void Awake()
    {
        ParentCanvas = gameObject.GetComponent<Canvas>();
        imgTwitterPanel = ParentCanvas.transform.FindChild("imgTwitterPanel").GetComponent<Image>();
        txtReview = imgTwitterPanel.transform.FindChild("txtReview").GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        ReviewManager.Instance.OnReviewMade.AddListener(ShowReview);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowReview(string review)
    {
        txtReview.text = review;
        imgTwitterPanel.gameObject.SetActive(true);

        StartCoroutine(HideReview());
    }

    IEnumerator HideReview()
    {
        yield return new WaitForSeconds(15);
        imgTwitterPanel.gameObject.SetActive(false);
        txtReview.text = "";
    }
}
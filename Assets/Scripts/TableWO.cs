using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableWO : MonoBehaviour
{
    public List<GameObject> ObjectsOnTable = new List<GameObject>();
    public PlacePoint[] PlacePoints;

    private void Awake()
    {
        PlacePoints = GetComponentsInChildren<PlacePoint>();
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public TableWO[] Tables;

    private void Awake()
    {
        Tables = FindObjectsOfType<TableWO>();
    }

    // Use this for initialization
    void Start ()
    {
        //TOOD: Place objects on tables.
        var coffinParts = CoffinManager.Instance.CoffinParts;
        SpawnParts(coffinParts);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnParts(CoffinPartList partList)
    {
        var partListCopy = new List<List<CoffinObject>>(new [] { partList.Lids, partList.Bases, partList.Tops, partList.Bottoms, partList.LeftSides, partList.RightSides, partList.HandlesLeft, partList.HandlesRight });
        var tablesCopy = new List<TableWO>(Tables);

        if (partListCopy.Count > tablesCopy.Count)
        {
            throw new System.Exception("There are more parts than there are tables!");
        }

        while (partListCopy.Count > 0)
        {
            var randomIndexParts = Random.Range(0, partListCopy.Count);
            var randomIndexTables = Random.Range(0, tablesCopy.Count);

            SpawnParts(partListCopy[randomIndexParts], tablesCopy[randomIndexTables]);

            partListCopy.RemoveAt(randomIndexParts);
            tablesCopy.RemoveAt(randomIndexTables);
        }
    }

    public void SpawnParts(List<CoffinObject> parts, TableWO table)
    {
        var partsCopy = new List<CoffinObject>(parts);
        var placePointsCopy = new List<PlacePoint>(table.PlacePoints);

        if (partsCopy.Count > placePointsCopy.Count)
        {
            throw new System.Exception("There's no room at the table!");
        }

        while (partsCopy.Count > 0)
        {
            var randomIndexParts = Random.Range(0, partsCopy.Count);
            var randomIndexPlaces = Random.Range(0, placePointsCopy.Count);

            var part = partsCopy[randomIndexParts];

            var instanCoffinPart = CoffinManager.Instance.InstantiateCoffinPart(part.Resource, placePointsCopy[randomIndexPlaces].transform.position, Quaternion.identity, table.transform); //TODO: Add random rotation for pretty.

            var partComponent = instanCoffinPart.AddComponent<CoffinPartWorldObject>();
            partComponent.CoffinObject = part;
            var colliderComponent = instanCoffinPart.AddComponent<BoxCollider>(); //TODO: Change the shape and size of this based on something.
            colliderComponent.isTrigger = true;

            partsCopy.RemoveAt(randomIndexParts);
            placePointsCopy.RemoveAt(randomIndexPlaces);
        }
    }
}
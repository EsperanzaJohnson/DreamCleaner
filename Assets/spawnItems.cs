using System.Collections.Generic;
using UnityEngine;

public class spawnItems : MonoBehaviour
{

    public List<GameObject> possibleItems = new List<GameObject>();
    public int maxItemAmount;
    public int currentlySpawned = 0;

    private void spawnItem(GameObject item)
    {
        GameObject spawnedItem = Instantiate(item);
        item.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
        getClicked clickedScript = spawnedItem.GetComponent<getClicked>();
        if (clickedScript != null)
        {
            clickedScript.Spawner = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        while (currentlySpawned < maxItemAmount)
        {
            spawnItem(possibleItems[Random.Range(0, possibleItems.Count)]);
            currentlySpawned++;
        }

    }



}
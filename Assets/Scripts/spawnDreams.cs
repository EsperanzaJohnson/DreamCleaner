using System.Collections.Generic;
using UnityEngine;

public class spawnDreams : MonoBehaviour
{
    public List<GameObject> possibleItems = new List<GameObject>();
    public int maxItemAmount = 5;
    public int currentlySpawned = 0;

    private void spawnDream(GameObject item)
    {
        GameObject spawnedDream = Instantiate(item);
        //To change Random.Range(-9, 9), Random.Range(-4,4) to specific points at random
        //Potential idea: switch case with random number seed, and then spawn at specific coordinates
        //Vector2 coordinates to spawn from: (4, 1.5) is the center upper bed
        // (-4, 1.5) bottom, (7, 4) right bed, (-4, -4) left bed
        spawnedDream.transform.position = new Vector2(Random.Range(-9, 9), Random.Range(-4, 4));
        DreamClassScript clickedScript = spawnedDream.GetComponent<DreamClassScript>();
        if (clickedScript != null)
        {
            clickedScript.DreamSpawner = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        while (currentlySpawned < maxItemAmount && currentlySpawned >=0)
        {
            spawnDream(possibleItems[Random.Range(0, possibleItems.Count)]);
            currentlySpawned++;
        }

    }
}

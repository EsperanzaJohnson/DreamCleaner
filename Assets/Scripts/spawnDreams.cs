using System.Collections.Generic;
using UnityEngine;

public class spawnDreams : MonoBehaviour
{
    public List<GameObject> possibleItems = new List<GameObject>();
    public int maxItemAmount = 5;
    public int currentlySpawned = 0;

    private void spawnDream(GameObject dream)
    {
        int randomPosition = 0;
        randomPosition = Random.Range(0, 6);
        GameObject spawnedDream = Instantiate(dream);
        switch (randomPosition)
        {
            case 0://Upper center bed
                spawnedDream.transform.position = new Vector2(4.0f, 1.5f);
            break;
            case 1://Lower center bed
                spawnedDream.transform.position = new Vector2(-4.0f, 1.5f);
            break;
            case 2://Upper right bed
                spawnedDream.transform.position = new Vector2(7.0f, 4.0f);
                break;
            case 3://Lower right bed
                spawnedDream.transform.position = new Vector2(7.0f, -4.0f);
                break;
            case 4://Upper left bed
                spawnedDream.transform.position = new Vector2(-4.0f, 4.0f);
                break;
            case 5://Lower left bed
                spawnedDream.transform.position = new Vector2(-4.0f, -4.0f);
                break;
            default:
                spawnedDream.transform.position = new Vector2(4.0f, 1.5f);
            break;

        }
        
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

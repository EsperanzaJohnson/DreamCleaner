using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DreamSpawner : MonoBehaviour
{
    public int MaxDreams;
    public int CurrentDreams=0;
    public GameObject newSprite;
    public GameObject spritePrefab;
    public GameObject spritePrefabGood;
    public GameObject spritePrefabBad;
    public int dreamType = 0;
    public int totalPoints = 0;
    public float spawnInterval = 2.0f; 
    private List<int> AvailablePositions;
    private float timer;
    private float DreamLifetime=3.0f;

    public Vector2[] spawnPositions = new Vector2[]
    {
        new Vector2(-2.142833f, 4.02131f),
        new Vector2(2.25f, 4.07f),
        new Vector2(6.83f, 4.04f),
        new Vector2(-2.19f, -2.73f),
        new Vector2(2.39f, -2.78f),
        new Vector2(6.83f, -2.59f),
    };



    void Start()
    {
        AvailablePositions=new List<int>();
        for(int i=0;i<spawnPositions.Length;i++)
        {
            AvailablePositions.Add(i);
        }
        timer = spawnInterval;
    }

    
    void Update()
    {
        timer -= Time.deltaTime; 
        if (timer <= 0 && CurrentDreams<MaxDreams)
        {
            SpawnSprite(); 
            CurrentDreams++;
            timer = spawnInterval; 
        }
    }

    void SpawnSprite()
    {
        int randomIndex = Random.Range(0, AvailablePositions.Count);
        int positionIndex = AvailablePositions[randomIndex];
        int randomDreamPrefab = Random.Range(0, 3);

        if (randomDreamPrefab == 0) 
        { 
            newSprite = Instantiate(spritePrefab, spawnPositions[positionIndex], Quaternion.identity);
            dreamType = 0;
        }

        else
        {
            if (randomDreamPrefab == 1) 
            { 
                newSprite = Instantiate(spritePrefabGood, spawnPositions[positionIndex], Quaternion.identity); 
                dreamType = 1;
            }
            else 
            { 
                newSprite = Instantiate(spritePrefabBad, spawnPositions[positionIndex], Quaternion.identity);
                dreamType = -1;
            }
        }
        //GameObject newSprite = Instantiate(spritePrefab, spawnPositions[positionIndex], Quaternion.identity);
        AvailablePositions.RemoveAt(randomIndex);
        DreamCollisionHandler collisionHandler = newSprite.AddComponent<DreamCollisionHandler>(); 
        collisionHandler.SetSpawner(this, positionIndex, DreamLifetime);
        StartCoroutine(DestroySpriteAfterTime(newSprite, positionIndex));

    }

    private IEnumerator DestroySpriteAfterTime(GameObject Dream, int positionIndex)
    {
        yield return new WaitForSeconds(DreamLifetime);

        if (Dream != null)
        {
            Destroy(Dream);
            totalPoints += -1;
            Debug.Log("Dream Spawner points:");
            Debug.Log(totalPoints.ToString());
            CurrentDreams--;
            AvailablePositions.Add(positionIndex);
        }
    }
     public void DestroyDreamImmediately(int positionIndex, GameObject Dream, int points)
    {
        StopCoroutine(DestroySpriteAfterTime(Dream, positionIndex));
        Destroy(Dream);
        totalPoints += points;
        CurrentDreams--;
        AvailablePositions.Add(positionIndex);
    }
}

public class DreamCollisionHandler : MonoBehaviour
{
    public GameObject dropItem;
    //public GameObject dreamElement;
    private DreamSpawner spawner;
    private int positionIndex;
    private int itemType;
    private int dreamType;
    private int dreamPoints;

    public void SetSpawner(DreamSpawner spawnerReference, int index, float timer)
    {
        spawner = spawnerReference;
        positionIndex = index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dropItem = collision.gameObject;
        itemType = dropItem.GetComponent<DragAndDrop>().objectType;
        dreamType = spawner.dreamType;
        Debug.Log("Dream Type Hit is:");
        Debug.Log(dreamType.ToString());

        if (spawner != null && dreamType==itemType)
        {
            spawner.DestroyDreamImmediately(positionIndex, gameObject, 1);
            spawner.CurrentDreams--; 
        }
        else
        {
            if(spawner != null && itemType == -10)
            {
                spawner.DestroyDreamImmediately(positionIndex, gameObject, -10);
                spawner.CurrentDreams--;
            }
        }
    }
}

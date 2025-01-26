using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DreamSpawner : MonoBehaviour
{
    public int MaxDreams;
    public int CurrentDreams=0;
    public GameObject spritePrefab;
    public float spawnInterval = 2.0f; 
    private List<int> AvailablePositions;
    private float timer;
    private float DreamLifetime=10.0f;

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

        GameObject newSprite = Instantiate(spritePrefab, spawnPositions[positionIndex], Quaternion.identity);
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
            CurrentDreams--;
            AvailablePositions.Add(positionIndex);
        }
    }
     public void DestroyDreamImmediately(int positionIndex, GameObject Dream)
    {
        StopCoroutine(DestroySpriteAfterTime(Dream, positionIndex));
        Destroy(Dream);
        CurrentDreams--;
        AvailablePositions.Add(positionIndex);
    }
}

public class DreamCollisionHandler : MonoBehaviour
{
    private DreamSpawner spawner;
    private int positionIndex;

    public void SetSpawner(DreamSpawner spawnerReference, int index, float timer)
    {
        spawner = spawnerReference;
        positionIndex = index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spawner != null)
        {
            spawner.DestroyDreamImmediately(positionIndex, gameObject);
            spawner.CurrentDreams--; 
        }
    }
}

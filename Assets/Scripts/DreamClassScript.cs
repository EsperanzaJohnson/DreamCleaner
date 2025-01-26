using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DreamClassScript : MonoBehaviour
{
    private bool isNightmare = false;
    private float dreamTimer = 5.0f;
    private int dreamPoint = 0;
    public int totalPoints = 0;
    private int dreamType;
    private string dreamText = "Test Dream";
    private int attackDreamType = -1;
    private string dreamSpriteName = "";
    public GameObject GODream;
    public DragAndDrop dadItem;
    public GameObject GOItem;
    public spawnDreams DreamSpawner;
    public TotalPoints globalPoints;

    public enum DreamType
    {
        Bad = -1,
        Neutral = 0,
        Good = 1
    }
    public DreamClassScript()
    {
        dreamText = "Test Dream";
    }

    public DreamClassScript(bool newIsNightmare, float newTimerCountdown, int newDreamPoint, int newDreamType, string newDreamText)
    {
        this.isNightmare = newIsNightmare;
        this.dreamTimer = newTimerCountdown;
        this.dreamPoint = newDreamPoint;
        this.dreamType = newDreamType;
        this.dreamText = newDreamText;
    }

    public bool getIsNightmare()
    {
        return isNightmare;
    }

    public int getDreamPoint()
    {
        return dreamPoint;
    }

    public string getDreamText()
    {
        return dreamText;
    }

    public void setIsNightmare(bool newIsNightmare)
    {
        isNightmare = newIsNightmare;
    }

    public void setDreamPoint(int newDreamPoint)
    {
        dreamPoint = newDreamPoint;
    }

    public void setDreamText(string newDreamText)
    {
        dreamText = newDreamText;
    }

    public void Pop()
    {


    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dreamSpriteName = GetComponent<SpriteRenderer>().sprite.name;
        if (dreamSpriteName.Contains("Neut"))
        {
            dreamType = (int)DreamType.Neutral;
        }
        else
        {
            if (dreamSpriteName.Contains("Good"))
            {
                dreamType = (int)DreamType.Good;
            }
            else
            {
                if (dreamSpriteName.Contains("Bad"))
                {
                    dreamType = (int)DreamType.Bad;
                }
                else
                {
                    dreamType = (int)DreamType.Neutral;
                }
            }
        }
        //Debug.Log(dreamType.ToString());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
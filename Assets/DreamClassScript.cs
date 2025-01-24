using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DreamClassScript : MonoBehaviour
{
    private bool isNightmare = false;
    private float dreamTimer = 3.0f;
    private int dreamPoint = 1;
    private int dreamType = 2;
    private string dreamText = "Test Dream";
    private int attackDreamType = -1;
    public GameObject GODream;

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
        DreamBehaviour();
        //Destroy(GODream, 2.0f);
        //Debug.Log(dreamPoint.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DreamBehaviour()
    {
        while (dreamTimer != 0.0f && dreamType != attackDreamType)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                attackDreamType = 2;
            }

            if (dreamType == attackDreamType)
            {
                Destroy(GODream, 2.0f);
                Debug.Log("Correct Dream Type attack! You get 1 points!");
                Debug.Log(dreamPoint.ToString());
            }
            else
            {
                Debug.Log("The Dream Type is not the correct one to destroy");
            }
        }
    }
}

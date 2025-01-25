using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DreamScript", menuName = "Scriptable Objects/DreamScript")]
public class DreamScript : ScriptableObject
{
    private bool isNightmare = false;
    private float dreamTimer = 0.0f;
    private int dreamPoint = 1;
    private int dreamType = -1;
    private string dreamText = "";

    public DreamScript() {
        dreamText = "Test Dream";
    }

    public DreamScript(bool newIsNightmare, float newTimerCountdown, int newDreamPoint, int newDreamType, string newDreamText)
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
        isNightmare=newIsNightmare;
    }

    public void setDreamPoint(int newDreamPoint)
    {
        dreamPoint = newDreamPoint;
    }

    public void setDreamText(string newDreamText)
    {
        dreamText=newDreamText;
    }

    public void Pop()
    {

    }
}

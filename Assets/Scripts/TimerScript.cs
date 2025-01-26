using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public DreamSpawner dreamInstance;
    public int gamePoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            gamePoints = dreamInstance.GetComponent<DreamSpawner>().totalPoints;
            //Debug.Log("Timer Game Points:");
            //Debug.Log(gamePoints.ToString());
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            if (gamePoints >= 0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
     SceneManager.LoadScene(0);   
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameScreen : MonoBehaviour
{
    public void Continue()
    {
        if (GameManager.Instance.IsEveryLevelCompleted())
        {
            SceneManager.LoadScene("Menu");
            return;
        }
        GameManager.Instance.LoadNextLevel();
    }
    
    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
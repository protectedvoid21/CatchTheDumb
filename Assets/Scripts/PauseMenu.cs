using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
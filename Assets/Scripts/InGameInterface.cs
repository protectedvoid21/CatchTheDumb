using System.Collections;
using TMPro;
using UnityEngine;

public class InGameInterface : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _catchablesLeftText;
    [SerializeField]
    private TextMeshProUGUI _timerText;

    [SerializeField] 
    private TextMeshProUGUI _levelText;
    
    [SerializeField] 
    private GameObject _pausePanel;

    [SerializeField] 
    private GameObject _winPanel;
    [SerializeField]
    private GameObject _gameOverPanel;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            _pausePanel.SetActive(!_pausePanel.activeSelf);
        }
    }

    public void Initialize(int level)
    {
        _levelText.text = level.ToString();
    }

    public void UpdateTimerUI(int timeLeft)
    {
        _timerText.text = timeLeft.ToString();
    }
    
    public void UpdateCatchableCountUI(int catchablesLeft)
    {
        _catchablesLeftText.text = catchablesLeft.ToString();
    }
    
    public void HideShownPanels()
    {
        _pausePanel.SetActive(false);
        _winPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
    }
    
    public void DisplayGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void DisplayWinPanel()
    {
        _winPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
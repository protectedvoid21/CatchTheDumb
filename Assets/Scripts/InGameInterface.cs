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
    private int _gameDurationInSeconds;
    [SerializeField] 
    private GameObject _pausePanel;

    [SerializeField] 
    private GameObject _winPanel;
    [SerializeField]
    private GameObject _gameOverPanel;
    
    private void Start()
    {
        var catchablePool = FindFirstObjectByType<CatchablePool>();
        _catchablesLeftText.text = catchablePool.RemainingCatchablesCount.ToString();
        
        StartCoroutine(RunTimer());
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            _pausePanel.SetActive(!_pausePanel.activeSelf);
        }
    }

    private IEnumerator RunTimer()
    {
        while (_gameDurationInSeconds > 0)
        {
            _gameDurationInSeconds--;
            _timerText.text = _gameDurationInSeconds.ToString();
            yield return new WaitForSeconds(1);
        }
        GameManager.Instance.FinishGame();
    }
    
    public void UpdateCatchableCountUI(int catchablesLeft)
    {
        _catchablesLeftText.text = catchablesLeft.ToString();
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
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private InGameInterface _inGameInterface;
    private CatchablePool _catchablePool;
    private int _timeLeft;
    private Coroutine _timerCoroutine;

    [SerializeField]
    private Level _level;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GetAllReferences();
            SetupLevel();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void GetAllReferences()
    {
        _inGameInterface = FindAnyObjectByType<InGameInterface>();
        _catchablePool = FindAnyObjectByType<CatchablePool>();
    }

    public void CatchCatchable()
    {
        _catchablePool.CatchCatchable();
        _inGameInterface.UpdateCatchableCountUI(_catchablePool.RemainingCatchablesCount);
        if (IsGameWon())
        {
            WinGame();
        }
    }
    
    private IEnumerator RunTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft--;
            _inGameInterface.UpdateTimerUI(_timeLeft);
            yield return new WaitForSeconds(1);
        }
        FinishGame();
    }
    
    public void RestartGame()
    {
        SetupLevel();
    }
    
    public void LoadNextLevel()
    {
        _level = _level.NextLevel;
        SetupLevel();
    }
    
    private void SetupLevel()
    {
        _catchablePool.Initialize(_level);
        _timeLeft = _level.TimeLimit;
        _inGameInterface.Initialize(_level.Number);
        _inGameInterface.UpdateCatchableCountUI(_level.CatchableCount);
        _inGameInterface.HideShownPanels();
        Time.timeScale = 1;
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }
        _timerCoroutine = StartCoroutine(RunTimer());
    }
    
    public bool IsEveryLevelCompleted()
    {
        return _level.NextLevel == null;
    }
    
    public void ReturnCatchableToPool()
    {
        _catchablePool.ReturnCatchableToPool();
    }

    public void FinishGame()
    {
        if (IsGameWon())
        {
            WinGame();
        }
        else
        {
            GameOver();
        }
    }

    private bool IsGameWon()
    {
        return _catchablePool.RemainingCatchablesCount == 0;
    }

    private void WinGame()
    {
        print("Win!");
        _inGameInterface.DisplayWinPanel();
    }
    
    private void GameOver()
    {
        print("Game Over!");
        _inGameInterface.DisplayGameOverPanel();
    }
}
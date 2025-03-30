using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private InGameInterface _inGameInterface;
    private CatchablePool _catchablePool;
    private LevelLoader _levelLoader;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GetAllReferences();
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
        _levelLoader = FindAnyObjectByType<LevelLoader>();
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
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private InGameInterface _inGameInterface;
    private CatchablePool _catchablePool;

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
    }

    public void CatchCatchable()
    {
        _catchablePool.CatchCatchable();
        _inGameInterface.UpdateCatchableCountUI(_catchablePool.RemainingCatchablesCount);
    }
    
    public void ReturnCatchableToPool()
    {
        _catchablePool.ReturnCatchableToPool();
    }

    public void FinishGame()
    {
        if (_catchablePool.RemainingCatchablesCount == 0)
        {
            WinGame();
        }
        else
        {
            GameOver();
        }
    }

    private void WinGame()
    {
        print("Win!");
    }
    
    private void GameOver()
    {
        print("Game Over!");
    }
}
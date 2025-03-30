using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private InGameInterface _inGameInterface;

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
    }

    public void CatchCatchable(PlayerCatchEventArgs value)
    {
        print(value.IsCaught ? "Caught an object!" : "Object escaped!");
        _inGameInterface.ReceiveCatchEvent(value);
    }
}
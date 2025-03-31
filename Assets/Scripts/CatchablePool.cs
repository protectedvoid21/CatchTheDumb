using System.Collections;
using UnityEngine;

public class CatchablePool : MonoBehaviour
{
    [SerializeField]
    private CatchablesSpawner _catchablesSpawner;
    
    private float _spawnInterval;
    private float _spawnIntervalVariance;

    public int RemainingCatchablesCount { get; private set; }

    private int _catchablesOutsideCount;
    
    public void Initialize(Level level)
    {
        var catchablesOutside = FindObjectsByType<CatchObject>(FindObjectsSortMode.None);
        foreach (var catchable in catchablesOutside)
        {
            Destroy(catchable.gameObject);
        }
        
        RemainingCatchablesCount = level.CatchableCount;
        _catchablesOutsideCount = 0;
        _spawnInterval = level.SpawnInterval;
        _spawnIntervalVariance = level.SpawnInterval * 0.2f;
        StartCoroutine(SpawnCatchables());
    }
    
    private IEnumerator SpawnCatchables()
    {
        while (RemainingCatchablesCount > 0)
        {
            while (AreAllCatchablesOutside())
            {
                yield return null;
            }
            if (RemainingCatchablesCount == 0)
            {
                break;
            }
            _catchablesSpawner.SpawnCatchable();
            _catchablesOutsideCount++;
            
            yield return new WaitForSeconds(_spawnInterval + Random.Range(-_spawnIntervalVariance, _spawnIntervalVariance));
        }
    }
    
    private bool AreAllCatchablesOutside()
    {
        return _catchablesOutsideCount == RemainingCatchablesCount && RemainingCatchablesCount > 0;
    }
    
    public void ReturnCatchableToPool()
    {
        _catchablesOutsideCount--;
    }

    public void CatchCatchable()
    {
        _catchablesOutsideCount--;
        RemainingCatchablesCount--;
    }
}
using System.Collections;
using UnityEngine;

public class CatchablePool : MonoBehaviour
{
    private CatchablesSpawner _catchablesSpawner;
    
    [SerializeField, Min(0)]
    private float _spawnInterval;
    [SerializeField, Min(0)]
    private float _spawnIntervalVariance;

    [SerializeField, Min(0)]
    private int _remainingCatchablesCount;
    public int RemainingCatchablesCount => _remainingCatchablesCount;
    
    private int _catchablesOutsideCount;

    private void Awake()
    {
        _catchablesSpawner = FindAnyObjectByType<CatchablesSpawner>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCatchables());
    }
    
    private IEnumerator SpawnCatchables()
    {
        while (_remainingCatchablesCount > 0)
        {
            while (AreAllCatchablesOutside())
            {
                yield return null;
            }
            _catchablesSpawner.SpawnCatchable();
            _catchablesOutsideCount++;
            
            yield return new WaitForSeconds(_spawnInterval + Random.Range(-_spawnIntervalVariance, _spawnIntervalVariance));
        }
    }
    
    private bool AreAllCatchablesOutside()
    {
        return _catchablesOutsideCount == _remainingCatchablesCount && _remainingCatchablesCount > 0;
    }
    
    public void ReturnCatchableToPool()
    {
        _catchablesOutsideCount--;
    }

    public void CatchCatchable()
    {
        _catchablesOutsideCount--;
        _remainingCatchablesCount--;
    }
}
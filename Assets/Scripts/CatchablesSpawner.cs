using System.Collections;
using UnityEngine;

public class CatchablesSpawner : MonoBehaviour
{
    [SerializeField]
    private CatchObject[] _spawnableCatchables;
    [SerializeField]
    private Transform[] _holes;
    [SerializeField, Min(0)]
    private float _spawnInterval;
    [SerializeField, Min(0)]
    private float _spawnIntervalVariance;

    [SerializeField, Min(0)]
    private int _remainingCatchablesCount;
    
    public int CatchablesToSpawnCount { get; private set; }
    
    private void Awake()
    {
        CatchablesToSpawnCount = _remainingCatchablesCount;
    }
    
    private void Start()
    {
        StartCoroutine(SpawnCatchablesCoroutine());
    }

    private IEnumerator SpawnCatchablesCoroutine()
    {
        while (_remainingCatchablesCount > 0)
        {
            var catchableToSpawn = _spawnableCatchables[Random.Range(0, _spawnableCatchables.Length)];
            var catchableSpawnData = GetRandomCatchablePosition();
           
            CatchObject catchObject = Instantiate(catchableToSpawn, catchableSpawnData.StartHole.position, Quaternion.identity);
            catchObject.DestinationHole = catchableSpawnData.DestinationHole;
            
            _remainingCatchablesCount--;
            yield return new WaitForSeconds(Random.Range(_spawnInterval - _spawnIntervalVariance, _spawnInterval + _spawnIntervalVariance));
        }
    }

    private CatchableSpawnData GetRandomCatchablePosition()
    {
        int randomStartIndex = Random.Range(0, _holes.Length);
        int randomDestinationIndex = Random.Range(0, _holes.Length);

        while (randomStartIndex == randomDestinationIndex)
        {
            randomStartIndex = Random.Range(0, _holes.Length);
        }
        
        return new CatchableSpawnData
        {
            StartHole = _holes[randomStartIndex],
            DestinationHole = _holes[randomDestinationIndex]
        };
    }
}
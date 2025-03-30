using System.Collections;
using UnityEngine;

public class CatchablesSpawner : MonoBehaviour
{
    [SerializeField]
    private CatchObject[] _spawnableCatchables;
    [SerializeField]
    private Transform[] _holes;
    
    public void SpawnCatchable()
    {
        var catchableToSpawn = _spawnableCatchables[Random.Range(0, _spawnableCatchables.Length)];
        var catchableSpawnData = GetRandomCatchablePosition();
           
        CatchObject catchObject = Instantiate(catchableToSpawn, catchableSpawnData.StartHole.position, Quaternion.identity);
        catchObject.DestinationHole = catchableSpawnData.DestinationHole;
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
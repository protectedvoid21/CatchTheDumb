using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField]
    private Animal[] _spawnableAnimals;
    [SerializeField]
    private Transform[] _holes;
    [SerializeField, Min(0)]
    private float _spawnInterval;
    [SerializeField, Min(0)]
    private float _spawnIntervalVariance;

    [SerializeField, Min(0)]
    private int _animalsToSpawnCount;
    
    private void Start()
    {
        StartCoroutine(SpawnAnimalsCoroutine());
    }

    private IEnumerator SpawnAnimalsCoroutine()
    {
        while (_animalsToSpawnCount > 0)
        {
            var animalToSpawn = _spawnableAnimals[Random.Range(0, _spawnableAnimals.Length)];
            var animalSpawnData = GetRandomAnimalPosition();
            Animal animal = Instantiate(animalToSpawn, animalSpawnData.StartHole.position, Quaternion.identity);
            animal.DestinationHole = animalSpawnData.DestinationHole;
            
            _animalsToSpawnCount--;
            yield return new WaitForSeconds(Random.Range(_spawnInterval - _spawnIntervalVariance, _spawnInterval + _spawnIntervalVariance));
        }
    }

    private AnimalSpawnData GetRandomAnimalPosition()
    {
        int randomStartIndex = Random.Range(0, _holes.Length);
        int randomDestinationIndex = Random.Range(0, _holes.Length);

        while (randomStartIndex == randomDestinationIndex)
        {
            randomStartIndex = Random.Range(0, _holes.Length);
        }
        
        return new AnimalSpawnData
        {
            StartHole = _holes[randomStartIndex],
            DestinationHole = _holes[randomDestinationIndex]
        };
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    private readonly float areaSize = 49.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRabbit), 1, 1);
        InvokeRepeating(nameof(SpawnFox), 2, 2);
        InvokeRepeating(nameof(SpawnBear), 5, 5);
    }

    private void SpawnRabbit()
    {
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        Instantiate(animalPrefabs[0], randomPos, animalPrefabs[0].transform.rotation);
    }

    private void SpawnFox()
    {
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        Instantiate(animalPrefabs[1], randomPos, animalPrefabs[1].transform.rotation);
    }

    private void SpawnBear()
    {
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        Instantiate(animalPrefabs[2], randomPos, animalPrefabs[2].transform.rotation);
    }
}

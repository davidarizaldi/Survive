using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject[] animalPrefabs;
    private readonly float areaSize = GameManager.areaSize;

    // Start is called before the first frame update
    void Start()
    {
        animalPrefabs = GameManager.animalPrefabs;
        SpawnMultiple(32);
    }

    void SpawnRabbit()
    {
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        Instantiate(animalPrefabs[0], randomPos, animalPrefabs[0].transform.rotation);
    }

    void SpawnFox()
    {
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        Instantiate(animalPrefabs[1], randomPos, animalPrefabs[1].transform.rotation);
    }

    void SpawnBear()
    {
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        Instantiate(animalPrefabs[2], randomPos, animalPrefabs[2].transform.rotation);
    }

    public void SpawnRepeat()
    {
        InvokeRepeating(nameof(SpawnRabbit), 1, 1);
        InvokeRepeating(nameof(SpawnFox), 4, 4);
        InvokeRepeating(nameof(SpawnBear), 16, 16);
    }

    public void SpawnMultiple(int number)
    {
        for (int i = 0; i < number; i++)
        {
            SpawnRabbit();
            if (i % 4 == 0) SpawnFox();
            if (i % 16 == 0) SpawnBear();
        }
    }
}

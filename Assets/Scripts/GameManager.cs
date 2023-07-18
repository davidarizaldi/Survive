using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject[] animalPrefabs;
    [SerializeField] private GameObject[] _animalPrefabs;
    [HideInInspector] public static readonly float areaSize = 49.0f;

    private SpawnManager spawner;

    [HideInInspector] public static Animal playerObject;
    [HideInInspector] public static string playerName;
    [HideInInspector] public static int playerIndex;
    [HideInInspector] public static bool isAlive;

    private void Awake()
    {
        animalPrefabs = _animalPrefabs;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner = new();
        SpawnPlayer(MainManager.playerName, MainManager.animalIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer(string playerName, int playerIndex)
    {
        GameManager.playerName = playerName;
        GameManager.playerIndex = playerIndex;
        
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        playerObject = Instantiate(animalPrefabs[playerIndex], randomPos, animalPrefabs[playerIndex].transform.rotation).GetComponent<Animal>();
        playerObject.isPlayer = true;
        isAlive = true;
    }

    public static void GameOver()
    {

    }
}

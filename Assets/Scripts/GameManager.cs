using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject[] animalPrefabs;
    [SerializeField] private GameObject[] _animalPrefabs;
    [HideInInspector] public static readonly float areaSize = 49.0f;

    private SpawnManager spawner;

    [HideInInspector] public static GameObject playerObject;
    [HideInInspector] public static Animal playerAnimalObj;
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
        spawner = gameObject.AddComponent<SpawnManager>();
        spawner.SpawnRepeat();
        SpawnPlayer(MainManager.playerName, MainManager.animalIndex);
    }

    public static void SpawnPlayer(string playerName, int playerIndex)
    {
        GameManager.playerName = playerName;
        GameManager.playerIndex = playerIndex;
        
        Vector3 randomPos = new(Random.Range(-areaSize, areaSize), 0.5f, Random.Range(-areaSize, areaSize));
        playerObject = Instantiate(animalPrefabs[playerIndex], randomPos, animalPrefabs[playerIndex].transform.rotation);
        playerAnimalObj = playerObject.GetComponentInChildren<Animal>();
        playerAnimalObj.isPlayer = true;
        isAlive = true;
        TimeUI.ResetTime();
        HudUIHandler.HideGameOver();
        CamFollowPlayer.ChangeHeight();
        if (playerIndex == 0)
        {
            HudUIHandler.Instance.ShowTip();
        }
    }

    public static void GameOver()
    {
        isAlive = false;

        HudUIHandler.ShowGameOver();
    }
}

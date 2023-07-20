using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    private Vector3 cameraHeight = new(0, 20, 0);
    private static Camera cameraInstance;

    private void Awake()
    {
        cameraInstance = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.isAlive)
        {
            transform.position = GameManager.playerAnimalObj.transform.position + cameraHeight;
        }
    }

    public static void ChangeHeight()
    {
        cameraInstance.orthographicSize = 8.0f + GameManager.playerIndex * 2.0f;
    }
}

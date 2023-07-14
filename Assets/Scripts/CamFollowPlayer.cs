using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    private Vector3 cameraHeight = new(0, 20, 0);

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.isAlive)
        {
            transform.position = GameManager.playerObject.transform.position + cameraHeight;
        }
    }
}

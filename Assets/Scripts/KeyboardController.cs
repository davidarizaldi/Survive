using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    private Animal player;
    private bool moveUp;
    private bool moveLeft;
    private bool moveDown;
    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveUp = false;
            UpdateMovement();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
            UpdateMovement();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveDown = false;
            UpdateMovement();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
            UpdateMovement();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveUp = true;
            UpdateMovement();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
            UpdateMovement();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDown = true;
            UpdateMovement();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
            UpdateMovement();
        }
    }

    void UpdateMovement()
    {
        float XAxis =  (moveRight ? 1 : 0) + (moveLeft ? 1 : 0) * -1;
        float YAxis = (moveUp ? 1 : 0) + (moveDown ? 1 : 0) * -1;
        player.SetVelocity(new Vector3(XAxis, 0, YAxis));
    }
}

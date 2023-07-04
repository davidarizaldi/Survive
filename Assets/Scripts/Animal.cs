using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected string animalName;
    protected int animalType;
    protected float HP;
    protected float maxHP = 100;

    public bool isPlayer;
    private Vector3 currentVelocity;
    protected float speed = 10.0f;
    private float decaySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        if (!isPlayer)
        {
            StartCoroutine(ChangeVelocityRoutine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Decay();
        Move();
    }

    protected virtual void Initialize()
    {
        animalName = gameObject.name;
        HP = maxHP;
        decaySpeed = 2;
    }

    public void SetVelocity(Vector3 velocity)
    {
        currentVelocity = velocity * speed;
    }

    private void Move()
    {
        transform.position = transform.position + currentVelocity * Time.deltaTime;
    }

    private void PickNewVelocity()
    {
        currentVelocity = Random.insideUnitSphere;
        currentVelocity.y = 0;
        currentVelocity *= speed;
    }

    IEnumerator ChangeVelocityRoutine()
    {
        PickNewVelocity();
        float timer = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(timer);
        StartCoroutine(ChangeVelocityRoutine());
    }

    private void Decay()
    {
        HP -= decaySpeed * Time.deltaTime;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        InvertOnEdge(collision);
    }

    private void InvertOnEdge(Collision collision)
    {
        if (collision.gameObject.name == "Left Wall" && currentVelocity.x < 0)
        {
            currentVelocity.x *= -1;
        }
        else if (collision.gameObject.name == "Right Wall" && currentVelocity.x > 0)
        {
            currentVelocity.x *= -1;
        }

        if (collision.gameObject.name == "Bottom Wall" && currentVelocity.z < 0)
        {
            currentVelocity.z *= -1;
        }
        else if (collision.gameObject.name == "Upper Wall" && currentVelocity.z > 0)
        {
            currentVelocity.z *= -1;
        }
    }

    private void OnDestroy()
    {
        if (isPlayer)
        {

        }
    }
}

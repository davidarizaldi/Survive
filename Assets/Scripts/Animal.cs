using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected string animalName;
    protected int animalType;       // 0 = rabbit, 1 = fox, 2 = bear
    [HideInInspector] public float HP;
    [HideInInspector] public float maxHP = 60;       // 0 = 20, 1 = 60, 2 = 180

    [HideInInspector] public bool isPlayer;
    protected Vector3 currentVelocity;
    protected float speed = 10.0f;
    protected const float decaySpeed = 2;

    Animator anim;

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
    protected virtual void Update()
    {
        Decay();
        Move();
    }

    protected virtual void Initialize()
    {
        animalName = gameObject.name;
        HP = maxHP;
        anim = GetComponent<Animator>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        currentVelocity = velocity * speed;
    }

    void Move()
    {
        if (currentVelocity != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentVelocity), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        transform.position = transform.position + currentVelocity * Time.deltaTime;
    }

    protected virtual void PickNewVelocity()
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

    void Decay()
    {
        HP -= decaySpeed * Time.deltaTime;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Eat(collision);
        
        InvertOnEdge(collision);
    }

    protected void Eat(Collision collision)
    {
        Animal animal = collision.gameObject.GetComponent<Animal>();
        if (animal == null) return;

        if (animal.animalType < animalType)
        {
            if (animal.HP < 0.25f * animal.maxHP)
            {
                HP += 0.25f * animal.maxHP;
            }
            else
            {
                HP += animal.HP;
            }
            if (HP > maxHP)
            {
                HP = maxHP;
            }
            Destroy(collision.gameObject);
        }
    }

    void InvertOnEdge(Collision collision)
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

    void OnDestroy()
    {
        if (isPlayer)
        {
            GameManager.GameOver();
        }
    }
}

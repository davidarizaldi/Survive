using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    protected override void Update()
    {
        Regenerate();
        base.Update();
    }

    protected override void Initialize()
    {
        animalType = 0;
        maxHP = 20;
        speed = 12.5f;
        base.Initialize();
    }

    protected override void PickNewVelocity()
    {
        if (Random.value < 0.7f && HP > 0.1f * maxHP)
        {
            base.PickNewVelocity();
        }
        else
        {
            currentVelocity = Vector3.zero;
        }
    }

    void Regenerate()
    {
        if (currentVelocity == Vector3.zero)
        {
            HP += 1.5f * decaySpeed * Time.deltaTime;
        }
    }

    protected override void PlayEatSound(int eatenIndex)
    {
        
    }
}

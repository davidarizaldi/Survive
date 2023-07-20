using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal
{
    protected override void Initialize()
    {
        animalType = 2;
        maxHP = 120;
        speed = 7.5f;
        base.Initialize();
    }

    protected override void PlayEatSound(int eatenIndex)
    {
        if (animalType - eatenIndex < 2)
        {
            eatSFX.Play();
        }
    }
}

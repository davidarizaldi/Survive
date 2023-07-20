using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal  // INHERITANCE
{
    protected override void Initialize()    // POLYMORPHISM
    {
        animalType = 2;
        maxHP = 120;
        speed = 7.5f;
        base.Initialize();
    }

    protected override void PlayEatSound(int eatenIndex)    // POLYMORPHISM
    {
        if (animalType - eatenIndex < 2)
        {
            eatSFX.Play();
        }
    }
}

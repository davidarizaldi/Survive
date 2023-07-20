using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal   // INHERITANCE
{
    protected override void Initialize()    // POLYMORPHISM
    {
        animalType = 1;
        maxHP = 60;
        speed = 10;
        base.Initialize();
    }

    protected override void PlayEatSound(int eatenIndex)    // POLYMORPHISM
    {
        eatSFX.Play();
    }
}

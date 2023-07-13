using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
    protected override void Initialize()
    {
        animalType = 2;
        maxHP = 100;
        speed = 10;
        base.Initialize();
    }
}

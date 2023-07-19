using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
    protected override void Initialize()
    {
        animalType = 1;
        maxHP = 60;
        speed = 10;
        base.Initialize();
    }
}

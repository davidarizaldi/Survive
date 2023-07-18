using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal
{
    protected override void Initialize()
    {
        animalType = 2;
        maxHP = 320;
        speed = 7.5f;
        base.Initialize();
    }
}

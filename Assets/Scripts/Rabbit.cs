using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    protected override void Initialize()
    {
        maxHP = 20;
        speed = 15;
        base.Initialize();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
    protected override void Initialize()
    {
        maxHP = 100;
        speed = 10;
        base.Initialize();
    }
}

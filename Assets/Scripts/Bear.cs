using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal
{
    protected override void Initialize()
    {
        maxHP = 500;
        speed = 7.5f;
        base.Initialize();
    }
}

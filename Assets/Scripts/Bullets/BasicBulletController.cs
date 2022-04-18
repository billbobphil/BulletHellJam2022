using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasicBulletController : BulletController
{
    protected override void StartLogicHook()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(0, -.5f, 0);
    }
}

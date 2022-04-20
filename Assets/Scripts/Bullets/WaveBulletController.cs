using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using UnityEngine;

public class WaveBulletController : BulletController
{
    protected override void StartLogicHook()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(BulletSpeed);
    }
}

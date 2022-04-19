using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using Guns;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasicBulletController : BulletController
{
    protected override void StartLogicHook()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(myGunController.bulletSpeed);
    }
}

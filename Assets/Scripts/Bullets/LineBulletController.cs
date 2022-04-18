using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using Unity.VisualScripting;
using UnityEngine;

public class LineBulletController : BulletController
{
    [NonSerialized]
    public Vector3 BulletSpeed;
    
    protected override void StartLogicHook()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(BulletSpeed);
    }
}

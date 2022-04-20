using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using Unity.VisualScripting;
using UnityEngine;

public class LineBulletController : BulletController
{
    protected override void StartLogicHook()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(EnableCollision());
    }

    private void FixedUpdate()
    {
        transform.Translate(myGunController.bulletSpeed);
    }

    private IEnumerator EnableCollision()
    {
        yield return new WaitForSecondsRealtime(.5f);
        GetComponent<CircleCollider2D>().enabled = true;
    }
}

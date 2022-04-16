using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletController : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(0, -.5f, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

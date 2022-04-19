using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using UnityEngine;

public class SwerveBulletController : BulletController
{
    private float _verticalMoveSpeed;
    private const float Frequency = 1f;
    private const float Magnitude = 8f;

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += (Mathf.Sin(Time.time * Frequency) * Magnitude) * Time.deltaTime;
        newPosition.y += _verticalMoveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
    

    protected override void StartLogicHook()
    {
        _verticalMoveSpeed = myGunController.bulletSpeed.y;
    }
}

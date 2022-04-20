using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using UnityEngine;
using Random = UnityEngine.Random;

public class SwerveBulletController : BulletController
{
    private float _verticalMoveSpeed;
    private const float Frequency = 1f;
    private const float Magnitude = 3f;
    private float _phase;
    private float _mySpawnTime;

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += (Mathf.Sin((Time.time * Frequency) + _phase) * Magnitude) * Time.deltaTime;
        newPosition.y += _verticalMoveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
    

    protected override void StartLogicHook()
    {
        _verticalMoveSpeed = myGunController.bulletSpeed.y;
        _phase = Random.value;
    }
}

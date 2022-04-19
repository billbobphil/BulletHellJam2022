using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrajectoryChangeBulletController : BulletController
{
    public float timeToTrajectoryChange;
    private Vector3 _currentTrajectory;
    [System.NonSerialized]
    public Vector3 PostChangeTrajectory;

    protected override void StartLogicHook()
    {
        _currentTrajectory = myGunController.bulletSpeed;
        StartCoroutine(ChangeTrajectory());
    }

    private void FixedUpdate()
    {
        transform.Translate(_currentTrajectory);
    }

    private IEnumerator ChangeTrajectory()
    {
        yield return new WaitForSecondsRealtime(timeToTrajectoryChange);
        _currentTrajectory = PostChangeTrajectory;
    }
}

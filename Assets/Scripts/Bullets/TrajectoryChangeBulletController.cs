using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrajectoryChangeBulletController : MonoBehaviour
{
    private Color _myColor;
    public float timeToTrajectoryChange;
    private Vector3 _currentTrajectory;
    [System.NonSerialized]
    public Vector3 PostChangeTrajectory;
    
    private void Start()
    {
        _myColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        GetComponent<SpriteRenderer>().color = _myColor;
        GetComponent<TrailRenderer>().startColor = _myColor;
        _currentTrajectory = new Vector3(0, -.25f, 0);
        StartCoroutine(ChangeTrajectory());
    }

    private void FixedUpdate()
    {
        transform.Translate(_currentTrajectory);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private IEnumerator ChangeTrajectory()
    {
        yield return new WaitForSecondsRealtime(timeToTrajectoryChange);
        _currentTrajectory = PostChangeTrajectory;
    }
}

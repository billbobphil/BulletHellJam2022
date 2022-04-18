using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BasicBulletController : MonoBehaviour
{
    private Color _myColor;
    
    private void Start()
    {
        _myColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        GetComponent<SpriteRenderer>().color = _myColor;
        GetComponent<TrailRenderer>().startColor = _myColor;
    }

    private void FixedUpdate()
    {
        transform.Translate(0, -.5f, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

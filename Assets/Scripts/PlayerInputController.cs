using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private const float PlayerSpeed = .1f;
    private float _playerWidth;
    private float _playerHeight;
    private MovementRestriction _movementRestriction;

    private void Awake()
    {
        _movementRestriction = GameObject.FindWithTag("Overseer").GetComponent<MovementRestriction>();
    }
    
    private void Start()
    {
        _playerWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        _playerHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, PlayerSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-PlayerSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(PlayerSpeed, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -PlayerSpeed, 0);
        }
    }

    private void LateUpdate()
    {
        _movementRestriction.RestrictObjectMovement(transform, _playerWidth, _playerHeight);
    }
}

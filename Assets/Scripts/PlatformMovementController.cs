using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementController : MonoBehaviour
{
    private const float PlatformSpeed = 0.025f;
    private bool _playerOnBoard = false;
    private PlatformDirections _currentDirection;
    private Transform _playerTransform;
    private float _platformWidth;
    private float _platformHeight;
    private MovementRestriction _movementRestriction;
    private bool _isAtEdge = false;

    public enum PlatformDirections
    {
        Stationary,
        Forward,
        Backwards,
        Left,
        Right
    }

    private void Awake()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _movementRestriction = GameObject.FindWithTag("Overseer").GetComponent<MovementRestriction>();
    }
    
    private void Start()
    {
        _currentDirection = PlatformDirections.Stationary;
        _platformWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        _platformHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection;
        switch (_currentDirection)
        {
            case(PlatformDirections.Forward):
                movementDirection = new Vector3(0, PlatformSpeed, 0);
                break;
            case(PlatformDirections.Backwards):
                movementDirection = new Vector3(0, -PlatformSpeed, 0);
                break;
            case(PlatformDirections.Left):
                movementDirection = new Vector3(-PlatformSpeed,0, 0);
                break;
            case(PlatformDirections.Right):
                movementDirection = new Vector3(PlatformSpeed, 0, 0);
                break;
            case(PlatformDirections.Stationary):
                movementDirection = new Vector3(0, 0, 0);
                break;
            default:
                movementDirection = new Vector3(0, 0, 0);
                break;
        }
        
        transform.Translate(movementDirection);
        
        if (_playerOnBoard && !_isAtEdge)
        {
           _playerTransform.Translate(movementDirection);
        }
    }

    private void LateUpdate()
    {
        _isAtEdge = _movementRestriction.RestrictObjectMovement(transform, _platformWidth, _platformHeight);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _playerOnBoard = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _playerOnBoard = false;
        }
    }

    public void ChangeDirection(PlatformDirections direction)
    {
        _currentDirection = direction;
    }
}

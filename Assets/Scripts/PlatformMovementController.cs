using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformMovementController : MonoBehaviour
{
    private const float PlatformSpeed = 0.04f;
    private bool _playerOnBoard = false;
    private PlatformDirections _currentDirection;
    private Transform _playerTransform;
    private float _platformWidth;
    private float _platformHeight;
    private PlatformMovementRestriction _platformMovementRestriction;
    private List<PlatformMovementRestriction.CollisionDirection> _collisionEdges = new();

    public enum PlatformDirections
    {
        Forward,
        Backwards,
        Left,
        Right,
        Stationary
    }

    private void Awake()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _platformMovementRestriction = GameObject.FindWithTag("Overseer").GetComponent<PlatformMovementRestriction>();
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

        if (!_playerOnBoard) return;

        if (!_collisionEdges.Contains((PlatformMovementRestriction.CollisionDirection)_currentDirection) && _currentDirection != PlatformDirections.Stationary)
        {
            _playerTransform.Translate(movementDirection);
        }
    }

    private void LateUpdate()
    {
        _collisionEdges = _platformMovementRestriction.RestrictObjectMovement(transform, _platformWidth, _platformHeight);
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

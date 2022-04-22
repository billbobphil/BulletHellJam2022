using System.Collections.Generic;
using Overseer;
using UnityEngine;

public class PlatformMovementController : MonoBehaviour
{
    public float platformSpeed;
    private bool _playerOnBoard = false;
    private PlatformDirections _currentDirection;
    private Transform _playerTransform;
    private float _platformWidth;
    private float _platformHeight;
    private PlatformMovementRestriction _platformMovementRestriction;
    private List<PlatformMovementRestriction.CollisionDirection> _collisionEdges = new();
    private bool _canMoveForward = true;
    private bool _canMoveBackwards = true;
    private bool _canMoveLeft = true;
    private bool _canMoveRight = true;
    private PlatformDirectionNodeController _activeNodeController;
    public bool shouldIgnoreCameraBounds;

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
                movementDirection = _canMoveForward ? new Vector3(0, platformSpeed, 0) : new Vector3(0, 0, 0);
                break;
            case(PlatformDirections.Backwards):
                movementDirection = _canMoveBackwards ? new Vector3(0, -platformSpeed, 0) : new Vector3(0, 0, 0);
                break;
            case(PlatformDirections.Left):
                movementDirection = _canMoveLeft ? new Vector3(-platformSpeed,0, 0) : new Vector3(0,0,0);
                break;
            case(PlatformDirections.Right):
                movementDirection = _canMoveRight ? new Vector3(platformSpeed, 0, 0) : new Vector3(0,0,0);
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
        if (shouldIgnoreCameraBounds) return;
        
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

    public void EnterCollisionWithOtherPlatform(PlatformDirections directionToRestrict)
    {
        switch (directionToRestrict)
        {
            case PlatformDirections.Forward:
                _canMoveForward = false;
                break;
            case PlatformDirections.Backwards:
                _canMoveBackwards = false;
                break;
            case PlatformDirections.Left:
                _canMoveLeft = false;
                break;
            case PlatformDirections.Right:
                _canMoveRight = false;
                break;
        }    
        
        ChangeDirection(PlatformDirections.Stationary);
    }

    public void ExitCollisionWithOtherPlatform(PlatformDirections directionExiting)
    {
        switch (directionExiting)
        {
            case PlatformDirections.Forward:
                _canMoveBackwards = true;
                break;
            case PlatformDirections.Backwards:
                _canMoveForward = true;
                break;
            case PlatformDirections.Left:
                _canMoveRight = true;
                break;
            case PlatformDirections.Right:
                _canMoveLeft = true;
                break;
        }    
    }

    public void ChangeDirection(PlatformDirections direction)
    {
        _currentDirection = direction;
    }

    public void ToggleActiveControlNode(PlatformDirectionNodeController controller)
    {
        if (_activeNodeController != null)
        {
            _activeNodeController.MakeUnactivated();
        }
        
        controller.MakeActivated();

        _activeNodeController = controller;
    }
}

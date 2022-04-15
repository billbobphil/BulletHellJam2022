using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private const float PlayerSpeed = .1f;
    private Camera _mainCamera;
    private Vector2 _screenBounds;
    private float _playerWidth;
    private float _playerHeight;

    private void Awake()
    {
        
    }
    
    private void Start()
    {
        _mainCamera = Camera.main;
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
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
        RestrictPlayerMovementBounds();
    }
    
    private void RestrictPlayerMovementBounds()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, (_screenBounds.x * -1) + _playerWidth, _screenBounds.x - _playerWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, (_screenBounds.y * -1) + _playerHeight, _screenBounds.y - _playerHeight);
        transform.position = viewPosition;
    }
}

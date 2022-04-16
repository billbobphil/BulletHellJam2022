using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDirectionNodeController : MonoBehaviour
{
    public PlatformMovementController.PlatformDirections myDirection;
    private PlatformMovementController _parentPlatformMovementController;
    public Sprite unactivatedSprite;
    public Sprite activatedSprite;
    private SpriteRenderer _mySpriteRenderer;

    private void Awake()
    {
        _parentPlatformMovementController = transform.parent.GetComponent<PlatformMovementController>();
        _mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Sword"))
        {
            _parentPlatformMovementController.ChangeDirection(myDirection);
            _parentPlatformMovementController.ToggleActiveControlNode(this);
        }
    }

    public void MakeActivated()
    {
        _mySpriteRenderer.sprite = activatedSprite;
    }
    
    public void MakeUnactivated()
    {
        _mySpriteRenderer.sprite = unactivatedSprite;
    }
}

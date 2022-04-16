using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEdgeColliderController : MonoBehaviour
{
    private PlatformMovementController _parentPlatform;

    private void Awake()
    {
        _parentPlatform = transform.parent.GetComponent<PlatformMovementController>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("TopPlatform"))
        {
            _parentPlatform.EnterCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Backwards);
        }

        if (col.CompareTag("BottomPlatform"))
        {
            _parentPlatform.EnterCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Forward);
        }

        if (col.CompareTag("RightPlatform"))
        {
            _parentPlatform.EnterCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Left);
        }

        if (col.CompareTag("LeftPlatform"))
        {
            _parentPlatform.EnterCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Right);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TopPlatform"))
        {
            _parentPlatform.ExitCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Forward);
        }

        if (other.CompareTag("BottomPlatform"))
        {
            _parentPlatform.ExitCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Backwards);
        }

        if (other.CompareTag("RightPlatform"))
        {
            _parentPlatform.ExitCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Right);
        }

        if (other.CompareTag("LeftPlatform"))
        {
            _parentPlatform.ExitCollisionWithOtherPlatform(PlatformMovementController.PlatformDirections.Left);
        }
    }
}

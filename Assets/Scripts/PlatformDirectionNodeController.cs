using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDirectionNodeController : MonoBehaviour
{
    public PlatformMovementController.PlatformDirections myDirection;
    private PlatformMovementController _parentPlatformMovementController;

    private void Awake()
    {
        _parentPlatformMovementController = transform.parent.GetComponent<PlatformMovementController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Sword"))
        {
            _parentPlatformMovementController.ChangeDirection(myDirection);
        }
    }
}

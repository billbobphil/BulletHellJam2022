using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPositionController : MonoBehaviour
{
    private Camera _mainCamera;
    
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        AimSwordAtMouse();
    }

    private void AimSwordAtMouse()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        PointSwordAtTarget(mousePosition, gameObject.transform.position, gameObject, 1);
    }

    private static void PointSwordAtTarget(Vector2 targetPosition, Vector2 shooterPosition, GameObject sword, float distanceBetweenPlayerAndSword)
    {
        double x = targetPosition.x - shooterPosition.x;
        double y = targetPosition.y - shooterPosition.y;
        
        double angleInRadians = Math.Atan2(x, y);
        double angleInDegrees = angleInRadians * (180 / Mathf.PI);
        
        double smallX = distanceBetweenPlayerAndSword * Math.Sin(angleInRadians);
        double smallY = distanceBetweenPlayerAndSword * Math.Cos(angleInRadians);
        
        Vector3 newSwordPosition = new ((float)smallX, (float)smallY, 0);
        
        Vector3 newSwordAngle = new (0, 0, (float)-angleInDegrees);
        
        sword.transform.localPosition = newSwordPosition;
        sword.transform.eulerAngles = newSwordAngle;
    }
}

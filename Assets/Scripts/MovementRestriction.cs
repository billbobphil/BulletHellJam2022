using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRestriction : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector2 _screenBounds;
    
    private void Start()
    {
        _mainCamera = Camera.main;
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
    }
    
    public bool RestrictObjectMovement(Transform objectTransform, float objectWidth,  float objectHeight)
    {
        Vector3 viewPosition = objectTransform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, (_screenBounds.x * -1) + objectWidth, _screenBounds.x - objectWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, (_screenBounds.y * -1) + objectHeight, _screenBounds.y - objectHeight);
        objectTransform.position = viewPosition;

        if (viewPosition.x == (_screenBounds.x * -1) + objectWidth || viewPosition.x == _screenBounds.x - objectWidth)
        {
            return true;
        }

        if (viewPosition.y == (_screenBounds.y * -1) + objectHeight || viewPosition.y == _screenBounds.y - objectHeight)
        {
            return true;
        }

        return false;
    }
}

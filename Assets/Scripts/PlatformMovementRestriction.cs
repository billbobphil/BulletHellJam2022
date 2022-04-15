using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementRestriction : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector2 _screenBounds;

    public enum CollisionDirection
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }
    
    private void Start()
    {
        _mainCamera = Camera.main;
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
    }
    
    public List<CollisionDirection> RestrictObjectMovement(Transform objectTransform, float objectWidth,  float objectHeight)
    {
        List<CollisionDirection> collisions = new();
        
        Vector3 viewPosition = objectTransform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, (_screenBounds.x * -1) + objectWidth, _screenBounds.x - objectWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, (_screenBounds.y * -1) + objectHeight, _screenBounds.y - objectHeight);
        objectTransform.position = viewPosition;

        if (viewPosition.x == (_screenBounds.x * -1) + objectWidth)
        {
            collisions.Add(CollisionDirection.Left);
        }

        if (viewPosition.x == _screenBounds.x - objectWidth)
        {
            collisions.Add(CollisionDirection.Right);
        }

        if (viewPosition.y == (_screenBounds.y * -1) + objectHeight)
        {
            collisions.Add(CollisionDirection.Bottom);
        }

        if (viewPosition.y == _screenBounds.y - objectHeight)
        {
            collisions.Add(CollisionDirection.Top);
        }

        if (collisions.Count == 0)
        {
            collisions.Add(CollisionDirection.None);
        }

        return collisions;
    }
}

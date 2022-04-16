using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementRestriction : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector2 _screenBounds;
    private float _startingPlatformHeight;
    private float _endingPlatformHeight;

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
        SpriteRenderer startingPlatformSpriteRenderer = GameObject.FindWithTag("StartingPlatform").GetComponent<SpriteRenderer>();
        _startingPlatformHeight = startingPlatformSpriteRenderer.bounds.extents.y;
        SpriteRenderer endingPlatformSpriteRenderer = GameObject.FindWithTag("EndingPlatform").GetComponent<SpriteRenderer>();
        _endingPlatformHeight = startingPlatformSpriteRenderer.bounds.extents.y;
    }
    
    public List<CollisionDirection> RestrictObjectMovement(Transform objectTransform, float objectWidth,  float objectHeight)
    {
        List<CollisionDirection> collisions = new();
        
        Vector3 viewPosition = objectTransform.position;

        float minY = (_screenBounds.y * -1) + objectHeight + (_startingPlatformHeight * 2);
        float maxY = _screenBounds.y - objectHeight - (_endingPlatformHeight * 2);
        float minX = (_screenBounds.x * -1) + objectWidth;
        float maxX = _screenBounds.x - objectWidth;
        
        
        viewPosition.x = Mathf.Clamp(viewPosition.x, minX, maxX);
        viewPosition.y = Mathf.Clamp(viewPosition.y, minY, maxY);
        objectTransform.position = viewPosition;

        if (viewPosition.x == minX)
        {
            collisions.Add(CollisionDirection.Left);
        }

        if (viewPosition.x == maxX)
        {
            collisions.Add(CollisionDirection.Right);
        }

        if (viewPosition.y == minY)
        {
            collisions.Add(CollisionDirection.Bottom);
        }

        if (viewPosition.y == maxY)
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

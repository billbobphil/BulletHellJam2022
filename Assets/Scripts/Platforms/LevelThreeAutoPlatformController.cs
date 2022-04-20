using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeAutoPlatformController : MonoBehaviour
{
   private PlatformMovementController _platformMovementController;
   private float _originalSpeed;
   
   private void Start()
   {
      _platformMovementController = GetComponentInParent<PlatformMovementController>();
      _originalSpeed = _platformMovementController.platformSpeed;
      StartCoroutine(MovePlatform());
   }

   private IEnumerator MovePlatform()
   {
      yield return new WaitForSecondsRealtime(1);
      _platformMovementController.platformSpeed = _originalSpeed / 3;
      _platformMovementController.ChangeDirection(PlatformMovementController.PlatformDirections.Forward);
      GameObject forwardControlNode = GameObject.FindGameObjectsWithTag("PlatformControlNode")[0];
      _platformMovementController.ToggleActiveControlNode(forwardControlNode.GetComponent<PlatformDirectionNodeController>());
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("StartingPlatform"))
      {
         _platformMovementController.ChangeDirection(PlatformMovementController.PlatformDirections.Stationary);
         _platformMovementController.platformSpeed = _originalSpeed;
         transform.position = new Vector3(transform.position.x, -.2f, 0);
      }
   }
}

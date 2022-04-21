using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeAutoPlatformController : MonoBehaviour
{
   private PlatformMovementController _platformMovementController;
   private float _originalSpeed;
   private AudioSource _mySoundEffect;
   
   private void Start()
   {
      _platformMovementController = GetComponentInParent<PlatformMovementController>();
      _originalSpeed = _platformMovementController.platformSpeed;
      
      _mySoundEffect = GetComponent<AudioSource>();
   }

   public void StartMovingPlatform()
   {
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
         _mySoundEffect.Play();
         StartCoroutine(MuteAudioSource());
         _platformMovementController.ChangeDirection(PlatformMovementController.PlatformDirections.Stationary);
         _platformMovementController.platformSpeed = _originalSpeed;
         transform.position = new Vector3(transform.position.x, -.2f, 0);
         GameObject.FindWithTag("Boss").GetComponent<BossThreeController>().ChangeBossState(BossThreeController.BossThreeState.PhaseTwo);
      }
   }

   private IEnumerator MuteAudioSource()
   {
      yield return new WaitForSecondsRealtime(4);
      _mySoundEffect.mute = true;
   }
   
}

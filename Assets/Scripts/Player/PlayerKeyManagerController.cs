using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyManagerController : MonoBehaviour
{
   [NonSerialized]
   public int numberOfKeysCollected;

   public GameObject doorAudioManager;
   public GameObject keyUiManager;

   private const int TotalNumberOfKeys = 4;

   public AudioSource keyPickupAudioSource;
   public GameObject keyIndicatorPrefab;
   public List<GameObject> keys;
   private List<SpriteRenderer> _keyRenderers = new List<SpriteRenderer>();
   private List<SpriteRenderer> _keyIndicatorRenderers = new List<SpriteRenderer>();

   private List<GameObject> _keyIndicators = new List<GameObject>();
   
   private void Start()
   {
      for (int i = 0; i < 4; i++)
      {
         _keyIndicators.Add(Instantiate(keyIndicatorPrefab, transform));
         _keyIndicators[i].GetComponent<SpriteRenderer>().color = keys[i].GetComponent<SpriteRenderer>().color;
         _keyRenderers.Add(keys[i].GetComponent<SpriteRenderer>());
         _keyIndicatorRenderers.Add(_keyIndicators[i].GetComponent<SpriteRenderer>());
      }
   }

   private void FixedUpdate()
   {
      for (int i = 0; i < _keyIndicators.Count; i++)
      {
         if (_keyRenderers[i].isVisible)
         {
            _keyIndicatorRenderers[i].enabled = false;
         }
         else if(!_keyIndicatorRenderers[i].enabled)
         {
            _keyIndicatorRenderers[i].enabled = true;
         }

         PointIndicatorAtTarget(keys[i].transform.position, _keyIndicators[i].transform.position, _keyIndicators[i], 3);
      }
   }
   
   private static void PointIndicatorAtTarget(Vector2 targetPosition, Vector2 pointerPosition, GameObject pointer, float distanceBetweenPlayerAndPointer)
   {
      double x = targetPosition.x - pointerPosition.x;
      double y = targetPosition.y - pointerPosition.y;
        
      double angleInRadians = Math.Atan2(x, y);
      double angleInDegrees = angleInRadians * (180 / Mathf.PI);
        
      double smallX = distanceBetweenPlayerAndPointer * Math.Sin(angleInRadians);
      double smallY = distanceBetweenPlayerAndPointer * Math.Cos(angleInRadians);
        
      Vector3 newSwordPosition = new ((float)smallX, (float)smallY, 0);
        
      Vector3 newSwordAngle = new (0, 0, (float)-angleInDegrees);
        
      pointer.transform.localPosition = newSwordPosition;
      pointer.transform.eulerAngles = newSwordAngle;
   }


   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Key"))
      {
         //need to identify which key is the culprit and remove indicator and key from list
         int index = keys.IndexOf(col.gameObject);
         keys.RemoveAt(index);
         GameObject keyIndicator = _keyIndicators[index];
         _keyIndicators.RemoveAt(index);
         Destroy(keyIndicator);
         Destroy(col.gameObject);
         numberOfKeysCollected++;
         keyPickupAudioSource.Play();
      }

      if (col.CompareTag("Door"))
      {
         if (numberOfKeysCollected == TotalNumberOfKeys)
         {
            Destroy(col.gameObject);
            doorAudioManager.GetComponent<DoorAudioManager>().doorOpenAudioSource.Play();
         }
         else
         {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - .5f, -1);
            if (!doorAudioManager.GetComponent<DoorAudioManager>().doorClosedAudioSource.isPlaying)
            {
               doorAudioManager.GetComponent<DoorAudioManager>().doorClosedAudioSource.Play();
            }
            keyUiManager.GetComponent<KeyUIManager>().ShowKeyReminder();
         }
      }
   }
}
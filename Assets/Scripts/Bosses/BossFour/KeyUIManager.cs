using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIManager : MonoBehaviour
{
   public GameObject keyTutorialPanel;
   public GameObject notEnoughKeysPanel;
   private bool _hasClosedTutorialPanel;

   private void Awake()
   {
      notEnoughKeysPanel.SetActive(false);
   }

   private void LateUpdate()
   {
      if (!_hasClosedTutorialPanel)
      {
         if (Input.GetKeyDown(KeyCode.Space))
         {
            _hasClosedTutorialPanel = true;
            keyTutorialPanel.SetActive(false);
         }
      }
      else
      {
         if (keyTutorialPanel.activeInHierarchy)
         {
            keyTutorialPanel.SetActive(false);
         }
      }
   }

   public void ShowKeyReminder()
   {
      notEnoughKeysPanel.SetActive(true);
   }
}

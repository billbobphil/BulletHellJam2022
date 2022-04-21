using System;
using System.Collections;
using System.Collections.Generic;
using Bosses;
using UnityEngine;

public class LevelThreeMechanicTutorialController : MonoBehaviour
{
    public GameObject mechanicTutorialPanel;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mechanicTutorialPanel.SetActive(false);
            GameObject.FindWithTag("Boss").GetComponent<BossController>().CommenceBattleStart();
            GameObject.FindWithTag("Platform").GetComponent<LevelThreeAutoPlatformController>().StartMovingPlatform();
        }
    }
}

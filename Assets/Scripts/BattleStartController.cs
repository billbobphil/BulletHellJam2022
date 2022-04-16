using System.Collections;
using System.Collections.Generic;
using Bosses;
using UnityEngine;

public class BattleStartController : MonoBehaviour
{
    public GameObject levelBoss;

    public void Begin()
    {
        levelBoss.GetComponent<TutorialBossController>().CommenceBattleStart();
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThreePhaseThreeTriggerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GetComponentInParent<BossThreeController>().ChangeBossState(BossThreeController.BossThreeState.PhaseThree);
        }
    }
}

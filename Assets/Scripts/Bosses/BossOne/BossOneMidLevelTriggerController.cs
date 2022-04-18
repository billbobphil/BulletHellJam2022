using System;
using UnityEngine;

namespace Bosses.BossOne
{
    public class BossOneMidLevelTriggerController : MonoBehaviour
    {
        private bool _hasBeenTriggered = false;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!_hasBeenTriggered && col.CompareTag("Player"))
            {
                _hasBeenTriggered = true;
                GetComponentInParent<BossOneController>().ChangeBossState(BossOneController.BossOneState.NextGunState);
            }
        }
    }
}

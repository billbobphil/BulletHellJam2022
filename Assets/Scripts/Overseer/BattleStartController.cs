using Bosses;
using UnityEngine;

namespace Overseer
{
    public class BattleStartController : MonoBehaviour
    {
        public GameObject levelBoss;

        public void Begin()
        {
            levelBoss.GetComponent<BossController>().CommenceBattleStart();
        }
    
    }
}

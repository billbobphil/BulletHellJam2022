using Bosses;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overseer
{
    public class BattleStartController : MonoBehaviour
    {
        public GameObject levelBoss;
        public int currentLevel;

        private void Awake()
        {
            currentLevel = SceneManager.GetActiveScene().buildIndex;
        }

        public void Begin()
        {
            levelBoss.GetComponent<BossController>().CommenceBattleStart();
        }
    
    }
}

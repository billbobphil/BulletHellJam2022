using Bosses;
using Player;
using UnityEngine;

namespace Overseer
{
    public class GameStopController : MonoBehaviour
    {
        public void StopGame()
        {
            foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
            {
                platform.GetComponent<PlatformMovementController>().ChangeDirection(PlatformMovementController.PlatformDirections.Stationary);
            }
        
            GameObject.FindWithTag("Boss").GetComponent<BossController>().BecomeInactive();
        }
    }
}

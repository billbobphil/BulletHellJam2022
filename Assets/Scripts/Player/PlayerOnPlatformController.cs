using System.Collections.Generic;
using Overseer;
using UnityEngine;

namespace Player
{
    public class PlayerOnPlatformController : MonoBehaviour
    {
        private List<Collider2D> platformColliders = new();
        private PlayerDeathController _playerDeathController;

        private void Awake()
        {
            _playerDeathController = GameObject.FindWithTag("Overseer").GetComponent<PlayerDeathController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsColliderPlatform(other))
            {
                platformColliders.Add(other);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (IsColliderPlatform(other))
            {
                platformColliders.Remove(other);
            }

            if (platformColliders.Count == 0)
            {
                Debug.Log("Death from platform count");
                _playerDeathController.KillPlayer();
            }
        }

        private static bool IsColliderPlatform(Component other)
        {
            return other.CompareTag("StartingPlatform") || other.CompareTag("Platform") || other.CompareTag("EndingPlatform");
        }
    }
}

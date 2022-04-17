using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overseer
{
    public class VictoryController : MonoBehaviour
    {
        private bool _isVictoryAchieved = false;
        
        public void VictoryAchieved()
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovementController>().SetPlayerCanMove(false);
            gameObject.GetComponent<GameStopController>().StopGame();
            gameObject.GetComponent<UIManager>().ShowVictoryScreen();
            _isVictoryAchieved = true;
        }

        private void LateUpdate()
        {
            if (!_isVictoryAchieved) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //TODO: Progress to next level
                Debug.Log("Progress to next level from Victory");
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                //TODO: Return to main menu
                Debug.Log("Return to main menu from Victory");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

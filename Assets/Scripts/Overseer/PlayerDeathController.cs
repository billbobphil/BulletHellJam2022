using Bosses;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overseer
{
    public class PlayerDeathController : MonoBehaviour
    {
        private bool _playerHasDied = false;
    
        public void KillPlayer()
        {
            Destroy(GameObject.FindWithTag("Player"));
            
            gameObject.GetComponent<GameStopController>().StopGame();
            
            gameObject.GetComponent<UIManager>().ShowGameOverScreen();

            _playerHasDied = true;
        }


        private void LateUpdate()
        {
            if (!_playerHasDied) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Restart level from player has death");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                //TODO: go to main menu
                Debug.Log("Should go to menu");
            }
        }
    }
}

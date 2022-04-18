using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overseer
{
    public class VictoryController : MonoBehaviour
    {
        private bool _isVictoryAchieved = false;
        public AudioClip victorySoundEffect;
        private int _currentLevelIndex;

        private void Start()
        {
            _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public void VictoryAchieved()
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovementController>().SetPlayerCanMove(false);
            gameObject.GetComponent<GameStopController>().StopGame();
            gameObject.GetComponent<UIManager>().ShowVictoryScreen();
            AudioSource audioSource = gameObject.GetComponentInParent<AudioSource>();
            audioSource.clip = victorySoundEffect;
            audioSource.volume = .5f;
            audioSource.Play();
            _isVictoryAchieved = true;
        }

        private void LateUpdate()
        {
            if (!_isVictoryAchieved) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(_currentLevelIndex + 1);
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

using Bosses;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Overseer
{
    public class PlayerDeathController : MonoBehaviour
    {
        private bool _playerHasDied = false;
        public AudioClip deathSoundEffect;

        public void KillPlayer()
        {
            Destroy(GameObject.FindWithTag("Player"));
            
            gameObject.GetComponent<GameStopController>().StopGame();
            
            gameObject.GetComponent<UIManager>().ShowGameOverScreen();
            
            AudioSource audioSource = gameObject.GetComponentInParent<AudioSource>();
            audioSource.clip = deathSoundEffect;
            audioSource.volume = 1f;
            audioSource.Play();

            _playerHasDied = true;
        }


        private void LateUpdate()
        {
            if (!_playerHasDied) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

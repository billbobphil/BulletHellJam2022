using UnityEngine;

namespace Overseer
{
    public class UIManager : MonoBehaviour
    {
        private GameObject _gameOverScreen;
        private GameObject _victoryScreen;
    
        private void Awake()
        {
            _gameOverScreen = GameObject.FindWithTag("GameoverUI");
            _gameOverScreen.SetActive(false);
            _victoryScreen = GameObject.FindWithTag("VictoryUI");
            _victoryScreen.SetActive(false);
        }

        public void ShowGameOverScreen()
        {
            _gameOverScreen.SetActive(true);
        }

        public void ShowVictoryScreen()
        {
            _victoryScreen.SetActive(true);
        }
    }
}

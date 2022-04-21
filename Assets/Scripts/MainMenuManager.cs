using System.Collections;
using System.Collections.Generic;
using Guns;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public List<GameObject> guns;

    private void Start()
    {
        foreach (GameObject gun in guns)
        {
            GunController gunController = gun.GetComponent<GunController>();
            gunController.MyAudioSource.mute = true;
            gunController.TurnOn();
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToTutorialLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLevelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToLevelThree()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToLevelFour()
    {
        SceneManager.LoadScene(5);
    }
}

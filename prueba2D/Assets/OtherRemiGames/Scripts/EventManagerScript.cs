using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManagerScript : MonoBehaviour
{
    public GameObject levelsScreen;
    public GameObject titleScreen;

    public void onPlay()
    {
        
        levelsScreen.SetActive(true);
        titleScreen.SetActive(false);

    }

    public void onExit()
    {
        Application.Quit();
    }

    public void onGame1()
    {
        SceneManager.LoadScene(1);
    }
    public void onGame2()
    {
        SceneManager.LoadScene(2);
    }
    public void onGame3()
    {
        SceneManager.LoadScene(3);
    }

    public void onExitGame()
    {
        SceneManager.LoadScene(0);
    }

}

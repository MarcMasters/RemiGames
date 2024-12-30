using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public void onPlay()
    {
        SceneManager.LoadScene("KeepTheBeet");
    }

    public void onExitGame()
    {
        Application.Quit();
        //SceneManager.LoadScene("TitleScreen");
    }

    public void onShop()
    {
        SceneManager.LoadScene("KTBShop");
    }
}

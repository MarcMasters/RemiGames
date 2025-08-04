using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) onPlay();
    }
    public void onPlay()
    {
        SceneManager.LoadScene("KeepTheBeet");
    }

    public void onExitGame()
    {
        Application.Quit();
    }

    public void onShop()
    {
        SceneManager.LoadScene("KTBShop");
    }
}

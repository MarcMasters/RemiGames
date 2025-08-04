using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShopScript : MonoBehaviour
{

    public void onExit()
    {
        SceneManager.LoadScene("KTBTitleScreen");
    }
}

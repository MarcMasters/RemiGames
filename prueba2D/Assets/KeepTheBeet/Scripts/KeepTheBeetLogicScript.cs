using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeepTheBeetLogicScript : MonoBehaviour
{
    public int playerScore = 0;
    [SerializeField] private Text scoreText;
    public GameObject gameOverScreen;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private RotationScript rotation;
    private int prevScore = 0;

    void Start()
    {
        rotation = GameObject.FindGameObjectWithTag("Orbita").GetComponent<RotationScript>();
    }

    void Update()
    {
        if (checkScoreChanges())
        {
            prevScore = playerScore;
        }
    }

    public bool checkScoreChanges()
    {
        if (playerScore > prevScore)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void onPlay()
    {
        scoreText.text = playerScore.ToString();
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        rotation.remiIsAlive = true;
    }

    public void onRestart()
    {
        SceneManager.LoadScene("KeepTheBeet");
    }

    public void onExitGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        rotation.remiIsAlive = false;
    }
}

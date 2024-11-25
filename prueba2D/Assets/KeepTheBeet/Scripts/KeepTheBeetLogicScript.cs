using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class KeepTheBeetLogicScript : MonoBehaviour
{
    public int playerScore = 0;
    [SerializeField] private Text scoreText;
    public GameObject gameOverScreen;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private RotationScript rotation;
    private int prevScore = 0;

    public bool canPressSpace;
    public HandScript activeHand;

    private float timer = 0f;
    public bool missClick = false;
    [SerializeField] private float animCoolDown = .5f;

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

        if (Input.GetKeyDown(KeyCode.Space) && !canPressSpace)
        {
            // Animacion + cooldown para gameOver
            missClick = true;
            //if (timer < animCoolDown)
            //{
            //    timer += Time.deltaTime;
            //}
            //else
            //{
            //    timer = 0f;                
            //    gameOver();
            //    missClick = false;
            //}
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

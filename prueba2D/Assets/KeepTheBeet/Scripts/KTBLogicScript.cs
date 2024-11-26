using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KTBLogicScript : MonoBehaviour
{
    public int playerScore = 0;
    [SerializeField] private Text scoreText;
    public GameObject gameOverScreen;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private RotationScript rotation;
    private int prevScore = 0;

    public bool canPressSpace;
    public HandScript activeHand;
    public bool missClick = false;

    void Start()
    {
        rotation = GameObject.FindGameObjectWithTag("Orbita").GetComponent<RotationScript>();
        scoreText.text = playerScore.ToString();
        rotation.remiIsAlive = true;
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

    public void onRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        rotation.remiIsAlive = false;
    }

    public void onExit()
    {
        SceneManager.LoadScene("KTBTitleScreen");
    }
}

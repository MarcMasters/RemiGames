using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KTBLogicScript : MonoBehaviour
{
    public int playerScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject mecanicaCheck;
    private int prevScore = 0;

    public bool canPressSpace;
    public HandScript activeHand;
    public bool missClick = false;
    public bool remiIsAlive;

    private float spaceTimer = 0;
    private float holdSpaceTime = .5f;
    public bool holdingE;

    void Start()
    {
        scoreText.text = playerScore.ToString();
        remiIsAlive = true;
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

        eHolding();
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
        remiIsAlive = false;
    }

    public void onExit()
    {
        SceneManager.LoadScene("KTBTitleScreen");
    }

    public void eHolding()
    {
        // Tecla espacio mantenida o no
        if (Input.GetKey(KeyCode.E) && remiIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space)) gameOver();

            if (spaceTimer < holdSpaceTime)
            {
                spaceTimer += Time.deltaTime;
            }
            else
            {
                spaceTimer = 0f;
                holdingE = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.E)) holdingE = false;
        if (holdingE) mecanicaCheck.SetActive(true);
        else mecanicaCheck.SetActive(false);
    }
}

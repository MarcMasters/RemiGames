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
    private int prevScore = 0;

    public int currentPlayerCash = 0;
    public int totalPlayerCash;
    [SerializeField] private Text cashText;
    [SerializeField] private Text totalCashText;

    public bool canPressSpace;
    public HandScript activeHand;
    public bool missClick = false;
    public bool remiIsAlive;

    private float spaceTimer = 0;
    private float holdSpaceTime = .5f;
    public bool holdingE;
    Animator animBarra;

    [SerializeField] private AudioClip[] deathSounds;
    [SerializeField] private AudioClip[] handFailed;


    void Start()
    {
        scoreText.text = playerScore.ToString();
        remiIsAlive = true;
        animBarra = GameObject.FindGameObjectWithTag("Barra").GetComponent<Animator>();

        totalPlayerCash = PlayerPrefs.GetInt("Dinero");
        totalCashText.text = "TOTAL: " + totalPlayerCash.ToString();
    }

    void Update()
    {
        if (checkScoreChanges())
        {
            prevScore = playerScore;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !canPressSpace)
        {
            missClick = true;
            SoundFXManager.instance.PlayRandomSoundFXClip(handFailed, transform, 1f);
        }

        if (!remiIsAlive && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))) onRestart();

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
        SoundFXManager.instance.PlayRandomSoundFXClip(deathSounds, transform, 1f);
        addCashToTotal();

        if (gameOverScreen!=null) gameOverScreen.SetActive(true);
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
            animBarra.SetBool("ePressed",true);


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
        if (Input.GetKeyUp(KeyCode.E)) 
        {
            holdingE = false;
            animBarra.SetBool("ePressed", false);
        }
    }

    public void addCashToCurrent(int cash)
    {
        currentPlayerCash += cash;
        cashText.text = currentPlayerCash.ToString();
    }

    private void addCashToTotal()
    {
        totalPlayerCash += currentPlayerCash;
        PlayerPrefs.SetInt("Dinero", totalPlayerCash);

        totalCashText.text = "TOTAL: "+ totalPlayerCash.ToString();
    }
}

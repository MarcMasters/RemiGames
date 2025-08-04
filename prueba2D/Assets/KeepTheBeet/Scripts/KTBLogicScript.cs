using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class KTBLogicScript : MonoBehaviour
{
    public int playerScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverScreen;
    private int prevScore = 0;

    public int currentPlayerCash = 0;
    public int totalPlayerCash;
    [SerializeField] private TextMeshProUGUI cashText;
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

    //[SerializeField] private Image GO_text_hand;
    [SerializeField] private GameObject[] deathMessages;


    void Start()
    {
        scoreText.text = playerScore.ToString();
        remiIsAlive = true;
        animBarra = GameObject.FindGameObjectWithTag("Barra").GetComponent<Animator>();

        totalPlayerCash = PlayerPrefs.GetInt("Dinero");
        totalCashText.text = "TOTAL: " + totalPlayerCash.ToString();

        //PlayerPrefs.SetInt("Dinero",0);
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

    public void gameOver(int deathIndex)
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(deathSounds, transform, 1f);
        addCashToTotal();

        if (gameOverScreen!=null) gameOverScreen.SetActive(true);
        remiIsAlive = false;

        // Mensajes de muerte
        switch (deathIndex)
        {
            case 0:
                print("muerte 0");
                //GO_text_hand.enabled = true;
                deathMessages[0].SetActive(true);
                break;
            case 1:
                print("muerte 1");
                deathMessages[1].SetActive(true);
                break;
            case 2:
                print("muerte 2");
                deathMessages[2].SetActive(true);
                break;
        }
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
            if (Input.GetKeyDown(KeyCode.Space)) { gameOver(2); }
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
        totalPlayerCash = PlayerPrefs.GetInt("Dinero");
        print("Almacenado: "+totalPlayerCash);
        totalPlayerCash += currentPlayerCash;
        print("Añadido: " + currentPlayerCash);
        PlayerPrefs.SetInt("Dinero", totalPlayerCash);

        totalCashText.text = "TOTAL: "+ totalPlayerCash.ToString();
    }
}

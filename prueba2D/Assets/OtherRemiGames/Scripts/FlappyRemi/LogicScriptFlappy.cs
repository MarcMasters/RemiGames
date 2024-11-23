using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScriptFlappy : MonoBehaviour
{
    [SerializeField] private int playerScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text highScoreText;
    [SerializeField] private GameObject abilityReadyScreen;

    private void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore+= scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void updateHighScore()
    {

        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (playerScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore",playerScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", playerScore);
        }

        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        updateHighScore();
        gameOverScreen.SetActive(true);
    }

    public void megaFlapReady(bool ready)
    {
        if (ready)
        {
            abilityReadyScreen.SetActive(true);
        }
        else
        {
            abilityReadyScreen.SetActive(false);
        }
    }
}

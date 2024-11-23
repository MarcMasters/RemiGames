using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject highScoreScreen;
    private bool newHighScore = false;

    private void Start()
    {
        highScoreText.text = "Récord: " + PlayerPrefs.GetInt("HighScore",0);
    }

    [ContextMenu("IncreaseScore")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Saltos legítimos: " + playerScore.ToString();
        highScoreCheck();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (newHighScore)
        {
            highScoreScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void highScoreCheck()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",playerScore);
            newHighScore = true;
        }
    }

}

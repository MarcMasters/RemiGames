using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    [SerializeField] private float scoreRate = 0.2f;
    private float timer = 0;
    private int score = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private RemiScript remi;

    void Start()
    {
        
    }

    void Update()
    {
        if (remi.remiAlive)
        {
            if (timer < scoreRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                addScore();
                timer = 0;
            }
        }
    }

    void addScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}

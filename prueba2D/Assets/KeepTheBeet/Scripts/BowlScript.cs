using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlScript : MonoBehaviour
{
    [SerializeField] private Image image;
    private float currLife = 10f;
    private float maxLife = 10f;
    private float timer = 0f;
    private float timer2 = 0f;

    private KTBLogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
    }

    void Update()
    {
        if (logic.remiIsAlive)
        {
            image.fillAmount = currLife/maxLife;
            updateLife();
        }
    }

    public void updateLife()
    {
        // Si se acaba el tiempo, game over
        if (currLife == 0)
        {
            logic.gameOver();
            //print("gameOver bowl");
            return;
        }


        // Si aguantas E durante 0.25 seg, suma
        if (logic.holdingE)
        {
            if (timer2 < .25f)
            {
                timer2 += Time.deltaTime;
            }
            else
            {
                timer2 = 0f;
                currLife += .25f;
                if (currLife > 10f) currLife = 10f;
                //print(currLife + "" + logic.holdingE + "");
            }
        }


        // Si no aguantas E durante 0.5 seg, resta
        if (!logic.holdingE)
        {
            if (timer < .5f)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                currLife -= .25f;
                //print(currLife);
            }
        }
    }
}

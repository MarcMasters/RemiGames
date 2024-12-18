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

    Animator anim;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (logic.remiIsAlive)
        {
            image.fillAmount = currLife/maxLife;
            updateLife();
            animateBowl();
        }
    }

    public void updateLife()
    {
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

    private void animateBowl()
    {
        if (currLife > maxLife * 2 / 3)
        {
            anim.SetInteger("bowl_phase", 0);
        }
        else if (currLife < maxLife * 2 / 3 && currLife > maxLife * 1 / 3)
        {
            anim.SetInteger("bowl_phase", 1);
        }
        else if (currLife < maxLife * 1 / 3 && currLife > maxLife * 0)
        {
            anim.SetInteger("bowl_phase", 2);
        }
        else if (currLife <= 0f)
        {
            anim.SetInteger("bowl_phase", 3);
            logic.remiIsAlive = false;
            return;
        }
    }
    public void bowlGameOver() { logic.gameOver(); }
}

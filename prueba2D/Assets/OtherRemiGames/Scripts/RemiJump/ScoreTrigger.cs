using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public LogicScript logic;
    public RemiController remi;

    private void Update()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        remi = GameObject.FindGameObjectWithTag("Player").GetComponent<RemiController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            remi.jumping = false;
            remi.doubleJumping = false;
        }
    }

}

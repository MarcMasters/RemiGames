using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KTBtRemiScript : MonoBehaviour
{
    private KTBLogicScript logic;
    private HandScript handScript;
    Animator anim;
    
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se puede pulsar espacio al entrar al trigger
        if (other.CompareTag("Mano"))
        {
            //Debug.Log("trigger enter");
            logic.canPressSpace = true;
            // Vincular como mano activa "esta" (la que hace trigger)
            logic.activeHand = other.GetComponent<HandScript>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Al salir del trigger ya no se puede pulsar espacio
        // y pierdes si no has acertado \ sumado 1 punto
        if (other.CompareTag("Mano") && logic.remiIsAlive)
        {
            //Debug.Log("trigger exit");
            logic.canPressSpace = false;
            anim.SetBool("remiSpawning",true);

            // Desvincular al salir del trigger
            if (logic.activeHand == other.GetComponent<HandScript>())
            {
                logic.activeHand = null;
            }

            if (!logic.checkScoreChanges())
            {
                logic.gameOver();
                //print("gameOver remi");
            }
        }
    }

    public void resetBool()
    {
        anim.SetBool("remiSpawning", false);
    }
}

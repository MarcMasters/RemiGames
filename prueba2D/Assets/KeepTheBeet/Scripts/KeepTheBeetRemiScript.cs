using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTheBeetRemiScript : MonoBehaviour
{
    private KeepTheBeetLogicScript logic;
    private HandScript handScript;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KeepTheBeetLogicScript>();
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
        if (other.CompareTag("Mano"))
        {
            //Debug.Log("trigger exit y bool false");
            logic.canPressSpace = false;

            // Desvincular al salir del trigger
            if (logic.activeHand == other.GetComponent<HandScript>())
            {
                logic.activeHand = null;
            }

            if (!logic.checkScoreChanges())
            {
                logic.gameOver();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private KTBLogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && logic.remiIsAlive)
        {
            print("moneda");
            // Moneda se destruye
            Destroy(gameObject);

            // Se suma 1 a money
            //logic.addEuro();
        }
    }
}
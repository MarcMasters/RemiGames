using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private KTBLogicScript logic;
    [SerializeField] private CircleCollider2D coinCollider;
    private float timer = 0f;
    [SerializeField] private float noclipCD;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
        coinCollider.enabled = false;
    }

    private void Update()
    {
        if (timer < noclipCD) { timer += Time.deltaTime; }
        else { timer = 0f; coinCollider.enabled = true; }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && logic.remiIsAlive)
        {
            // Moneda se destruye
            Destroy(gameObject);

            // Se suma 1 a money
            //logic.addEuro();
        }
    }
}
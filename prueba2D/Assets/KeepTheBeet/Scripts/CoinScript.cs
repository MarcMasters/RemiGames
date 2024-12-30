using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private KTBLogicScript logic;
    private BowlScript bowlScript;
    private CoinManager coin;
    [SerializeField] private CircleCollider2D coinCollider;
    private float timer = 0f;
    [SerializeField] private float noclipCD;
    [SerializeField] private AudioClip[] coinSounds;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();
        bowlScript = GameObject.FindGameObjectWithTag("Bowl").GetComponent<BowlScript>();
        coin = GameObject.FindGameObjectWithTag("Logic").GetComponent<CoinManager>();
        coinCollider.enabled = false;
    }

    private void Update()
    {
        if (logic.remiIsAlive)
        {
            if (timer < noclipCD) { timer += Time.deltaTime; }
            else { timer = 0f; coinCollider.enabled = true; }
        }
        else
        {
            Destroy(gameObject);
        }

        // SuperCoin
        if (bowlScript.hardSwingPhase && this.transform.position.x < -2)
        {
            print("superCoin añadida");
            SoundFXManager.instance.PlayRandomSoundFXClip(coinSounds, transform, 1f);
            logic.addCashToCurrent(10);
            coin.superCoinExists = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && logic.remiIsAlive)
        {
            //Sonido
            SoundFXManager.instance.PlayRandomSoundFXClip(coinSounds, transform, 1f);
            // Se suma 1 a money
            logic.addCashToCurrent(1);
            // Moneda se destruye
            Destroy(gameObject);
        }
    }
}
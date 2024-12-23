using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private Transform parent;
    [SerializeField] private float radio;
    private float x, y, spawnAngle;
    private float timer = 0f;
    [SerializeField] private float coinCoolDown;

    void Update()
    {
        if (timer < coinCoolDown)
        {
            timer += Time.deltaTime;
        }
        else {
            timer = 0f;
            spawnCoin();
        }
    }

    private void spawnCoin()
    {
        spawnAngle = Random.Range(0, 2 * Mathf.PI);
        float x = (Mathf.Cos(spawnAngle) * radio) + 3.5f;
        float y = Mathf.Sin(spawnAngle) * radio;

        Vector3 spawnPos = new Vector3(x, y, 0);

        Instantiate(coin, spawnPos, Quaternion.identity, parent);
    }
}

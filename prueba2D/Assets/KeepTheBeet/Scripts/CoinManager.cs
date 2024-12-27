using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private HandSpawner spawner;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject superCoin;
    [SerializeField] private Transform coinParent;

    public bool superCoinExists = false;

    void Start()
    {
        coinParent = GameObject.FindGameObjectWithTag("HandSpawner").GetComponent<Transform>();
    }

    public void spawnCoin(float xCoin, float yCoin)
    {
        Vector3 spawnPos = new Vector3(xCoin, yCoin, 0);
        Instantiate(coin, spawnPos, Quaternion.identity, coinParent);
    }

    public void spawnSuperCoin()
    {
        if (Random.Range(0, 4) == 1 && !superCoinExists)
        {
            superCoinExists = true;
            Vector3 superCoinPos = new Vector3(-4,3.6f,0);
            Instantiate(superCoin, superCoinPos, Quaternion.identity, coinParent);
        }
    }
}

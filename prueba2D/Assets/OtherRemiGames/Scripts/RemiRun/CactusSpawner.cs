using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cactus1;
    [SerializeField] private GameObject cactus2;
    [SerializeField] private GameObject cactus3;
    [SerializeField] private RemiScript remi;
    private float timer = 0;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private int lowestW = 1;
    [SerializeField] private int highestW = 8;
    private int tipoCactus;
    private float posCactus;
    [SerializeField] private float minDistance = 2f;

    void Update()
    {
        if (remi.remiAlive)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnCactus();
                timer = 0;
            }
        }
    }

    void spawnCactus()
    {
        tipoCactus = Random.Range(0,3);
        posCactus = transform.position.x + minDistance + Random.Range(0,4);

        if (tipoCactus == 0)
        {
            Instantiate(cactus1, new Vector3(posCactus, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
        }else if (tipoCactus == 1){
            Instantiate(cactus2, new Vector3(posCactus, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
        }
        else
        {
            Instantiate(cactus3, new Vector3(posCactus, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
        }
    }
}


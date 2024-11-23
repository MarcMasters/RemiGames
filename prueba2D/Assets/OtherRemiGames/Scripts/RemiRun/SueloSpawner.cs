using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloSpawner : MonoBehaviour
{
    [SerializeField] private GameObject suelo;
    [SerializeField] private GameObject nube;
    [SerializeField] private GameObject sueloRef;
    [SerializeField] private RemiScript remi;

    private float timerNube = 0;
    private SpriteRenderer nubeSR;
    [SerializeField] private float spawnRateNube = 0.3f;
    [SerializeField] private int lowestH = 1;
    [SerializeField] private int highestH = 6;

    private float sueloPosX;
    private float sueloLen;
    private Collider2D sueloCol;
    [SerializeField] private WorldMove worldMove;
    private float spawnCondition;

    void Start()
    {
        nubeSR = nube.GetComponent<SpriteRenderer>();
        sueloCol = sueloRef.GetComponent<Collider2D>();

        spawnCondition = worldMove.despawnZone + 25;   // +25 para que spawnSuelo() se active un poco antes de que este se destruya
        sueloLen = sueloCol.bounds.size.x - 0.1f;
        //print(sueloCol.bounds.size.x);

        // Primer suelo en base al ya creado en el mapa (sueloRef)
        sueloPosX = sueloRef.transform.position.x + sueloLen;   // +49.5f: aprox. la longitud/2 del suelo
        spawnSuelo();
    }

    void Update()
    {
        if (remi.remiAlive)
        {
            if (suelo.transform.position.x < spawnCondition)
            {
                spawnSuelo();
                //print(suelo.transform.position.x + sueloLen);
            }

            sueloPosX = suelo.transform.position.x + sueloLen;

            if (timerNube < spawnRateNube)
            {
                timerNube += Time.deltaTime;
            }
            else
            {
                spawnNube();
                timerNube = 0;
            }
        }
    }

    void spawnSuelo()
    {
        suelo = Instantiate(suelo, new Vector3(sueloPosX, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
    }
    void spawnNube()
    {
        nube = Instantiate(nube, new Vector3(transform.position.x + Random.Range(-2,2), transform.position.y + Random.Range(lowestH,highestH), transform.position.z), Quaternion.identity, this.transform);
        nubeSR.sortingOrder = -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject suelo;
    public float spawnRate = 1.5f;
    private float timer = 0f;
    private float lowestPoint = -5;
    private float highestPoint = 2;
    public RemiController remi;

    // Start is called before the first frame update
    void Start()
    {
        remi = GameObject.FindGameObjectWithTag("Player").GetComponent<RemiController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnSuelo();
            timer = 0;
        }
        
    }

    void spawnSuelo()
    {
        if (remi.remiAlive)
        {
            Instantiate(suelo, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity, this.transform); // this.transform establece como padre al spawner
        }
    }


}

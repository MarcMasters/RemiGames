using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField] private GameObject nube;
    [SerializeField] private float spawnRate;
    private float timer = 0;
    private float lowestPoint = -4;
    private float highestPoint = 6;
    private RemiController remi;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        remi = GameObject.FindGameObjectWithTag("Player").GetComponent<RemiController>();
        spriteRenderer = nube.GetComponent<SpriteRenderer>();
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
            spawnNube();
            timer = 0;
        }
    }

    void spawnNube()
    {
        if (remi.remiAlive)
        {
            nube = Instantiate(nube, new Vector3(Random.Range(12,17), Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity, this.transform);
            spriteRenderer.sortingOrder = -1; // Nubes al fondo

            if (Random.Range(1,6) == 2)
            {
                nube.transform.localScale = new Vector3(2.0f, 1.0f, 1); // Algunas nubes más pequeñas
            }
            else
            {
                nube.transform.localScale = new Vector3(4.8f, 2, 1);    // Si no se cumple, tamaño normal
            }
        }
    }
}

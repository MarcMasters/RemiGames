using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private float spawnRate = 2f;
    private float timer = 0f;
    [SerializeField] private float heightOffset;
    [SerializeField] private BirdScript remi;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
        remi = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remi.remiIsAlive)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0f;
            }
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation, this.transform);
    }
}

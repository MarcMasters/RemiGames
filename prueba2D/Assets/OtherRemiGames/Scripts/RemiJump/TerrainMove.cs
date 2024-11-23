using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMove : MonoBehaviour
{
    public float speed;
    public int despawnZone = -30;
    public RemiController remi;

    // Start is called before the first frame update
    void Start()
    {
        remi = GameObject.FindGameObjectWithTag("Player").GetComponent<RemiController>();
    }

    // Update is called once per frame
    void Update()
    {
        //speed = Random.Range(0.001f, 0.01f);

        if (remi.remiAlive)
        {
            transform.position += Vector3.left * speed;

            if (transform.position.x < despawnZone)
            {
                Destroy(gameObject);
            }
        }
    }
}

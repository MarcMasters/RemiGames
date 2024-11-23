using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    [SerializeField] private float speed=0.08f;
    public int despawnZone = -20;
    [SerializeField] private RemiScript remi;


    void Start()
    {
        remi = GameObject.FindGameObjectWithTag("Player").GetComponent<RemiScript>();
    }

    void Update()
    {
        if (remi.remiAlive)
        {
            transform.position = transform.position + (Vector3.left * speed);

            if (transform.position.x < despawnZone)
            {
                Destroy(gameObject);

            }
        }
    }
}

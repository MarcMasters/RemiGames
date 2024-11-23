using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float deadZone = -15;
    [SerializeField] private BirdScript remi;

    // Start is called before the first frame update
    void Start()
    {
        remi = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remi.remiIsAlive)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
                //Debug.Log("Pipe deleted");
            }
        }
    }
}

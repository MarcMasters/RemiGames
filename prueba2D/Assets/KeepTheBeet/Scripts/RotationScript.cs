using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool clockwise = true;
    public bool remiIsAlive;

    void Update()
    {
        if (remiIsAlive)
        {
            if (clockwise)
            {
                transform.Rotate(new Vector3(0, 0, -rotationSpeed) * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }
}

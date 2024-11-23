using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform target;

    [SerializeField] private float radio;
    [SerializeField] private float proximitySpawnFactor;
    private float prev_x, prev_y, x, y, spawnAngle;

    [SerializeField] private KeepTheBeetLogicScript logic;
    private int prevScore = 0;

    void Start()
    {
        // Angulo y primeras coords. aleatorios
        float spawnAngle = Random.Range(0, 2 * Mathf.PI);
        x = (Mathf.Cos(spawnAngle) * radio);
        y = Mathf.Sin(spawnAngle) * radio;
        prev_x = 0f; prev_y = 1f;

        // Hand no hará el 1r spawn en el hemisferio norte
        y = -Mathf.Abs(y);
        
        // Primera hand
        spawnHand(x, y);

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KeepTheBeetLogicScript>();
    }
    
    void Update()
    {
        if (logic.checkScoreChanges())
        {
            float distance;
            // Comprueba si el las nuevas coordenadas son demasiado cercanas a las inmediatamente anteriores
            do
            {
                // Coordenadas muy cerca, se generan otras
                spawnAngle = Random.Range(0, 2 * Mathf.PI);
                x = (Mathf.Cos(spawnAngle) * radio);
                y = Mathf.Sin(spawnAngle) * radio;
                // Fórmula de la distancia entre 2 puntos en el espacio
                distance = Mathf.Sqrt(Mathf.Pow(x - prev_x, 2) + Mathf.Pow(y - prev_y, 2));
                //Debug.Log(distance);
                //Debug.Log("Nuevas coords:" + x + " / " + y);
            }
            while (distance < proximitySpawnFactor);

            spawnHand(x,y);
            prev_x = x; prev_y = y;
        }
    }

    //private void spawnHand(float x, float y)
    //{
    //    Vector3 spawnPos = new Vector3(x, y, 0);

    //    // Vector de dirección hacia el centro (el origen)
    //    Vector3 relativePos = spawnPos - transform.position;

    //    // Calcular la rotación hacia el centro
    //    Quaternion handRotation = Quaternion.LookRotation(relativePos, Vector3.up);

    //    Instantiate(hand, spawnPos, handRotation, parent);
    //    //Debug.Log($"Spawned hand at x: {x}, y: {y}, rotation: {handRotation.eulerAngles}");
    //}

    private void spawnHand(float x, float y)
    {
        Vector3 spawnPos = new Vector3(x, y, 0);

        // Vector de dirección hacia el centro (el origen)
        Vector3 directionToCenter = -spawnPos.normalized;

        // Calcular la rotación hacia el centro
        Quaternion handRotation = Quaternion.LookRotation(Vector3.forward, directionToCenter);

        Instantiate(hand, spawnPos, handRotation, parent);
        //Debug.Log($"Spawned hand at x: {x}, y: {y}, rotation: {handRotation.eulerAngles}");
    }

    //private void spawnHand(float x, float y, float spawnAngle)
    //{
    //    // Cálculo de compensación de ángulo para 'hand' a partir de 'spawnAngle'
    //    // Quaternion.Euler(0,0,X) gira el GameObject X grados a la izquierda
    //    Quaternion handRotation = Quaternion.identity;
    //    float alfa = spawnAngle*180/Mathf.PI;
    //    Debug.Log("x:" + x + " y:" + y + " ang:" + alfa);

    //    if (alfa < 90 && alfa >= 0f)
    //    {
    //        //1r cuadrante
    //        handRotation = Quaternion.Euler(0f, 0f, 180-(90-alfa));
    //        Debug.Log("1: " + alfa);
    //    }
    //    else if (alfa < 180 && alfa >= 90)
    //    {
    //        //2º cuadrante
    //        handRotation = Quaternion.Euler(0f, 0f, -(180-(90-(180-alfa))));
    //        Debug.Log("2: " + alfa);
    //    }
    //    else if (alfa < 270 && alfa >= 180)
    //    {
    //        //3r cuadrante
    //        handRotation = Quaternion.Euler(0f, 0f, -(180-(90-(270-alfa))));
    //        Debug.Log("3: " + alfa);
    //    }
    //    else if (alfa < 360f && alfa >= 270)
    //    {
    //        //4º cuadrante
    //        handRotation = Quaternion.Euler(0f, 0f, 180-(90-(360-alfa)));
    //        Debug.Log("4: " + alfa);
    //    }
    //    else
    //    {
    //        Debug.LogError("Error encontrando cuadrante. Ángulo: " + alfa);
    //    }

    //    Instantiate(hand, new Vector3(x, y, 0), handRotation);
    //    //Debug.Log("Mano generada");
    //}
}

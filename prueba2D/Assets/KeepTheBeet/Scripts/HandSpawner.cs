using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private Transform parent;
    
    [SerializeField] private float radio;
    [SerializeField] private float proximitySpawnFactor;
    private float prev_x, prev_y, x, y, spawnAngle;

    [SerializeField] private KeepTheBeetLogicScript logic;
    public float distancePlayerHand;
    private Transform playerTransform;
    private GameObject newHand;

    void Start()
    {
        // Angulo y primeras coords. aleatorios
        float spawnAngle = Random.Range(0, 2 * Mathf.PI);
        x = (Mathf.Cos(spawnAngle) * radio);
        y = Mathf.Sin(spawnAngle) * radio;
        prev_x = 0f; prev_y = 1f;

        // Hand no hará el 1r spawn en el hemisferio norte
        y = -Mathf.Abs(y);

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

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
            
            // Antes de generar otra, newHand es la anterior
            //if (newHand != null)
            //{
            //    distancePlayerHand = GetDistanceToPlayer(playerTransform, newHand.transform);
            //    print("Distancia player-hand: " + distancePlayerHand);
            //}

            spawnHand(x, y);
            prev_x = x; prev_y = y;
        }
    }

    private void spawnHand(float x, float y)
    {
        Vector3 spawnPos = new Vector3(x, y, 0);

        // Vector de dirección hacia el centro (el origen)
        Vector3 directionToCenter = -spawnPos.normalized;

        // Calcular la rotación hacia el centro
        Quaternion handRotation = Quaternion.LookRotation(Vector3.forward, directionToCenter);

        newHand = Instantiate(hand, spawnPos, handRotation, parent);
        //Debug.Log($"Spawned hand at x: {x}, y: {y}, rotation: {handRotation.eulerAngles}");
    }

    public float GetDistanceToPlayer()
    {
        return Vector2.Distance(newHand.transform.position, playerTransform.position);
    }
}

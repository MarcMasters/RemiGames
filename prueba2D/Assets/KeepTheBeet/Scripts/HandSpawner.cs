using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private Transform handParent;

    [SerializeField] private GameObject coin;
    [SerializeField] private Transform coinParent;
    [SerializeField] private float coinRadius = 4f;

    [SerializeField] private float radius = 4.5f;
    [SerializeField] private float proximitySpawnFactor;
    private float prev_x, prev_y, x, y, spawnAngle;

    [SerializeField] private KTBLogicScript logic;
    private GameObject newHand;
    [SerializeField] private float xMapOffset = 3.5f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KTBLogicScript>();

        // Angulo y primeras coords. aleatorios
        float spawnAngle = Random.Range(0, 2 * Mathf.PI);
        x = (Mathf.Cos(spawnAngle) * radius) + xMapOffset;
        y = Mathf.Sin(spawnAngle) * radius;
        prev_x = 0f; prev_y = -radius;

        // Hand no hará el 1r spawn en el hemisferio norte
        y = -Mathf.Abs(y);

        // Primera hand
        spawnHand(x, y);
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
                x = (Mathf.Cos(spawnAngle) * radius) + xMapOffset;
                y = Mathf.Sin(spawnAngle) * radius;
                // Fórmula de la distancia entre 2 puntos en el espacio
                distance = Mathf.Sqrt(Mathf.Pow(x - prev_x, 2) + Mathf.Pow(y - prev_y, 2));
                Debug.Log("Nuevas coords:" + x + " / " + y + " Distancia: " + distance);
            }
            while (distance < proximitySpawnFactor);

            spawnHand(x, y, distance);
            prev_x = x; prev_y = y;

            // Se genera una moneda en la mano anterior (donde se ha cogido una remolacha)
            spawnCoin();
        }
    }

    private void spawnHand(float x, float y, float distance = 0f)
    {
        Vector3 spawnPos = new Vector3(x, y, 0);

        // Posición objetivo hacia donde apuntará el objeto
        Vector3 targetPos = new Vector3(xMapOffset, 0, 0);

        // Vector de dirección hacia el centro (el origen)
        //Vector3 directionToCenter = -spawnPos.normalized;

        // Vector de dirección hacia la posición objetivo
        Vector3 directionToTarget = (targetPos - spawnPos).normalized;

        // Calcular la rotación hacia el centro
        Quaternion handRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);

        newHand = Instantiate(hand, spawnPos, handRotation, handParent);
        Debug.Log($"Spawned hand at x: {x}, y: {y}, rotation: {handRotation.eulerAngles}, distance: {distance}");
    }

    private void spawnCoin()
    {
        float coin_x = (Mathf.Cos(spawnAngle) * coinRadius) + xMapOffset;
        float coin_y = Mathf.Sin(spawnAngle) * coinRadius;
        Vector3 spawnPos = new Vector3(coin_x, coin_y, 0);
        Instantiate(coin, spawnPos, Quaternion.identity, coinParent);
    }
}

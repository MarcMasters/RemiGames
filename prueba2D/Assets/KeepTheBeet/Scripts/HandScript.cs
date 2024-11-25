using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private RotationScript rotation;
    private KeepTheBeetLogicScript logic;
    private HandSpawner spawner;

    [SerializeField] private float lowestRS = 100f;
    [SerializeField] private float highestRS = 250f;
    
    Animator anim;
    //private float distancePlayerHand;

    void Start()
    {
        rotation = GameObject.FindGameObjectWithTag("Orbita").GetComponent<RotationScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KeepTheBeetLogicScript>();
        //spawner = GameObject.FindGameObjectWithTag("HandSpawner").GetComponent<HandSpawner>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (logic.missClick) anim.SetBool("missClick", true);

        // Si la mano activa (en trigger) no es la de este script > return (no hace nada)
        if (logic.activeHand != this) return;

        if (Input.GetKeyDown(KeyCode.Space) && rotation.remiIsAlive && logic.canPressSpace && !logic.missClick)
        {
            // Esto pasa cuando se acierta y ganas 1 punto
            if (rotation.clockwise == true)
            {
                rotation.clockwise = false;
            }
            else
            {
                rotation.clockwise = true;
            }

            logic.addScore();                                               // +1 a score en 'logic'
            anim.SetBool("remiCaught", true);                               // Animacion de remiCaught
            rotation.rotationSpeed = Random.Range(lowestRS, highestRS);     // Velocidad de rotacion en 'rotation' random
            GetComponent<CircleCollider2D>().enabled = false;               // Se desactiva el collider de 'hand'
                
            Destroy(gameObject, 0.3f);
        }
    }
}

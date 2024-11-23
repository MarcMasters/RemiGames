using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private bool canPressSpace = false;
    private RotationScript rotation;
    private KeepTheBeetLogicScript logic;
    [SerializeField] private float lowestRS = 100f;
    [SerializeField] private float highestRS = 250f;
    Animator anim;
    private float timer = 0f;
    [SerializeField] private float animCoolDown = .5f;

    void Start()
    {
        rotation = GameObject.FindGameObjectWithTag("Orbita").GetComponent<RotationScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<KeepTheBeetLogicScript>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rotation.remiIsAlive)
        {
            if (canPressSpace)
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
                
                Destroy(gameObject, 0.5f);
            }
            else
            {
                // Si se falla, pierdes
                //anim.SetBool("remiCaught", false);
                logic.gameOver();
                //if (timer < animCoolDown)
                //{
                //    timer += Time.deltaTime;
                //}
                //else
                //{
                //    logic.gameOver();
                //}
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se puede pulsar espacio al entrar al trigger
        //Debug.Log("trigger enter");
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("bool en true");
            canPressSpace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Al salir del trigger ya no se puede pulsar espacio
        // y pierdes si no has acertado \ sumado 1 punto
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("trigger exit");
            canPressSpace = false;

            if (!logic.checkScoreChanges())
            {
                logic.gameOver();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemiController : MonoBehaviour
{
    public Rigidbody2D remi;
    public bool jumping = false;
    public bool doubleJumping = false;
    public LogicScript logic;
    public bool remiAlive = true;
    public float jumpForce;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && remiAlive) 
        {
            if (jumping == false || doubleJumping == false) // Algun bool en false -> Puede saltar
            {
                //remi.velocity += Vector2.up * jumpForce;    // Salto
                remi.velocity = new Vector2 (0f, jumpForce);  // Salto gravity friendly :D
                if (jumping)
                {
                    doubleJumping = true;                   // Si salta saltando, doble salto
                }
            }
        }

        anim.SetBool("doubleJumping", doubleJumping);
    }

    // Remi saltando cuando no toca el suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            jumping = true;
        }
    }

    // Fin de la partida al entrar en los triggers de muerte (fuera de rango)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Muerte"))
        {
            logic.gameOver();
            remiAlive = false;
        }
    }
}

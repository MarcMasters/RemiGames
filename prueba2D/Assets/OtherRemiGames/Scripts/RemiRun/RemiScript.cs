using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemiScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Remi;
    [SerializeField] private float jumpForce = 15.0f;
    private bool isGrounded = true;
    public bool remiAlive = true;
    [SerializeField] private Logic logic;
    [SerializeField] private Animator anim;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Remi.velocity = Vector3.up * jumpForce;
                isGrounded = false;
            }
        }

        anim.SetBool("grounded", isGrounded);
        anim.SetBool("remAlive", remiAlive);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
        if (collision.collider.CompareTag("Muerte"))
        {
            remiAlive = false;
            logic.gameOver();
        }
    }
}
